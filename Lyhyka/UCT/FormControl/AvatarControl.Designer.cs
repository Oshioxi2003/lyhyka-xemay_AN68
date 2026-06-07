namespace ReStart.FormControl
{
    partial class AvatarControl
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
            this.ovalPanel1 = new ReStart.FormControl.OvalPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.ovalPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ovalPanel1
            // 
            this.ovalPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(228)))));
            this.ovalPanel1.Controls.Add(this.lblName);
            this.ovalPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ovalPanel1.Location = new System.Drawing.Point(0, 0);
            this.ovalPanel1.Name = "ovalPanel1";
            this.ovalPanel1.Size = new System.Drawing.Size(150, 150);
            this.ovalPanel1.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.White;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblName.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(47)))), ((int)(((byte)(36)))));
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(150, 150);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "DN";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AvatarControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ovalPanel1);
            this.Name = "AvatarControl";
            this.Load += new System.EventHandler(this.AvatarControl_Load);
            this.ovalPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OvalPanel ovalPanel1;
        private System.Windows.Forms.Label lblName;
    }
}
