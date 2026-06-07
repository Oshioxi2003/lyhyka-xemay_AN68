using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReStart.FormControl
{
    public partial class AnalystControl : UserControl
    {
        public AnalystControl()
        {
            InitializeComponent();
        }
        private string _title = "Total Completed";
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                Invalidate();
                lblTitle.Text = value;
            }
        }
        private int _total1 = 0;
        public int Total1
        {
            get { return _total1; }
            set
            {
                _total1 = value;
                Invalidate();
                lblTotalCompleted1.Text = value.ToString();
            }
        }
        private int _total2 = 0;
        public int Total2
        {
            get { return _total2; }
            set
            {
                _total2 = value;
                Invalidate();
                lblTotalCompleted2.Text = "/"+ value.ToString();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        { 
            base.OnPaint(e);    
        }
    }
}
