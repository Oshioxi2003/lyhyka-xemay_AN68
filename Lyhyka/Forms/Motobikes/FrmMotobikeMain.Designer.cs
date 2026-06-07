namespace Lyhyka
{
    partial class FrmMotobikeMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMotobikeMain));
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.headerUC1 = new Lyhyka.UCT.HeaderUC();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSwitch = new System.Windows.Forms.Panel();
           
            this.motobikeInfoDashboardUC = new Lyhyka.UCT.MotobikeInfoDashboardUC();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlContainer.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlSwitch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.headerUC1);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1236, 77);
            this.pnlHeader.TabIndex = 0;
            // 
            // headerUC1
            // 
            this.headerUC1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.headerUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerUC1.Location = new System.Drawing.Point(2, 2);
            this.headerUC1.Margin = new System.Windows.Forms.Padding(4);
            this.headerUC1.Name = "headerUC1";
            this.headerUC1.Padding = new System.Windows.Forms.Padding(10);
            this.headerUC1.Size = new System.Drawing.Size(1232, 73);
            this.headerUC1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.pnlContainer);
            this.panel1.Controls.Add(this.pnlLeft);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.Size = new System.Drawing.Size(1236, 724);
            this.panel1.TabIndex = 1;
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlContainer.Controls.Add(this.pnlMain);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(20, 20);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(511, 684);
            this.pnlContainer.TabIndex = 1;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(10);
            this.pnlMain.Size = new System.Drawing.Size(511, 684);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.panel2);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLeft.Location = new System.Drawing.Point(531, 20);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(685, 684);
            this.pnlLeft.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(20, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(665, 684);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnlSwitch, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.motobikeInfoDashboardUC, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(665, 684);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.pnlSwitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.pnlSwitch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            
            this.pnlSwitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSwitch.Location = new System.Drawing.Point(3, 3);
            this.pnlSwitch.Name = "panel3";
            this.pnlSwitch.Padding = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.pnlSwitch.Size = new System.Drawing.Size(659, 336);
            this.pnlSwitch.TabIndex = 1;

            
            // 
            // motobikeInfoDashboardUC
            // 
            this.motobikeInfoDashboardUC.BackColor = System.Drawing.Color.White;
            this.motobikeInfoDashboardUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.motobikeInfoDashboardUC.Location = new System.Drawing.Point(0, 342);
            this.motobikeInfoDashboardUC.Margin = new System.Windows.Forms.Padding(0);
            this.motobikeInfoDashboardUC.Name = "motobikeInfoDashboardUC";
            this.motobikeInfoDashboardUC.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.motobikeInfoDashboardUC.Size = new System.Drawing.Size(665, 342);
            this.motobikeInfoDashboardUC.TabIndex = 0;
            // 
            // FrmMotobikeMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1236, 801);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlHeader);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMotobikeMain";
            this.Text = "Kiểm tra thiết bị";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMotobikeMain_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlContainer.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlSwitch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private UCT.HeaderUC headerUC1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private UCT.MotobikeInfoDashboardUC motobikeInfoDashboardUC;
        private System.Windows.Forms.Panel pnlSwitch; 
    }
}