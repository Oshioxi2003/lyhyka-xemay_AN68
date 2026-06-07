namespace Lyhyka.Forms.Motobikes
{
    partial class FrmLightStandalone
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
            this.lightStandaloneUC = new Lyhyka.UCT.LightStandaloneUC();
            this.SuspendLayout();
            // 
            // lightStandaloneUC
            // 
            this.lightStandaloneUC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lightStandaloneUC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lightStandaloneUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lightStandaloneUC.Location = new System.Drawing.Point(20, 20);
            this.lightStandaloneUC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lightStandaloneUC.Name = "lightStandaloneUC";
            this.lightStandaloneUC.Size = new System.Drawing.Size(1272, 651);
            this.lightStandaloneUC.TabIndex = 0;
            // 
            // FrmLightStandalone
            // 
            this.ClientSize = new System.Drawing.Size(1312, 691);
            this.Controls.Add(this.lightStandaloneUC);
            this.Name = "FrmLightStandalone";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Text = "Hệ thống đo đèn";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private UCT.LightStandaloneUC lightStandaloneUC;
    }
}