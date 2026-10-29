using Lyhyka.Core;
using Lyhyka.DBCore;
using Microsoft.Reporting.WinForms;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lyhyka
{
    public partial class TestReport : Form
    {
        private string reportName = "Lyhyka.Reports.MotorbikeReport.rdlc";
        private DataTable reportData;
       
        public TestReport(DataTable data)
        {
            InitializeComponent();
            reportData = data;
            reportName = GetReportResourceName();
        }

        private string GetReportResourceName()
        {
            string templateSetting = ConfigurationManager.AppSettings["ReportTemplate"];
            bool isOld = false;
            if (!string.IsNullOrWhiteSpace(templateSetting))
            {
                string s = templateSetting.Trim().ToLowerInvariant();
                if (s == "old" || s == "cu" || s == "cũ" || s == "maucu" || s == "maucũ" || s == "mẫu cũ" || s == "legacy" || s == "0")
                {
                    isOld = true;
                }
            }

            if (GlobalVariables.IsElectricMotorbike)
            {
                return isOld ? "Lyhyka.Reports.ElectricBicycleReport_Old.rdlc" : "Lyhyka.Reports.ElectricBicycleReport.rdlc";
            }
            else
            {
                return isOld ? "Lyhyka.Reports.MotorbikeReport_Old.rdlc" : "Lyhyka.Reports.MotorbikeReport.rdlc";
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
                WriteLog($"Xuất report [{reportName}] thành công với {safeData.Rows.Count} dòng lúc {DateTime.Now}");
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
