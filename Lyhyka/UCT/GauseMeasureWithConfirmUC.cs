using DevExpress.XtraGauges.Core.Model;
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

namespace Lyhyka.UCT
{
    public partial class GauseMeasureWithConfirmUC : UserControl
    {
        int roundingNumber = 1;
        public GauseMeasureWithConfirmUC(string buttonName)
        {
            InitializeComponent();
            titleAndValueUC1.Value = "0";
            titleAndValueUC2.Value = "0";
            switch (buttonName.ToLower())
            {
                case MenuConstants.Speed:
                    roundingNumber = 1;
                    headerLabelUC.Title = "ĐO TỐC ĐỘ";
                    titleAndValueUC1.Title = "Tốc độ(Km/h)";
                    titleAndValueUC2.Title = "Thời gian(s)";
                    SetRange(0, GlobalVariables.SelectedBrand.SpeedMin, GlobalVariables.SelectedBrand.SpeedMax);
                    break;
                case MenuConstants.BrakeForce:
                    roundingNumber = 0;
                    headerLabelUC.Title = "ĐO LỰC PHANH";
                    titleAndValueUC1.Title = "Lực phanh trước(N)";
                    titleAndValueUC2.Title = "Lực phanh sau(N)";
                    SetRange(0, GlobalVariables.SelectedBrand.BrakeForceFrontMin, GlobalVariables.SelectedBrand.BrakeForceFrontMax);
                    break;
                case MenuConstants.Weight:
                    roundingNumber = 0;
                    headerLabelUC.Title = "ĐO TRỌNG LƯỢNG";
                    titleAndValueUC1.Title = "Bánh trước(Kg)";
                    titleAndValueUC2.Title = "Bánh sau(Kg)";
                    SetRange(0, GlobalVariables.SelectedBrand.WeightFrontMin, GlobalVariables.SelectedBrand.WeightFrontMax);
                    break;
            }
        }
        public void UpdateRange(string buttonName)
        {

            switch (buttonName.ToLower())
            {
                case MenuConstants.Speed:
                    SetRange(0, GlobalVariables.SelectedBrand.SpeedMin, GlobalVariables.SelectedBrand.SpeedMax);
                    break;
                case MenuConstants.BrakeForce:
                    SetRange(0, GlobalVariables.SelectedBrand.BrakeForceFrontMin, GlobalVariables.SelectedBrand.BrakeForceFrontMax);
                    break;
                case MenuConstants.Weight:
                    SetRange(0, GlobalVariables.SelectedBrand.WeightFrontMin, GlobalVariables.SelectedBrand.WeightFrontMax);
                    break;
            }
        }
        bool IsLFrontBrakeForce = true;
        public void UpdateBrakeRange(bool isFrontBrakeForce)
        {
            if (IsLFrontBrakeForce == isFrontBrakeForce)
                return;
            SetRange(0, isFrontBrakeForce ? GlobalVariables.SelectedBrand.BrakeForceFrontMin: GlobalVariables.SelectedBrand.BrakeForceRearMin, isFrontBrakeForce ? GlobalVariables.SelectedBrand.BrakeForceFrontMax: GlobalVariables.SelectedBrand.BrakeForceRearMax);
            IsLFrontBrakeForce = isFrontBrakeForce;
        }
        private void SetRange(float min, float middle, float max)
        {
            arcScaleRange1.StartValue = min;
            arcScaleRange1.EndValue = middle;
            arcScaleRange2.StartValue = middle;
            arcScaleRange2.EndValue = max;
            arcScaleRange3.StartValue = max;
            arcScaleRange3.EndValue = 2 * max - middle;
            arcScaleComponent.MaxValue = 2 * max - middle;
        }
        public void SetValue(float value)
        {
            try
            {
                if(value<0)
                {
                    value = 0;
                }    
                this.Invoke((MethodInvoker)(() =>
                {
                    arcScaleComponent.Value = value;
                    lblValue.Text = Math.Round(value, roundingNumber).ToString();
                    foreach (var range in arcScaleComponent.Ranges)
                    {
                        if (value >= range.StartValue && value <= range.EndValue)
                        {
                            var color = ((DevExpress.XtraGauges.Core.Drawing.SolidBrushObject)((DevExpress.XtraGauges.Core.Model.BaseRange)range).AppearanceRange.ContentBrush).Color;

                            lblValue.AppearanceText.TextBrush =
                                 this.lblValue.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#" + color.Name);

                            break;
                        }
                    }
                }));
            }
            catch (Exception)
            {
                // Handle exception if necessary
            }
        }

        public void SetConfirmValue1(float value)
        {
            try
            {
                this.Invoke((MethodInvoker)(() =>
            {
                titleAndValueUC1.Value = value.ToString(roundingNumber==0?"F0":"F1");
            }));
            }
            catch (Exception)
            {
                // Handle exception if necessary
            }
        }
        public void SetConfirmValue2(float value)
        {
            try
            {
                this.Invoke((MethodInvoker)(() =>
            {
                titleAndValueUC2.Value = value.ToString(roundingNumber == 0 ? "F0" : "F1");
            }));
            }
            catch (Exception)
            {
                // Handle exception if necessary
            }
        }
    }
}
