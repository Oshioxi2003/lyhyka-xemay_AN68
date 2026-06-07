using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Lyhyka.Core;
using Lyhyka.DBCore;
using Lyhyka.UCT;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Lyhyka.Forms.Motobikes
{
    public partial class FrmSetting : Form
    { 
        private BindingList<Brand> _bindingList;
        private BindingList<Admin> _bindingList1;
        MyDbContext _dbContext = new MyDbContext();
        public FrmSetting()
        {
            InitializeComponent();
            tabControl1.SelectedIndex = 0;
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            //gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            //gridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;

            //gridView.OptionsBehavior.Editable = true;
            gridView.OptionsBehavior.ReadOnly = true;
            //gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            //gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            using(var dbContext = new MyDbContext())
                _bindingList = new BindingList<Brand>(dbContext.Brands.ToList());
            gridControl.DataSource = _bindingList;
            //gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            //gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;

            gridView.PopulateColumns();
            gridView.Columns["Id"].Visible = false;
            gridView.Columns["WeightFrontMin"].Visible = false; 
            gridView.Columns["WeightFrontMax"].Visible = false;
            gridView.Columns["WeightRearMin"].Visible = false;
            gridView.Columns["WeightRearMax"].Visible = false;
            gridView.Columns["Type"].Caption = "Loại xe";
            gridView.Columns["Name"].Caption = "Tên";
            gridView.Columns["SpeedMin"].Caption = "Tốc độ min";
            gridView.Columns["SpeedMax"].Caption = "Tốc độ max";
            gridView.Columns["BrakeForceFrontMin"].Caption = "Phanh trước min";
            gridView.Columns["BrakeForceFrontMax"].Caption = "Phanh trước min";
            gridView.Columns["BrakeForceRearMin"].Caption = "Phanh sau min";
            gridView.Columns["BrakeForceRearMax"].Caption = "Phanh sau max";
            gridView.Columns["SlideSlipMin"].Caption = "Trùng vết min";
            gridView.Columns["SlideSlipMax"].Caption = "Trùng vết max";
            gridView.Columns["WhistleMin"].Caption = "Đồ ồn min";
            gridView.Columns["WhistleMax"].Caption = "Đồ ồn max";


            gridView.Columns["LongRangeLightIntensityMin"].Caption = "Cường độ chiếu sáng xa min";
            gridView.Columns["LongRangeLightIntensityMax"].Caption = "Cường độ chiếu sáng xa max";

            gridView.Columns["LightDeviationUDMin"].Caption = "Độ lệch đèn U/D min";
            gridView.Columns["LightDeviationUDMax"].Caption = "Độ lệch đèn U/D max";

            gridView.Columns["LightDeviationLRMin"].Caption = "Độ lệch đèn L/R min";
            gridView.Columns["LightDeviationLRMax"].Caption = "Độ lệch đèn L/R max";

            gridView.Columns["LongRangeNearLightIntensityMin"].Caption = "Cường độ chiếu sáng xa min(cốt)";
            gridView.Columns["LongRangeNearLightIntensityMax"].Caption = "Cường độ chiếu sáng xa max(cốt)";

            gridView.Columns["NearLightDeviationUDMin"].Caption = "Độ lệch đèn U/D min(cốt)";
            gridView.Columns["NearLightDeviationUDMax"].Caption = "Độ lệch đèn U/D max(cốt)";

            gridView.Columns["NearLightDeviationLRMin"].Caption = "Độ lệch đèn L/R min(cốt)";
            gridView.Columns["NearLightDeviationLRMax"].Caption = "Độ lệch đèn L/R max(cốt)";


            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;

            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsBehavior.ReadOnly = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True; 
            
            _bindingList1 = new BindingList<Admin>(_dbContext.Admins.Where(x=>x.IsTester==1).ToList());
            gridControl1.DataSource = _bindingList1;
            gridView1.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gridView1.PopulateColumns();
            gridView1.Columns["IsTester"].Visible = false;
            gridView1.Columns["Password"].Visible = false;
            gridView1.Columns["UserName"].Caption = "Tên tester";

            GridColumn colEdit = new GridColumn();
            colEdit.Caption = "Sửa";
            colEdit.FieldName = "EditButton";     // any unique name
            colEdit.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            colEdit.Visible = true;
            colEdit.VisibleIndex = gridView.Columns.Count;   // put at last column
            colEdit.Width = 50;
            colEdit.OptionsColumn.AllowEdit = true;
            colEdit.OptionsColumn.FixedWidth = true; 
          
            colEdit.AppearanceHeader.Options.UseTextOptions = true;
            colEdit.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView.Columns.Add(colEdit);
            // 👉 Center header
            RepositoryItemButtonEdit btnEdit = new RepositoryItemButtonEdit();
            btnEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnEdit.Buttons[0].Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph;

            System.Drawing.Image original = Properties.Resources.edit_button;

            // Resize the image to 24x24 or any size you want
            var resized = new Bitmap(original, new Size(24, 24));

            btnEdit.Buttons[0].ImageOptions.Image = resized;
            btnEdit.Buttons[0].Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            btnEdit.Buttons[0].Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            // Hide text box area
            btnEdit.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            btnEdit.ButtonClick += BtnEdit_ButtonClick;

            gridControl.RepositoryItems.Add(btnEdit);
            colEdit.ColumnEdit = btnEdit;

            chkHeadLightUnitIsPercentage.Checked = Properties.Settings.Default.HeadLightUnitIsPercentage;
        }
        private void BtnEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            int rowHandle = gridView.FocusedRowHandle;
            
            // Get the clicked row object
            var row = gridView.GetRow(rowHandle);
            using (var dbContext = new MyDbContext())
            {
                // Example: show a cell value
                var Id = int.Parse(gridView.GetRowCellValue(rowHandle, "Id").ToString());
                var brand = dbContext.Brands.Find(Id);
                if (brand == null)
                    brand = new Brand();
                FrmThresholeSetting frmThresholeSetting = new FrmThresholeSetting(brand);
                frmThresholeSetting.FormClosed += Child_FormClosed; // subscribe
                frmThresholeSetting.Show();
            }
        }
        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            using (var dbContext = new MyDbContext())
                dbContext.SaveChanges(); // Saves changes to DB
        }
        private void gridView_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var newBrand = (Brand)gridView.GetRow(e.RowHandle);
            using (var dbContext = new MyDbContext())
                dbContext.Brands.Add(newBrand);
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {

                _dbContext.SaveChanges(); // Saves changes to DB
            }
            catch (Exception)
            {
                 
            }
        }
        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var admin = (Admin)gridView1.GetRow(e.RowHandle);
            admin.Password = "123456";
            admin.IsTester = 1;
            admin.UserName = "";
            _dbContext.Admins.Add(admin);
            _dbContext.SaveChanges();
        }

        private void FrmSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            MotobikeInfoDashboardUC.OnTesterDataReceived?.Invoke();
        }

        private void gridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.RowHandle >= 0) // valid data row
            {
                // Get the clicked row object
                var row = gridView.GetRow(e.RowHandle);
                using (var dbContext = new MyDbContext())
                {
                    // Example: show a cell value
                    var Id = int.Parse(gridView.GetRowCellValue(e.RowHandle, "Id").ToString());
                    var brand = dbContext.Brands.Find(Id);
                    if (brand == null)
                        brand = new Brand();
                    FrmThresholeSetting frmThresholeSetting = new FrmThresholeSetting(brand);
                    frmThresholeSetting.FormClosed += Child_FormClosed; // subscribe
                    frmThresholeSetting.Show();
                }

            }
        }
        private void Child_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmSetting_Load(null,null); // your reload function
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmThresholeSetting frmThresholeSetting = new FrmThresholeSetting(null);
            frmThresholeSetting.FormClosed += Child_FormClosed; // subscribe
            frmThresholeSetting.Show();
        }

        private void chkHeadLightUnitIsPercentage_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.HeadLightUnitIsPercentage = chkHeadLightUnitIsPercentage.Checked;
            Properties.Settings.Default.Save();
            GlobalVariables.UpdateGlobalSetting();
        }
    }
}
