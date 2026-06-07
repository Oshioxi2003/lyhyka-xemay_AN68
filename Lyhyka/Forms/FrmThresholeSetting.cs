using Lyhyka.Core;
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

namespace Lyhyka.Forms
{
    public partial class FrmThresholeSetting : Form
    {
        Brand _brand;

        // Tiêu chuẩn tổng phanh
        private TextBox txtBrakeForceSumMin = new TextBox();
        private TextBox txtBrakeForceSumMax = new TextBox();

        // Tiêu chuẩn xác suất
        private TextBox txtVoltageDropMin = new TextBox();
        private TextBox txtVoltageDropMax = new TextBox();
        private TextBox txtOverCurrentMin = new TextBox();
        private TextBox txtOverCurrentMax = new TextBox();
        private TextBox txtAxleTorqueFrontMin = new TextBox();
        private TextBox txtAxleTorqueFrontMax = new TextBox();
        private TextBox txtAxleTorqueRearMin = new TextBox();
        private TextBox txtAxleTorqueRearMax = new TextBox();
        private TextBox txtAxleTorqueForkMin = new TextBox();
        private TextBox txtAxleTorqueForkMax = new TextBox();
        private CheckBox chkHideInspection = new CheckBox();

        // Thông tin xe mặc định
        private TextBox txtDefaultCertificateNumber = new TextBox();
        private TextBox txtDefaultVehicleBrandName = new TextBox();
        private TextBox txtDefaultVehicleColor = new TextBox();

        // Đèn pha (HB) - per-direction min/max
        private TextBox txtHBLeftMin = new TextBox();
        private TextBox txtHBLeftMax = new TextBox();
        private TextBox txtHBRightMin = new TextBox();
        private TextBox txtHBRightMax = new TextBox();
        private TextBox txtHBUpMin = new TextBox();
        private TextBox txtHBUpMax = new TextBox();
        private TextBox txtHBDownMin = new TextBox();
        private TextBox txtHBDownMax = new TextBox();

        // Đèn cốt (LB) - per-direction min/max
        private TextBox txtLBLeftMin = new TextBox();
        private TextBox txtLBLeftMax = new TextBox();
        private TextBox txtLBRightMin = new TextBox();
        private TextBox txtLBRightMax = new TextBox();
        private TextBox txtLBUpMin = new TextBox();
        private TextBox txtLBUpMax = new TextBox();
        private TextBox txtLBDownMin = new TextBox();
        private TextBox txtLBDownMax = new TextBox();

        public FrmThresholeSetting(Brand brand)
        {
            InitializeComponent();
            cboType.SelectedIndex = 0;
            _brand = brand;
            if (_brand != null)
            {
                txtLightDeviationUDMax.Text = _brand.LightDeviationUDMax.ToString();
                txtLightDeviationUDMin.Text = _brand.LightDeviationUDMin.ToString();
                txtLightDeviationLRMax.Text = _brand.LightDeviationLRMax.ToString();
                txtLightDeviationLRMin.Text = _brand.LightDeviationLRMin.ToString();
                txtLongRangeLightIntensityMax.Text = _brand.LongRangeLightIntensityMax.ToString();
                txtLongRangeLightIntensityMin.Text = _brand.LongRangeLightIntensityMin.ToString();

                txtNearLightDeviationUDMax.Text = _brand.NearLightDeviationUDMax.ToString();
                txtNearLightDeviationUDMin.Text = _brand.NearLightDeviationUDMin.ToString();
                txtNearLightDeviationLRMax.Text = _brand.NearLightDeviationLRMax.ToString();
                txtNearLightDeviationLRMin.Text = _brand.NearLightDeviationLRMin.ToString();
                txtLongRangeNearLightIntensityMax.Text = _brand.LongRangeNearLightIntensityMax.ToString();
                txtLongRangeNearLightIntensityMin.Text = _brand.LongRangeNearLightIntensityMin.ToString();

                txtBrakeForceFrontMin.Text = _brand.BrakeForceFrontMin.ToString();
                txtBrakeForceFrontMax.Text = _brand.BrakeForceFrontMax.ToString();

                txtBrakeForceRearMin.Text = _brand.BrakeForceRearMin.ToString();
                txtBrakeForceRearMax.Text = _brand.BrakeForceRearMax.ToString();

                txtWeightFrontMin.Text = _brand.WeightFrontMin.ToString();
                txtWeightFrontMax.Text = _brand.WeightFrontMax.ToString();

                txtWeightRearMin.Text = _brand.WeightRearMin.ToString();
                txtWeightRearMax.Text = _brand.WeightRearMax.ToString();

                txtCOMin.Text = _brand.COMin.ToString();
                txtCOMax.Text = _brand.COMax.ToString();
                txtHCMin.Text = _brand.HCMin.ToString();
                txtHCMax.Text = _brand.HCMax.ToString();

                txtSpeedMin.Text = _brand.SpeedMin.ToString();
                txtSpeedMax.Text = _brand.SpeedMax.ToString();

                txtSlideSlipMin.Text = _brand.SlideSlipMin.ToString();
                txtSlideSlipMax.Text = _brand.SlideSlipMax.ToString();
                txtWhistleMin.Text = _brand.WhistleMin.ToString();
                txtWhistleMax.Text = _brand.WhistleMax.ToString();
                cboType.Text = _brand.Type;
                chkShowRealSpeed.Checked = _brand.IsShowRealSpeed;
                txtBrandName.Text = _brand.Name;
                txtNoiseMax.Text = _brand.NoiseMax.ToString();  
                txtNoiseMin.Text = _brand.NoiseMin.ToString();

                // Tiêu chuẩn tổng phanh
                txtBrakeForceSumMin.Text = _brand.BrakeForceSumMin.ToString();
                txtBrakeForceSumMax.Text = _brand.BrakeForceSumMax.ToString();

                // Tiêu chuẩn xác suất
                txtVoltageDropMin.Text = _brand.VoltageDropMin.ToString();
                txtVoltageDropMax.Text = _brand.VoltageDropMax.ToString();
                txtOverCurrentMin.Text = _brand.OverCurrentMin.ToString();
                txtOverCurrentMax.Text = _brand.OverCurrentMax.ToString();
                txtAxleTorqueFrontMin.Text = _brand.AxleTorqueFrontMin.ToString();
                txtAxleTorqueFrontMax.Text = _brand.AxleTorqueFrontMax.ToString();
                txtAxleTorqueRearMin.Text = _brand.AxleTorqueRearMin.ToString();
                txtAxleTorqueRearMax.Text = _brand.AxleTorqueRearMax.ToString();
                txtAxleTorqueForkMin.Text = _brand.AxleTorqueForkMin.ToString();
                txtAxleTorqueForkMax.Text = _brand.AxleTorqueForkMax.ToString();
                chkHideInspection.Checked = _brand.IsHideInspectionSection;

                // Thông tin xe mặc định
                txtDefaultCertificateNumber.Text = _brand.CertificateNumber ?? "";
                txtDefaultVehicleBrandName.Text = _brand.VehicleBrandName ?? "";
                txtDefaultVehicleColor.Text = _brand.VehicleColor ?? "";

                // Per-direction deviation - HB
                txtHBLeftMin.Text = _brand.LightDeviationLeftMin.ToString();
                txtHBLeftMax.Text = _brand.LightDeviationLeftMax.ToString();
                txtHBRightMin.Text = _brand.LightDeviationRightMin.ToString();
                txtHBRightMax.Text = _brand.LightDeviationRightMax.ToString();
                txtHBUpMin.Text = _brand.LightDeviationUpMin.ToString();
                txtHBUpMax.Text = _brand.LightDeviationUpMax.ToString();
                txtHBDownMin.Text = _brand.LightDeviationDownMin.ToString();
                txtHBDownMax.Text = _brand.LightDeviationDownMax.ToString();

                // Per-direction deviation - LB
                txtLBLeftMin.Text = _brand.NearLightDeviationLeftMin.ToString();
                txtLBLeftMax.Text = _brand.NearLightDeviationLeftMax.ToString();
                txtLBRightMin.Text = _brand.NearLightDeviationRightMin.ToString();
                txtLBRightMax.Text = _brand.NearLightDeviationRightMax.ToString();
                txtLBUpMin.Text = _brand.NearLightDeviationUpMin.ToString();
                txtLBUpMax.Text = _brand.NearLightDeviationUpMax.ToString();
                txtLBDownMin.Text = _brand.NearLightDeviationDownMin.ToString();
                txtLBDownMax.Text = _brand.NearLightDeviationDownMax.ToString();
            }
        }

        private void FrmThresholeSetting_Load(object sender, EventArgs e)
        { 
            // Bật scrollbar cho panel39
            panel39.AutoScroll = true;

            // Đổi panel1 từ Fill sang Top + chiều cao cố định để scrollbar hoạt động
            panel1.Dock = DockStyle.Top;
            panel1.Height = 700;

            CreateExtraSettingsPanel();
            SetupDeviationUI();
        }

        private void SetupDeviationUI()
        {
            var labelFont = new Font("Microsoft Sans Serif", 13F);
            var textFont = new Font("Microsoft Sans Serif", 13F);
            var headerFont = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);

            // Lấy textbox cường độ sáng ra khỏi parent trước khi clear
            ExtractFromParent(txtLongRangeLightIntensityMin);
            ExtractFromParent(txtLongRangeLightIntensityMax);
            ExtractFromParent(txtLongRangeNearLightIntensityMin);
            ExtractFromParent(txtLongRangeNearLightIntensityMax);

            // === Rebuild panel2 (Đèn pha) ===
            panel2.Controls.Clear();
            RebuildLightPanel(panel2, "Đèn pha",
                txtLongRangeLightIntensityMin, txtLongRangeLightIntensityMax,
                txtHBLeftMin, txtHBLeftMax, txtHBRightMin, txtHBRightMax,
                txtHBUpMin, txtHBUpMax, txtHBDownMin, txtHBDownMax,
                labelFont, textFont, headerFont);

            // === Rebuild panel9 (Đèn cốt) ===
            panel9.Controls.Clear();
            RebuildLightPanel(panel9, "Đèn cốt",
                txtLongRangeNearLightIntensityMin, txtLongRangeNearLightIntensityMax,
                txtLBLeftMin, txtLBLeftMax, txtLBRightMin, txtLBRightMax,
                txtLBUpMin, txtLBUpMax, txtLBDownMin, txtLBDownMax,
                labelFont, textFont, headerFont);
        }

        private void ExtractFromParent(Control ctrl)
        {
            if (ctrl.Parent != null)
                ctrl.Parent.Controls.Remove(ctrl);
        }

        private void RebuildLightPanel(Panel container, string title,
            TextBox intensityMin, TextBox intensityMax,
            TextBox leftMin, TextBox leftMax,
            TextBox rightMin, TextBox rightMax,
            TextBox upMin, TextBox upMax,
            TextBox downMin, TextBox downMax,
            Font labelFont, Font textFont, Font headerFont)
        {
            container.BorderStyle = BorderStyle.FixedSingle;

            // Header
            var header = new Label
            {
                Text = title,
                Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(200, 50, 50),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Main table
            var table = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 8
            };
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            for (int i = 0; i < 8; i++)
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));

            int row = 0;

            // Row 0: Cường độ sáng xa min
            table.Controls.Add(MakeLabel("Cường độ sáng xa min", labelFont), 0, row);
            ConfigTextBox(intensityMin, textFont);
            table.Controls.Add(intensityMin, 1, row);
            table.SetColumnSpan(intensityMin, 2);
            row++;

            // Row 1: Cường độ sáng xa max
            table.Controls.Add(MakeLabel("Cường độ sáng xa max", labelFont), 0, row);
            ConfigTextBox(intensityMax, textFont);
            table.Controls.Add(intensityMax, 1, row);
            table.SetColumnSpan(intensityMax, 2);
            row++;

            // Row 2: Sub-header
            var subHdr = MakeLabel("Độ lệch (mm/10m)", headerFont);
            subHdr.BackColor = Color.LightSteelBlue;
            table.Controls.Add(subHdr, 0, row);
            var minHdr = MakeLabel("Min", headerFont);
            minHdr.BackColor = Color.LightSteelBlue;
            minHdr.TextAlign = ContentAlignment.MiddleCenter;
            table.Controls.Add(minHdr, 1, row);
            var maxHdr = MakeLabel("Max", headerFont);
            maxHdr.BackColor = Color.LightSteelBlue;
            maxHdr.TextAlign = ContentAlignment.MiddleCenter;
            table.Controls.Add(maxHdr, 2, row);
            row++;

            // Row 3-6: Deviation rows
            AddDevRow(table, row++, "Đổi độ lệch đèn trái (mm/10m)", leftMin, leftMax, labelFont, textFont);
            AddDevRow(table, row++, "Đổi độ lệch đèn phải (mm/10m)", rightMin, rightMax, labelFont, textFont);
            AddDevRow(table, row++, "Đổi độ lệch đèn trên (mm/10m)", upMin, upMax, labelFont, textFont);
            AddDevRow(table, row++, "Đổi độ lệch đèn dưới (mm/10m)", downMin, downMax, labelFont, textFont);

            // Thêm vào container (table fill, header top)
            container.Controls.Add(table);
            container.Controls.Add(header);
        }

        private Label MakeLabel(string text, Font font)
        {
            return new Label
            {
                Text = text,
                Font = font,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
        }

        private void ConfigTextBox(TextBox txt, Font font)
        {
            txt.Font = font;
            txt.Dock = DockStyle.Fill;
            txt.TextAlign = HorizontalAlignment.Right;
            txt.BorderStyle = BorderStyle.FixedSingle;
        }

        private void AddDevRow(TableLayoutPanel table, int row, string label,
            TextBox minTxt, TextBox maxTxt, Font labelFont, Font textFont)
        {
            table.Controls.Add(MakeLabel(label, labelFont), 0, row);
            ConfigTextBox(minTxt, textFont);
            table.Controls.Add(minTxt, 1, row);
            ConfigTextBox(maxTxt, textFont);
            table.Controls.Add(maxTxt, 2, row);
        }

        private void CreateExtraSettingsPanel()
        {
            // Tạo panel mới cho các thiết lập bổ sung
            var extraPanel = new Panel();
            extraPanel.Dock = DockStyle.Bottom;
            extraPanel.Height = 340;
            extraPanel.BorderStyle = BorderStyle.FixedSingle;

            var extraTable = new TableLayoutPanel();
            extraTable.Dock = DockStyle.Fill;
            extraTable.ColumnCount = 4;
            extraTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            extraTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            extraTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            extraTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            extraTable.RowCount = 12;
            for (int i = 0; i < 12; i++)
                extraTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));

            var headerFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            var labelFont = new Font("Microsoft Sans Serif", 10F);
            var textFont = new Font("Microsoft Sans Serif", 10F);

            // Header: Tiêu chuẩn tổng phanh
            var headerBrake = new Label { Text = "Tiêu chuẩn tổng phanh", Font = headerFont, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, BackColor = Color.LightSteelBlue };
            extraTable.Controls.Add(headerBrake, 0, 0);
            extraTable.SetColumnSpan(headerBrake, 4);

            AddSettingRow(extraTable, 1, "Tổng phanh min", txtBrakeForceSumMin, "Tổng phanh max", txtBrakeForceSumMax, labelFont, textFont);

            // Header: Tiêu chuẩn kiểm tra xác suất
            var headerProb = new Label { Text = "Tiêu chuẩn kiểm tra xác suất", Font = headerFont, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, BackColor = Color.LightSteelBlue };
            extraTable.Controls.Add(headerProb, 0, 2);
            extraTable.SetColumnSpan(headerProb, 4);

            AddSettingRow(extraTable, 3, "Sụt áp min", txtVoltageDropMin, "Sụt áp max", txtVoltageDropMax, labelFont, textFont);
            AddSettingRow(extraTable, 4, "Quá dòng min", txtOverCurrentMin, "Quá dòng max", txtOverCurrentMax, labelFont, textFont);
            AddSettingRow(extraTable, 5, "Lực siết trục trước min", txtAxleTorqueFrontMin, "Lực siết trục trước max", txtAxleTorqueFrontMax, labelFont, textFont);
            AddSettingRow(extraTable, 6, "Lực siết trục sau min", txtAxleTorqueRearMin, "Lực siết trục sau max", txtAxleTorqueRearMax, labelFont, textFont);
            AddSettingRow(extraTable, 7, "Lực siết trục càng min", txtAxleTorqueForkMin, "Lực siết trục càng max", txtAxleTorqueForkMax, labelFont, textFont);

            // Header: Thông tin xe mặc định
            var headerVehicle = new Label { Text = "Thông tin xe mặc định", Font = headerFont, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft, BackColor = Color.LightSteelBlue };
            extraTable.Controls.Add(headerVehicle, 0, 8);
            extraTable.SetColumnSpan(headerVehicle, 4);

            AddFullWidthRow(extraTable, 9, "Số GCNR:", txtDefaultCertificateNumber, labelFont, textFont);
            AddFullWidthRow(extraTable, 10, "Nhãn hiệu:", txtDefaultVehicleBrandName, labelFont, textFont);
            AddFullWidthRow(extraTable, 11, "Màu sắc:", txtDefaultVehicleColor, labelFont, textFont);

            // Checkbox ẩn/hiện kiểm tra xác suất
            chkHideInspection.Text = "Ẩn phần kiểm tra xác suất";
            chkHideInspection.Font = labelFont;
            chkHideInspection.Dock = DockStyle.Fill;
            chkHideInspection.TextAlign = ContentAlignment.MiddleLeft;

            chkHideInspection.CheckedChanged += (sender, e) =>
            {
                ToggleInspectionSectionVisibility(extraTable, extraPanel, !chkHideInspection.Checked);
            };

            extraPanel.Controls.Add(extraTable);

            // Add checkbox below table in a separate row
            var checkPanel = new Panel();
            checkPanel.Dock = DockStyle.Bottom;
            checkPanel.Height = 25;
            checkPanel.Controls.Add(chkHideInspection);
            extraPanel.Controls.Add(checkPanel);

            this.panel39.Controls.Add(extraPanel);

            // Apply initial state
            ToggleInspectionSectionVisibility(extraTable, extraPanel, !chkHideInspection.Checked);
        }

        private void ToggleInspectionSectionVisibility(TableLayoutPanel extraTable, Panel extraPanel, bool show)
        {
            foreach (Control ctrl in extraTable.Controls)
            {
                int row = extraTable.GetRow(ctrl);
                if (row >= 2 && row <= 7)
                {
                    ctrl.Visible = show;
                }
            }

            for (int i = 2; i <= 7; i++)
            {
                extraTable.RowStyles[i].Height = show ? 25F : 0F;
            }

            extraPanel.Height = show ? 340 : 190;
        }

        private void AddSettingRow(TableLayoutPanel table, int row, string label1Text, TextBox txt1, string label2Text, TextBox txt2, Font labelFont, Font textFont)
        {
            var lbl1 = new Label { Text = label1Text, Font = labelFont, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            txt1.Font = textFont;
            txt1.Dock = DockStyle.Fill;
            txt1.TextAlign = HorizontalAlignment.Right;
            txt1.BorderStyle = BorderStyle.FixedSingle;

            var lbl2 = new Label { Text = label2Text, Font = labelFont, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            txt2.Font = textFont;
            txt2.Dock = DockStyle.Fill;
            txt2.TextAlign = HorizontalAlignment.Right;
            txt2.BorderStyle = BorderStyle.FixedSingle;

            table.Controls.Add(lbl1, 0, row);
            table.Controls.Add(txt1, 1, row);
            table.Controls.Add(lbl2, 2, row);
            table.Controls.Add(txt2, 3, row);
        }

        private void AddFullWidthRow(TableLayoutPanel table, int row, string labelText, TextBox txt, Font labelFont, Font textFont)
        {
            var lbl = new Label { Text = labelText, Font = labelFont, Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
            txt.Font = textFont;
            txt.Dock = DockStyle.Fill;
            txt.BorderStyle = BorderStyle.FixedSingle;

            table.Controls.Add(lbl, 0, row);
            table.Controls.Add(txt, 1, row);
            table.SetColumnSpan(txt, 3);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtBrandName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại xe");
                return;
            }
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    Brand brand = null;
                    if (_brand == null)
                        brand = new Brand();
                    else
                        brand = dbContext.Brands.FirstOrDefault(x => x.Id == _brand.Id);
                    
                    if (brand == null)
                    {
                        MessageBox.Show("Không tìm thấy loại xe trong cơ sở dữ liệu.");
                        return;
                    }

                    brand.LightDeviationLRMax = ToFloat(txtLightDeviationLRMax.Text);
                    brand.LightDeviationLRMin = ToFloat(txtLightDeviationLRMin.Text);
                    brand.LightDeviationUDMax = ToFloat(txtLightDeviationUDMax.Text);
                    brand.LightDeviationUDMin = ToFloat(txtLightDeviationUDMin.Text);
                    brand.LongRangeLightIntensityMax = ToFloat(txtLongRangeLightIntensityMax.Text);
                    brand.LongRangeLightIntensityMin = ToFloat(txtLongRangeLightIntensityMin.Text);

                    brand.NearLightDeviationLRMax = ToFloat(txtNearLightDeviationLRMax.Text);
                    brand.NearLightDeviationLRMin = ToFloat(txtNearLightDeviationLRMin.Text);
                    brand.NearLightDeviationUDMax = ToFloat(txtNearLightDeviationUDMax.Text);
                    brand.NearLightDeviationUDMin = ToFloat(txtNearLightDeviationUDMin.Text);
                    brand.LongRangeNearLightIntensityMax = ToFloat(txtLongRangeNearLightIntensityMax.Text);
                    brand.LongRangeNearLightIntensityMin = ToFloat(txtLongRangeNearLightIntensityMin.Text);

                    brand.BrakeForceFrontMin = ToFloat(txtBrakeForceFrontMin.Text);
                    brand.BrakeForceFrontMax = ToFloat(txtBrakeForceFrontMax.Text);

                    brand.BrakeForceRearMin = ToFloat(txtBrakeForceRearMin.Text);
                    brand.BrakeForceRearMax = ToFloat(txtBrakeForceRearMax.Text);

                    brand.WeightFrontMin = ToFloat(txtWeightFrontMin.Text);
                    brand.WeightFrontMax = ToFloat(txtWeightFrontMax.Text);

                    brand.WeightRearMin = ToFloat(txtWeightRearMin.Text);
                    brand.WeightRearMax = ToFloat(txtWeightRearMax.Text);

                    brand.COMin = ToFloat(txtCOMin.Text);
                    brand.COMax = ToFloat(txtCOMax.Text);
                    brand.HCMin = ToFloat(txtHCMin.Text);
                    brand.HCMax = ToFloat(txtHCMax.Text);

                    brand.SpeedMin = ToFloat(txtSpeedMin.Text);
                    brand.SpeedMax = ToFloat(txtSpeedMax.Text);

                    brand.SlideSlipMin = ToFloat(txtSlideSlipMin.Text);
                    brand.SlideSlipMax = ToFloat(txtSlideSlipMax.Text);

                    brand.WhistleMin = ToFloat(txtWhistleMin.Text);
                    brand.WhistleMax = ToFloat(txtWhistleMax.Text);
                    brand.Type = cboType.Text;
                    brand.ShowRealSpeed = chkShowRealSpeed.Checked ? 1 : 0;
                    brand.Name = txtBrandName.Text;
                    brand.NoiseMin = ToFloat(txtNoiseMin.Text);
                    brand.NoiseMax = ToFloat(txtNoiseMax.Text);

                    // Tiêu chuẩn tổng phanh
                    brand.BrakeForceSumMin = ToFloat(txtBrakeForceSumMin.Text);
                    brand.BrakeForceSumMax = ToFloat(txtBrakeForceSumMax.Text);

                    // Tiêu chuẩn xác suất
                    brand.VoltageDropMin = ToFloat(txtVoltageDropMin.Text);
                    brand.VoltageDropMax = ToFloat(txtVoltageDropMax.Text);
                    brand.OverCurrentMin = ToFloat(txtOverCurrentMin.Text);
                    brand.OverCurrentMax = ToFloat(txtOverCurrentMax.Text);
                    brand.AxleTorqueFrontMin = ToFloat(txtAxleTorqueFrontMin.Text);
                    brand.AxleTorqueFrontMax = ToFloat(txtAxleTorqueFrontMax.Text);
                    brand.AxleTorqueRearMin = ToFloat(txtAxleTorqueRearMin.Text);
                    brand.AxleTorqueRearMax = ToFloat(txtAxleTorqueRearMax.Text);
                    brand.AxleTorqueForkMin = ToFloat(txtAxleTorqueForkMin.Text);
                    brand.AxleTorqueForkMax = ToFloat(txtAxleTorqueForkMax.Text);
                    brand.HideInspectionSection = chkHideInspection.Checked ? 1 : 0;

                    // Thông tin xe mặc định
                    brand.CertificateNumber = txtDefaultCertificateNumber.Text.Trim();
                    brand.VehicleBrandName = txtDefaultVehicleBrandName.Text.Trim();
                    brand.VehicleColor = txtDefaultVehicleColor.Text.Trim();

                    // Per-direction deviation - HB
                    brand.LightDeviationLeftMin = ToFloat(txtHBLeftMin.Text);
                    brand.LightDeviationLeftMax = ToFloat(txtHBLeftMax.Text);
                    brand.LightDeviationRightMin = ToFloat(txtHBRightMin.Text);
                    brand.LightDeviationRightMax = ToFloat(txtHBRightMax.Text);
                    brand.LightDeviationUpMin = ToFloat(txtHBUpMin.Text);
                    brand.LightDeviationUpMax = ToFloat(txtHBUpMax.Text);
                    brand.LightDeviationDownMin = ToFloat(txtHBDownMin.Text);
                    brand.LightDeviationDownMax = ToFloat(txtHBDownMax.Text);

                    // Per-direction deviation - LB
                    brand.NearLightDeviationLeftMin = ToFloat(txtLBLeftMin.Text);
                    brand.NearLightDeviationLeftMax = ToFloat(txtLBLeftMax.Text);
                    brand.NearLightDeviationRightMin = ToFloat(txtLBRightMin.Text);
                    brand.NearLightDeviationRightMax = ToFloat(txtLBRightMax.Text);
                    brand.NearLightDeviationUpMin = ToFloat(txtLBUpMin.Text);
                    brand.NearLightDeviationUpMax = ToFloat(txtLBUpMax.Text);
                    brand.NearLightDeviationDownMin = ToFloat(txtLBDownMin.Text);
                    brand.NearLightDeviationDownMax = ToFloat(txtLBDownMax.Text);

                    if (_brand == null)
                        dbContext.Brands.Add(brand);
                    dbContext.SaveChanges();
                    GlobalVariables.InitBrands();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private float ToFloat(string input)
        {
            if (float.TryParse(input, out var value))
                return value;

            return 0f; // tránh Crash
        }
    }
}
