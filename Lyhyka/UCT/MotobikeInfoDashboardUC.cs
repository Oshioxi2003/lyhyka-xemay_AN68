using DevExpress.XtraEditors;
using Lyhyka.Core;
using Lyhyka.DBCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lyhyka.UCT
{
    public partial class MotobikeInfoDashboardUC : UserControl
    {
        public static Action OnTesterDataReceived; // Delegate to call the form 
        public static Action OnBrandDataReceived; // Delegate to call the form 


        public MotobikeInfoDashboardUC()
        {
            InitializeComponent();
            // 1. Disable default look and feel (this is critical)
            //simpleButton1.LookAndFeel.UseDefaultLookAndFeel = false;

            //// 2. Set a flat style so appearance settings are respected
            //simpleButton1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;

            //simpleButton1.AppearanceHovered.BackColor = Color.Red;
            //simpleButton1.AppearanceHovered.ForeColor = Color.White;
            //simpleButton1.AppearanceHovered.Options.UseBackColor = true;

            btnSpeed.Appearance.BackColor = Color.FromArgb(255, 220, 50, 53);
            btnSpeed.Appearance.ForeColor = Color.White; // Set the text color to white
            OnTesterDataReceived += SetTester;
            OnBrandDataReceived += SetBrand;
        }
        public event EventHandler<string> MenuButtonClicked;
        private void btnMenuButton_Click(object sender, EventArgs e)
        {
            ResetButtonStyles();

             //bool isMeasureChecked = false;
             var simpleButton = sender as SimpleButton;
            switch(simpleButton)
            {
                case SimpleButton btn when btn.Name == "btnSpeed": 
                    btnSpeed.Appearance.BackColor = Color.FromArgb(255, 220, 50, 53);
                    btnSpeed.Appearance.ForeColor = Color.White; // Set the text color to white
                    break;
                case SimpleButton btn when btn.Name == "btnBrakeForce":
                    btnBrakeForce.Appearance.BackColor = Color.FromArgb(255, 220, 50, 53);
                    btnBrakeForce.Appearance.ForeColor = Color.White; // Set the text color to white
                    break;
                case SimpleButton btn when btn.Name == "btnSlideSlip":
                    btnSlideSlip.Appearance.BackColor = Color.FromArgb(255, 220, 50, 53);
                    btnSlideSlip.Appearance.ForeColor = Color.White; // Set the text color to white
                    break;
                case SimpleButton btn when btn.Name == "btnWeight":
                    btnWeight.Appearance.BackColor = Color.FromArgb(255, 220, 50, 53);
                    btnWeight.Appearance.ForeColor = Color.White; // Set the text color to white
                    break;
                case SimpleButton btn when btn.Name == "btnHeadlight":
                    btnHeadlight.Appearance.BackColor = Color.FromArgb(255, 220, 50, 53);
                    btnHeadlight.Appearance.ForeColor = Color.White; // Set the text color to white
                    break;
                default:
                    break; // If the button is not recognized, do nothing
            }    
           
            // Raise event to notify MainForm
            // Use AccessibleName if set, otherwise fall back to Text
            string menuName = !string.IsNullOrEmpty(simpleButton.AccessibleName) 
                ? simpleButton.AccessibleName 
                : simpleButton.Text.ToLower();
            MenuButtonClicked?.Invoke(this, menuName);
        }
        private void ResetButtonStyles()
        {
            btnSpeed.Appearance.BackColor = Color.White;
            btnSpeed.Appearance.ForeColor = Color.Black;

            btnBrakeForce.Appearance.BackColor = Color.White;
            btnBrakeForce.Appearance.ForeColor = Color.Black;

            btnWeight.Appearance.BackColor = Color.White;
            btnWeight.Appearance.ForeColor = Color.Black;

            btnSlideSlip.Appearance.BackColor = Color.White;
            btnSlideSlip.Appearance.ForeColor = Color.Black;

            btnHeadlight.Appearance.BackColor = Color.White;
            btnHeadlight.Appearance.ForeColor = Color.Black;
        }
        public void SetSelectedButton(string selectedMenu)
        {
            ResetButtonStyles();

            //bool isMeasureChecked = false; 
            switch (selectedMenu.ToLower())
            {
                case MenuConstants.Speed:
                    btnSpeed.Appearance.BackColor = Color.FromArgb(255, 220, 50, 53);
                    btnSpeed.Appearance.ForeColor = Color.White; // Set the text color to white
                    break;
                case MenuConstants.BrakeForce:
                    btnBrakeForce.Appearance.BackColor = Color.FromArgb(255, 220, 50, 53);
                    btnBrakeForce.Appearance.ForeColor = Color.White; // Set the text color to white
                    break;
                case MenuConstants.SlideSlip:
                    btnSlideSlip.Appearance.BackColor = Color.FromArgb(255, 220, 50, 53);
                    btnSlideSlip.Appearance.ForeColor = Color.White; // Set the text color to white
                    break;
                case MenuConstants.Weight:
                    btnWeight.Appearance.BackColor = Color.FromArgb(255, 220, 50, 53);
                    btnWeight.Appearance.ForeColor = Color.White; // Set the text color to white
                    break;
                case MenuConstants.Headlight:
                    btnHeadlight.Appearance.BackColor = Color.FromArgb(255, 220, 50, 53);
                    btnHeadlight.Appearance.ForeColor = Color.White; // Set the text color to white
                    break;
                default:
                    break; // If the button is not recognized, do nothing
            }
        }
        private void MotobikeInfoDashboardUC_Load(object sender, EventArgs e)
        {
            cboTester.DataSource = GlobalVariables.Admins;
            cboTester.DisplayMember = "UserName"; // Text shown to user
            cboTester.ValueMember = "UserName";     // Internal value 

            cboBrand.DataSource = GlobalVariables.Brands;
            cboBrand.DisplayMember = "DisplayName"; // Text shown to user
            cboBrand.ValueMember = "DisplayName";     // Internal value  
            GlobalVariables.TestVehicle.VehicleType= GlobalVariables.SelectedBrand.Name;
            GlobalVariables.TestVehicle.Tester = cboTester.Text;
            cboBrand.SelectedIndex = GlobalVariables.SelectedBrandIndex;
            this.cboBrand.SelectedIndexChanged += new System.EventHandler(this.cboBrand_SelectedIndexChanged);

            // Tạo thêm fields nhập thông tin xe
            CreateExtraVehicleInfoFields();
            txtColor.Text = GlobalVariables.TestVehicle.VehicleColor ?? "";
        }

        private void CreateExtraVehicleInfoFields()
        {
            // Tự động load thông tin mặc định từ brand vào TestVehicle
            if (GlobalVariables.SelectedBrand != null)
            {
                if (string.IsNullOrEmpty(GlobalVariables.TestVehicle.CertificateNumber))
                    GlobalVariables.TestVehicle.CertificateNumber = GlobalVariables.SelectedBrand.CertificateNumber ?? "";
                if (string.IsNullOrEmpty(GlobalVariables.TestVehicle.VehicleBrandName))
                    GlobalVariables.TestVehicle.VehicleBrandName = GlobalVariables.SelectedBrand.VehicleBrandName ?? "";
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        void SetTester()
        {
            GlobalVariables.InitAdmins();
            cboTester.DataSource = GlobalVariables.Admins;
            cboTester.DisplayMember = "UserName"; // Text shown to user
            cboTester.ValueMember = "UserName";     // Internal value 
        }
        void SetBrand()
        { 
            cboBrand.DataSource = GlobalVariables.Brands;
            cboBrand.DisplayMember = "DisplayName"; // Text shown to user
            cboBrand.ValueMember = "DisplayName";     // Internal value  
        }
        public void SetVinAndFrameNumber()
        {
            txtVin.Text = GlobalVariables.TestVehicle.EngineNumber;
            txtFrameNumber.Text = GlobalVariables.TestVehicle.FrameNumber;
            txtColor.Text = GlobalVariables.TestVehicle.VehicleColor;
            cboBrand.Text = GlobalVariables.TestVehicle.VehicleType;
            cboTester.Text = GlobalVariables.TestVehicle.Tester;
        }
        private void txtVin_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.EngineNumber = txtVin.Text.Trim();
        }
        private void txtFrameNumber_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.FrameNumber = txtFrameNumber.Text.Trim();
        }
        private void txtColor_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.VehicleColor = txtColor.Text.Trim();
        }

        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboBrand.SelectedIndexChanged -= new System.EventHandler(this.cboBrand_SelectedIndexChanged);
            GlobalVariables.TestVehicle.VehicleType = cboBrand.Text;
            GlobalVariables.UpdateSelectedBrand(cboBrand.Text);
            this.cboBrand.SelectedIndexChanged += new System.EventHandler(this.cboBrand_SelectedIndexChanged);
            GlobalVariables.SelectedBrandIndex = cboBrand.SelectedIndex;
        }
        public void UpdateSelectedBrand()
        {
          
        }
        private void cboTester_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.Tester = cboTester.Text;
           
        }
    }
}
