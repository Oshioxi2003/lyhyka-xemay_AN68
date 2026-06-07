using DevExpress.XtraGauges.Core.Model;

namespace Lyhyka.UCT
{
    partial class GauseMeasureWithConfirmUC
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gaugeControl = new DevExpress.XtraGauges.Win.GaugeControl();
            this.arcScaleBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent();
            this.arcScaleComponent = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent();
            this.lblValue = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.arcScaleNeedleComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent();
            this.arcScaleSpindleCapComponent1 = new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.circularGauge = new DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge();
            this.titleAndValueUC2 = new Lyhyka.UCT.TitleAndValueUC();
            this.titleAndValueUC1 = new Lyhyka.UCT.TitleAndValueUC();
            this.headerLabelUC = new Lyhyka.UCT.HeaderLabelUC();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circularGauge)).BeginInit();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.panel3);
            this.panelControl1.Controls.Add(this.panel2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 84);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Padding = new System.Windows.Forms.Padding(10);
            this.panelControl1.Size = new System.Drawing.Size(1241, 642);
            this.panelControl1.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gaugeControl);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(10, 10);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1221, 254);
            this.panel3.TabIndex = 2;
            // 
            // gaugeControl
            // 
            this.gaugeControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugeControl.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.circularGauge});
            this.gaugeControl.Location = new System.Drawing.Point(0, 0);
            this.gaugeControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gaugeControl.Name = "gaugeControl";
            this.gaugeControl.Size = new System.Drawing.Size(1221, 254);
            this.gaugeControl.TabIndex = 1;
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
            this.lblValue.Position = new DevExpress.XtraGauges.Core.Base.PointF2D(125F, 180F);
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
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 264);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1221, 368);
            this.panel2.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1221, 368);
            this.panel4.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tableLayoutPanel1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(180, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.panel6.Size = new System.Drawing.Size(1041, 368);
            this.panel6.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel9, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel7, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1035, 356);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.titleAndValueUC2);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(520, 2);
            this.panel9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(512, 352);
            this.panel9.TabIndex = 2;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.titleAndValueUC1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(3, 2);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(511, 352);
            this.panel7.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel10);
            this.panel5.Controls.Add(this.panel8);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(0);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 12);
            this.panel5.Size = new System.Drawing.Size(180, 368);
            this.panel5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(50)))), ((int)(((byte)(53)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 199);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chốt số";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.headerLabelUC);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1241, 84);
            this.panel1.TabIndex = 3;
            // 
            // circularGauge
            // 
            this.circularGauge.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent[] {
            this.arcScaleBackgroundLayerComponent1});
            this.circularGauge.Bounds = new System.Drawing.Rectangle(6, 6, 1209, 242);
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
            // titleAndValueUC2
            // 
            this.titleAndValueUC2.BackColor = System.Drawing.Color.White;
            this.titleAndValueUC2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleAndValueUC2.Location = new System.Drawing.Point(0, 0);
            this.titleAndValueUC2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.titleAndValueUC2.Name = "titleAndValueUC2";
            this.titleAndValueUC2.Size = new System.Drawing.Size(512, 352);
            this.titleAndValueUC2.TabIndex = 1;
            this.titleAndValueUC2.Title = "";
            this.titleAndValueUC2.Value = "";
            // 
            // titleAndValueUC1
            // 
            this.titleAndValueUC1.BackColor = System.Drawing.Color.White;
            this.titleAndValueUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titleAndValueUC1.Location = new System.Drawing.Point(0, 0);
            this.titleAndValueUC1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.titleAndValueUC1.Name = "titleAndValueUC1";
            this.titleAndValueUC1.Size = new System.Drawing.Size(511, 352);
            this.titleAndValueUC1.TabIndex = 0;
            this.titleAndValueUC1.Title = "";
            this.titleAndValueUC1.Value = "";
            // 
            // headerLabelUC
            // 
            this.headerLabelUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLabelUC.Location = new System.Drawing.Point(10, 10);
            this.headerLabelUC.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.headerLabelUC.Name = "headerLabelUC";
            this.headerLabelUC.Size = new System.Drawing.Size(1221, 64);
            this.headerLabelUC.TabIndex = 0;
            this.headerLabelUC.Title = "ĐO TỐC ĐỘ";
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(180, 133);
            this.panel8.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label1);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 133);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(180, 199);
            this.panel10.TabIndex = 2;
            // 
            // GauseMeasureWithConfirmUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GauseMeasureWithConfirmUC";
            this.Size = new System.Drawing.Size(1241, 726);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleComponent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleNeedleComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arcScaleSpindleCapComponent1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.circularGauge)).EndInit();
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGauges.Core.Model.ArcScaleRange arcScaleRange1, arcScaleRange2, arcScaleRange3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Panel panel1;
        public HeaderLabelUC headerLabelUC;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl;
        private DevExpress.XtraGauges.Win.Gauges.Circular.CircularGauge circularGauge;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleBackgroundLayerComponent arcScaleBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleComponent arcScaleComponent;
        private DevExpress.XtraGauges.Win.Base.LabelComponent lblValue;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleNeedleComponent arcScaleNeedleComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Circular.ArcScaleSpindleCapComponent arcScaleSpindleCapComponent1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel7;
        public TitleAndValueUC titleAndValueUC1;
        private System.Windows.Forms.Panel panel9;
        public TitleAndValueUC titleAndValueUC2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel10;
    }
}
