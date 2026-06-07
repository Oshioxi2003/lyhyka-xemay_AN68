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
    public partial class AutoFontTextBoxUC : TextBox
    {
        public AutoFontTextBoxUC()
        {
            this.Multiline = false;
            this.TextAlign = HorizontalAlignment.Right;
            this.BorderStyle = BorderStyle.FixedSingle;

            this.TextChanged += (s, e) => AdjustFont();
            this.Resize += (s, e) => AdjustFont();
        }

        private void AdjustFont()
        {
            if (this.Parent == null)
                return;

            int maxHeight = this.Parent.ClientSize.Height - this.Margin.Vertical;
            float fontSize = this.Font.Size;
            Font testFont = this.Font;

            using (Graphics g = this.CreateGraphics())
            {
                SizeF textSize = g.MeasureString("Hg", testFont); // Use "Hg" as typical text height reference

                // Increase until just fits
                while (textSize.Height < maxHeight-5 && fontSize < 200)
                {
                    fontSize += 0.5f;
                    testFont = new Font(this.Font.FontFamily, fontSize, this.Font.Style);
                    textSize = g.MeasureString("Hg", testFont);
                }

                // If too tall, shrink down
                while (textSize.Height > maxHeight && fontSize > 4)
                {
                    fontSize -= 0.5f;
                    testFont = new Font(this.Font.FontFamily, fontSize, this.Font.Style);
                    textSize = g.MeasureString("Hg", testFont);
                }
            }

            this.Font = testFont;
        }
    }
}