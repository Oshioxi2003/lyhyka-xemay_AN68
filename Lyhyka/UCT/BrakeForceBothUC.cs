using DevExpress.XtraGauges.Win.Gauges.Circular;
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
using System.Windows.Media;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lyhyka.UCT
{
    public partial class BrakeForceBothUC : UserControl
    {
        public BrakeForceBothUC()
        {
            InitializeComponent();
        }
        private void BrakeForceBothUC_Load(object sender, EventArgs e)
        {
            SetRange();
        }
        public void SetRange()
        {
            SetRange(0, GlobalVariables.SelectedBrand.BrakeForceFrontMin, GlobalVariables.SelectedBrand.BrakeForceFrontMax);
            SetRange2(0, GlobalVariables.SelectedBrand.BrakeForceRearMin, GlobalVariables.SelectedBrand.BrakeForceRearMax);
        }
        public void SetFrontValue(float value)
        { 
            SetValue(value, arcScaleComponent1, labelComponentFront);
        }
        public void SetRearValue(float value)
        {
            SetValue(value, arcScaleComponent, labelComponentRear);
        }
        public void SetValue(float value, DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleComponent, DevExpress.XtraGauges.Win.Base.LabelComponent label)
        {
            arcScaleComponent.Value = value;
            label.Text = value.ToString("F0");
            foreach (var range in arcScaleComponent.Ranges)
            {
                if (value >= range.StartValue && value <= range.EndValue)
                {
                    var color = ((DevExpress.XtraGauges.Core.Drawing.SolidBrushObject)((DevExpress.XtraGauges.Core.Model.BaseRange)range).AppearanceRange.ContentBrush).Color; 
                    label.AppearanceText.TextBrush  = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#" + color.Name); 
                    break;
                }
            }
        }
        private void SetRange(float min, float middle, float max)
        {
            arcScaleRange1.StartValue = min;
            arcScaleRange1.EndValue = middle;
            arcScaleRange2.StartValue = middle;
            arcScaleRange2.EndValue = max;
            arcScaleRange3.StartValue = max;
            arcScaleRange3.EndValue = 2 * max - middle;
            arcScaleComponent1.MaxValue = 2 * max - middle;
        }
        private void SetRange2(float min, float middle, float max)
        {
            arcScaleRange4.StartValue = min;
            arcScaleRange4.EndValue = middle;
            arcScaleRange5.StartValue = middle;
            arcScaleRange5.EndValue = max;
            arcScaleRange6.StartValue = max;
            arcScaleRange6.EndValue = 2 * max - middle;
            arcScaleComponent.MaxValue = 2 * max - middle;
        }

       
    }
}
