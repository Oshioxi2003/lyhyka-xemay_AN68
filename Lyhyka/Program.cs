using DevExpress.XtraWaitForm;
using Lyhyka.Core;
using Lyhyka.RS232;
using System;
using System.Windows.Forms;

namespace Lyhyka
{
    internal static class Program
    {
        public static FrmMotobikeMain MainFormInstance;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //MQD6AParser.Process();
                //MQD3BParser.Process();
                //PacketParser.Parse("SL0072-609+00408000000+000+00000000060-706+305080000.000\r\n00+0000000R0061-616+00508000000+000+00000000057-693+305080000.00000+0000000P");
                //MQD3BParser.Process("SL1197+999+00008000000+000+00000001185-112+357080007.30000+0000000R1197+999+00008000000+000+00000001185-110+357080006.60000+0000000P");
                GlobalVariables.Inits();
                MainFormInstance = new FrmMotobikeMain();
                Application.Run(MainFormInstance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
