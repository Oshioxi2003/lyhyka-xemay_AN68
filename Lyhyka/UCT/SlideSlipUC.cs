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

namespace Lyhyka.UCT
{
    public partial class SlideSlipUC : MeasureBaseUC
    {
        public SlideSlipUC()
        {
            InitializeComponent();
        }
        private void SlideSlipUC_Load(object sender, EventArgs e)
        {
            SetRange(GlobalVariables.SelectedBrand.SlideSlipMin, GlobalVariables.SelectedBrand.SlideSlipMax);
        }

        private void SetRange(float min, float max)
        {
            linearScaleComponent.MinValue = linearScaleComponent.Ranges[0].StartValue = min - Constants.SlideSlipDelta;
            linearScaleComponent.Ranges[0].EndValue = min;
            linearScaleComponent.Ranges[1].StartValue = min;
            linearScaleComponent.Ranges[1].EndValue = max;
            linearScaleComponent.Ranges[2].StartValue = max;
            linearScaleComponent.MaxValue = linearScaleComponent.Ranges[2].EndValue = max + Constants.SlideSlipDelta;
        }
        public void SetValue(float value)
        {
            linearScaleComponent.Value = value;
            lblValue.Text = value>=0 ?"+"+ value.ToString(): value.ToString();
            foreach (var range in linearScaleComponent.Ranges)
            {
                if (value >= range.StartValue && value <= range.EndValue)
                {
                    lblValue.ForeColor = ((DevExpress.XtraGauges.Core.Drawing.SolidBrushObject)((DevExpress.XtraGauges.Core.Model.BaseRange)range).AppearanceRange.ContentBrush).Color;
                    break;
                }
            }
        }

       
    }
}
