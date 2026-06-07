using DevExpress.XtraGauges.Win.Gauges.Linear;
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
using static DevExpress.Utils.Diagnostics.GUIResources;

namespace Lyhyka.UCT
{
    public partial class SlideSlipWithConfirmUC : UserControl
    {
        public SlideSlipWithConfirmUC()
        {
            InitializeComponent(); 
        }
        private void SlideSlipWithConfirmUC_Load(object sender, EventArgs e)
        {
            SetRange(GlobalVariables.SelectedBrand.SlideSlipMin, GlobalVariables.SelectedBrand.SlideSlipMax);
        }
        private void SetRange(float min, float max)
        {

            linearScaleComponent.MinValue =linearScaleComponent.Ranges[0].StartValue = min - Constants.SlideSlipDelta;
            linearScaleComponent.Ranges[0].EndValue = min; 
            linearScaleComponent.Ranges[1].StartValue = min;
            linearScaleComponent.Ranges[1].EndValue = max;
            linearScaleComponent.Ranges[2].StartValue = max;
            linearScaleComponent.MaxValue = linearScaleComponent.Ranges[2].EndValue = max + Constants.SlideSlipDelta;
        }
        public void SetValue(float value)
        {
            try
            {
                this.Invoke((MethodInvoker)(() =>
                   {
                       linearScaleComponent.Value = value;
                       lblValue.Text =  value.ToString();
                       foreach (var range in linearScaleComponent.Ranges)
                       {
                           if (value >= range.StartValue && value <= range.EndValue)
                           {
                               lblValue.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#" + ((DevExpress.XtraGauges.Core.Drawing.SolidBrushObject)((DevExpress.XtraGauges.Core.Model.BaseRange)range).AppearanceRange.ContentBrush).Color.Name);
                               break;
                           }
                       }
                   }));
            }
            catch (Exception)
            {
                 
            }
          
        }
        public void SetConfirmValue1(float value)
        {
            try
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    txtValue.Text = value.ToString();
                }));
            }
            catch (Exception)
            {

            }
        }

      
    }
}
