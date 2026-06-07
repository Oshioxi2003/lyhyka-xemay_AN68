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
    public partial class HeaderUC : UserControl
    {
        public HeaderUC()
        {
            InitializeComponent();
        }
        private void label_SizeChanged(object sender, EventArgs e)
        {
            //LabelHelper.AdjustLabelFontSize((Label)sender);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
