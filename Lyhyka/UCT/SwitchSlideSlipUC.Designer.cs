namespace Lyhyka.UCT
{
    partial class SwitchSlideSlipUC
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
            this.tlpSlideSlip = new System.Windows.Forms.TableLayoutPanel();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.switchUC3 = new Lyhyka.UCT.SwitchUC();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.switchUC2 = new Lyhyka.UCT.SwitchUC();
            this.switchUC1 = new Lyhyka.UCT.SwitchUC();
            this.tlpSlideSlip.SuspendLayout();
            this.tlpBottom.SuspendLayout();
            this.tlpTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpSlideSlip
            // 
            this.tlpSlideSlip.ColumnCount = 1;
            this.tlpSlideSlip.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSlideSlip.Controls.Add(this.tlpBottom, 0, 1);
            this.tlpSlideSlip.Controls.Add(this.tlpTop, 0, 0);
            this.tlpSlideSlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSlideSlip.Location = new System.Drawing.Point(0, 0);
            this.tlpSlideSlip.Name = "tlpSlideSlip";
            this.tlpSlideSlip.RowCount = 2;
            this.tlpSlideSlip.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSlideSlip.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpSlideSlip.Size = new System.Drawing.Size(804, 459);
            this.tlpSlideSlip.TabIndex = 13;
            // 
            // tlpBottom
            // 
            this.tlpBottom.ColumnCount = 3;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBottom.Controls.Add(this.switchUC3, 1, 0);
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottom.Location = new System.Drawing.Point(3, 232);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.Size = new System.Drawing.Size(798, 224);
            this.tlpBottom.TabIndex = 13;
            // 
            // switchUC3
            // 
            this.switchUC3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchUC3.Location = new System.Drawing.Point(202, 3);
            this.switchUC3.Name = "switchUC3";
            this.switchUC3.Offtext = "Khóa";
            this.switchUC3.Ontext = "Mở";
            this.switchUC3.Padding = new System.Windows.Forms.Padding(20);
            this.switchUC3.Size = new System.Drawing.Size(393, 218);
            this.switchUC3.TabIndex = 1;
            this.switchUC3.Title = "CHỐT BÀN";
            // 
            // tlpTop
            // 
            this.tlpTop.ColumnCount = 2;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTop.Controls.Add(this.switchUC2, 1, 0);
            this.tlpTop.Controls.Add(this.switchUC1, 0, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop.Location = new System.Drawing.Point(3, 3);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpTop.Size = new System.Drawing.Size(798, 223);
            this.tlpTop.TabIndex = 12;
            // 
            // switchUC2
            // 
            this.switchUC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchUC2.Location = new System.Drawing.Point(402, 3);
            this.switchUC2.Name = "switchUC2";
            this.switchUC2.Offtext = "Nhả";
            this.switchUC2.Ontext = "Kẹp";
            this.switchUC2.Padding = new System.Windows.Forms.Padding(20);
            this.switchUC2.Size = new System.Drawing.Size(393, 217);
            this.switchUC2.TabIndex = 1;
            this.switchUC2.Title = "NẸP TRƯỚC";
            // 
            // switchUC1
            // 
            this.switchUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.switchUC1.Location = new System.Drawing.Point(3, 3);
            this.switchUC1.Name = "switchUC1";
            this.switchUC1.Offtext = "Nhả";
            this.switchUC1.Ontext = "Kẹp";
            this.switchUC1.Padding = new System.Windows.Forms.Padding(20);
            this.switchUC1.Size = new System.Drawing.Size(393, 217);
            this.switchUC1.TabIndex = 0;
            this.switchUC1.Title = "NẸP SAU";
            // 
            // SwitchSlideSlipUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpSlideSlip);
            this.Name = "SwitchSlideSlipUC";
            this.Size = new System.Drawing.Size(804, 459);
            this.tlpSlideSlip.ResumeLayout(false);
            this.tlpBottom.ResumeLayout(false);
            this.tlpTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpSlideSlip;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private SwitchUC switchUC3;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private SwitchUC switchUC2;
        private SwitchUC switchUC1;
    }
}
