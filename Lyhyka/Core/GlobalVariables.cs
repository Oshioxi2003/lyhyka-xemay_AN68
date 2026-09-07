using Lyhyka.DBCore;
using Lyhyka.RS232;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lyhyka.Core
{
    public class GlobalVariables
    {
        public static Action OnSelectedBrandChanged; // Delegate to call the form 
        public static Action OnUpdatedGlobalSettingChanged; // Delegate to call the form 
        public static Action OnLightDataChanged; // Delegate to notify light form when data changes 
        public static Action OnEmissionDataChanged; // Delegate to notify emission UI when data changes 
        public static int SelectedBrandIndex = 0;
        public static bool HeadLightUnitIsPercentage = false;
        public static TestVehicle TestVehicle { set; get; } = new TestVehicle()
        {
            EngineNumber = "",
            FrameNumber = ""
        };
        public static Calibration Calibration { set; get; } 

        public static void UpdateNHA506(NHA506PacketData data)
        {
            if (data == null || TestVehicle == null) return;
            TestVehicle.OilTemperature = data.OT != null ? (float)data.OT.Value : 0;
            TestVehicle.HC = data.HC != null ? (float)data.HC.Value : 0;
            TestVehicle.CO = data.CO != null ? (float)data.CO.Value : 0;
            TestVehicle.CO2 = data.CO2 != null ? (float)data.CO2.Value : 0;
            TestVehicle.O2 = data.O2 != null ? (float)data.O2.Value : 0;
            TestVehicle.NO = data.NO != null ? (float)data.NO.Value : 0;
            TestVehicle.RPM = data.RPM != null ? (float)data.RPM.Value : 0;
            OnEmissionDataChanged?.Invoke();
        } 

        public static float SpeedZero
        {
            get
            {
                if (Calibration != null && Calibration.SpeedZero != null)
                    return (float)Calibration.SpeedZero;
                return 0;
            }
        }
        public static float SlideSlipZero
        {
            get
            {
                if (Calibration != null && Calibration.SlideSlipZero != null)
                    return (float)Calibration.SlideSlipZero;
                return 0;
            }
        }
        public static float BrakeForceZero
        {
            get
            {
                if (Calibration != null && Calibration.BrakeForceZero != null)
                    return (float)Calibration.BrakeForceZero;
                return 0;
            }
        }
        public static void RefreshVin()
        {
            //TestVehicle.EngineNumber = "";
            //TestVehicle.FrameNumber = "";
        }
        public static List<Admin> Admins { set; get; }
        public static List<Brand> Brands { set; get; }
        public static Brand SelectedBrand { set; get; } = new Brand()
        {

        };
        public static bool IsElectricMotorbike
        {
            get
            {
                return RemoveVietnameseSigns(SelectedBrand.Type.ToLower()).Contains("dien");
            }
        }
        public static void Inits()
        {
            HeadLightUnitIsPercentage = Properties.Settings.Default.HeadLightUnitIsPercentage;

            using (var context = new MyDbContext())
            {
                EnsureDeviationColumns(context);
                Admins = context.Admins.Where(x => x.IsTester == 1).ToList();
                Brands = context.Brands.ToList();
                SelectedBrand = Brands.FirstOrDefault();
                Calibration = context.Calibrations.FirstOrDefault();
            }
        }
        private static void EnsureDeviationColumns(MyDbContext context)
        {
            var columns = new[]
            {
                "LightDeviationLeftMin", "LightDeviationLeftMax",
                "LightDeviationRightMin", "LightDeviationRightMax",
                "LightDeviationUpMin", "LightDeviationUpMax",
                "LightDeviationDownMin", "LightDeviationDownMax",
                "NearLightDeviationLeftMin", "NearLightDeviationLeftMax",
                "NearLightDeviationRightMin", "NearLightDeviationRightMax",
                "NearLightDeviationUpMin", "NearLightDeviationUpMax",
                "NearLightDeviationDownMin", "NearLightDeviationDownMax"
            };
            foreach (var col in columns)
            {
                try
                {
                    context.Database.ExecuteSqlCommand($"ALTER TABLE Brands ADD COLUMN {col} REAL DEFAULT 0");
                }
                catch { /* Column already exists */ }
            }
        }
        public static void InitAdmins()
        {
            using (var context = new MyDbContext())
            {
                Admins = context.Admins.Where(x => x.IsTester == 1).ToList(); 
            }
        }
        public static void InitBrands()
        {
            using (var context = new MyDbContext())
            {
                Brands = context.Brands.ToList();
                if (SelectedBrand != null)
                {
                    var updated = Brands.FirstOrDefault(x => x.Id == SelectedBrand.Id);
                    if (updated != null)
                    {
                        SelectedBrand = updated;
                        OnSelectedBrandChanged?.Invoke();
                    }
                }
            }
        }
        public static void UpdateSelectedBrand(string brandName)
        {
            using (var context = new MyDbContext())
            {
                var brands = context.Brands.ToList();
                foreach (var brand in brands)
                {
                    if (brand.DisplayName == brandName)
                    {
                        SelectedBrandIndex = brands.IndexOf(brand);
                        SelectedBrand = brand;
                        break;
                    }
                } 
            }
            OnSelectedBrandChanged?.Invoke();
        }
        public static void UpdateGlobalSetting()
        {
            HeadLightUnitIsPercentage = Properties.Settings.Default.HeadLightUnitIsPercentage;
            OnUpdatedGlobalSettingChanged?.Invoke();
        }
        private static string RemoveVietnameseSigns(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            // Normalize to FormD (decompose unicode)
            string normalized = text.Normalize(NormalizationForm.FormD);

            // Remove all combining marks (accents)
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string result = regex.Replace(normalized, String.Empty)
                                 .Replace('đ', 'd')
                                 .Replace('Đ', 'D');

            return result;
        }
    }
}
