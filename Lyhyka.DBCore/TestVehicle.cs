using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyhyka.DBCore
{
    public class TestVehicle
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Brand { get; set; }
        public string EngineNumber { get; set; }
        public string FrameNumber { get; set; }
        public string VehicleType { get; set; }
        public string Tester { get; set; }
        public long TestedDate { get; set; }
        public DateTime TestedDateTime
        {
            get
            {
                return DateTimeOffset.FromUnixTimeSeconds(TestedDate).DateTime;
            }
        }
        public float WeightFront { get; set; }
        public float WeightRear { get; set; }
        public float Speed { get; set; }
        public float RealSpeed { get; set; }
        public float BrakeForceFront { get; set; }
        public float BrakeForceRear { get; set; }
        public float SlideSlip { get; set; }
        public float Whistle { get; set; }
        public float Noise { get; set; }
        public float LongRangeLightIntensity { get; set; }
        public float LightDeviationUD { get; set; }
        public float LightDeviationLR { get; set; }

        public float LongRangeNearLightIntensity { get; set; }
        public float NearLightDeviationUD { get; set; }
        public float NearLightDeviationLR { get; set; }

        public float VoltageDrop { get; set; }
        public float? VoltageDrop1 { get; set; }
        public float OverCurrent { get; set; }
        public float AxleTorqueFront { get; set; }
        public float AxleTorqueRear { get; set; }

        // Thông tin bổ sung cho báo cáo
        public string CertificateNumber { get; set; }
        public string VehicleBrandName { get; set; }
        public string VehicleColor { get; set; }
        public float AxleTorqueFork { get; set; }

        public float AccelerationTime { get; set; }

        public float HC { get; set; }
        public float CO { get; set; }
        public float CO2 { get; set; }
        public float O2 { get; set; }
        public float NO { get; set; }
        public float OilTemperature { get; set; }
        public float RPM { get; set; }

    }
}
