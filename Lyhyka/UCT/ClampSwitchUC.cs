
using DevExpress.Drawing.Internal.Fonts;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace ClampSwitchControlApp
{
    public class ClampSwitchUC : UserControl
    {
        private bool isClamped = false;
        public event EventHandler<bool> StateChanged;

        private Label lblRelease, lblClamp;
        private Panel thumbPanel;
        private Panel trackPanel;
        public ClampSwitchUC()
        { 
            this.BackColor = Color.White;
            thumbPanel = new Panel
            {
                BackColor = Color.Gray,
                Size = new Size(40, 35),
                Location = new Point(10, this.Height/2-10),
                Cursor = Cursors.Hand
            };

            thumbPanel.Paint += (s, e) =>
            {
                var g = e.Graphics;
                var pen = new Pen(Color.White, 3);
                g.DrawLine(pen, 6, 3, 6, 21);
                g.DrawLine(pen, 13, 3, 13, 21);
                g.DrawLine(pen, 20, 3, 20, 21);
            };

            thumbPanel.Click += (s, e) =>
            {
                ToggleState(true); 
            };
            this.Controls.Add(thumbPanel);
            trackPanel = new Panel
            {
                BackColor = Color.LightGray,
                Location = new Point(20, this.Height / 2),
                Size = new Size(this.Width - 30, 10)
            };
            this.Controls.Add(trackPanel);

            // Label Nhả
            lblRelease = new Label
            {
                Text = "Nhả",
                Location = new Point(0, this.Height / 2-55),
                AutoSize = true,
                ForeColor = Color.Black
            };
            this.Controls.Add(lblRelease);

            // Label Kẹp
            lblClamp = new Label
            {
                Text = "Kẹp",
                AutoSize = true,
                Location = new Point(this.Width - 40, this.Height / 2 - 55),
                ForeColor = Color.Black
            };
            this.Controls.Add(lblClamp);

            this.Resize += OnResizeHandler; // Correctly subscribe to the Resize event
        }
        public void Trigger(bool value)
        {
            try
            {
                //value = !value; // Invert the value to match the toggle logic
                if (value != isClamped)
                {
                    this.Invoke((MethodInvoker)(() =>
                    {
                        //thumbPanel.Click
                        ToggleState();
                    }));
                } 
            }
            catch
            {
            }
        }
        public void SetOffText(string offText)
        {
            lblRelease.Text = offText;
        }
        public void SetOnText(string onText)
        {
            lblClamp.Text = onText;
        }
        private void OnResizeHandler(object sender, EventArgs e)
        {
            trackPanel.Size = new Size(this.Width - 30, 10);
            thumbPanel.Location = new Point(isClamped ? this.Width - thumbPanel.Width - 10 : 10, thumbPanel.Location.Y);
            lblClamp.Location = new Point(this.Width - lblClamp.Width - 10, lblClamp.Location.Y);
        }
        bool isRunning  = false;
        private void ToggleState(bool triggerEvent = false)
        { 
            while(isRunning)
            {
                Thread.Sleep(30);
            }
            isRunning = true;
            isClamped = !isClamped;
            int newX = isClamped ? this.Width - thumbPanel.Width - 10 : 10;
            var timer = new Timer()
            {
                Interval = 10
            };
            timer.Tick += (s, e) =>
            {
                int step = (newX - thumbPanel.Left) / 3;
                if (Math.Abs(step) < 1) step = newX > thumbPanel.Left ? 1 : -1;
                thumbPanel.Left += step;

                if (Math.Abs(thumbPanel.Left - newX) <= 1)
                {
                    thumbPanel.Left = newX;
                    timer.Stop();
                    isRunning = false;
                    if (triggerEvent)
                    {
                        // Notify the state change
                        StateChanged?.Invoke(this, isClamped);
                    }    
                }
            };
            timer.Start();

            //StateChanged?.Invoke(this, isClamped);
        }

        public bool IsClamped => isClamped;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ClampSwitchUC
            // 
            this.Name = "ClampSwitchUC";
            //this.Size = new System.Drawing.Size(442, 150);
            this.ResumeLayout(false);

        }

        
    }
}
