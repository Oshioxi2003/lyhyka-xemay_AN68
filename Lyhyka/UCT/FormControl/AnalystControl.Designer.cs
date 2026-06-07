namespace ReStart.FormControl
{
    partial class AnalystControl
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTotalCompleted1 = new System.Windows.Forms.Label();
            this.lblTotalCompleted2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitle.Location = new System.Drawing.Point(0, 53);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(275, 25);
            this.lblTitle.TabIndex = 5;
            this.lblTitle.Text = "Total Completed";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTotalCompleted1
            // 
            this.lblTotalCompleted1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCompleted1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCompleted1.Location = new System.Drawing.Point(3, 0);
            this.lblTotalCompleted1.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblTotalCompleted1.Name = "lblTotalCompleted1";
            this.lblTotalCompleted1.Size = new System.Drawing.Size(134, 53);
            this.lblTotalCompleted1.TabIndex = 4;
            this.lblTotalCompleted1.Text = "0";
            this.lblTotalCompleted1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalCompleted2
            // 
            this.lblTotalCompleted2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCompleted2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCompleted2.Location = new System.Drawing.Point(140, 0);
            this.lblTotalCompleted2.Name = "lblTotalCompleted2";
            this.lblTotalCompleted2.Size = new System.Drawing.Size(132, 53);
            this.lblTotalCompleted2.TabIndex = 7;
            this.lblTotalCompleted2.Text = "/0";
            this.lblTotalCompleted2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblTotalCompleted1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalCompleted2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(275, 53);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // AnalystControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblTitle);
            this.Name = "AnalystControl";
            this.Size = new System.Drawing.Size(275, 78);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotalCompleted1;
        private System.Windows.Forms.Label lblTotalCompleted2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
