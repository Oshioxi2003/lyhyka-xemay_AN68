namespace Lyhyka
{
    partial class FrmMotobikeDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMotobikeDashboard));
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.headerUC1 = new Lyhyka.UCT.HeaderUC();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.weightBothUC = new Lyhyka.UCT.WeightBothUC();
            this.speedUC = new Lyhyka.UCT.SpeedUC();
            this.brakeForceBothUC = new Lyhyka.UCT.BrakeForceBothUC();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.noiseAndLightsUC = new Lyhyka.UCT.NoiseAndLightsUC();
            this.slideSlipAndAccelerationTimeUC = new Lyhyka.UCT.SlideSlipAndAccelerationTimeUC();
            this.motobikeInfoDashboardUC = new Lyhyka.UCT.MotobikeInfoDashboardUC();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.headerUC1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1552, 84);
            this.pnlHeader.TabIndex = 1;
            // 
            // headerUC1
            // 
            this.headerUC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.headerUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerUC1.Location = new System.Drawing.Point(2, 2);
            this.headerUC1.Margin = new System.Windows.Forms.Padding(4);
            this.headerUC1.Name = "headerUC1";
            this.headerUC1.Padding = new System.Windows.Forms.Padding(15);
            this.headerUC1.Size = new System.Drawing.Size(1548, 80);
            this.headerUC1.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.Controls.Add(this.tableLayoutPanel1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 84);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(6);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1552, 837);
            this.pnlMain.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1548, 833);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.Controls.Add(this.weightBothUC, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.speedUC, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.brakeForceBothUC, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1536, 404);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // weightBothUC
            // 
            this.weightBothUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.weightBothUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weightBothUC.Location = new System.Drawing.Point(6, 6);
            this.weightBothUC.Margin = new System.Windows.Forms.Padding(6);
            this.weightBothUC.Name = "weightBothUC";
            this.weightBothUC.Size = new System.Drawing.Size(525, 392);
            this.weightBothUC.TabIndex = 0;
            // 
            // speedUC
            // 
            this.speedUC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.speedUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.speedUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speedUC.Location = new System.Drawing.Point(543, 6);
            this.speedUC.Margin = new System.Windows.Forms.Padding(6);
            this.speedUC.Name = "speedUC";
            this.speedUC.Size = new System.Drawing.Size(448, 392);
            this.speedUC.TabIndex = 1;
            // 
            // brakeForceBothUC
            // 
            this.brakeForceBothUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.brakeForceBothUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.brakeForceBothUC.Location = new System.Drawing.Point(1003, 6);
            this.brakeForceBothUC.Margin = new System.Windows.Forms.Padding(6);
            this.brakeForceBothUC.Name = "brakeForceBothUC";
            this.brakeForceBothUC.Size = new System.Drawing.Size(527, 392);
            this.brakeForceBothUC.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.slideSlipAndAccelerationTimeUC, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.motobikeInfoDashboardUC, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(6, 422);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(6);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1536, 405);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.noiseAndLightsUC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(541, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(452, 397);
            this.panel1.TabIndex = 3;
            // 
            // noiseAndLightsUC
            // 
            this.noiseAndLightsUC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.noiseAndLightsUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.noiseAndLightsUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.noiseAndLightsUC.Location = new System.Drawing.Point(3, 3);
            this.noiseAndLightsUC.Margin = new System.Windows.Forms.Padding(4);
            this.noiseAndLightsUC.Name = "noiseAndLightsUC";
            this.noiseAndLightsUC.Size = new System.Drawing.Size(446, 391);
            this.noiseAndLightsUC.TabIndex = 0;
            // 
            // slideSlipAndAccelerationTimeUC
            // 
            this.slideSlipAndAccelerationTimeUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slideSlipAndAccelerationTimeUC.Location = new System.Drawing.Point(4, 4);
            this.slideSlipAndAccelerationTimeUC.Margin = new System.Windows.Forms.Padding(4);
            this.slideSlipAndAccelerationTimeUC.Name = "slideSlipAndAccelerationTimeUC";
            this.slideSlipAndAccelerationTimeUC.Size = new System.Drawing.Size(529, 397);
            this.slideSlipAndAccelerationTimeUC.TabIndex = 4;
            // 
            // motobikeInfoDashboardUC
            // 
            this.motobikeInfoDashboardUC.BackColor = System.Drawing.Color.White;
            this.motobikeInfoDashboardUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.motobikeInfoDashboardUC.Location = new System.Drawing.Point(997, 0);
            this.motobikeInfoDashboardUC.Margin = new System.Windows.Forms.Padding(0);
            this.motobikeInfoDashboardUC.Name = "motobikeInfoDashboardUC";
            this.motobikeInfoDashboardUC.Padding = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.motobikeInfoDashboardUC.Size = new System.Drawing.Size(539, 405);
            this.motobikeInfoDashboardUC.TabIndex = 5;
            // 
            // FrmMotobikeDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1552, 921);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMotobikeDashboard";
            this.Text = "Tổng hợp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMotobikeDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private UCT.WeightBothUC weightBothUC;
        private UCT.SpeedUC speedUC;
        private UCT.BrakeForceBothUC brakeForceBothUC;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Panel panel1;
        private UCT.NoiseAndLightsUC noiseAndLightsUC;
        private UCT.HeaderUC headerUC1;
        private UCT.SlideSlipAndAccelerationTimeUC slideSlipAndAccelerationTimeUC;
        private UCT.MotobikeInfoDashboardUC motobikeInfoDashboardUC;
    }
}