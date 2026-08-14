using Lyhyka.Core;
using Lyhyka.RS232;
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
    public partial class NoiseAndLightsUC : UserControl
    {
        public NoiseAndLightsUC()
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
           
            txtLongRangeHeadLightIntensity.Text = GlobalVariables.TestVehicle.LongRangeLightIntensity.ToString();
            txtHeadLightDeviationUD.Text = GlobalVariables.TestVehicle.LightDeviationUD.ToString();
            txtHeadLightDeviationLR.Text = GlobalVariables.TestVehicle.LightDeviationLR.ToString();

            txtNearLightDeviationUD.Text = GlobalVariables.TestVehicle.NearLightDeviationUD.ToString();
            txtNearLightDeviationLR.Text = GlobalVariables.TestVehicle.NearLightDeviationLR.ToString();
            txtLongRangeNearLightIntensity.Text = GlobalVariables.TestVehicle.LongRangeNearLightIntensity.ToString();

            if (GlobalVariables.TestVehicle.VoltageDrop1 == null)
                GlobalVariables.TestVehicle.VoltageDrop1 = 0;
            txtVoltageDrop.Text = GlobalVariables.TestVehicle.VoltageDrop.ToString();
            txtVoltageDrop1.Text = GlobalVariables.TestVehicle.VoltageDrop1.ToString();
            txtOverCurrent.Text = GlobalVariables.TestVehicle.OverCurrent.ToString();
            txtAxleTorqueFront.Text = GlobalVariables.TestVehicle.AxleTorqueFront.ToString();
            txtAxleTorqueRear.Text = GlobalVariables.TestVehicle.AxleTorqueRear.ToString();
            txtAxleTorqueFront2.Text = GlobalVariables.TestVehicle.AxleTorqueFront.ToString();
            txtAxleTorqueRear2.Text = GlobalVariables.TestVehicle.AxleTorqueRear.ToString();
            txtWhistle.Text = GlobalVariables.TestVehicle.Whistle.ToString();
            txtNoise.Text = GlobalVariables.TestVehicle.Noise.ToString();
            txtRealSpeed2.Text = txtRealSpeed.Text = GlobalVariables.TestVehicle.RealSpeed.ToString();

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
            txtWhistle.BackColor = CheckColor(GlobalVariables.TestVehicle.Whistle, GlobalVariables.SelectedBrand.WhistleMin, GlobalVariables.SelectedBrand.WhistleMax);
            txtNoise.BackColor = CheckColor(GlobalVariables.TestVehicle.Noise, GlobalVariables.SelectedBrand.NoiseMin, GlobalVariables.SelectedBrand.NoiseMax);

            txtLongRangeHeadLightIntensity.BackColor = CheckColor(GlobalVariables.TestVehicle.LongRangeLightIntensity, GlobalVariables.SelectedBrand.LongRangeLightIntensityMin, GlobalVariables.SelectedBrand.LongRangeLightIntensityMax);
            txtHeadLightDeviationUD.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.LightDeviationUD, GlobalVariables.SelectedBrand.LightDeviationUpMin, GlobalVariables.SelectedBrand.LightDeviationUpMax, GlobalVariables.SelectedBrand.LightDeviationDownMin, GlobalVariables.SelectedBrand.LightDeviationDownMax, GlobalVariables.SelectedBrand.LightDeviationUDMin, GlobalVariables.SelectedBrand.LightDeviationUDMax);
            txtHeadLightDeviationLR.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.LightDeviationLR, GlobalVariables.SelectedBrand.LightDeviationLeftMin, GlobalVariables.SelectedBrand.LightDeviationLeftMax, GlobalVariables.SelectedBrand.LightDeviationRightMin, GlobalVariables.SelectedBrand.LightDeviationRightMax, GlobalVariables.SelectedBrand.LightDeviationLRMin, GlobalVariables.SelectedBrand.LightDeviationLRMax);


            txtLongRangeNearLightIntensity.BackColor = CheckColor(GlobalVariables.TestVehicle.LongRangeNearLightIntensity, GlobalVariables.SelectedBrand.LongRangeNearLightIntensityMin, GlobalVariables.SelectedBrand.LongRangeNearLightIntensityMax);
            txtNearLightDeviationUD.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.NearLightDeviationUD, GlobalVariables.SelectedBrand.NearLightDeviationUpMin, GlobalVariables.SelectedBrand.NearLightDeviationUpMax, GlobalVariables.SelectedBrand.NearLightDeviationDownMin, GlobalVariables.SelectedBrand.NearLightDeviationDownMax, GlobalVariables.SelectedBrand.NearLightDeviationUDMin, GlobalVariables.SelectedBrand.NearLightDeviationUDMax);
            txtNearLightDeviationLR.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.NearLightDeviationLR, GlobalVariables.SelectedBrand.NearLightDeviationLeftMin, GlobalVariables.SelectedBrand.NearLightDeviationLeftMax, GlobalVariables.SelectedBrand.NearLightDeviationRightMin, GlobalVariables.SelectedBrand.NearLightDeviationRightMax, GlobalVariables.SelectedBrand.NearLightDeviationLRMin, GlobalVariables.SelectedBrand.NearLightDeviationLRMax);

            SetVisibleAccordingToVehicleType();
        }
        private void SetVisibleAccordingToVehicleType()
        {
            if (GlobalVariables.IsElectricMotorbike)
            {
                ElectricTab.PageVisible = true;
                GasTab.PageVisible = false;
            }
            else
            {
                ElectricTab.PageVisible = false ;
                GasTab.PageVisible = true;
            }
        }
        private void txtWhistle_TextChanged(object sender, EventArgs e)
        {
            float val;
            if (float.TryParse(txtWhistle.Text, out val))
            {
                GlobalVariables.TestVehicle.Whistle = val;
            }
            else
            {
                GlobalVariables.TestVehicle.Whistle = 0;
            }
            txtWhistle.BackColor = CheckColor(GlobalVariables.TestVehicle.Whistle, GlobalVariables.SelectedBrand.WhistleMin, GlobalVariables.SelectedBrand.WhistleMax);
        }

        private void txtNoise_TextChanged(object sender, EventArgs e)
        {
            float val;
            if (float.TryParse(txtNoise.Text, out val))
            {
                GlobalVariables.TestVehicle.Noise = val;
            }
            else
            {
                GlobalVariables.TestVehicle.Noise = 0;
            }
            txtNoise.BackColor = CheckColor(GlobalVariables.TestVehicle.Noise, GlobalVariables.SelectedBrand.NoiseMin, GlobalVariables.SelectedBrand.NoiseMax);
        }


        private void txtLongRangeHeadLightIntensity_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.LongRangeLightIntensity = string.IsNullOrEmpty(txtLongRangeHeadLightIntensity.Text) ? 0 : float.Parse(txtLongRangeHeadLightIntensity.Text);

            txtLongRangeHeadLightIntensity.BackColor = CheckColor(GlobalVariables.TestVehicle.LongRangeLightIntensity, GlobalVariables.SelectedBrand.LongRangeLightIntensityMin, GlobalVariables.SelectedBrand.LongRangeLightIntensityMax);
            GlobalVariables.OnLightDataChanged?.Invoke();
        }

        private void txtHeadLightDeviationUD_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.LightDeviationUD = string.IsNullOrEmpty(txtHeadLightDeviationUD.Text) ? 0 : float.Parse(txtHeadLightDeviationUD.Text);
            txtHeadLightDeviationUD.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.LightDeviationUD, GlobalVariables.SelectedBrand.LightDeviationUpMin, GlobalVariables.SelectedBrand.LightDeviationUpMax, GlobalVariables.SelectedBrand.LightDeviationDownMin, GlobalVariables.SelectedBrand.LightDeviationDownMax, GlobalVariables.SelectedBrand.LightDeviationUDMin, GlobalVariables.SelectedBrand.LightDeviationUDMax);
            GlobalVariables.OnLightDataChanged?.Invoke();
        }

        private void txtHeadLightDeviationLR_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.LightDeviationLR = string.IsNullOrEmpty(txtHeadLightDeviationLR.Text) ? 0 : float.Parse(txtHeadLightDeviationLR.Text);

            txtHeadLightDeviationLR.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.LightDeviationLR, GlobalVariables.SelectedBrand.LightDeviationLeftMin, GlobalVariables.SelectedBrand.LightDeviationLeftMax, GlobalVariables.SelectedBrand.LightDeviationRightMin, GlobalVariables.SelectedBrand.LightDeviationRightMax, GlobalVariables.SelectedBrand.LightDeviationLRMin, GlobalVariables.SelectedBrand.LightDeviationLRMax);
            GlobalVariables.OnLightDataChanged?.Invoke();
        }


        private void txtLongRangeNearLightIntensity_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.LongRangeNearLightIntensity = string.IsNullOrEmpty(txtLongRangeNearLightIntensity.Text) ? 0 : float.Parse(txtLongRangeNearLightIntensity.Text);

            txtLongRangeNearLightIntensity.BackColor = CheckColor(GlobalVariables.TestVehicle.LongRangeNearLightIntensity, GlobalVariables.SelectedBrand.LongRangeNearLightIntensityMin, GlobalVariables.SelectedBrand.LongRangeNearLightIntensityMax);
            GlobalVariables.OnLightDataChanged?.Invoke();
        }

        private void txtNearLightDeviationUD_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.NearLightDeviationUD = string.IsNullOrEmpty(txtNearLightDeviationUD.Text) ? 0 : float.Parse(txtNearLightDeviationUD.Text);
            txtNearLightDeviationUD.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.NearLightDeviationUD, GlobalVariables.SelectedBrand.NearLightDeviationUpMin, GlobalVariables.SelectedBrand.NearLightDeviationUpMax, GlobalVariables.SelectedBrand.NearLightDeviationDownMin, GlobalVariables.SelectedBrand.NearLightDeviationDownMax, GlobalVariables.SelectedBrand.NearLightDeviationUDMin, GlobalVariables.SelectedBrand.NearLightDeviationUDMax);
            GlobalVariables.OnLightDataChanged?.Invoke();
        }

        private void txtNearLightDeviationLR_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.NearLightDeviationLR = string.IsNullOrEmpty(txtNearLightDeviationLR.Text) ? 0 : float.Parse(txtNearLightDeviationLR.Text);

            txtNearLightDeviationLR.BackColor = CheckColorDeviation(GlobalVariables.TestVehicle.NearLightDeviationLR, GlobalVariables.SelectedBrand.NearLightDeviationLeftMin, GlobalVariables.SelectedBrand.NearLightDeviationLeftMax, GlobalVariables.SelectedBrand.NearLightDeviationRightMin, GlobalVariables.SelectedBrand.NearLightDeviationRightMax, GlobalVariables.SelectedBrand.NearLightDeviationLRMin, GlobalVariables.SelectedBrand.NearLightDeviationLRMax);
            GlobalVariables.OnLightDataChanged?.Invoke();
        }


        private void txtVoltageDrop_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.VoltageDrop = string.IsNullOrEmpty(txtVoltageDrop.Text) ? 0 : float.Parse(txtVoltageDrop.Text);
        }
        private void txtVoltageDrop1_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.VoltageDrop1 = string.IsNullOrEmpty(txtVoltageDrop1.Text) ? 0 : float.Parse(txtVoltageDrop1.Text);
        }
        private void txtOverCurrent_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.OverCurrent = string.IsNullOrEmpty(txtOverCurrent.Text) ? 0 : float.Parse(txtOverCurrent.Text);
        }
        private void txtAxleTorqueFront_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.AxleTorqueFront = string.IsNullOrEmpty(txtAxleTorqueFront.Text) ? 0 : float.Parse(txtAxleTorqueFront.Text);
        }
        private void txtAxleTorqueRear_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.AxleTorqueRear = string.IsNullOrEmpty(txtAxleTorqueRear.Text) ? 0 : float.Parse(txtAxleTorqueRear.Text);
        }
        private void txtAxleTorqueFront2_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.AxleTorqueFront = string.IsNullOrEmpty(txtAxleTorqueFront2.Text) ? 0 : float.Parse(txtAxleTorqueFront2.Text);
        }
        private void txtAxleTorqueRear2_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.AxleTorqueRear = string.IsNullOrEmpty(txtAxleTorqueRear2.Text) ? 0 : float.Parse(txtAxleTorqueRear2.Text);
        }
        private void txtHC_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.HC = string.IsNullOrEmpty(txtHc.Text) ? 0 : float.Parse(txtHc.Text);
            txtHc.BackColor = CheckColor(GlobalVariables.TestVehicle.HC, GlobalVariables.SelectedBrand.HCMin, GlobalVariables.SelectedBrand.HCMax);

        }
        private void txtCO_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.CO = string.IsNullOrEmpty(txtCO.Text) ? 0 : float.Parse(txtCO.Text);
            txtCO.BackColor = CheckColor(GlobalVariables.TestVehicle.CO, GlobalVariables.SelectedBrand.COMin, GlobalVariables.SelectedBrand.COMax);

        }
        private void txtCO2_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.CO2 = string.IsNullOrEmpty(txtCO2.Text) ? 0 : float.Parse(txtCO2.Text);
        }
        private void txtO2_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.O2 = string.IsNullOrEmpty(txtO2.Text) ? 0 : float.Parse(txtO2.Text);
        }
        private void txtNO_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.NO = string.IsNullOrEmpty(txtNO.Text) ? 0 : float.Parse(txtNO.Text);
        }
        private void txtRpm_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.RPM = string.IsNullOrEmpty(txtRpm.Text) ? 0 : float.Parse(txtRpm.Text);
        }
        private void txtOilTemperature_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.OilTemperature = string.IsNullOrEmpty(txtOilTemperature.Text) ? 0 : float.Parse(txtOilTemperature.Text);
        }
        private void NoiseAndLightsUC_Load(object sender, EventArgs e)
        {
            RegisterTextBoxEvents(this);
            btnStartHigh.Visible = btnStopHigh.Visible = btnStartLow.Visible = btnStopLow.Visible = RS232Manager.UsingMQD6A;
            SetVisibleAccordingToVehicleType();
            lblLongRangeNearLightIntensity.Visible = txtLongRangeNearLightIntensity.Visible = RS232Manager.ShowLowBeamLightIntensity;
            lblNearLR.Visible = txtNearLightDeviationLR.Visible = RS232Manager.ShowLowBeamLightDeviationLR;

            if (!RS232Manager.ShowTorqueCheck)
            {
                label12.Visible = txtAxleTorqueFront.Visible = false;
                label5.Visible = txtAxleTorqueRear.Visible = false;
                label17.Visible = txtAxleTorqueFront2.Visible = false;
                label18.Visible = txtAxleTorqueRear2.Visible = false;

                tableLayoutPanel1.RowStyles[2] = new RowStyle(SizeType.Absolute, 0F);
                tableLayoutPanel1.RowStyles[3] = new RowStyle(SizeType.Absolute, 0F);
                tableLayoutPanel2.RowStyles[7] = new RowStyle(SizeType.Absolute, 0F);
                tableLayoutPanel2.RowStyles[8] = new RowStyle(SizeType.Absolute, 0F);
            }
        }

        private void RegisterTextBoxEvents(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.Enter += textBox_Enter;
                    ctrl.MouseUp += textBox_MouseUp;
                    ctrl.KeyPress += textBox_KeyPress;
                }
                else if (ctrl.HasChildren)
                {
                    RegisterTextBoxEvents(ctrl);
                }
            }
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

        private void btnNoise_Click(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.Noise = OPCManager.MaxNoise;
            OPCManager.ResetMaxNoise();
            txtNoise.Text = GlobalVariables.TestVehicle.Noise.ToString("F1");
        }

        private void btnWhistle_Click(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.Whistle = OPCManager.MaxNoise;
            OPCManager.ResetMaxNoise();
            txtWhistle.Text = GlobalVariables.TestVehicle.Whistle.ToString("F1");
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

        private void textRealSpeed_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.RealSpeed = string.IsNullOrEmpty(txtRealSpeed.Text) ? 0 : float.Parse(txtRealSpeed.Text);
        }
        private void textRealSpeed2_TextChanged(object sender, EventArgs e)
        {
            GlobalVariables.TestVehicle.RealSpeed = string.IsNullOrEmpty(txtRealSpeed2.Text) ? 0 : float.Parse(txtRealSpeed2.Text);
        }
    }
}
