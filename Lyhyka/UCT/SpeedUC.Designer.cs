namespace Lyhyka.UCT
{
    partial class SpeedUC
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
            arcScaleRange1 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            arcScaleRange2 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();
            arcScaleRange3 = new DevExpress.XtraGauges.Core.Model.ArcScaleRange();

            this.panel1 = new System.Windows.Forms.Panel();
            this.headerLabelUC1 = new Lyhyka.UCT.HeaderLabelUC();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gaugeControl = new DevExpress.XtraGauges.Win.GaugeControl();
            this.circularGauge = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();
            this.arcScaleBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent();
            this.arcScaleComponent = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
            this.lblValue = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.arcScaleNeedleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent();
            this.arcScaleSpindleCapComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularGauge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.headerLabelUC1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(492, 84);
            this.panel1.TabIndex = 1;
            // 
            // headerLabelUC1
            // 
            this.headerLabelUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLabelUC1.Location = new System.Drawing.Point(10, 10);
            this.headerLabelUC1.Name = "headerLabelUC1";
            this.headerLabelUC1.Size = new System.Drawing.Size(472, 64);
            this.headerLabelUC1.TabIndex = 0;
            this.headerLabelUC1.Title = "ĐO TỐC ĐỘ";
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.panel3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 84);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl1.Size = new System.Drawing.Size(492, 570);
            this.panelControl1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gaugeControl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(472, 550);
            this.panel3.TabIndex = 1;
            // 
            // gaugeControl
            // 
            this.gaugeControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.gaugeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugeControl.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.circularGauge});
            this.gaugeControl.Location = new System.Drawing.Point(0, 0);
            this.gaugeControl.Name = "gaugeControl";
            this.gaugeControl.Size = new System.Drawing.Size(472, 550);
            this.gaugeControl.TabIndex = 0;
            // 
            // circularGauge
            // 
            this.circularGauge.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent[] {
            this.arcScaleBackgroundLayerComponent1});
            this.circularGauge.Bounds = new System.Drawing.Rectangle(6, 6, 460, 538);
            this.circularGauge.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.lblValue});
            this.circularGauge.Name = "circularGauge";
            this.circularGauge.Needles.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent[] {
            this.arcScaleNeedleComponent1});
            this.circularGauge.Scales.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent[] {
            this.arcScaleComponent});
            this.circularGauge.SpindleCaps.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent[] {
            this.arcScaleSpindleCapComponent1});
            // 
            // arcScaleBackgroundLayerComponent1
            // 
            this.arcScaleBackgroundLayerComponent1.ArcScale = this.arcScaleComponent;
            this.arcScaleBackgroundLayerComponent1.Name = "bg1";
            this.arcScaleBackgroundLayerComponent1.ScaleCenterPos = new DevExpress.XtraGauges.Core.Base.PointF2D(0.5F, 0.584F);
            this.arcScaleBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.BackgroundLayerShapeType.CircularThreeFourth_Style27;
            this.arcScaleBackgroundLayerComponent1.Size = new System.Drawing.SizeF(200F, 170.7F);
            this.arcScaleBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // arcScaleComponent
            // 
            this.arcScaleComponent.AppearanceMajorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent.AppearanceMajorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent.AppearanceMinorTickmark.BorderBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent.AppearanceMinorTickmark.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:White");
            this.arcScaleComponent.AppearanceTickmarkText.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 10F);
            this.arcScaleComponent.AppearanceTickmarkText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#999999");
            this.arcScaleComponent.Center = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 125F);
            this.arcScaleComponent.EndAngle = 45F;
            this.arcScaleComponent.MajorTickmark.AllowTickOverlap = true;
            this.arcScaleComponent.MajorTickmark.FormatString = "{0:F0}";
            this.arcScaleComponent.MajorTickmark.ShapeOffset = -4F;
            this.arcScaleComponent.MajorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style27_1;
            this.arcScaleComponent.MajorTickmark.TextOffset = 18F;
            this.arcScaleComponent.MajorTickmark.TextOrientation = DevExpress.XtraGauges.Core.Model.LabelOrientation.LeftToRight;
            this.arcScaleComponent.MaxValue = 100F;
            this.arcScaleComponent.MinorTickCount = 4;
            this.arcScaleComponent.MinorTickmark.ShapeOffset = 4F;
            this.arcScaleComponent.MinorTickmark.ShapeType = DevExpress.XtraGauges.Core.Model.TickmarkShapeType.Circular_Style27_1;
            this.arcScaleComponent.MinorTickmark.ShowTick = false;
            this.arcScaleComponent.Name = "scale1";
            this.arcScaleComponent.RadiusX = 101F;
            this.arcScaleComponent.RadiusY = 100.5F;
            arcScaleRange1.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#FFBF00");
            arcScaleRange1.EndThickness = 22F;
            arcScaleRange1.EndValue = 33F;
            arcScaleRange1.Name = "Range0";
            arcScaleRange1.ShapeOffset = -4F;
            arcScaleRange1.StartThickness = 22F;
            arcScaleRange2.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#9BBB59");
            arcScaleRange2.EndThickness = 22F;
            arcScaleRange2.EndValue = 66F;
            arcScaleRange2.Name = "Range1";
            arcScaleRange2.ShapeOffset = -4F;
            arcScaleRange2.StartThickness = 22F;
            arcScaleRange2.StartValue = 33F;
            arcScaleRange3.AppearanceRange.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#E73141");
            arcScaleRange3.EndThickness = 22F;
            arcScaleRange3.EndValue = 100F;
            arcScaleRange3.Name = "Range2";
            arcScaleRange3.ShapeOffset = -4F;
            arcScaleRange3.StartThickness = 22F;
            arcScaleRange3.StartValue = 66F;
            this.arcScaleComponent.Ranges.AddRange(new DevExpress.XtraGauges.Core.Model.IRange[] {
            arcScaleRange1,
            arcScaleRange2,
            arcScaleRange3});
            this.arcScaleComponent.StartAngle = -225F;
            this.arcScaleComponent.Value = 22F;
            // 
            // lblValue
            // 
            this.lblValue.AppearanceText.DXFont = new DevExpress.Drawing.DXFont("Tahoma", 36F, DevExpress.Drawing.DXFontStyle.Bold);
            this.lblValue.AppearanceText.TextBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#DC3235");
            this.lblValue.Name = "circularGauge1_Label1";
            this.lblValue.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 205F);
            this.lblValue.Size = new System.Drawing.SizeF(250F, 25F);
            this.lblValue.Text = "20";
            this.lblValue.ZOrder = -1001;
            // 
            // arcScaleNeedleComponent1
            // 
            this.arcScaleNeedleComponent1.ArcScale = this.arcScaleComponent;
            this.arcScaleNeedleComponent1.EndOffset = 8F;
            this.arcScaleNeedleComponent1.Name = "needle1";
            this.arcScaleNeedleComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.NeedleShapeType.CircularFull_Style27;
            this.arcScaleNeedleComponent1.StartOffset = -6F;
            this.arcScaleNeedleComponent1.ZOrder = -50;
            // 
            // arcScaleSpindleCapComponent1
            // 
            this.arcScaleSpindleCapComponent1.ArcScale = this.arcScaleComponent;
            this.arcScaleSpindleCapComponent1.Name = "cap1";
            this.arcScaleSpindleCapComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.SpindleCapShapeType.Empty;
            this.arcScaleSpindleCapComponent1.Size = new System.Drawing.SizeF(25F, 25F);
            this.arcScaleSpindleCapComponent1.ZOrder = -100;
            // 
            // SpeedUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panel1);
            this.Name = "SpeedUC";
            this.Size = new System.Drawing.Size(492, 654);
            this.Load += new System.EventHandler(this.SpeedUC_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.circularGauge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange1, arcScaleRange2, arcScaleRange3;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl;
        private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGauge;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent arcScaleBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleComponent;
        private DevExpress.XtraGauges.Win.Base.LabelComponent lblValue;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent arcScaleNeedleComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent arcScaleSpindleCapComponent1;
        private HeaderLabelUC headerLabelUC1;
    }
}
