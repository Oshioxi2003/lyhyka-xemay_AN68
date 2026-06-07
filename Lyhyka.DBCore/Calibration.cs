using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyhyka.DBCore
{
    public class Calibration
    {
        public int Id { get; set; }
        public float WeightA { get; set; }
        public float WeightB { get; set; }
        public float SpeedA { get; set; }
        public float SpeedB { get; set; }
        public float BrakeForceFrontA { get; set; }
        public float BrakeForceFrontB { get; set; }
        public float BrakeForceRearA { get; set; }
        public float BrakeForceRearB { get; set; }
        public float SlideSlipA { get; set; }
        public float SlideSlipB { get; set; }


        public float? SpeedZero { get; set; }
        public float? BrakeForceZero { get; set; }
        public float? SlideSlipZero { get; set; }
    }
}
