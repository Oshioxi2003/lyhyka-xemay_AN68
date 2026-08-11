using Lyhyka.Core;
using Lyhyka.DBCore;
using System;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Windows.Forms;

namespace Lyhyka.UCT
{
    public partial class CalibrationUC : UserControl
    {
        string _menu = "";
        bool isSlideSlip = false;
        string DeviceValueTag, CabiTag, ATag, BTag;
        string ATagTrai, BTagTrai, ATagPhai, BTagPhai;
        float x1 = 0;
        float x2 = 0; // Điểm đo 2 - nhánh trái khi là trùng vết, điểm đo 2 chung khi là tốc độ/lực phanh
        float x2Phai = 0; // Điểm đo 2 - nhánh phải, chỉ dùng cho trùng vết
        float zeroDelta = 0;
        float originalValue = 0;
        public CalibrationUC()
        {
            InitializeComponent(); 
        }
        public void SetType(string menu)
        {
            _menu = menu;
            using (var context = new MyDbContext())
            { 
                var calib = context.Calibrations.FirstOrDefault();  
                string deviceTag = TagConstants.speedDevice;
                switch (_menu)
                {
                    case MenuConstants.Speed:
                        zeroDelta = calib != null  && calib.SpeedZero!=null ?(float)calib.SpeedZero : 0;
                        deviceTag = TagConstants.speedDevice;
                        lbCalibrateTitle.Text = "Hiệu chuẩn tốc độ";
                        break;
                    case MenuConstants.BrakeForce:
                        zeroDelta = calib != null && calib.BrakeForceZero != null ? (float)calib.BrakeForceZero : 0;
                        deviceTag = TagConstants.brakeForceDevice;
                        lbCalibrateTitle.Text = "Hiệu chuẩn lực phanh";
                        break;
                    case MenuConstants.SlideSlip: 
                        zeroDelta = calib != null && calib.SlideSlipZero != null ? (float)calib.SlideSlipZero : 0;
                        deviceTag = TagConstants.slideSlipDevice;
                        lbCalibrateTitle.Text = "Hiệu chuẩn trùng vết";
                        isSlideSlip = true;

                        if (calib != null)
                        {
                            if (calib.SlideSlipA != null)
                                lbCalibrateIput1.Text = calib.SlideSlipA.ToString();
                            if (calib.SlideSlipB != null)
                            {
                                txt1.Text = calib.SlideSlipB.ToString();
                                x1 = (float)calib.SlideSlipB;
                            }
                        }

                        break;
                }
                DeviceValueTag = $"{TagConstants.chanel}.{deviceTag}.calib_tb";
                CabiTag = $"{TagConstants.chanel}.{deviceTag}.calib";
                ATag = $"{TagConstants.chanel}.{deviceTag}.calib_a";
                BTag = $"{TagConstants.chanel}.{deviceTag}.calib_b";
                ATagTrai = $"{TagConstants.chanel}.{deviceTag}.calib_a_trai";
                BTagTrai = $"{TagConstants.chanel}.{deviceTag}.calib_b_trai";
                ATagPhai = $"{TagConstants.chanel}.{deviceTag}.calib_a_phai";
                BTagPhai = $"{TagConstants.chanel}.{deviceTag}.calib_b_phai";
            }

            // Trùng vết có 2 nhánh (trái/phải) hiệu chuẩn riêng, các thông số khác chỉ có 1 điểm đo 2
            label5.Text = isSlideSlip ? "Điểm đo chuẩn 2 - Trái" : "Điểm đo chuẩn 2";
            label6.Text = isSlideSlip ? "Giá trị điểm đo từ thiết bị 2 - Trái" : "Giá trị điểm đo từ thiết bị 2";
            btnAcpCalibrate2.Text = isSlideSlip ? "CHỐT GIÁ TRỊ ĐO 2 (TRÁI)" : "CHỐT GIÁ TRỊ ĐO 2";
            label7.Visible = isSlideSlip;
            label8.Visible = isSlideSlip;
            txtCalibrateInput2Phai.Visible = isSlideSlip;
            lbCalibrateIput2Phai.Visible = isSlideSlip;
            txt2Phai.Visible = isSlideSlip;
            btnAcpCalibrate2Phai.Visible = isSlideSlip;
        }
      
        public void UpdateCurrentValue(float currentValue)
        {
            try
            {
                originalValue = currentValue+zeroDelta;
                this.Invoke((MethodInvoker)(() =>
                {
                    txtCurrentValue.Text = (currentValue).ToString("F2");
                }));
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the update
                //Console.WriteLine("Error updating current value: " + ex.Message);
            }
        }

        private void btnZeroValue_Click(object sender, EventArgs e)
        {  
            using (var context = new MyDbContext())
            { 
                var calib = context.Calibrations.FirstOrDefault();
                if(calib==null)
                {
                    calib = new Calibration(); 
                }
                switch (_menu)
                {
                    case MenuConstants.Speed:
                        calib.SpeedZero = originalValue;
                        break;
                    case MenuConstants.BrakeForce:
                        calib.BrakeForceZero = originalValue;
                        break;
                    case MenuConstants.SlideSlip:
                        calib.SlideSlipZero = originalValue; 
                        break;
                }
                if (calib.Id == 0)
                {
                    context.Calibrations.Add(calib);
                }
                context.SaveChanges();
                GlobalVariables.Calibration = calib;
                zeroDelta = originalValue;
            }
        }

        private void btnSavePara_Click_1(object sender, EventArgs e)
        {
            var y1 = float.Parse(txtCalibrateInput1.Text);

            if (isSlideSlip)
            {
                // Nhánh trái: đường thẳng qua (x1,y1) và (x2,y2Trai)
                var y2Trai = float.Parse(txtCalibrateInput2.Text);
                float aTrai = (y2Trai - y1) / (x2 - x1);
                float bTrai = y1 - aTrai * x1;

                // Nhánh phải: đường thẳng qua (x1,y1) và (x2Phai,y2Phai)
                var y2Phai = float.Parse(txtCalibrateInput2Phai.Text);
                float aPhai = (y2Phai - y1) / (x2Phai - x1);
                float bPhai = y1 - aPhai * x1;

                OPCManager.SetOPCValue(ATagTrai, aTrai);
                OPCManager.SetOPCValue(BTagTrai, bTrai);
                OPCManager.SetOPCValue(ATagPhai, aPhai);
                OPCManager.SetOPCValue(BTagPhai, bPhai);
                OPCManager.SetOPCValue(CabiTag, 1);
            }
            else
            {
                var y2 = float.Parse(txtCalibrateInput2.Text);
                float a = (y2 - y1) / (x2 - x1);
                float b = y1 - a * x1;
                OPCManager.SetOPCValue(ATag, a);
                OPCManager.SetOPCValue(BTag, b);
                OPCManager.SetOPCValue(CabiTag, 1);
            }
            MessageBox.Show("Hiểu chỉnh thành công!");
        }

        private void btnAcpCalibrate1_Click(object sender, EventArgs e)
        {
            lbCalibrateIput1.Text = txtCurrentValue.Text;
            // Send tag
            // Đọc giá trị thiết bị 
            x1 = OPCManager.GetOPCValueAsFloat(DeviceValueTag);  
            txt1.Text = x1.ToString("F2"); // Hiển thị giá trị x1 
            OPCManager.SetOPCValue(CabiTag, 0);
            if (isSlideSlip)
            {
                using (var context = new MyDbContext())
                {
                    var calib = context.Calibrations.FirstOrDefault();
                    if(calib != null)
                    {
                        calib.SlideSlipA = float.Parse(txtCurrentValue.Text);
                        calib.SlideSlipB = x1;
                        context.SaveChanges();
                    }
                    else
                    {
                        var newCalib = new Calibration
                        {
                            SlideSlipA = float.Parse(txtCurrentValue.Text),
                            SlideSlipB = x1
                        };
                        context.Calibrations.Add(newCalib);
                        context.SaveChanges();
                    }    
                }
            }
        }

        private void btnAcpCalibrate2_Click(object sender, EventArgs e)
        {
            lbCalibrateIput2.Text = txtCurrentValue.Text;
            x2 = OPCManager.GetOPCValueAsFloat(DeviceValueTag);
            txt2.Text = x2.ToString("F2"); // Hiển thị giá trị x2 (nhánh trái khi là trùng vết)
        }

        private void btnAcpCalibrate2Phai_Click(object sender, EventArgs e)
        {
            lbCalibrateIput2Phai.Text = txtCurrentValue.Text;
            x2Phai = OPCManager.GetOPCValueAsFloat(DeviceValueTag);
            txt2Phai.Text = x2Phai.ToString("F2"); // Hiển thị giá trị x2 nhánh phải
        }
    }
}
