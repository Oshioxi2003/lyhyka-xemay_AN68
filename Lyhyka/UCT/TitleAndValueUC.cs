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
    public partial class TitleAndValueUC : UserControl
    {
        public TitleAndValueUC()
        {
            InitializeComponent();
        }
        private string _title = "";
        [Browsable(true)]
        [Category("Custom Properties")]
        [Description("Sets the title of the control.")]
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                txtTitle.Text = value;
            }
        }

        private string _value = "0";
        [Browsable(true)]
        [Category("Custom Properties")]
        [Description("Sets the value of the control.")]
        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                txtValue.Text = value;
            }
        }
    }
}
