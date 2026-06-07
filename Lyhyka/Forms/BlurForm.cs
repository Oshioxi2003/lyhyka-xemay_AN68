using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lyhyka.Forms
{
    public partial class BlurForm : Form
    {
        public BlurForm(Form owner)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.Bounds = owner.Bounds;
            this.Owner = owner;
            this.BackColor = Color.Gray;
            this.Opacity = 0.5;
        }
    }
}
