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
    public partial class HeaderLabelUC : UserControl
    {
        public HeaderLabelUC()
        {
            InitializeComponent();
        }
        private string _title = "ĐO TỐC ĐỘ";
        [Browsable(true)]
        [Category("Custom Properties")]
        [Description("Sets the title of the control.")]
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                lblTitle.Text = value;
            }
        }

        [Browsable(true)]
        [Category("Custom Properties")]
        [Description("Sets the font of the title.")]
        public Font TitleFont
        {
            get => lblTitle.Font;
            set => lblTitle.Font = value;
        }
    }
}
