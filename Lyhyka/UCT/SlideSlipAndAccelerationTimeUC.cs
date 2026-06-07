using DevExpress.XtraGauges.Win.Gauges.Linear;
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
    public partial class SlideSlipAndAccelerationTimeUC : UserControl
    {
        public SlideSlipAndAccelerationTimeUC()
        {
            InitializeComponent();
        }
        public void SetValue(float value)
        {
             this.slideSlipUC.SetValue(value);
        }
    }
}
