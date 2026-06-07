using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Lyhyka.Core;
using Lyhyka.DBCore;
using Lyhyka.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lyhyka.Forms.Motobikes
{
    public partial class FrmHistory : Form
    {
        public FrmHistory()
        {
            InitializeComponent();
        }

        private void FrmHistory_Load(object sender, EventArgs e)
        {

            gridControl.ForceInitialize();

            gridView.OptionsView.ColumnAutoWidth = true;
            gridView.OptionsView.BestFitMode = GridBestFitMode.Full;
            gridView.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.False;
            gridView.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;

            gridView.BestFitColumns();

           

            // Auto-resize columns to fit content
            gridView.ScrollStyle = DevExpress.XtraGrid.Views.Grid.ScrollStyleFlags.LiveHorzScroll;
            gridView.OptionsFind.AlwaysVisible = true;
            gridView.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            gridView.OptionsFind.HighlightFindResults = true;  // Highlights results
            gridView.OptionsFind.ShowFindButton = false;       // Hides find button (search as you type)
            gridView.OptionsView.ShowAutoFilterRow = true;
            using (var context = new MyDbContext())
            {
                var data = context.TestVehicles.OrderByDescending(x=>x.TestedDate).ToList();
                gridControl.DataSource = data;
            }

            gridView.Columns["Id"].Visible = false;
            gridView.Columns["Brand"].Visible = false;
            gridView.Columns["TestedDate"].Visible = false;
            gridView.Columns["WeightFront"].Visible = false;
            gridView.Columns["WeightRear"].Visible = false;  
            gridView.Columns["VoltageDrop"].Visible = false;
            gridView.Columns["OverCurrent"].Visible = false;
            gridView.Columns["AxleTorqueFront"].Visible = false;
            gridView.Columns["AxleTorqueRear"].Visible = false;
            gridView.Columns["AccelerationTime"].Visible = false;


            gridView.Columns["EngineNumber"].Caption = "Số máy";
            gridView.Columns["FrameNumber"].Caption = "Số khung";
            gridView.Columns["VehicleType"].Caption = "Loại xe";
            gridView.Columns["Tester"].Caption = "Người test";
            gridView.Columns["TestedDateTime"].Caption = "Ngày test";
            gridView.Columns["WeightFront"].Caption = "Trọng lượng trước (kg)";
            gridView.Columns["WeightRear"].Caption = "Trọng lượng sau (kg)";
            gridView.Columns["Speed"].Caption = "Tốc độ (km/h)";
            gridView.Columns["BrakeForceFront"].Caption = "Lực phanh trước (N)";
            gridView.Columns["BrakeForceRear"].Caption = "Lực phanh sau (N)";
            gridView.Columns["SlideSlip"].Caption = "Trùng vết (mm)";
            gridView.Columns["Whistle"].Caption = "Đồ ồn (dB)";
            gridView.Columns["LongRangeLightIntensity"].Caption = "Pha - Cường độ chiếu sáng xa (cd)";
            gridView.Columns["LightDeviationUD"].Caption = "Pha - Độ lệch đèn U/D (mm)";
            gridView.Columns["LightDeviationLR"].Caption = "Pha - Độ lệch đèn L/R (mm)";
            gridView.Columns["VoltageDrop"].Caption = "Sụt áp (V)";
            gridView.Columns["OverCurrent"].Caption = "Dòng điện quá tải (A)";

            gridView.Columns["LongRangeNearLightIntensity"].Caption = "Cốt - Cường độ chiếu sáng xa (cd)";
            gridView.Columns["NearLightDeviationUD"].Caption = "Cốt - Độ lệch đèn U/D (mm)";
            gridView.Columns["NearLightDeviationLR"].Caption = "Cốt - Độ lệch đèn L/R (mm)";

            GridColumn colIn = new GridColumn();
            colIn.Caption = "In";
            colIn.FieldName = "InButton";     // any unique name
            colIn.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            colIn.Visible = true;
            colIn.VisibleIndex = gridView.Columns.Count;   // put at last column
            colIn.Width = 50;
            colIn.OptionsColumn.AllowEdit = true;
            colIn.OptionsColumn.FixedWidth = true;

            colIn.AppearanceHeader.Options.UseTextOptions = true;
            colIn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns.Add(colIn);
            // 👉 Center header
            RepositoryItemButtonEdit btnPrint = new RepositoryItemButtonEdit();
            btnPrint.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnPrint.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;

            System.Drawing.Image original = Properties.Resources.printing;

            // Resize the image to 24x24 or any size you want
            var resized = new Bitmap(original, new Size(24, 24));

            btnPrint.Buttons[0].ImageOptions.Image = resized;
            btnPrint.Buttons[0].Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            btnPrint.Buttons[0].Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            // Hide text box area
            btnPrint.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnPrint.ButtonClick += BtnPrint_ButtonClick;

            gridControl.RepositoryItems.Add(btnPrint);
            colIn.ColumnEdit = btnPrint;

            GridColumn colXoa = new GridColumn();
            colXoa.Caption = "Xóa";
            colXoa.FieldName = "DeleteButton";     // any unique name
            colXoa.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            colXoa.Visible = true;
            colXoa.VisibleIndex = gridView.Columns.Count;   // put at last column
            colXoa.Width = 50;
            colXoa.OptionsColumn.AllowEdit = true;
            colXoa.OptionsColumn.FixedWidth = true;

            colXoa.AppearanceHeader.Options.UseTextOptions = true;
            colXoa.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns.Add(colXoa);

            RepositoryItemButtonEdit btnDelete = new RepositoryItemButtonEdit();
            btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDelete.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;

            // Create a nice red trash can icon programmatically
            Bitmap deleteIcon = new Bitmap(24, 24);
            using (Graphics g = Graphics.FromImage(deleteIcon))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using (Brush brush = new SolidBrush(Color.FromArgb(220, 53, 69))) // Bootstrap Danger red
                using (Pen pen = new Pen(Color.FromArgb(220, 53, 69), 1.5f))
                {
                    // Lid handle
                    g.FillRectangle(brush, 10, 3, 4, 2);
                    // Lid
                    g.FillRectangle(brush, 6, 5, 12, 2);
                    // Body outline
                    g.DrawRectangle(pen, 7, 8, 10, 12);
                    // Vertical slats inside
                    g.DrawLine(pen, 10, 10, 10, 17);
                    g.DrawLine(pen, 14, 10, 14, 17);
                }
            }

            btnDelete.Buttons[0].ImageOptions.Image = deleteIcon;
            btnDelete.Buttons[0].Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            btnDelete.Buttons[0].Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            btnDelete.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnDelete.ButtonClick += BtnDelete_ButtonClick;

            gridControl.RepositoryItems.Add(btnDelete);
            colXoa.ColumnEdit = btnDelete;
        }

        private void BtnDelete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int rowHandle = gridView.FocusedRowHandle;
            if (rowHandle < 0) return;

            var idVal = gridView.GetRowCellValue(rowHandle, "Id");
            if (idVal == null) return;

            int id = int.Parse(idVal.ToString());

            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa lượt test này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (var dbContext = new MyDbContext())
                {
                    var testVehicle = dbContext.TestVehicles.Find(id);
                    if (testVehicle != null)
                    {
                        dbContext.TestVehicles.Remove(testVehicle);
                        dbContext.SaveChanges();

                        // Refresh grid data
                        var data = dbContext.TestVehicles.OrderByDescending(x => x.TestedDate).ToList();
                        gridControl.DataSource = data;
                    }
                }
            }
        }

        private void BtnPrint_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int rowHandle = gridView.FocusedRowHandle;

            // Get the clicked row object
            var row = gridView.GetRow(rowHandle);
            using (var dbContext = new MyDbContext())
            {
                // Example: show a cell value
                var Id = int.Parse(gridView.GetRowCellValue(rowHandle, "Id").ToString());
                var testVehicle = dbContext.TestVehicles.Find(Id);
                if(testVehicle != null)
                { 
                    var brand = dbContext.Brands.Where(x => x.Id == testVehicle.BrandId).FirstOrDefault();

                    DataTable reportDataList = RreportHelpers.GetVehicleReportData(testVehicle, brand);
                    TestReport exportReportForm = new TestReport(reportDataList);
                    exportReportForm.ShowDialog();
                }    
            }
        }
    }
}
