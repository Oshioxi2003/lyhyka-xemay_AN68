using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyhyka.Core
{
    public class GlobalFunctions
    {
        private static readonly Random random = new Random();
        private const string chars = "ABCDEFGHJKLMNPRSTUVWXYZ0123456789"; // VIN-safe chars

        public static bool CheckStandard(float? value, float? minValue, float? maxValue)
        {
            if (!value.HasValue)
                return true; // Nếu không có giá trị cần kiểm tra, mặc định đạt

            if (minValue.HasValue && value < minValue.Value)
                return false;

            if (maxValue.HasValue && value > maxValue.Value)
                return false;

            return true;
        }
        public static string FormatRange(float? min, float? max, string format = "F0")
        {
            if (min.HasValue && max.HasValue)
                return $"[ {min.Value.ToString(format)} ÷ {max.Value.ToString(format)} ]";
            else if (min.HasValue)
                return $"≥ {min.Value.ToString(format)}";
            else if (max.HasValue)
                return $"≤ {max.Value.ToString(format)}";
            else
                return "[    ÷    ]";
        }
       
        public static string GenerateFrameNumber()
        {
            StringBuilder vin = new StringBuilder();

            for (int i = 0; i < 8; i++)
            {
                vin.Append(chars[random.Next(chars.Length)]);
            }

            return vin.ToString();
        }
        public static float ConvertIntToFloat(string value)
        { 
            return (float)Math.Round((float)(int.Parse(value)) / 10,1);
        }
    }
}
