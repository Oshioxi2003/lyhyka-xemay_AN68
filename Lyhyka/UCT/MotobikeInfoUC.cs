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
    public partial class MotobikeInfoUC : UserControl
    {
        private Lyhyka.UCT.SwitchBrakeUC switchBrakeUC;
        private Lyhyka.UCT.SwitchSpeedUC switchSpeedUC;
        private Lyhyka.UCT.SwitchSlideSlipUC switchSlideSlipUC; 

        public MotobikeInfoUC()
        {
            InitializeComponent();
            InitUC();
        }

        private void InitUC()
        {
            switchBrakeUC = new Lyhyka.UCT.SwitchBrakeUC();
            switchSpeedUC = new Lyhyka.UCT.SwitchSpeedUC();
            switchSlideSlipUC = new Lyhyka.UCT.SwitchSlideSlipUC(); 
            switchBrakeUC.Dock = DockStyle.Fill;
            switchSpeedUC.Dock = DockStyle.Fill;
            switchSlideSlipUC.Dock = DockStyle.Fill;
            pnlControl.Controls.Add(switchBrakeUC);
            pnlControl.Controls.Add(switchSpeedUC);
            pnlControl.Controls.Add(switchSlideSlipUC);
            switchSpeedUC.BringToFront();  
        }
        public event EventHandler<string> MenuButtonClicked;
        private void btnMenuButton_Click(object sender, EventArgs e)
        {
            // Raise event to notify MainForm
            MenuButtonClicked?.Invoke(this, ((System.Windows.Forms.Control)sender).AccessibilityObject.Name);
        } 
        public void SetSwitchControl(string menuControl)
        {
            switch (menuControl)
            {
                case MenuConstants.Speed:
                    switchSpeedUC.Show();
                    switchSpeedUC.BringToFront();
                    break;
                case MenuConstants.BrakeForce:
                    switchBrakeUC.Show();
                    switchBrakeUC.BringToFront();
                    break;
                case MenuConstants.SlideSlip:
                    switchSlideSlipUC.Show();
                    switchSlideSlipUC.BringToFront();
                    break;
                case MenuConstants.Home:
                    break;
                default:
                    switchSpeedUC.Hide();
                    switchSlideSlipUC.Hide();
                    switchBrakeUC.Hide();
                    break;
            }
        }

        private void MotobikeInfoUC_Load(object sender, EventArgs e)
        { 
            cboTester.DataSource = GlobalVariables.Admins;
            cboTester.DisplayMember = "UserName"; // Text shown to user
            cboTester.ValueMember = "UserName";     // Internal value 

            cbTypeCar.DataSource = GlobalVariables.Brands;
            cbTypeCar.DisplayMember = "Name"; // Text shown to user
            cbTypeCar.ValueMember = "Name";     // Internal value 
        }
    }
}
