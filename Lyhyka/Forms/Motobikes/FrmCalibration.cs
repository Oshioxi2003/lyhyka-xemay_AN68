using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Lyhyka.DBCore;
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
    public partial class FrmCalibration : Form
    {
        private MyDbContext _dbContext = new MyDbContext();
        private BindingList<Calibration> _bindingList;
        public FrmCalibration()
        {
            InitializeComponent();
        }

        private void FrmCalibration_Load(object sender, EventArgs e)
        { 

            gridView.OptionsBehavior.Editable = true;
            gridView.OptionsBehavior.ReadOnly = false;
            gridView.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            gridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            _bindingList = new BindingList<Calibration>(_dbContext.Calibrations.ToList());
            gridControl.DataSource = _bindingList;
        }
        private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            _dbContext.SaveChanges(); // Saves changes to DB
        }
    }
}
