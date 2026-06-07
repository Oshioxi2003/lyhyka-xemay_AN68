using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lyhyka.UCT
{
    public partial class RoundPanelUC : UserControl
    {
        public RoundPanelUC()
        {
            InitializeComponent();
        }

        private void RoundPanelUC_Load(object sender, EventArgs e)
        {
            MakeRoundedPanel(panel, 20); // Adjust radius as needed
        }
        private void MakeRoundedPanel(Panel panel, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90); // top-left
            path.AddArc(panel.Width - radius, 0, radius, radius, 270, 90); // top-right
            path.AddArc(panel.Width - radius, panel.Height - radius, radius, radius, 0, 90); // bottom-right
            path.AddArc(0, panel.Height - radius, radius, radius, 90, 90); // bottom-left
            path.CloseAllFigures();
            panel.Region = new Region(path);
        }
    }
}
