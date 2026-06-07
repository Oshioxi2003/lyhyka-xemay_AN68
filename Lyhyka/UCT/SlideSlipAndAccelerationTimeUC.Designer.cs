namespace Lyhyka.UCT
{
    partial class SlideSlipAndAccelerationTimeUC
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.accelerationTimeUC = new Lyhyka.UCT.AccelerationTimeUC();
            this.panel1 = new System.Windows.Forms.Panel();
            this.slideSlipUC = new Lyhyka.UCT.SlideSlipUC();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(653, 563);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 397);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(20);
            this.panel5.Size = new System.Drawing.Size(647, 163);
            this.panel5.TabIndex = 10;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.accelerationTimeUC);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(20, 20);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(605, 121);
            this.panel6.TabIndex = 0;
            // 
            // accelerationTimeUC
            // 
            this.accelerationTimeUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accelerationTimeUC.Location = new System.Drawing.Point(0, 0);
            this.accelerationTimeUC.Name = "accelerationTimeUC";
            this.accelerationTimeUC.Size = new System.Drawing.Size(605, 121);
            this.accelerationTimeUC.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.slideSlipUC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 388);
            this.panel1.TabIndex = 8;
            // 
            // slideSlipUC
            // 
            this.slideSlipUC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.slideSlipUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.slideSlipUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.slideSlipUC.Location = new System.Drawing.Point(0, 0);
            this.slideSlipUC.Name = "slideSlipUC";
            this.slideSlipUC.Size = new System.Drawing.Size(647, 388);
            this.slideSlipUC.TabIndex = 0;
            // 
            // SlideSlipAndAccelerationTimeUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "SlideSlipAndAccelerationTimeUC";
            this.Size = new System.Drawing.Size(653, 563);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel1;
        private AccelerationTimeUC accelerationTimeUC;
        private SlideSlipUC slideSlipUC;
    }
}
