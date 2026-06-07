namespace Lyhyka.UCT
{
    partial class SwitchBrakeUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tlpBrake = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBrakeTop = new System.Windows.Forms.TableLayoutPanel();
            this.switchUC2 = new Lyhyka.UCT.SwitchUC();
            this.switchUC1 = new Lyhyka.UCT.SwitchUC();
            this.tlpBrakeBottom = new System.Windows.Forms.TableLayoutPanel();
            this.switchUC3 = new Lyhyka.UCT.SwitchUC();
            this.tlpBrake.SuspendLayout();
            this.tlpBrakeTop.SuspendLayout();
            this.tlpBrakeBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpBrake
            // 
            this.tlpBrake.ColumnCount = 1;
            this.tlpBrake.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBrake.Controls.Add(this.tlpBrakeBottom, 0, 1);
            this.tlpBrake.Controls.Add(this.tlpBrakeTop, 0, 0);
            this.tlpBrake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBrake.Location = new System.Drawing.Point(0, 0);
            this.tlpBrake.Name = "tlpBrake";
            this.tlpBrake.RowCount = 2;
            this.tlpBrake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBrake.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBrake.Size = new System.Drawing.Size(727, 373);
            this.tlpBrake.TabIndex = 12;
            // 
            // tlpBrakeTop
            // 
            this.tlpBrakeTop.ColumnCount = 2;
            this.tlpBrakeTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBrakeTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBrakeTop.Controls.Add(this.switchUC2, 1, 0);
            this.tlpBrakeTop.Controls.Add(this.switchUC1, 0, 0);
            this.tlpBrakeTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBrakeTop.Location = new System.Drawing.Point(3, 3);
            this.tlpBrakeTop.Name = "tlpBrakeTop";
            this.tlpBrakeTop.RowCount = 1;
            this.tlpBrakeTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBrakeTop.Size = new System.Drawing.Size(721, 180);
            this.tlpBrakeTop.TabIndex = 12;
            // 
            // switchUC2
            // 
            this.switchUC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchUC2.Location = new System.Drawing.Point(363, 3);
            this.switchUC2.Name = "switchUC2";
            this.switchUC2.Offtext = "Nhả";
            this.switchUC2.Ontext = "Kẹp";
            this.switchUC2.Padding = new System.Windows.Forms.Padding(20);
            this.switchUC2.Size = new System.Drawing.Size(355, 174);
            this.switchUC2.TabIndex = 1;
            this.switchUC2.Title = "NẸP SAU";
            // 
            // switchUC1
            // 
            this.switchUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchUC1.Location = new System.Drawing.Point(3, 3);
            this.switchUC1.Name = "switchUC1";
            this.switchUC1.Offtext = "Nhả";
            this.switchUC1.Ontext = "Kẹp";
            this.switchUC1.Padding = new System.Windows.Forms.Padding(20);
            this.switchUC1.Size = new System.Drawing.Size(354, 174);
            this.switchUC1.TabIndex = 0;
            this.switchUC1.Title = "NẸP TRƯỚC";
            // 
            // tlpBrakeBottom
            // 
            this.tlpBrakeBottom.ColumnCount = 3;
            this.tlpBrakeBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBrakeBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBrakeBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBrakeBottom.Controls.Add(this.switchUC3, 1, 0);
            this.tlpBrakeBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBrakeBottom.Location = new System.Drawing.Point(3, 189);
            this.tlpBrakeBottom.Name = "tlpBrakeBottom";
            this.tlpBrakeBottom.RowCount = 1;
            this.tlpBrakeBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBrakeBottom.Size = new System.Drawing.Size(721, 181);
            this.tlpBrakeBottom.TabIndex = 13;
            // 
            // switchUC3
            // 
            this.switchUC3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchUC3.Location = new System.Drawing.Point(183, 3);
            this.switchUC3.Name = "switchUC3";
            this.switchUC3.Offtext = "Dừng";
            this.switchUC3.Ontext = "Chạy";
            this.switchUC3.Padding = new System.Windows.Forms.Padding(20);
            this.switchUC3.Size = new System.Drawing.Size(354, 175);
            this.switchUC3.TabIndex = 1;
            this.switchUC3.Title = "MÔ TƠ RU LƠ";
            // 
            // SwitchBrakeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpBrake);
            this.Name = "SwitchBrakeUC";
            this.Size = new System.Drawing.Size(727, 373);
            this.tlpBrake.ResumeLayout(false);
            this.tlpBrakeTop.ResumeLayout(false);
            this.tlpBrakeBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpBrake;
        private System.Windows.Forms.TableLayoutPanel tlpBrakeTop;
        private SwitchUC switchUC2;
        private SwitchUC switchUC1;
        private System.Windows.Forms.TableLayoutPanel tlpBrakeBottom;
        private SwitchUC switchUC3;
    }
}
