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
    public partial class AvatarControl : UserControl
    {
        public AvatarControl()
        {
            InitializeComponent();
        }
        private int _fontSize = 36;
        public int FontSize
        {
            get { return _fontSize; }
            set
            {
                _fontSize = value;
                lblName.Font = new Font("Microsoft Sans Serif", value, FontStyle.Regular);
                Invalidate(); 
            }
        }
        private Color _backColor1;
        public Color BackColor1
        {
            get { return _backColor1; }
            set
            {
                _backColor1 = value;
                lblName.BackColor = value;
                Invalidate();
            }
        }
        private void AvatarControl_Load(object sender, EventArgs e)
        {
            lblName.ForeColor = Color.FromArgb(238,47,36);
        }
        public void SetName(string fullName)
        {
            string firstChars = fullName[0].ToString();
            var nameArr = fullName.Split(new char[] { ' ' });
            if(nameArr.Length>1)
            {
                firstChars+= nameArr[1][0].ToString();
            }
            lblName.Text = firstChars.ToUpper();
        }
    }
}
