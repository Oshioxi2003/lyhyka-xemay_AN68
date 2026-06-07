namespace Lyhyka.UCT
{
    partial class SwitchSpeedUC
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
            this.tlpSpeed = new System.Windows.Forms.TableLayoutPanel();
            this.switchUC4 = new Lyhyka.UCT.SwitchUC();
            this.switchUC3 = new Lyhyka.UCT.SwitchUC();
            this.switchUC2 = new Lyhyka.UCT.SwitchUC();
            this.switchUC1 = new Lyhyka.UCT.SwitchUC();
            this.tlpSpeed.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSpeed
            // 
            this.tlpSpeed.ColumnCount = 2;
            this.tlpSpeed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSpeed.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSpeed.Controls.Add(this.switchUC4, 1, 1);
            this.tlpSpeed.Controls.Add(this.switchUC3, 0, 1);
            this.tlpSpeed.Controls.Add(this.switchUC2, 1, 0);
            this.tlpSpeed.Controls.Add(this.switchUC1, 0, 0);
            this.tlpSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSpeed.Location = new System.Drawing.Point(0, 0);
            this.tlpSpeed.Name = "tlpSpeed";
            this.tlpSpeed.RowCount = 2;
            this.tlpSpeed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSpeed.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSpeed.Size = new System.Drawing.Size(705, 347);
            this.tlpSpeed.TabIndex = 11;
            // 
            // switchUC4
            // 
            this.switchUC4.BackColor = System.Drawing.Color.White;
            this.switchUC4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchUC4.Location = new System.Drawing.Point(355, 176);
            this.switchUC4.Name = "switchUC4";
            this.switchUC4.Offtext = "Hạ";
            this.switchUC4.Ontext = "Nâng";
            this.switchUC4.Padding = new System.Windows.Forms.Padding(20);
            this.switchUC4.Size = new System.Drawing.Size(347, 168);
            this.switchUC4.TabIndex = 3;
            this.switchUC4.Title = "BỆ ĐỠ";
            // 
            // switchUC3
            // 
            this.switchUC3.BackColor = System.Drawing.Color.White;
            this.switchUC3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchUC3.Location = new System.Drawing.Point(3, 176);
            this.switchUC3.Name = "switchUC3";
            this.switchUC3.Offtext = "Dừng";
            this.switchUC3.Ontext = "Chạy";
            this.switchUC3.Padding = new System.Windows.Forms.Padding(20);
            this.switchUC3.Size = new System.Drawing.Size(346, 168);
            this.switchUC3.TabIndex = 2;
            this.switchUC3.Title = "MÔ TƠ RU LƠ";
            // 
            // switchUC2
            // 
            this.switchUC2.BackColor = System.Drawing.Color.White;
            this.switchUC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchUC2.Location = new System.Drawing.Point(355, 3);
            this.switchUC2.Name = "switchUC2";
            this.switchUC2.Offtext = "Nhả";
            this.switchUC2.Ontext = "Kẹp";
            this.switchUC2.Padding = new System.Windows.Forms.Padding(20);
            this.switchUC2.Size = new System.Drawing.Size(347, 167);
            this.switchUC2.TabIndex = 1;
            this.switchUC2.Title = "NẸP TRƯỚC";
            // 
            // switchUC1
            // 
            this.switchUC1.BackColor = System.Drawing.Color.White;
            this.switchUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchUC1.Location = new System.Drawing.Point(3, 3);
            this.switchUC1.Name = "switchUC1";
            this.switchUC1.Offtext = "Nhả";
            this.switchUC1.Ontext = "Kẹp";
            this.switchUC1.Padding = new System.Windows.Forms.Padding(20);
            this.switchUC1.Size = new System.Drawing.Size(346, 167);
            this.switchUC1.TabIndex = 0;
            this.switchUC1.Title = "NẸP SAU";
            // 
            // SwitchSpeedUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpSpeed);
            this.Name = "SwitchSpeedUC";
            this.Size = new System.Drawing.Size(705, 347);
            this.tlpSpeed.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpSpeed;
        private SwitchUC switchUC4;
        private SwitchUC switchUC3;
        private SwitchUC switchUC2;
        private SwitchUC switchUC1;
    }
}
