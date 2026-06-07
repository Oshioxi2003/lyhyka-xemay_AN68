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
    public partial class WeightBothUC : UserControl
    {
        public WeightBothUC()
        {
            InitializeComponent();
        }
        private void WeightBothUC_Load(object sender, EventArgs e)
        {
            SetRange();
        }
        public void SetRange()
        {
            SetRange(0, GlobalVariables.SelectedBrand.WeightFrontMin, GlobalVariables.SelectedBrand.WeightFrontMax);
            SetRange2(0, GlobalVariables.SelectedBrand.WeightRearMin, GlobalVariables.SelectedBrand.WeightRearMax);
        }
        public void SetFrontValue(float value)
        {
            //weightFrontUC.SetValue(value);
        }
        public void SetRearValue(float value)
        {
            //weightRearUC.SetValue(value);
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
