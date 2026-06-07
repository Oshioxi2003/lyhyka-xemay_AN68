using Lyhyka.Core;
using Lyhyka.DBCore;
using Lyhyka.Forms;
using Lyhyka.Forms.Motobikes;
using Lyhyka.Reports;
using Lyhyka.RS232;
using Lyhyka.UCT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lyhyka
{
    public partial class FrmMotobikeDashboard : Form
    {
        FrmMotobikeMain _main;
        public FrmMotobikeDashboard(FrmMotobikeMain main, string selectedMenu)
        {
            InitializeComponent();
            _main = main;
            motobikeInfoDashboardUC.SetSelectedButton(selectedMenu);
            motobikeInfoDashboardUC.MenuButtonClicked += MenuButtonClicked;
            motobikeInfoDashboardUC.UpdateSelectedBrand(); 
            //this.FormBorderStyle = FormBorderStyle.Sizable;
        }
        private void MenuButtonClicked(object sender, string buttonName)
        {
            switch (buttonName.ToLower())
            {
                case MenuConstants.Speed:
                case MenuConstants.BrakeForce:
                case MenuConstants.SlideSlip:
                case MenuConstants.Weight:
                case MenuConstants.Headlight:
                    _main.Open(buttonName);
                    this.Close();
                    break;
                case MenuConstants.Print:
                    //var frmReport = new TestReport();
                    //frmReport.ShowDialog();
                    Print();
                    break;
                case MenuConstants.Exit:
                    Application.Exit();
                    break;
                case MenuConstants.Calibrate:
                    using (var blurForm = new BlurForm(this))
                    {
                        blurForm.Show();
                        var frmLogin = new FrmLogin(buttonName.ToLower());
                        frmLogin.ShowDialog();
                        blurForm.Hide();
                    }
                    break;
                case MenuConstants.Setting:
                    var frmSetting = new FrmSetting();
                    frmSetting.ShowDialog();
                    break;
                case MenuConstants.Search:
                    var frmHistory = new FrmHistory();
                    frmHistory.ShowDialog();
                    break;
            }
        }
        private bool SaveVehicleTest()
        {
            if (GlobalVariables.TestVehicle == null)
            {
                MessageBox.Show("Không có dữ liệu xe để lưu.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(GlobalVariables.TestVehicle.EngineNumber) || string.IsNullOrWhiteSpace(GlobalVariables.TestVehicle.FrameNumber))
            {
                MessageBox.Show("Số máy và số khung không được để trống.");
                return false;
            }
            
            using (var context = new MyDbContext())
            {
                GlobalVariables.TestVehicle.TestedDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                GlobalVariables.TestVehicle.BrandId = GlobalVariables.SelectedBrand.Id;
                var testVehicle = context.TestVehicles.FirstOrDefault(x => x.EngineNumber == GlobalVariables.TestVehicle.EngineNumber);
                if (testVehicle == null)
                {
                    context.TestVehicles.Add(GlobalVariables.TestVehicle);
                }
                else
                {
                    GlobalVariables.TestVehicle.Id = testVehicle.Id;
                    context.Entry(testVehicle).CurrentValues.SetValues(GlobalVariables.TestVehicle);
                }
                context.SaveChanges();
                return true;
            }
        }
        private void Print()
        {
            if (SaveVehicleTest())
            { 
                DataTable reportDataList = RreportHelpers.GetVehicleReportData(GlobalVariables.TestVehicle, GlobalVariables.SelectedBrand);
                TestReport exportReportForm = new TestReport(reportDataList);
                exportReportForm.ShowDialog();
                GlobalVariables.RefreshVin();
                motobikeInfoDashboardUC.SetVinAndFrameNumber();
            }
        }
    

        private void FrmMotobikeDashboard_Load(object sender, EventArgs e)
        {
            motobikeInfoDashboardUC.SetVinAndFrameNumber();
            noiseAndLightsUC.SetCurrentValue();
            SetSpeedValue();
            SetSlideSlipValue();
            SetWeightValue();
            SetBrakeForceValue();
            SetNoiseAndLightsValues();
            // Register callback
            MQD3BParser.OnDataReceived = SetNoiseAndLightsValues;
            MQD6AParser.OnDataReceived = SetNoiseAndLightsValues;
            OPCManager.OnDataReceived += SetDataFromOPC;
            GlobalVariables.OnSelectedBrandChanged = () =>
            {
                if (GlobalVariables.SelectedBrand != null)
                {
                    speedUC.SetRange();
                    weightBothUC.SetRange();
                    brakeForceBothUC.SetRange();
                    noiseAndLightsUC.UpdateRange();
                }
            };
        }
        public void SetNoiseAndLightsValues()
        {
            //MessageBox.Show("SetNoiseAndLightsValues");
            // Check if we are on the UI thread
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => noiseAndLightsUC.SetCurrentValue()));
            }
            else
            {
                noiseAndLightsUC.SetCurrentValue();
            }


        }
        public void SetDataFromOPC(string selectedMenu)
        {
            switch (selectedMenu)
            {
                case MenuConstants.Speed:
                    if (InvokeRequired)
                    {
                        BeginInvoke(new Action(() => SetSpeedValue()));
                    }
                    else
                    {
                        SetSpeedValue();
                    }
                    break;
                case MenuConstants.BrakeForce:
                    if (InvokeRequired)
                    {
                        BeginInvoke(new Action(() => SetBrakeForceValue()));
                    }
                    else
                    {
                        SetBrakeForceValue();
                    }
                    break;
                case MenuConstants.SlideSlip:
                    if (InvokeRequired)
                    {
                        BeginInvoke(new Action(() => SetSlideSlipValue()));
                    }
                    else
                    {
                        SetSlideSlipValue();
                    }
                    break;
                case MenuConstants.Weight:
                    if (InvokeRequired)
                    {
                        BeginInvoke(new Action(() => SetWeightValue()));
                    }
                    else
                    {
                        SetWeightValue();
                    }
                    break;
                case MenuConstants.Noise:
                    if (InvokeRequired)
                    {
                        BeginInvoke(new Action(() => noiseAndLightsUC.SetCurrentValue()));
                    }
                    else
                    {
                        noiseAndLightsUC.SetCurrentValue();
                    }
                    break;
            }
        }
        private void SetSpeedValue()
        {
            try
            {
                speedUC.SetValue(GlobalVariables.TestVehicle.Speed);
            }
            catch (Exception)
            {
                speedUC.SetValue(new Random().Next(0, 100)); // Set a random value for testing
            }
        }
        private void SetSlideSlipValue()
        {
            try
            {
                slideSlipAndAccelerationTimeUC.SetValue(GlobalVariables.TestVehicle.SlideSlip);
            }
            catch (Exception)
            {
                slideSlipAndAccelerationTimeUC.SetValue(new Random().Next(0, 100));
            }
        }

        private void SetBrakeForceValue()
        {
            try
            {
                brakeForceBothUC.SetFrontValue(GlobalVariables.TestVehicle.BrakeForceFront);
                brakeForceBothUC.SetRearValue(GlobalVariables.TestVehicle.BrakeForceRear);
            }
            catch (Exception)
            {
                brakeForceBothUC.SetFrontValue(new Random().Next(0, 100));
                brakeForceBothUC.SetRearValue(new Random().Next(0, 100));
            }
        }
        private void SetWeightValue()
        {
            try
            {

                //weightBothUC.SetValue((float)OPCManager.SpeedGroupInfo.Tags[TagConstants.tocdo_max].Value);
            }
            catch (Exception)
            {
            }
        }

    }
}
