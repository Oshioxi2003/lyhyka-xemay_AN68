namespace Lyhyka.Forms.Motobikes
{
    partial class FrmCalib
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCalib));
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Brake = new System.Windows.Forms.TabPage();
            this.calibrationUCBrake = new Lyhyka.UCT.CalibrationUC();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.calibrationUCSpeed = new Lyhyka.UCT.CalibrationUC();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.calibrationUCSlideSlip = new Lyhyka.UCT.CalibrationUC();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chkManualSpeedMeasing = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Brake.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.tabControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1292, 844);
            this.panelControl2.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Brake);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(2, 2);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1288, 840);
            this.tabControl1.TabIndex = 0;
            // 
            // Brake
            // 
            this.Brake.Controls.Add(this.calibrationUCBrake);
            this.Brake.Location = new System.Drawing.Point(4, 33);
            this.Brake.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Brake.Name = "Brake";
            this.Brake.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Brake.Size = new System.Drawing.Size(1280, 803);
            this.Brake.TabIndex = 0;
            this.Brake.Text = "Lực phanh";
            this.Brake.UseVisualStyleBackColor = true;
            // 
            // calibrationUCBrake
            // 
            this.calibrationUCBrake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrationUCBrake.Location = new System.Drawing.Point(3, 2);
            this.calibrationUCBrake.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.calibrationUCBrake.Name = "calibrationUCBrake";
            this.calibrationUCBrake.Size = new System.Drawing.Size(1274, 799);
            this.calibrationUCBrake.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.calibrationUCSpeed);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1280, 803);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tốc độ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // calibrationUCSpeed
            // 
            this.calibrationUCSpeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrationUCSpeed.Location = new System.Drawing.Point(3, 2);
            this.calibrationUCSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.calibrationUCSpeed.Name = "calibrationUCSpeed";
            this.calibrationUCSpeed.Size = new System.Drawing.Size(1274, 799);
            this.calibrationUCSpeed.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.calibrationUCSlideSlip);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1280, 803);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Trùng vết";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // calibrationUCSlideSlip
            // 
            this.calibrationUCSlideSlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrationUCSlideSlip.Location = new System.Drawing.Point(0, 0);
            this.calibrationUCSlideSlip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.calibrationUCSlideSlip.Name = "calibrationUCSlideSlip";
            this.calibrationUCSlideSlip.Size = new System.Drawing.Size(1280, 803);
            this.calibrationUCSlideSlip.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkManualSpeedMeasing);
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1280, 803);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Cấu hình khác";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chkManualSpeedMeasing
            // 
            this.chkManualSpeedMeasing.AutoSize = true;
            this.chkManualSpeedMeasing.Location = new System.Drawing.Point(47, 53);
            this.chkManualSpeedMeasing.Name = "chkManualSpeedMeasing";
            this.chkManualSpeedMeasing.Size = new System.Drawing.Size(283, 28);
            this.chkManualSpeedMeasing.TabIndex = 0;
            this.chkManualSpeedMeasing.Text = "Cấu hình đo tốc độ bằng tay";
            this.chkManualSpeedMeasing.UseVisualStyleBackColor = true;
            this.chkManualSpeedMeasing.CheckedChanged += new System.EventHandler(this.chkManualSpeedMeasing_CheckedChanged);
            // 
            // FrmCalib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 844);
            this.Controls.Add(this.panelControl2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmCalib";
            this.Text = "HIỆU CHUẨN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCalib_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.Brake.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Brake;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private UCT.CalibrationUC calibrationUCBrake;
        private UCT.CalibrationUC calibrationUCSpeed;
        private UCT.CalibrationUC calibrationUCSlideSlip;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkManualSpeedMeasing;
    }
}