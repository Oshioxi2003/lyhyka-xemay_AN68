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
    public partial class SpeedUC : MeasureBaseUC
    {
        public SpeedUC()
        {
            InitializeComponent(); 
        }
        public void SetValue(float value)
        {
            arcScaleComponent.Value = value;
            lblValue.Text = value.ToString("F0");
            foreach (var range in arcScaleComponent.Ranges)
            {
                if (value >= range.StartValue && value <= range.EndValue)
                {
                    var color = ((DevExpress.XtraGauges.Core.Drawing.SolidBrushObject)((DevExpress.XtraGauges.Core.Model.BaseRange)range).AppearanceRange.ContentBrush).Color;
                    
                    lblValue.AppearanceText.TextBrush =
                         this.lblValue.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#"+ color.Name); 

                    break;
                } 
            }
        }

        private void SpeedUC_Load(object sender, EventArgs e)
        {
            SetRange();
        }
        public void SetRange()
        {
            SetRange(0, GlobalVariables.SelectedBrand.SpeedMin, GlobalVariables.SelectedBrand.SpeedMax);
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
    }
}
