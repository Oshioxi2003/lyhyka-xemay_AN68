using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using Lyhyka.Core;
using Lyhyka.DBCore;
using Lyhyka.Reports;
using Lyhyka.RS232;
using Lyhyka.UCT;
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
    public partial class FrmLightStandalone : Form
    {
        public FrmLightStandalone()
        {
            InitializeComponent();
            this.Load += FrmLightStandalone_Load;
        }

        private void FrmLightStandalone_Load(object sender, EventArgs e)
        {
            SetNoiseAndLightsValues();
            // Register callback for device data
            MQD3BParser.OnDataReceived = SetNoiseAndLightsValues;
            MQD6AParser.OnDataReceived = SetNoiseAndLightsValues;
            // Register callback for manual data entry
            GlobalVariables.OnLightDataChanged = SetNoiseAndLightsValues;
        }

        private void FrmHistory_Load(object sender, EventArgs e)
        { 
            SetNoiseAndLightsValues();
            // Register callback
            MQD3BParser.OnDataReceived = SetNoiseAndLightsValues;
            MQD6AParser.OnDataReceived = SetNoiseAndLightsValues;
        }
        public void SetNoiseAndLightsValues()
        {
            //MessageBox.Show("SetNoiseAndLightsValues");
            // Check if we are on the UI thread
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => lightStandaloneUC.SetCurrentValue()));
            }
            else
            {
                lightStandaloneUC.SetCurrentValue();
            }


        }
    }
}
