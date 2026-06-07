using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyhyka.DBCore
{
    public class Brand
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public float WeightFrontMin { get; set; }
        public float WeightFrontMax { get; set; }
        public float WeightRearMin { get; set; }
        public float WeightRearMax { get; set; }
        public float SpeedMin { get; set; }
        public float SpeedMax { get; set; }
        public float BrakeForceFrontMin { get; set; }
        public float BrakeForceFrontMax { get; set; }
        public float BrakeForceRearMin { get; set; }
        public float BrakeForceRearMax { get; set; }
        public float SlideSlipMin { get; set; }
        public float SlideSlipMax { get; set; }

        // Âm lượng còi
        public float WhistleMin { get; set; }
        public float WhistleMax { get; set; }

        // Độ ồn
        public float NoiseMin { get; set; }
        public float NoiseMax { get; set; }

        public float LongRangeLightIntensityMin { get; set; }
        public float LongRangeLightIntensityMax { get; set; }

        public float LightDeviationUDMin { get; set; }
        public float LightDeviationUDMax { get; set; }

        public float LightDeviationLRMin { get; set; }
        public float LightDeviationLRMax { get; set; }


        public float LongRangeNearLightIntensityMin { get; set; }
        public float LongRangeNearLightIntensityMax { get; set; }

        public float NearLightDeviationUDMin { get; set; }
        public float NearLightDeviationUDMax { get; set; }

        public float NearLightDeviationLRMin { get; set; }

        public float NearLightDeviationLRMax { get; set; }

        // Độ lệch đèn pha (HB) - riêng từng hướng
        public float LightDeviationLeftMin { get; set; }
        public float LightDeviationLeftMax { get; set; }
        public float LightDeviationRightMin { get; set; }
        public float LightDeviationRightMax { get; set; }
        public float LightDeviationUpMin { get; set; }
        public float LightDeviationUpMax { get; set; }
        public float LightDeviationDownMin { get; set; }
        public float LightDeviationDownMax { get; set; }

        // Độ lệch đèn cốt (LB) - riêng từng hướng
        public float NearLightDeviationLeftMin { get; set; }
        public float NearLightDeviationLeftMax { get; set; }
        public float NearLightDeviationRightMin { get; set; }
        public float NearLightDeviationRightMax { get; set; }
        public float NearLightDeviationUpMin { get; set; }
        public float NearLightDeviationUpMax { get; set; }
        public float NearLightDeviationDownMin { get; set; }
        public float NearLightDeviationDownMax { get; set; }

        public float HCMin { get; set; }
        public float HCMax { get; set; } 
        public float COMin { get; set; }
        public float COMax { get; set; }

        // Tiêu chuẩn tổng phanh
        public float BrakeForceSumMin { get; set; }
        public float BrakeForceSumMax { get; set; }

        // Tiêu chuẩn kiểm tra xác suất
        public float VoltageDropMin { get; set; }
        public float VoltageDropMax { get; set; }
        public float OverCurrentMin { get; set; }
        public float OverCurrentMax { get; set; }
        public float AxleTorqueFrontMin { get; set; }
        public float AxleTorqueFrontMax { get; set; }
        public float AxleTorqueRearMin { get; set; }
        public float AxleTorqueRearMax { get; set; }
        public float AxleTorqueForkMin { get; set; }
        public float AxleTorqueForkMax { get; set; }

        // Ẩn/hiện kiểm tra xác suất
        public int HideInspectionSection { get; set; }
        public bool IsHideInspectionSection => HideInspectionSection == 1;

        // Thông tin xe mặc định theo loại xe
        public string CertificateNumber { get; set; }
        public string VehicleBrandName { get; set; }
        public string VehicleColor { get; set; }

        public int ShowRealSpeed { get; set; }
        public bool IsShowRealSpeed
        {
            get
            {
                return ShowRealSpeed == 1;
            }
        }
        public string DisplayName
        {
            get
            {
                return $"{Type}-{Name}";
            }
        }
    }
}
