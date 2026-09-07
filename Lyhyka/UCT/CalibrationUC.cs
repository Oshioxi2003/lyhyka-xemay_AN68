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
        string DeviceValueTag, CabiTag, ATag, BTag, ATagPhai, BTagPhai, X0Tag;
        float x1 = 0;
        float x2 = 0;
        float x2Phai = 0;
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

                        label5.Text = "Điểm đo chuẩn 2 (Trái)";
                        label6.Text = "Giá trị điểm đo từ thiết bị 2 (Trái)";
                        btnAcpCalibrate2.Text = "CHỐT GIÁ TRỊ ĐO 2 (TRÁI)";
                        label7.Visible = true;
                        txtCalibrateInput2Phai.Visible = true;
                        label8.Visible = true;
                        lbCalibrateIput2Phai.Visible = true;
                        txt2Phai.Visible = true;
                        btnAcpCalibrate2Phai.Visible = true;

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
                // calib_a/calib_b giữ nguyên làm cặp hệ số bên Trái (tag đã có sẵn trên PLC, không đổi địa chỉ)
                ATag = $"{TagConstants.chanel}.{deviceTag}.calib_a";
                BTag = $"{TagConstants.chanel}.{deviceTag}.calib_b";
                if (isSlideSlip)
                {
                    ATagPhai = $"{TagConstants.chanel}.{deviceTag}.calib_a_phai";
                    BTagPhai = $"{TagConstants.chanel}.{deviceTag}.calib_b_phai";
                    X0Tag = $"{TagConstants.chanel}.{deviceTag}.calib_x0";
                }
            }
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
            if (!float.TryParse(txtCalibrateInput1.Text, out float y1) || !float.TryParse(txtCalibrateInput2.Text, out float y2))
            {
                MessageBox.Show("Giá trị điểm chuẩn không hợp lệ, vui lòng kiểm tra lại.");
                return;
            }
            // Tính a (bên Trái khi hiệu chuẩn trùng vết)
            float a = (y2 - y1) / (x2 - x1);
            // Tính b
            float b = y1 - a * x1;
            // Lưu vào OPC
            OPCManager.SetOPCValue(ATag, a);
            OPCManager.SetOPCValue(BTag, b);

            if (isSlideSlip)
            {
                if (!float.TryParse(txtCalibrateInput2Phai.Text, out float y2Phai))
                {
                    MessageBox.Show("Giá trị điểm chuẩn 2 (Phải) không hợp lệ, vui lòng kiểm tra lại.");
                    return;
                }
                // Tính đường thẳng riêng cho bên Phải, dùng chung điểm chuẩn 1
                float aPhai = (y2Phai - y1) / (x2Phai - x1);
                float bPhai = y1 - aPhai * x1;
                OPCManager.SetOPCValue(ATagPhai, aPhai);
                OPCManager.SetOPCValue(BTagPhai, bPhai);
                // calib_x0 đã được gửi ngay khi chốt Điểm chuẩn 1 (btnAcpCalibrate1_Click)
            }

            OPCManager.SetOPCValue(CabiTag, 1);
            MessageBox.Show("Hiểu chỉnh thành công!");
        }

        private void btnAcpCalibrate1_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(txtCurrentValue.Text, out float currentDisplayValue))
            {
                MessageBox.Show("Chưa nhận được giá trị đo từ thiết bị, vui lòng đợi vài giây rồi thử lại.");
                return;
            }

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
                        calib.SlideSlipA = currentDisplayValue;
                        calib.SlideSlipB = x1;
                        context.SaveChanges();
                    }
                    else
                    {
                        var newCalib = new Calibration
                        {
                            SlideSlipA = currentDisplayValue,
                            SlideSlipB = x1
                        };
                        context.Calibrations.Add(newCalib);
                        context.SaveChanges();
                    }
                }
                // Gửi ngay mốc 1 (giá trị thô) lên PLC để PLC tự so sánh chọn Trái/Phải
                OPCManager.SetOPCValue(X0Tag, x1);
            }
        }

        private void btnAcpCalibrate2_Click(object sender, EventArgs e)
        {
            lbCalibrateIput2.Text = txtCurrentValue.Text;
            x2 = OPCManager.GetOPCValueAsFloat(DeviceValueTag);
            txt2.Text = x2.ToString("F2"); // Hiển thị giá trị x2 (Trái)
        }

        private void btnAcpCalibrate2Phai_Click(object sender, EventArgs e)
        {
            lbCalibrateIput2Phai.Text = txtCurrentValue.Text;
            x2Phai = OPCManager.GetOPCValueAsFloat(DeviceValueTag);
            txt2Phai.Text = x2Phai.ToString("F2"); // Hiển thị giá trị x2 (Phải)
        }
    }
}
