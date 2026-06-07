using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyhyka.DBCore
{
    public class TestCar
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string EngineNumber { get; set; }
        public string FrameNumber { get; set; }
        public string VehicleType { get; set; }
        public string Tester { get; set; }
        public long TestedDate { get; set; }


        public float Weight1 { get; set; }
        public float Weight2 { get; set; }
        public float Weight3 { get; set; }
        public float Weight4 { get; set; }
        public float Weight5 { get; set; }
        public float Speed { get; set; }
        public float SlideSlip { get; set; }
        public float Whistle { get; set; }
        public float Noise { get; set; }
        public float VoltageDrop { get; set; }
        public float OverCurrent { get; set; }
        public float AxleTorqueRear { get; set; }
        public float AxleTorqueFront { get; set; }
        public float AccelerationTime { get; set; }
        public float BrakeForceRight1 { get; set; }
        public float BrakeForceRight2 { get; set; }
        public float BrakeForceRight3 { get; set; }
        public float BrakeForceRight4 { get; set; }
        public float BrakeForceRight5 { get; set; }
        public float BrakeForceLeft1 { get; set; }
        public float BrakeForceLeft2 { get; set; }
        public float BrakeForceLeft3 { get; set; }
        public float BrakeForceLeft4 { get; set; }
        public float BrakeForceLeft5 { get; set; }
        public float BrakeForceHandLeft1 { get; set; }
        public float BrakeForceHandLeft2 { get; set; }
        public float BrakeForceHandLeft3 { get; set; }
        public float BrakeForceHandLeft4 { get; set; }
        public float BrakeForceHandLeft5 { get; set; }
        public float BrakeForceHandRight1 { get; set; }
        public float BrakeForceHandRight2 { get; set; }
        public float BrakeForceHandRight3 { get; set; }
        public float BrakeForceHandRight4 { get; set; }
        public float BrakeForceHandRight5 { get; set; }
        public float FarLeftLightIntensity { get; set; }
        public float FarLeftLightDeviationUD { get; set; }
        public float FarLeftLightDeviationLR { get; set; }
        public float FarRightLightIntensity { get; set; }
        public float FarRightLightDeviationUD { get; set; }
        public float FarRightLightDeviationLR { get; set; }
        public float NearLeftLightIntensity { get; set; }
        public float NearLeftLightDeviationUD { get; set; }
        public float NearLeftLightDeviationLR { get; set; }
        public float NearRightLightIntensity { get; set; }
        public float NearRightLightDeviationUD { get; set; }
        public float NearRightLightDeviationLR { get; set; }
        public float HC { get; set; }
        public float CO { get; set; }
        public float CO2 { get; set; }
        public float O2 { get; set; }
        public float NO { get; set; }
        public float OT { get; set; }
        public float RPM { get; set; }
        public float MinSpeed1 { get; set; }
        public float MinSpeed2 { get; set; }
        public float MinSpeed3 { get; set; }
        public float MaxSpeed1 { get; set; }
        public float MaxSpeed2 { get; set; }
        public float MaxSpeed3 { get; set; }
        public float Hsu1 { get; set; }
        public float Hsu2 { get; set; }
        public float Hsu3 { get; set; }
        public float AvgHsu { get; set; }
        public float OilTemperature { get; set; }
        public float SmokeOpacity { get; set; }


        public float BrakeForceDiff1
        {
            get
            {
                return BrakeForceHandLeft1 - BrakeForceHandRight1;
            }
        }
        public float BrakeForceDiff2
        {
            get
            {
                return BrakeForceHandLeft2- BrakeForceHandRight2;
            }
        }
        public float BrakeForceDiff3
        {
            get
            {
                return BrakeForceHandLeft3 - BrakeForceHandRight3;
            }
        }
        public float BrakeForceDiff4
        {
            get
            {
                return BrakeForceHandLeft4 - BrakeForceHandRight4;
            }
        }
        public float BrakeForceDiff5
        {
            get
            {
                return BrakeForceHandLeft5 - BrakeForceHandRight5;
            }
        }
    }
}
