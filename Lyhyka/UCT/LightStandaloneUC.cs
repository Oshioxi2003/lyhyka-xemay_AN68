using Lyhyka.Core;
using Lyhyka.RS232;
using System; 
using System.Drawing; 
using System.Windows.Forms;

namespace Lyhyka.UCT
{
    public partial class LightStandaloneUC : UserControl
    {
        public LightStandaloneUC()
        {
            InitializeComponent();
            GlobalVariables.OnUpdatedGlobalSettingChanged = () =>
            {
                SetHeadlightUnit();
            };
            SetHeadlightUnit();
            btnStartLow.Enabled= btnStartHigh.Enabled = true;
            btnStopLow.Enabled = btnStopHigh.Enabled = false;
             
        }
        void SetHeadlightUnit()
        {
            if(GlobalVariables.HeadLightUnitIsPercentage)
            {
                lblFarLR.Text = lblNearLR.Text = "Độ lệch đèn L/R(%)";
                lblFarUD.Text = lblNearUD.Text = "Độ lệch đèn U/D(%)"; 
            }
            else
            {
                lblFarLR.Text = lblNearLR.Text = "Độ lệch đèn L/R(mm/10m)";
                lblFarUD.Text = lblNearUD.Text = "Độ lệch đèn U/D(mm/10m)";
            }
        }
        public void SetCurrentValue()
        {
           
            txtLongRangeHeadLightIntensity.Text = (GlobalVariables.TestVehicle.LongRangeLightIntensity / 100).ToString("F0");
            txtHeadLightDeviationUD.Text = GlobalVariables.TestVehicle.LightDeviationUD.ToString();
            txtHeadLightDeviationLR.Text = GlobalVariables.TestVehicle.LightDeviationLR.ToString();

            txtNearLightDeviationUD.Text = GlobalVariables.TestVehicle.NearLightDeviationUD.ToString();
            txtNearLightDeviationLR.Text = GlobalVariables.TestVehicle.NearLightDeviationLR.ToString();
            txtLongRangeNearLightIntensity.Text = (GlobalVariables.TestVehicle.LongRangeNearLightIntensity / 100).ToString("F0");

            if (GlobalVariables.TestVehicle.VoltageDrop1 == null)
                GlobalVariables.TestVehicle.VoltageDrop1 = 0;
        }
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }

            // Only allow one decimal point
            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

            // Only allow minus sign at the beginning
            if (e.KeyChar == '-' && (sender as TextBox).SelectionStart != 0)
            {
                e.Handled = true;
            }
        }

        Color CheckColor(float value, float min, float max)
        {
            if (value < min)
            {
                return ColorConstants.LowerColor;
            }
            else if (value > max)
            {
                return ColorConstants.HigherColor;
            }
            else
            {
                return ColorConstants.InRangeColor;
            }
        }

        // Độ lệch đèn dùng ngưỡng riêng theo hướng và theo dấu (dương -> trái/trên, âm -> phải/dưới),
        // khớp với CheckLightDeviation trong RreportHelpers.cs
        Color CheckColorDeviation(float value, float leftOrUpMin, float leftOrUpMax, float rightOrDownMin, float rightOrDownMax, float fallbackMin, float fallbackMax)
        {
            if (leftOrUpMin == 0 && leftOrUpMax == 0 && rightOrDownMin == 0 && rightOrDownMax == 0)
            {
                return CheckColor(value, fallbackMin, fallbackMax);
            }

            if (value >= 0)
            {
                return CheckColor(value, leftOrUpMin, leftOrUpMax);
            }
            else
            {
                return CheckColor(Math.Abs(value), rightOrDownMin, rightOrDownMax);
            }
        }
        public void UpdateRange()
        {

            txtLongRangeHeadLightIntensity.BackColor = CheckColor(GlobalVariables.TestVehicle.LongRangeLightIntensity, GlobalVariables.SelectedBrand.LongRangeLightIntensityMin, GlobalVariables.SelectedBrand.LongRangeLightIntensityMax);
            txtHeadLightDeviationUD.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.LightDeviationUD, GlobalVariables.SelectedBrand.LightDeviationUpMin, GlobalVariables.SelectedBrand.LightDeviationUpMax, GlobalVariables.SelectedBrand.LightDeviationDownMin, GlobalVariables.SelectedBrand.LightDeviationDownMax, GlobalVariables.SelectedBrand.LightDeviationUDMin, GlobalVariables.SelectedBrand.LightDeviationUDMax);
            txtHeadLightDeviationLR.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.LightDeviationLR, GlobalVariables.SelectedBrand.LightDeviationLeftMin, GlobalVariables.SelectedBrand.LightDeviationLeftMax, GlobalVariables.SelectedBrand.LightDeviationRightMin, GlobalVariables.SelectedBrand.LightDeviationRightMax, GlobalVariables.SelectedBrand.LightDeviationLRMin, GlobalVariables.SelectedBrand.LightDeviationLRMax);


            txtLongRangeNearLightIntensity.BackColor = CheckColor(GlobalVariables.TestVehicle.LongRangeNearLightIntensity, GlobalVariables.SelectedBrand.LongRangeNearLightIntensityMin, GlobalVariables.SelectedBrand.LongRangeNearLightIntensityMax);
            txtNearLightDeviationUD.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.NearLightDeviationUD, GlobalVariables.SelectedBrand.NearLightDeviationUpMin, GlobalVariables.SelectedBrand.NearLightDeviationUpMax, GlobalVariables.SelectedBrand.NearLightDeviationDownMin, GlobalVariables.SelectedBrand.NearLightDeviationDownMax, GlobalVariables.SelectedBrand.NearLightDeviationUDMin, GlobalVariables.SelectedBrand.NearLightDeviationUDMax);
            txtNearLightDeviationLR.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.NearLightDeviationLR, GlobalVariables.SelectedBrand.NearLightDeviationLeftMin, GlobalVariables.SelectedBrand.NearLightDeviationLeftMax, GlobalVariables.SelectedBrand.NearLightDeviationRightMin, GlobalVariables.SelectedBrand.NearLightDeviationRightMax, GlobalVariables.SelectedBrand.NearLightDeviationLRMin, GlobalVariables.SelectedBrand.NearLightDeviationLRMax);

        }
       

        private void txtLongRangeHeadLightIntensity_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.LongRangeLightIntensity = string.IsNullOrEmpty(txtLongRangeHeadLightIntensity.Text) ? 0 : float.Parse(txtLongRangeHeadLightIntensity.Text);

            txtLongRangeHeadLightIntensity.BackColor = CheckColor(GlobalVariables.TestVehicle.LongRangeLightIntensity, GlobalVariables.SelectedBrand.LongRangeLightIntensityMin, GlobalVariables.SelectedBrand.LongRangeLightIntensityMax);
        }

        private void txtHeadLightDeviationUD_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.LightDeviationUD = string.IsNullOrEmpty(txtHeadLightDeviationUD.Text) ? 0 : float.Parse(txtHeadLightDeviationUD.Text);
            txtHeadLightDeviationUD.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.LightDeviationUD, GlobalVariables.SelectedBrand.LightDeviationUpMin, GlobalVariables.SelectedBrand.LightDeviationUpMax, GlobalVariables.SelectedBrand.LightDeviationDownMin, GlobalVariables.SelectedBrand.LightDeviationDownMax, GlobalVariables.SelectedBrand.LightDeviationUDMin, GlobalVariables.SelectedBrand.LightDeviationUDMax);

        }

        private void txtHeadLightDeviationLR_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.LightDeviationLR = string.IsNullOrEmpty(txtHeadLightDeviationLR.Text) ? 0 : float.Parse(txtHeadLightDeviationLR.Text);

            txtHeadLightDeviationLR.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.LightDeviationLR, GlobalVariables.SelectedBrand.LightDeviationLeftMin, GlobalVariables.SelectedBrand.LightDeviationLeftMax, GlobalVariables.SelectedBrand.LightDeviationRightMin, GlobalVariables.SelectedBrand.LightDeviationRightMax, GlobalVariables.SelectedBrand.LightDeviationLRMin, GlobalVariables.SelectedBrand.LightDeviationLRMax);
        }


        private void txtLongRangeNearLightIntensity_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.LongRangeNearLightIntensity = string.IsNullOrEmpty(txtLongRangeNearLightIntensity.Text) ? 0 : float.Parse(txtLongRangeNearLightIntensity.Text);

            txtLongRangeNearLightIntensity.BackColor = CheckColor(GlobalVariables.TestVehicle.LongRangeNearLightIntensity, GlobalVariables.SelectedBrand.LongRangeNearLightIntensityMin, GlobalVariables.SelectedBrand.LongRangeNearLightIntensityMax);
        }

        private void txtNearLightDeviationUD_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.NearLightDeviationUD = string.IsNullOrEmpty(txtNearLightDeviationUD.Text) ? 0 : float.Parse(txtNearLightDeviationUD.Text);
            txtNearLightDeviationUD.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.NearLightDeviationUD, GlobalVariables.SelectedBrand.NearLightDeviationUpMin, GlobalVariables.SelectedBrand.NearLightDeviationUpMax, GlobalVariables.SelectedBrand.NearLightDeviationDownMin, GlobalVariables.SelectedBrand.NearLightDeviationDownMax, GlobalVariables.SelectedBrand.NearLightDeviationUDMin, GlobalVariables.SelectedBrand.NearLightDeviationUDMax);

        }

        private void txtNearLightDeviationLR_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.NearLightDeviationLR = string.IsNullOrEmpty(txtNearLightDeviationLR.Text) ? 0 : float.Parse(txtNearLightDeviationLR.Text);

            txtNearLightDeviationLR.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.NearLightDeviationLR, GlobalVariables.SelectedBrand.NearLightDeviationLeftMin, GlobalVariables.SelectedBrand.NearLightDeviationLeftMax, GlobalVariables.SelectedBrand.NearLightDeviationRightMin, GlobalVariables.SelectedBrand.NearLightDeviationRightMax, GlobalVariables.SelectedBrand.NearLightDeviationLRMin, GlobalVariables.SelectedBrand.NearLightDeviationLRMax);
        }


        
        private void NoiseAndLightsUC_Load(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Enter += textBox_Enter;
                    ctrl.MouseUp += textBox_MouseUp;
                }
            }
            btnStartHigh.Visible = btnStopHigh.Visible = btnStartLow.Visible = btnStopLow.Visible = RS232Manager.UsingMQD6A; 
            lblLongRangeNearLightIntensity.Visible = txtLongRangeNearLightIntensity.Visible = RS232Manager.ShowLowBeamLightIntensity;
            lblNearLR.Visible = txtNearLightDeviationLR.Visible = RS232Manager.ShowLowBeamLightDeviationLR;
        }
        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                tb.SelectAll();
            }
        }
        private void textBox_MouseUp(object sender, MouseEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null && !tb.Focused)
            {
                tb.SelectAll();
            }
        }

         
        private void btnStartHigh_Click(object sender, EventArgs e)
        {
            btnStartLow.Enabled = false;
            btnStartHigh.Enabled = false;
            RS232Manager.SendHeadlightMQD6AHigh(btnStopHigh);
        }

        private void btnStopHigh_Click(object sender, EventArgs e)
        {
            btnStartHigh.Enabled = true;
            btnStartLow.Enabled = true;
            btnStopHigh.Enabled = false;
            RS232Manager.SendHeadlightMQD6AStop();
        }

        private void btnStartLow_Click(object sender, EventArgs e)
        {
            btnStartLow.Enabled = false; 
            btnStartHigh.Enabled = false;
            RS232Manager.SendHeadlightMQD6Low(btnStopLow);
        }

        private void btnStopLow_Click(object sender, EventArgs e)
        {
            btnStartHigh.Enabled = true;
            btnStartLow.Enabled = true;
            btnStopLow.Enabled = false;
            RS232Manager.SendHeadlightMQD6AStop();
        }

         
    }
}
