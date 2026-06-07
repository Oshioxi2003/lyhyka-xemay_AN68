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
    public partial class WeightUC : UserControl
    {
        public WeightUC()
        {
            InitializeComponent();
        }
        public WeightUC(string title)
        {
            InitializeComponent();
            lblTitle.Text = title;
        }
        public void SetValue(float value)
        {
            arcScaleComponent.Value = value;
            lblValue.Text = value.ToString();
            foreach (var range in arcScaleComponent.Ranges)
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
