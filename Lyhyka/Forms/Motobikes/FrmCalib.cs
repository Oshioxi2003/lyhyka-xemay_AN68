using Lyhyka.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lyhyka.Forms.Motobikes
{
    public partial class FrmCalib : Form
    {
        public FrmCalib()
        {
            InitializeComponent();
        }

        private void FrmCalib_Load(object sender, EventArgs e)
        {
            calibrationUCSpeed.SetType(MenuConstants.Speed);
            calibrationUCBrake.SetType(MenuConstants.BrakeForce);
            calibrationUCSlideSlip.SetType(MenuConstants.SlideSlip);
            OPCManager.OnCalibDataReceived += OPCManager_OnCalibDataReceived;
        }
        private void OPCManager_OnCalibDataReceived(string type,float value)
        {
            try
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    switch(type)
                    {
                        case  MenuConstants.Speed:
                            calibrationUCSpeed.UpdateCurrentValue(value);
                            break;
                        case MenuConstants.SlideSlip: 
                            calibrationUCSlideSlip.UpdateCurrentValue(value);
                            break;
                        case MenuConstants.BrakeForce:
                            calibrationUCBrake.UpdateCurrentValue(value);
                            break; 
                    }
                }));
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the update
                //Console.WriteLine("Error updating current value: " + ex.Message);
            }
        }

        private void chkManualSpeedMeasing_CheckedChanged(object sender, EventArgs e)
        {
            if (OPCManager.SetOPCValue($"{TagConstants.chanel}.{TagConstants.speedDevice}.chedo", chkManualSpeedMeasing.Checked))
                MessageBox.Show("Cập nhật chế độ đo tốc độ thành công!");
        }
    }
}
