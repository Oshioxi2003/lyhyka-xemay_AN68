using Lyhyka.Core;
using Lyhyka.DBCore;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lyhyka
{
    public partial class TestReport : Form
    {
        string reportName = "Lyhyka.Reports.MotorbikeReport.rdlc";
        private DataTable reportData;
       
        public TestReport(DataTable data)
        {
            InitializeComponent();
            reportData = data;
            if(GlobalVariables.IsElectricMotorbike)
            {
                reportName = "Lyhyka.Reports.ElectricBicycleReport.rdlc";
            }    
        }
       
        private void TestReport_Load(object sender, EventArgs e)
        {
            LoadReport();
        }
        private void LoadReport()
        {
            try
            {
                if (reportData == null || reportData.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất.");
                    WriteLog("Dữ liệu trống khi in report.");
                    return;
                }

                // Clone để tránh lỗi khi datatable bị dispose ở form khác
                var safeData = reportData.Copy();

                // Nạp file .rdlc
                reportViewer1.LocalReport.ReportEmbeddedResource = reportName;
                reportViewer1.LocalReport.EnableExternalImages = true;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("VehicleDataSet", safeData));


                reportViewer1.RefreshReport();

                // Log sau khi in thành công
                WriteLog($"Xuất report thành công với {safeData.Rows.Count} dòng lúc {DateTime.Now}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất report: " + ex.Message);
                WriteLog($"LỖI khi xuất report: {ex.Message} lúc {DateTime.Now}");
            }
            finally
            {
                // Giải phóng bộ nhớ sau khi in
                try
                {
                    reportViewer1.LocalReport.ReleaseSandboxAppDomain();
                }
                catch (Exception ex)
                {
                    WriteLog($"LỖI khi giải phóng sandbox: {ex.Message}");
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        private void WriteLog(string message)
        {
            string logPath = Path.Combine(Application.StartupPath, "ExportReportLog.txt");

            try
            {
                File.AppendAllText(logPath, $">>>{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}{Environment.NewLine}");
            }
            catch
            {
                // Nếu không ghi log được thì bỏ qua, tránh làm crash app
            }
        }
    }
}
