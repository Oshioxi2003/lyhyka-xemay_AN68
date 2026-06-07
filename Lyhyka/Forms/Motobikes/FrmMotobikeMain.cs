using Lyhyka.Core;
using Lyhyka.DBCore;
using Lyhyka.UCT;
using Lyhyka;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lyhyka.Forms;
using Lyhyka.RS232;
using Lyhyka.Forms.Motobikes;

namespace Lyhyka
{
    public partial class FrmMotobikeMain : Form
    {
        public FrmMotobikeDashboard FrmDashboard = null;
        private string _selectedMenu = MenuConstants.Speed;
        private OPCManager oPCManager;
        public Lyhyka.UCT.GauseMeasureWithConfirmUC speedUC;
        public Lyhyka.UCT.GauseMeasureWithConfirmUC brakeForceBothUC;
        public Lyhyka.UCT.GauseMeasureWithConfirmUC weightBothUC;
        public Lyhyka.UCT.SlideSlipWithConfirmUC slideSlipUC;
        public FrmLightStandalone lightStandaloneForm;
        public SwitchFourUC switchFourSpeedUC, switchFourSlideSlipUC, switchFourBrakeUC,switchWeightUC;

        public FrmMotobikeMain()
        {
            InitializeComponent();
            oPCManager = new OPCManager();
            RS232Manager.InitializeCOMConnections();
            InitUC();
            motobikeInfoDashboardUC.MenuButtonClicked += MenuButtonClicked; 
            GlobalVariables.OnSelectedBrandChanged = () =>
            {
                if (GlobalVariables.SelectedBrand != null)
                {
                    speedUC.UpdateRange(MenuConstants.Speed);
                    brakeForceBothUC.UpdateRange(MenuConstants.BrakeForce);
                    weightBothUC.UpdateRange(MenuConstants.Weight);
                    motobikeInfoDashboardUC.UpdateSelectedBrand();
                }
            };
            this.KeyPreview = true;
            this.KeyDown += FrmMotobikeMain_KeyDown; 
            //this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        private void FrmMotobikeMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                var frmSettingCompany = new FrmSettingCompany();
                frmSettingCompany.ShowDialog();
            }
        }

        public void Open(string menuName)
        {
            if (_selectedMenu == menuName.ToLower())
            {
                motobikeInfoDashboardUC.SetSelectedButton(menuName);
                motobikeInfoDashboardUC.MenuButtonClicked += MenuButtonClicked;
                return;
            }
            MenuButtonClicked(null, menuName);
            motobikeInfoDashboardUC.SetSelectedButton(menuName);
            motobikeInfoDashboardUC.MenuButtonClicked += MenuButtonClicked;
            motobikeInfoDashboardUC.SetVinAndFrameNumber();
        }
        public void OpenFromOPC(string menuName)
        {
            this.Invoke((MethodInvoker)(() =>
            {
                if (_selectedMenu == menuName.ToLower())
                {
                    motobikeInfoDashboardUC.SetSelectedButton(menuName);
                    return;
                }
                motobikeInfoDashboardUC.MenuButtonClicked -= MenuButtonClicked;
                MenuButtonClicked(null, menuName);
                motobikeInfoDashboardUC.SetSelectedButton(menuName);
                motobikeInfoDashboardUC.MenuButtonClicked += MenuButtonClicked;
            }));
        }
        private void InitUC()
        {
            this.speedUC = new Lyhyka.UCT.GauseMeasureWithConfirmUC(MenuConstants.Speed);
            this.brakeForceBothUC = new Lyhyka.UCT.GauseMeasureWithConfirmUC(MenuConstants.BrakeForce);
            this.slideSlipUC = new Lyhyka.UCT.SlideSlipWithConfirmUC();
            this.weightBothUC = new Lyhyka.UCT.GauseMeasureWithConfirmUC(MenuConstants.Weight);
            this.lightStandaloneForm = new FrmLightStandalone();
            this.lightStandaloneForm.TopLevel = false;
            this.lightStandaloneForm.FormBorderStyle = FormBorderStyle.None;

            speedUC.Dock = DockStyle.Fill;
            brakeForceBothUC.Dock = DockStyle.Fill;
            slideSlipUC.Dock = DockStyle.Fill;
            weightBothUC.Dock = DockStyle.Fill;
            lightStandaloneForm.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(speedUC);
            pnlMain.Controls.Add(brakeForceBothUC);
            pnlMain.Controls.Add(slideSlipUC);
            pnlMain.Controls.Add(weightBothUC);
            pnlMain.Controls.Add(lightStandaloneForm);
            lightStandaloneForm.Show();
            // Show only the first one by default

            speedUC.BringToFront();
            InitSwitch();
        }
        private SwitchFourUC InitSwitch(string name)
        {
            var switchUC = new SwitchFourUC();

            switchUC.Dock = System.Windows.Forms.DockStyle.Fill;
            switchUC.Location = new System.Drawing.Point(10, 0);
            switchUC.Name = name;
            return switchUC;
        }
        private void InitSwitch()
        {
            switchFourSpeedUC = InitSwitch("switchFourSpeedUC");
            switchFourBrakeUC = InitSwitch("switchFourBrakeUC");
            switchFourSlideSlipUC = InitSwitch("switchFourSlideSlipUC");
            switchWeightUC = InitSwitch("switchWeightUC");
            this.pnlSwitch.Controls.Add(this.switchFourSpeedUC);
            this.pnlSwitch.Controls.Add(this.switchFourBrakeUC);
            this.pnlSwitch.Controls.Add(this.switchFourSlideSlipUC);
            this.pnlSwitch.Controls.Add(this.switchWeightUC);

            switchFourSpeedUC.UpdateSwitch(MenuConstants.Speed);
            switchFourBrakeUC.UpdateSwitch(MenuConstants.BrakeForce);
            switchFourSlideSlipUC.UpdateSwitch(MenuConstants.SlideSlip);
            switchWeightUC.UpdateSwitch(MenuConstants.Weight);

            switchFourSpeedUC.BringToFront();
        }
        private void ReadDB()
        {
            using (var db = new MyDbContext())
            {
                Console.WriteLine("Reading Events table:"); 
                //db.TestVehicles.Add(new TestVehicle()
                //{
                //    BrakeForceRear=10,
                //    BrakeForceFront = 20,
                //    SlideSlip = 30,
                //    Speed = 40,
                //    WeightFront = 50,
                //    WeightRear = 60, 
                //    VehicleType = "Motorbike",
                //    Tester = "Tester Name",
                //    TestedDate = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                //    LongRangeLightIntensity = 100,
                //    LightDeviationUD = 5,
                //    LightDeviationLR = 5,
                //    VoltageDrop = 12.5f,
                //    OverCurrent = 15.0f,
                //    AxleTorqueFront = 200,
                //    AxleTorqueRear = 250,
                //    AccelerationTime = 3.5f,
                //    Brand = "Test Brand",
                //    EngineNumber = "ENG123456",
                //    FrameNumber = "FRAME987654",
                //    Whistle = 75 
                //});
                //db.SaveChanges();
                var testVehicles = db.Brands.ToList();
                foreach (var ev in testVehicles)
                {
                    Console.WriteLine($"Id={ev.Id}, Name={ev.Name}");
                }
                var Calibrations = db.Calibrations.ToList();
                foreach (var ev in Calibrations)
                {
                    Console.WriteLine($"Id={ev.Id}, Name={ev.BrakeForceRearB}");
                }
            } 
        }
        private void MenuButtonClicked(object sender, string buttonName)
        { 
            string lowerButtonName = buttonName.ToLower();
            switch (lowerButtonName)
            {
                case MenuConstants.Speed:
                    _selectedMenu = MenuConstants.Speed;
                    speedUC.BringToFront();
                    switchFourSpeedUC.BringToFront();
                    break;
                case MenuConstants.BrakeForce:
                    _selectedMenu = MenuConstants.BrakeForce;
                    brakeForceBothUC.BringToFront(); 
                    switchFourBrakeUC.BringToFront();
                    break;
                case MenuConstants.SlideSlip: 
                    _selectedMenu = MenuConstants.SlideSlip;
                    slideSlipUC.BringToFront();
                    switchFourSlideSlipUC.BringToFront();
                    break;
                case MenuConstants.Weight:
                    _selectedMenu = MenuConstants.Weight;
                    weightBothUC.BringToFront();
                    switchWeightUC.BringToFront(); 
                    break;
                case MenuConstants.Home:
                    motobikeInfoDashboardUC.MenuButtonClicked -= MenuButtonClicked;
                    FrmDashboard = new FrmMotobikeDashboard(this, _selectedMenu);
                    FrmDashboard.ShowDialog();
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
                case MenuConstants.Headlight:
                    _selectedMenu = MenuConstants.Headlight;
                    if (lightStandaloneForm == null || lightStandaloneForm.IsDisposed)
                    {
                        lightStandaloneForm = new FrmLightStandalone();
                        lightStandaloneForm.TopLevel = false;
                        lightStandaloneForm.FormBorderStyle = FormBorderStyle.None;
                        lightStandaloneForm.Dock = DockStyle.Fill;
                        pnlMain.Controls.Add(lightStandaloneForm);
                        lightStandaloneForm.Show();
                    }
                    lightStandaloneForm.BringToFront();
                    break;
            }
            //menu.SetSwitchControl(buttonName);
        }

        private void FrmMotobikeMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            RS232Manager.CloseConnections(); 
        } 
    }
}
