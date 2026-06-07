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
    public partial class AutoFontLabelUC: Label
    {
        public AutoFontLabelUC()
        {
            this.AutoSize = false;
            this.TextAlign = ContentAlignment.MiddleCenter;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustFont();
        }

        private void AdjustFont()
        {
            if (string.IsNullOrEmpty(this.Text))
                return;

            float fontSize = 100; // Start from a large font size
            Font testFont = new Font(this.Font.FontFamily, fontSize, this.Font.Style);

            using (Graphics g = this.CreateGraphics())
            {
                SizeF textSize = g.MeasureString(this.Text, testFont);

                // Shrink font size until it fits
                while ((textSize.Width > this.Width || textSize.Height > this.Height) && fontSize > 1)
                {
                    fontSize -= 1;
                    testFont = new Font(this.Font.FontFamily, fontSize, this.Font.Style);
                    textSize = g.MeasureString(this.Text, testFont);
                }
            }

            this.Font = new Font(this.Font.FontFamily, fontSize, this.Font.Style);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            AdjustFont();
        }
    }
}
