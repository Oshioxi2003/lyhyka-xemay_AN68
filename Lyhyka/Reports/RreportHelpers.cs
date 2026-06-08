using Lyhyka.Core;
using Lyhyka.DBCore;
using Lyhyka.RS232;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyhyka.Reports
{
    public class RreportHelpers
    {
        public static DataTable GetVehicleReportData(TestVehicle testData, Brand brand)
        {
            // Tạo DataTable để chứa dữ liệu báo cáo
            DataTable reportDataTable = new DataTable();

            reportDataTable.Columns.Add("PublishSeri", typeof(string));
            reportDataTable.Columns.Add("PublishVer", typeof(string));
            reportDataTable.Columns.Add("PublishDate", typeof(string));
            // Thêm các cột cho báo cáo
            reportDataTable.Columns.Add("SerialNumber", typeof(string));
            reportDataTable.Columns.Add("FrameNumber", typeof(string));
            reportDataTable.Columns.Add("VehicleType", typeof(string));
            reportDataTable.Columns.Add("Inspector", typeof(string));
            reportDataTable.Columns.Add("InspectionDate", typeof(string));
            reportDataTable.Columns.Add("Fuel", typeof(bool));
            reportDataTable.Columns.Add("Company", typeof(string));
            reportDataTable.Columns.Add("ImagePath", typeof(string));
            reportDataTable.Columns.Add("ImageVisible", typeof(int));

            // Thông tin bổ sung header
            reportDataTable.Columns.Add("CertificateNumber", typeof(string));
            reportDataTable.Columns.Add("VehicleBrandName", typeof(string));
            reportDataTable.Columns.Add("VehicleColor", typeof(string));
            reportDataTable.Columns.Add("ReportSequence", typeof(string));

            reportDataTable.Columns.Add("Speed", typeof(decimal));
            reportDataTable.Columns.Add("RealSpeed", typeof(decimal));
            reportDataTable.Columns.Add("MinSpeed", typeof(decimal));
            reportDataTable.Columns.Add("MaxSpeed", typeof(decimal));

            reportDataTable.Columns.Add("SideSlip", typeof(decimal));
            reportDataTable.Columns.Add("MinSideSlip", typeof(decimal));
            reportDataTable.Columns.Add("MaxSideSlip", typeof(decimal));

            reportDataTable.Columns.Add("Noise", typeof(decimal));
            reportDataTable.Columns.Add("MinNoise", typeof(decimal));
            reportDataTable.Columns.Add("MaxNoise", typeof(decimal));

            reportDataTable.Columns.Add("Whistle", typeof(decimal));
            reportDataTable.Columns.Add("MinWhistle", typeof(decimal));
            reportDataTable.Columns.Add("MaxWhistle", typeof(decimal));

            reportDataTable.Columns.Add("HC", typeof(decimal));
            reportDataTable.Columns.Add("MaxHC", typeof(decimal));

            reportDataTable.Columns.Add("CO", typeof(decimal));
            reportDataTable.Columns.Add("MaxCO", typeof(decimal));

            reportDataTable.Columns.Add("CO2", typeof(decimal));
            reportDataTable.Columns.Add("MaxCO2", typeof(decimal));

            reportDataTable.Columns.Add("O2", typeof(decimal));
            reportDataTable.Columns.Add("MaxO2", typeof(decimal));

            reportDataTable.Columns.Add("NO", typeof(decimal));
            reportDataTable.Columns.Add("MaxNO", typeof(decimal));
            reportDataTable.Columns.Add("OilTemp", typeof(decimal));
            reportDataTable.Columns.Add("RPM", typeof(decimal));

            reportDataTable.Columns.Add("FrontLeftWeight", typeof(decimal));
            reportDataTable.Columns.Add("FrontRightWeight", typeof(decimal));
            reportDataTable.Columns.Add("FrontSumWeight", typeof(decimal));
            reportDataTable.Columns.Add("RearLeftWeight", typeof(decimal));
            reportDataTable.Columns.Add("RearRightWeight", typeof(decimal));
            reportDataTable.Columns.Add("RearSumWeight", typeof(decimal));

            reportDataTable.Columns.Add("FrontLeftBrake", typeof(decimal));
            reportDataTable.Columns.Add("FrontRightBrake", typeof(decimal));
            reportDataTable.Columns.Add("RearLeftBrake", typeof(decimal));
            reportDataTable.Columns.Add("RearRightBrake", typeof(decimal));
            reportDataTable.Columns.Add("HandLeftBrake", typeof(decimal));
            reportDataTable.Columns.Add("HandRightBrake", typeof(decimal));

            reportDataTable.Columns.Add("FrontSumBrake", typeof(decimal));
            reportDataTable.Columns.Add("MinFrontBrake", typeof(string));
            reportDataTable.Columns.Add("RearSumBrake", typeof(decimal));
            reportDataTable.Columns.Add("MinRearBrake", typeof(string));
            reportDataTable.Columns.Add("MainSumBrake", typeof(decimal));
            reportDataTable.Columns.Add("MinSumBrake", typeof(decimal));
            // Tiêu chuẩn tổng phanh
            reportDataTable.Columns.Add("BrakeSumStandard", typeof(string));

            reportDataTable.Columns.Add("FrontDiffBrake", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffFrontBrake", typeof(decimal));
            reportDataTable.Columns.Add("RearDiffBrake", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffRearBrake", typeof(decimal));
            reportDataTable.Columns.Add("HandSumBrake", typeof(decimal));
            reportDataTable.Columns.Add("MinHandBrake", typeof(decimal));
            reportDataTable.Columns.Add("HandDiffBrake", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffHandBrake", typeof(decimal));

            reportDataTable.Columns.Add("FrontBrakeEff", typeof(decimal));
            reportDataTable.Columns.Add("RearBrakeEff", typeof(decimal));
            reportDataTable.Columns.Add("SumBrakeEff", typeof(decimal));
            reportDataTable.Columns.Add("HandBrakeEff", typeof(decimal));

            reportDataTable.Columns.Add("LHLIntensity", typeof(decimal));
            reportDataTable.Columns.Add("RHLIntensity", typeof(decimal));
            reportDataTable.Columns.Add("MinHLIntensity", typeof(decimal));
            reportDataTable.Columns.Add("MaxHBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("LHLVertical", typeof(decimal));
            reportDataTable.Columns.Add("RHLVertical", typeof(decimal));
            reportDataTable.Columns.Add("MinDiffVertiHB", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffVertiHB", typeof(decimal));
            reportDataTable.Columns.Add("LHLHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("RHLHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("MinDiffHoriHB", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffHoriHB", typeof(decimal));
            reportDataTable.Columns.Add("LLBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("RLBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("MinLBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("MaxLBIntensity", typeof(decimal));
            reportDataTable.Columns.Add("LLBVertical", typeof(decimal));
            reportDataTable.Columns.Add("RLBVertical", typeof(decimal));
            reportDataTable.Columns.Add("MinDiffVertiLB", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffVertiLB", typeof(decimal));
            reportDataTable.Columns.Add("LLBHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("RLBHorizontal", typeof(decimal));
            reportDataTable.Columns.Add("MinDiffHoriLB", typeof(decimal));
            reportDataTable.Columns.Add("MaxDiffHoriLB", typeof(decimal));

            reportDataTable.Columns.Add("HBIntensityRange", typeof(string));
            reportDataTable.Columns.Add("LBIntensityRange", typeof(string));
            reportDataTable.Columns.Add("LightDeviationUDMinMax", typeof(string));
            reportDataTable.Columns.Add("LightDeviationLRMinMax", typeof(string));
            reportDataTable.Columns.Add("NearLightDeviationUDMinMax", typeof(string));
            reportDataTable.Columns.Add("NearLightDeviationLRMinMax", typeof(string));

            // Split L/R and U/D deviation standards cho đèn chiếu xa
            reportDataTable.Columns.Add("HBDeviationLRLeft", typeof(string));
            reportDataTable.Columns.Add("HBDeviationLRRight", typeof(string));
            reportDataTable.Columns.Add("HBDeviationUDUp", typeof(string));
            reportDataTable.Columns.Add("HBDeviationUDDown", typeof(string));
            // Split L/R and U/D deviation standards cho đèn chiếu gần
            reportDataTable.Columns.Add("LBDeviationLRLeft", typeof(string));
            reportDataTable.Columns.Add("LBDeviationLRRight", typeof(string));
            reportDataTable.Columns.Add("LBDeviationUDUp", typeof(string));
            reportDataTable.Columns.Add("LBDeviationUDDown", typeof(string));


            reportDataTable.Columns.Add("MinSpeed1", typeof(decimal));
            reportDataTable.Columns.Add("MaxSpeed1", typeof(decimal));
            reportDataTable.Columns.Add("HSU1", typeof(decimal));
            reportDataTable.Columns.Add("MinSpeed2", typeof(decimal));
            reportDataTable.Columns.Add("MaxSpeed2", typeof(decimal));
            reportDataTable.Columns.Add("HSU2", typeof(decimal));
            reportDataTable.Columns.Add("MinSpeed3", typeof(decimal));
            reportDataTable.Columns.Add("MaxSpeed3", typeof(decimal));
            reportDataTable.Columns.Add("HSU3", typeof(decimal));
            reportDataTable.Columns.Add("AvgHSU", typeof(decimal));
            reportDataTable.Columns.Add("MaxHSU", typeof(decimal));

            reportDataTable.Columns.Add("LeftSteerLW", typeof(decimal));
            reportDataTable.Columns.Add("LeftSteerRW", typeof(decimal));
            reportDataTable.Columns.Add("MinLeftSteer", typeof(decimal));
            reportDataTable.Columns.Add("MaxLeftSteer", typeof(decimal));
            reportDataTable.Columns.Add("RightSteerLW", typeof(decimal));
            reportDataTable.Columns.Add("RightSteerRW", typeof(decimal));
            reportDataTable.Columns.Add("MinRightSteer", typeof(decimal));
            reportDataTable.Columns.Add("MaxRightSteer", typeof(decimal));

            reportDataTable.Columns.Add("MinLightHeight", typeof(decimal));


            reportDataTable.Columns.Add("VoltageDrop", typeof(decimal));
            reportDataTable.Columns.Add("VoltageDrop1", typeof(decimal));
            reportDataTable.Columns.Add("OverCurrent", typeof(decimal));
            reportDataTable.Columns.Add("AxleTorqueFront", typeof(decimal));
            reportDataTable.Columns.Add("AxleTorqueRear", typeof(decimal));
            reportDataTable.Columns.Add("AxleTorqueFork", typeof(decimal));

            // Tiêu chuẩn xác suất
            reportDataTable.Columns.Add("VoltageDropStandard", typeof(string));
            reportDataTable.Columns.Add("OverCurrentStandard", typeof(string));
            reportDataTable.Columns.Add("AxleTorqueFrontStandard", typeof(string));
            reportDataTable.Columns.Add("AxleTorqueRearStandard", typeof(string));
            reportDataTable.Columns.Add("AxleTorqueForkStandard", typeof(string));

            // Kết quả xác suất
            reportDataTable.Columns.Add("VoltageDropResult", typeof(bool));
            reportDataTable.Columns.Add("OverCurrentResult", typeof(bool));
            reportDataTable.Columns.Add("AxleTorqueFrontResult", typeof(bool));
            reportDataTable.Columns.Add("AxleTorqueRearResult", typeof(bool));
            reportDataTable.Columns.Add("AxleTorqueForkResult", typeof(bool));

            reportDataTable.Columns.Add("SideSlipResult", typeof(bool));
            reportDataTable.Columns.Add("BrakeResult", typeof(bool));
            reportDataTable.Columns.Add("BrakeSumResult", typeof(bool));
            reportDataTable.Columns.Add("BrakeFrontResult", typeof(bool));
            reportDataTable.Columns.Add("BrakeRearResult", typeof(bool));
            reportDataTable.Columns.Add("SteerAngleResult", typeof(bool));
            reportDataTable.Columns.Add("SpeedResult", typeof(bool));
            reportDataTable.Columns.Add("PetrolResult", typeof(bool));
            reportDataTable.Columns.Add("DieselResult", typeof(bool));
            reportDataTable.Columns.Add("HLResult", typeof(bool));
            reportDataTable.Columns.Add("HBResult", typeof(bool));
            reportDataTable.Columns.Add("LBResult", typeof(bool));
            reportDataTable.Columns.Add("HBIntensityResult", typeof(bool));
            reportDataTable.Columns.Add("HBLRResult", typeof(bool));
            reportDataTable.Columns.Add("HBUDResult", typeof(bool));
            reportDataTable.Columns.Add("LBIntensityResult", typeof(bool));
            reportDataTable.Columns.Add("LBLRResult", typeof(bool));
            reportDataTable.Columns.Add("LBUDResult", typeof(bool));
            reportDataTable.Columns.Add("NoiseResult", typeof(bool));
            reportDataTable.Columns.Add("WhistleResult", typeof(bool));

            reportDataTable.Columns.Add("FinalResult", typeof(bool));
            reportDataTable.Columns.Add("HeadlightUnit", typeof(string));

            reportDataTable.Columns.Add("ShowLowBeamLightIntensity", typeof(int));
            reportDataTable.Columns.Add("ShowLowBeamLightDeviationLR", typeof(int));
            reportDataTable.Columns.Add("ShowRealSpeed", typeof(int));
            reportDataTable.Columns.Add("HideInspectionSection", typeof(int));

            // Gọi hàm GetVehicleStandardsByTypeCar để lấy tiêu chuẩn theo loại xe
            string vehicleType = brand.Name;
            string company = ConfigurationManager.AppSettings["Company"];
            string imagePath = ConfigurationManager.AppSettings["ImagePath"];
            // Thêm dữ liệu vào DataTable
            DataRow reportRow = reportDataTable.NewRow();
            reportRow["Company"] = company;
             
            if (!string.IsNullOrEmpty(imagePath))
            {
                reportRow["ImagePath"] = new Uri(imagePath).AbsoluteUri;
                reportRow["ImageVisible"] = 1;
            }
            else
            {
                reportRow["ImagePath"] = "";
                reportRow["ImageVisible"] = 0;
            }

            reportRow["SerialNumber"] = testData.EngineNumber;
            reportRow["FrameNumber"] = testData.FrameNumber;
            reportRow["VehicleType"] = vehicleType;
            reportRow["Inspector"] = testData.Tester;

            // Thông tin bổ sung header (ưu tiên TestVehicle, fallback về Brand)
            reportRow["CertificateNumber"] = !string.IsNullOrEmpty(testData.CertificateNumber) ? testData.CertificateNumber : (brand.CertificateNumber ?? "");
            reportRow["VehicleBrandName"] = !string.IsNullOrEmpty(testData.VehicleBrandName) ? testData.VehicleBrandName : (brand.VehicleBrandName ?? "");
            reportRow["VehicleColor"] = !string.IsNullOrEmpty(testData.VehicleColor) ? testData.VehicleColor : (brand.VehicleColor ?? "");
            reportRow["ReportSequence"] = GetNextReportSequence();

            DateTime localDateTime = DateTimeOffset.FromUnixTimeSeconds(testData.TestedDate).LocalDateTime;
            reportRow["InspectionDate"] = localDateTime.ToString("dd/MM/yyyy HH:mm");
            reportRow["Speed"] = ConvertToDecimal(testData.Speed).ToString("F1");
            reportRow["RealSpeed"] = ConvertToDecimal(testData.RealSpeed).ToString("F1");
            reportRow["MinSpeed"] = ConvertToDecimal(brand.SpeedMin).ToString("F1");
            reportRow["MaxSpeed"] = ConvertToDecimal(brand.SpeedMax).ToString("F1");

            reportRow["SideSlip"] = ConvertToDecimal(testData.SlideSlip).ToString("F1");
            reportRow["MinSideSlip"] = ConvertToDecimal(brand.SlideSlipMin).ToString("F1");
            reportRow["MaxSideSlip"] = ConvertToDecimal(brand.SlideSlipMax).ToString("F1");

            reportRow["Whistle"] = ConvertToDecimal(testData.Whistle).ToString("F1");
            reportRow["Noise"] = ConvertToDecimal(testData.Noise).ToString("F1");
            
            //reportRow["MinWhistle"] = ConvertToDecimal(brand.wi).ToString("F1");

            reportRow["FrontLeftWeight"] = testData.WeightFront.ToString("F0");
            reportRow["RearLeftWeight"] = testData.WeightRear.ToString("F0");
            reportRow["FrontSumWeight"] = (testData.WeightFront + testData.WeightRear).ToString("F0");
            reportRow["FrontLeftBrake"] = testData.BrakeForceFront.ToString("F0");
            reportRow["RearLeftBrake"] = testData.BrakeForceRear.ToString("F0");
            reportRow["MinFrontBrake"] = GlobalFunctions.FormatRange(brand.BrakeForceFrontMax, null, "F0"); 
            reportRow["MinRearBrake"] = GlobalFunctions.FormatRange(brand.BrakeForceRearMax, null, "F0");
            reportRow["FrontDiffBrake"] = (testData.BrakeForceFront - testData.BrakeForceRear).ToString("F0");
            // Tính trung bình lực phanh thay vì tổng
            decimal avgBrake = ((decimal)testData.BrakeForceFront + (decimal)testData.BrakeForceRear) / 2;
            reportRow["FrontSumBrake"] = avgBrake.ToString("F0");
            // Tiêu chuẩn tổng phanh
            reportRow["BrakeSumStandard"] = GlobalFunctions.FormatRange(brand.BrakeForceSumMax, null, "F0");

            // Pha
            reportRow["LHLIntensity"] = testData.LongRangeLightIntensity.ToString("F1");
            reportRow["LHLVertical"] = GlobalVariables.HeadLightUnitIsPercentage ? (testData.LightDeviationUD / 100).ToString("F1") : testData.LightDeviationUD.ToString("F1");
            reportRow["LHLHorizontal"] = GlobalVariables.HeadLightUnitIsPercentage ? (testData.LightDeviationLR / 100).ToString("F1") : testData.LightDeviationLR.ToString("F1");

            // Cốt
            reportRow["LLBIntensity"] = testData.LongRangeNearLightIntensity.ToString("F1");
            reportRow["LLBVertical"] = GlobalVariables.HeadLightUnitIsPercentage ? (testData.NearLightDeviationUD / 100).ToString("F1") : testData.NearLightDeviationUD.ToString("F1");
            reportRow["LLBHorizontal"] = GlobalVariables.HeadLightUnitIsPercentage ? (testData.NearLightDeviationLR / 100).ToString("F1") : testData.NearLightDeviationLR.ToString("F1");


            reportRow["MinWhistle"] = brand.WhistleMin.ToString("F1");
            reportRow["MaxWhistle"] = brand.WhistleMax.ToString("F1");
            reportRow["MinNoise"] = brand.NoiseMin.ToString("F1");
            reportRow["MaxNoise"] = brand.NoiseMax.ToString("F1");


            reportRow["VoltageDrop"] = testData.VoltageDrop.ToString("F1");
            reportRow["VoltageDrop1"] = testData.VoltageDrop1.Value.ToString("F1");
            reportRow["OverCurrent"] = testData.OverCurrent.ToString("F1");
            reportRow["AxleTorqueFront"] = testData.AxleTorqueFront.ToString("F1");
            reportRow["AxleTorqueRear"] = testData.AxleTorqueRear.ToString("F1");
            reportRow["AxleTorqueFork"] = testData.AxleTorqueFork.ToString("F1");

            // Tiêu chuẩn xác suất
            reportRow["VoltageDropStandard"] = GlobalFunctions.FormatRange(brand.VoltageDropMin, brand.VoltageDropMax, "F0");
            reportRow["OverCurrentStandard"] = GlobalFunctions.FormatRange(brand.OverCurrentMin, brand.OverCurrentMax, "F0");
            reportRow["AxleTorqueFrontStandard"] = GlobalFunctions.FormatRange(brand.AxleTorqueFrontMin, brand.AxleTorqueFrontMax, "F0");
            reportRow["AxleTorqueRearStandard"] = GlobalFunctions.FormatRange(brand.AxleTorqueRearMin, brand.AxleTorqueRearMax, "F0");
            reportRow["AxleTorqueForkStandard"] = GlobalFunctions.FormatRange(brand.AxleTorqueForkMin, brand.AxleTorqueForkMax, "F0");

            reportRow["CO"] = testData.CO.ToString("F1");
            reportRow["HC"] = testData.HC.ToString("F1");
            reportRow["OilTemp"] = testData.OilTemperature.ToString("F1");
            reportRow["RPM"] = testData.RPM.ToString("F1");

            reportRow["MaxHC"] = brand.HCMax.ToString("F1");
            reportRow["MaxCO"] = brand.COMax.ToString("F1");


            reportRow["HeadlightUnit"] = GlobalVariables.HeadLightUnitIsPercentage ? "%" : "mm/10m";
            reportRow["ShowLowBeamLightIntensity"] = RS232Manager.ShowLowBeamLightIntensity ? 0 : 1;
            reportRow["ShowLowBeamLightDeviationLR"] = RS232Manager.ShowLowBeamLightDeviationLR ? 0 : 1;
            reportRow["ShowRealSpeed"] = brand.IsShowRealSpeed ? 0 : 1;
            reportRow["HideInspectionSection"] = brand.IsHideInspectionSection ? 1 : 0;

            // Tính toán kết quả cho các phần
            bool sideSlipResult = GlobalFunctions.CheckStandard(testData.SlideSlip, brand.SlideSlipMin, brand.SlideSlipMax);
            bool brakeFrontResult = testData.BrakeForceFront >= brand.BrakeForceFrontMax;
            bool brakeRearResult = testData.BrakeForceRear >= brand.BrakeForceRearMax;
            bool brakeResult = brakeFrontResult && brakeRearResult;
            bool brakeSumResult = (float)avgBrake >= brand.BrakeForceSumMax;
            bool speedResult = GlobalFunctions.CheckStandard(testData.Speed, brand.SpeedMin, brand.SpeedMax);
            bool whistleResult = GlobalFunctions.CheckStandard(testData.Whistle, brand.WhistleMin, brand.WhistleMax);
            bool noiseResult = GlobalFunctions.CheckStandard(testData.Noise, brand.NoiseMin, brand.NoiseMax);


            bool hbIntensityResult = testData.LongRangeLightIntensity >= brand.LongRangeLightIntensityMax;
            bool hbLRResult = CheckLightDeviation(testData.LightDeviationLR, brand.LightDeviationLeftMin, brand.LightDeviationLeftMax, brand.LightDeviationRightMin, brand.LightDeviationRightMax, brand.LightDeviationLRMin, brand.LightDeviationLRMax);
            bool hbUDResult = CheckLightDeviation(testData.LightDeviationUD, brand.LightDeviationUpMin, brand.LightDeviationUpMax, brand.LightDeviationDownMin, brand.LightDeviationDownMax, brand.LightDeviationUDMin, brand.LightDeviationUDMax);
            bool headLightResult = hbIntensityResult && hbLRResult && hbUDResult;

            bool lbIntensityResult = testData.LongRangeNearLightIntensity >= brand.LongRangeNearLightIntensityMax;
            bool lbLRResult = CheckLightDeviation(testData.NearLightDeviationLR, brand.NearLightDeviationLeftMin, brand.NearLightDeviationLeftMax, brand.NearLightDeviationRightMin, brand.NearLightDeviationRightMax, brand.NearLightDeviationLRMin, brand.NearLightDeviationLRMax);
            bool lbUDResult = CheckLightDeviation(testData.NearLightDeviationUD, brand.NearLightDeviationUpMin, brand.NearLightDeviationUpMax, brand.NearLightDeviationDownMin, brand.NearLightDeviationDownMax, brand.NearLightDeviationUDMin, brand.NearLightDeviationUDMax);
            bool nearLighResult = lbIntensityResult && lbLRResult && lbUDResult;
            bool hcResult = GlobalVariables.IsElectricMotorbike ? true : GlobalFunctions.CheckStandard(testData.HC, brand.HCMin, brand.HCMax);
            bool coResult = GlobalVariables.IsElectricMotorbike ? true : GlobalFunctions.CheckStandard(testData.CO, brand.COMin, brand.COMax);

            // Kết quả xác suất
            bool voltageDropResult = GlobalFunctions.CheckStandard(testData.VoltageDrop, brand.VoltageDropMin, brand.VoltageDropMax);
            bool overCurrentResult = GlobalFunctions.CheckStandard(testData.OverCurrent, brand.OverCurrentMin, brand.OverCurrentMax);
            bool axleTorqueFrontResult = GlobalFunctions.CheckStandard(testData.AxleTorqueFront, brand.AxleTorqueFrontMin, brand.AxleTorqueFrontMax);
            bool axleTorqueRearResult = GlobalFunctions.CheckStandard(testData.AxleTorqueRear, brand.AxleTorqueRearMin, brand.AxleTorqueRearMax);
            bool axleTorqueForkResult = GlobalFunctions.CheckStandard(testData.AxleTorqueFork, brand.AxleTorqueForkMin, brand.AxleTorqueForkMax);

            reportRow["SideSlipResult"] = sideSlipResult;
            reportRow["BrakeResult"] = brakeResult;
            reportRow["BrakeSumResult"] = brakeSumResult;
            reportRow["BrakeFrontResult"] = brakeFrontResult;
            reportRow["BrakeRearResult"] = brakeRearResult;
            reportRow["SpeedResult"] = speedResult;
            reportRow["NoiseResult"] = noiseResult;
            reportRow["WhistleResult"] = whistleResult;
            reportRow["HBResult"] = headLightResult;
            reportRow["LBResult"] = nearLighResult;
            reportRow["HBIntensityResult"] = hbIntensityResult;
            reportRow["HBLRResult"] = hbLRResult;
            reportRow["HBUDResult"] = hbUDResult;
            reportRow["LBIntensityResult"] = lbIntensityResult;
            reportRow["LBLRResult"] = lbLRResult;
            reportRow["LBUDResult"] = lbUDResult;

            reportRow["VoltageDropResult"] = voltageDropResult;
            reportRow["OverCurrentResult"] = overCurrentResult;
            reportRow["AxleTorqueFrontResult"] = axleTorqueFrontResult;
            reportRow["AxleTorqueRearResult"] = axleTorqueRearResult;
            reportRow["AxleTorqueForkResult"] = axleTorqueForkResult;

            reportRow["HLResult"] = headLightResult && nearLighResult;
            reportRow["Fuel"] = coResult && hcResult;

            reportRow["HBIntensityRange"] = brand.LongRangeLightIntensityMax.ToString("F0");
            reportRow["LBIntensityRange"] = brand.LongRangeNearLightIntensityMax.ToString("F0");

            if (GlobalVariables.HeadLightUnitIsPercentage)
            {
                if (brand.LightDeviationUpMin == 0 && brand.LightDeviationUpMax == 0 && brand.LightDeviationDownMin == 0 && brand.LightDeviationDownMax == 0)
                {
                    reportRow["LightDeviationUDMinMax"] = GlobalFunctions.FormatRange(brand.LightDeviationUDMin, brand.LightDeviationUDMax, "F0");
                }
                else
                {
                    reportRow["LightDeviationUDMinMax"] = $"U{GlobalFunctions.FormatRange(brand.LightDeviationUpMin, brand.LightDeviationUpMax, "F0")} D{GlobalFunctions.FormatRange(brand.LightDeviationDownMin, brand.LightDeviationDownMax, "F0")}";
                }

                if (brand.LightDeviationLeftMin == 0 && brand.LightDeviationLeftMax == 0 && brand.LightDeviationRightMin == 0 && brand.LightDeviationRightMax == 0)
                {
                    reportRow["LightDeviationLRMinMax"] = GlobalFunctions.FormatRange(brand.LightDeviationLRMin / 100, brand.LightDeviationLRMax / 100, "F0");
                }
                else
                {
                    reportRow["LightDeviationLRMinMax"] = $"L{GlobalFunctions.FormatRange(brand.LightDeviationLeftMin / 100, brand.LightDeviationLeftMax / 100, "F0")} R{GlobalFunctions.FormatRange(brand.LightDeviationRightMin / 100, brand.LightDeviationRightMax / 100, "F0")}";
                }

                if (brand.NearLightDeviationUpMin == 0 && brand.NearLightDeviationUpMax == 0 && brand.NearLightDeviationDownMin == 0 && brand.NearLightDeviationDownMax == 0)
                {
                    reportRow["NearLightDeviationUDMinMax"] = GlobalFunctions.FormatRange(brand.NearLightDeviationUDMin, brand.NearLightDeviationUDMax, "F0");
                }
                else
                {
                    reportRow["NearLightDeviationUDMinMax"] = $"U{GlobalFunctions.FormatRange(brand.NearLightDeviationUpMin, brand.NearLightDeviationUpMax, "F0")} D{GlobalFunctions.FormatRange(brand.NearLightDeviationDownMin, brand.NearLightDeviationDownMax, "F0")}";
                }

                if (brand.NearLightDeviationLeftMin == 0 && brand.NearLightDeviationLeftMax == 0 && brand.NearLightDeviationRightMin == 0 && brand.NearLightDeviationRightMax == 0)
                {
                    reportRow["NearLightDeviationLRMinMax"] = GlobalFunctions.FormatRange(brand.NearLightDeviationLRMin / 100, brand.NearLightDeviationLRMax / 100, "F0");
                }
                else
                {
                    reportRow["NearLightDeviationLRMinMax"] = $"L{GlobalFunctions.FormatRange(brand.NearLightDeviationLeftMin / 100, brand.NearLightDeviationLeftMax / 100, "F0")} R{GlobalFunctions.FormatRange(brand.NearLightDeviationRightMin / 100, brand.NearLightDeviationRightMax / 100, "F0")}";
                }

                // Split deviations - HB
                reportRow["HBDeviationLRLeft"] = FormatSplitRange(brand.LightDeviationLeftMin, brand.LightDeviationLeftMax, "trái");
                reportRow["HBDeviationLRRight"] = FormatSplitRange(brand.LightDeviationRightMin, brand.LightDeviationRightMax, "phải");
                reportRow["HBDeviationUDUp"] = FormatSplitRange(brand.LightDeviationUpMin, brand.LightDeviationUpMax, "trên");
                reportRow["HBDeviationUDDown"] = FormatSplitRange(brand.LightDeviationDownMin, brand.LightDeviationDownMax, "dưới");
                // Split deviations - LB
                reportRow["LBDeviationLRLeft"] = FormatSplitRange(brand.NearLightDeviationLeftMin, brand.NearLightDeviationLeftMax, "trái");
                reportRow["LBDeviationLRRight"] = FormatSplitRange(brand.NearLightDeviationRightMin, brand.NearLightDeviationRightMax, "phải");
                reportRow["LBDeviationUDUp"] = FormatSplitRange(brand.NearLightDeviationUpMin, brand.NearLightDeviationUpMax, "trên");
                reportRow["LBDeviationUDDown"] = FormatSplitRange(brand.NearLightDeviationDownMin, brand.NearLightDeviationDownMax, "dưới");
            }
            else
            {
                if (brand.LightDeviationUpMin == 0 && brand.LightDeviationUpMax == 0 && brand.LightDeviationDownMin == 0 && brand.LightDeviationDownMax == 0)
                {
                    reportRow["LightDeviationUDMinMax"] = GlobalFunctions.FormatRange(brand.LightDeviationUDMin, brand.LightDeviationUDMax, "F0");
                }
                else
                {
                    reportRow["LightDeviationUDMinMax"] = $"U{GlobalFunctions.FormatRange(brand.LightDeviationUpMin, brand.LightDeviationUpMax, "F0")} D{GlobalFunctions.FormatRange(brand.LightDeviationDownMin, brand.LightDeviationDownMax, "F0")}";
                }

                if (brand.LightDeviationLeftMin == 0 && brand.LightDeviationLeftMax == 0 && brand.LightDeviationRightMin == 0 && brand.LightDeviationRightMax == 0)
                {
                    reportRow["LightDeviationLRMinMax"] = GlobalFunctions.FormatRange(brand.LightDeviationLRMin, brand.LightDeviationLRMax, "F0");
                }
                else
                {
                    reportRow["LightDeviationLRMinMax"] = $"L{GlobalFunctions.FormatRange(brand.LightDeviationLeftMin, brand.LightDeviationLeftMax, "F0")} R{GlobalFunctions.FormatRange(brand.LightDeviationRightMin, brand.LightDeviationRightMax, "F0")}";
                }

                if (brand.NearLightDeviationUpMin == 0 && brand.NearLightDeviationUpMax == 0 && brand.NearLightDeviationDownMin == 0 && brand.NearLightDeviationDownMax == 0)
                {
                    reportRow["NearLightDeviationUDMinMax"] = GlobalFunctions.FormatRange(brand.NearLightDeviationUDMin, brand.NearLightDeviationUDMax, "F0");
                }
                else
                {
                    reportRow["NearLightDeviationUDMinMax"] = $"U{GlobalFunctions.FormatRange(brand.NearLightDeviationUpMin, brand.NearLightDeviationUpMax, "F0")} D{GlobalFunctions.FormatRange(brand.NearLightDeviationDownMin, brand.NearLightDeviationDownMax, "F0")}";
                }

                if (brand.NearLightDeviationLeftMin == 0 && brand.NearLightDeviationLeftMax == 0 && brand.NearLightDeviationRightMin == 0 && brand.NearLightDeviationRightMax == 0)
                {
                    reportRow["NearLightDeviationLRMinMax"] = GlobalFunctions.FormatRange(brand.NearLightDeviationLRMin, brand.NearLightDeviationLRMax, "F0");
                }
                else
                {
                    reportRow["NearLightDeviationLRMinMax"] = $"L{GlobalFunctions.FormatRange(brand.NearLightDeviationLeftMin, brand.NearLightDeviationLeftMax, "F0")} R{GlobalFunctions.FormatRange(brand.NearLightDeviationRightMin, brand.NearLightDeviationRightMax, "F0")}";
                }

                // Split deviations - HB
                reportRow["HBDeviationLRLeft"] = FormatSplitRange(brand.LightDeviationLeftMin, brand.LightDeviationLeftMax, "trái");
                reportRow["HBDeviationLRRight"] = FormatSplitRange(brand.LightDeviationRightMin, brand.LightDeviationRightMax, "phải");
                reportRow["HBDeviationUDUp"] = FormatSplitRange(brand.LightDeviationUpMin, brand.LightDeviationUpMax, "trên");
                reportRow["HBDeviationUDDown"] = FormatSplitRange(brand.LightDeviationDownMin, brand.LightDeviationDownMax, "dưới");
                // Split deviations - LB
                reportRow["LBDeviationLRLeft"] = FormatSplitRange(brand.NearLightDeviationLeftMin, brand.NearLightDeviationLeftMax, "trái");
                reportRow["LBDeviationLRRight"] = FormatSplitRange(brand.NearLightDeviationRightMin, brand.NearLightDeviationRightMax, "phải");
                reportRow["LBDeviationUDUp"] = FormatSplitRange(brand.NearLightDeviationUpMin, brand.NearLightDeviationUpMax, "trên");
                reportRow["LBDeviationUDDown"] = FormatSplitRange(brand.NearLightDeviationDownMin, brand.NearLightDeviationDownMax, "dưới");
            }
            if (GlobalVariables.IsElectricMotorbike)
            {
                reportRow["FinalResult"] = sideSlipResult && brakeResult && speedResult && whistleResult && noiseResult && headLightResult && nearLighResult && voltageDropResult && overCurrentResult && axleTorqueFrontResult && axleTorqueRearResult && axleTorqueForkResult;
            }
            else
            {
                reportRow["FinalResult"] = sideSlipResult && brakeResult && speedResult && whistleResult && noiseResult && headLightResult && nearLighResult && coResult && hcResult;
            }
            reportDataTable.Rows.Add(reportRow);


            return reportDataTable;
        }

        /// <summary>
        /// Tạo số thứ tự biên bản theo format YYMMDD-NNN, reset counter mỗi ngày mới
        /// </summary>
        public static string GetNextReportSequence()
        {
            try
            {
                using (var context = new MyDbContext())
                {
                    string today = DateTime.Now.ToString("yyMMdd");
                    var counter = context.ReportCounters.FirstOrDefault(x => x.CounterDate == today);
                    if (counter == null)
                    {
                        counter = new ReportCounter
                        {
                            CounterDate = today,
                            Counter = 1
                        };
                        context.ReportCounters.Add(counter);
                    }
                    else
                    {
                        counter.Counter++;
                    }
                    context.SaveChanges();
                    return $"{today}-{counter.Counter:D3}";
                }
            }
            catch
            {
                return DateTime.Now.ToString("yyMMdd") + "-001";
            }
        }

        /// <summary>
        /// Format split range cho tiêu chuẩn đèn (trái/phải/trên/dưới riêng biệt)
        /// </summary>
        static string FormatSplitRange(float? min, float? max, string label)
        {
            // Khi cả min và max đều = 0 → ẩn (trả về chuỗi rỗng)
            if ((!min.HasValue || min.Value == 0) && (!max.HasValue || max.Value == 0))
                return "";
            return $"{label} {GlobalFunctions.FormatRange(min, max, "F0")}";
        }

        public static bool CheckLightDeviation(float value, float leftOrUpMin, float leftOrUpMax, float rightOrDownMin, float rightOrDownMax, float fallbackMin, float fallbackMax)
        {
            if (leftOrUpMin == 0 && leftOrUpMax == 0 && rightOrDownMin == 0 && rightOrDownMax == 0)
            {
                return GlobalFunctions.CheckStandard(value, fallbackMin, fallbackMax);
            }

            if (value >= 0)
            {
                return value >= leftOrUpMin && value <= leftOrUpMax;
            }
            else
            {
                return Math.Abs(value) >= rightOrDownMin && Math.Abs(value) <= rightOrDownMax;
            }
        }

        static decimal ConvertToDecimal(object value, decimal defaultValue = 0)
        {
            if (value != DBNull.Value && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                return Convert.ToDecimal(value);
            }
            return defaultValue;
        }
    }
}
