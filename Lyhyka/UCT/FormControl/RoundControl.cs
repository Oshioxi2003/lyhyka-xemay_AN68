using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ReStart.FormControl
{
    public partial class RoundControl : UserControl
    {

        private int _radius = 10;
        public int Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
                Invalidate();
            }
        }

        private string _key = "Test";
        public string Key
        {
            get { return _key; }
            set
            {
                _key = value;
                Invalidate();
            }
        }

        private string _value = "Test";
        public string Value
        {
            get { return _value; }
            set
            {
                _value = value;
                Invalidate();
            }
        }


        private SolidBrush _backgroundBrush = new SolidBrush(SystemColors.Control);
        private Color _backgroundColor = SystemColors.Control;
        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundBrush = new SolidBrush(_backgroundColor = value);
                Invalidate();
            }
        }

        private Color _borderColor = SystemColors.Control;
        private Pen _borderPen = new Pen(ControlPaint.Light(SystemColors.Control, 0.0f), 0);
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                _borderPen = new Pen(ControlPaint.Light(_borderColor, 0.0f), _borderWidth);
                Invalidate();
            }
        }

        private float _borderWidth = 1.0f;
        public float BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                _borderWidth = value;
                _borderPen = new Pen(ControlPaint.Light(_borderColor, 0.0f), _borderWidth);
                Invalidate();
            }
        }

        public RoundControl()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            drawBorder(g);
            drawBackground(g);
            drawKey(g);
            drawValue(g);
        }

        private void drawBorder(Graphics g) =>
            g.DrawRoundedRectangle(_borderPen, 5, 0, Width - 10, Height, _radius);

        private void drawBackground(Graphics g) =>
            g.FillRoundedRectangle(_backgroundBrush, 5, 0, Width - 10, Height, _radius);


        System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
        System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 11);
        System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        int padding = 15;
        private void drawKey(Graphics g)
        {
            float width = ((float)this.ClientRectangle.Width);
            float height = ((float)this.ClientRectangle.Height);

            RectangleF drawRect = new RectangleF(padding, 0, width, height);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Near;
            drawFormat.LineAlignment = StringAlignment.Center;

            g.DrawString(_key, drawFont, drawBrush, drawRect, drawFormat);
        }
        private void drawValue(Graphics g)
        {
            float width = ((float)this.ClientRectangle.Width);
            float height = ((float)this.ClientRectangle.Height);

            RectangleF drawRect = new RectangleF(0, 0, width - padding, height);

            // Set format of string.
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Far;
            drawFormat.LineAlignment = StringAlignment.Center;

            g.DrawString(_value, drawFont, drawBrush, drawRect, drawFormat);
        }
    }
}
