using System.Drawing;
using System.Windows.Forms;

namespace ReStart.FormControl
{
    public partial class ProgressBarUserControl : ProgressBar
    {
        public ProgressBarUserControl()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), 2, 2, this.Width, this.Height);

            rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4;
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height - 4;
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(231, 120, 23)), 2, 2, rec.Width, rec.Height);
        }
    }
}
