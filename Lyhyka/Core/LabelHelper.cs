using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lyhyka.Core
{
    public class LabelHelper
    {
        public static void AdjustLabelFontSize(Label label)
        {
            if (string.IsNullOrEmpty(label.Text)) return;

            float fontSize = 10;  // start small
            SizeF textSize;
            Graphics g = label.CreateGraphics();

            // Increase font size until text is too big for label
            do
            {
                fontSize += 1;
                using (Font testFont = new Font(label.Font.FontFamily, fontSize, label.Font.Style))
                {
                    textSize = g.MeasureString(label.Text, testFont);
                }
            } while (textSize.Width < label.Width && textSize.Height < label.Height);

            // Step back one size to fit
            fontSize -= 1;
            label.Font = new Font(label.Font.FontFamily, fontSize, label.Font.Style);
        }
    }
}
