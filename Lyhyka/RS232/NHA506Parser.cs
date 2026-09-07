using Lyhyka.Core;
using System;
using System.Linq;

namespace Lyhyka.RS232
{
    public class NHA506Parser
    {
        public static Action<NHA506PacketData> OnDataReceived; // Delegate to call the form 
        private const int FrameLength = 21;

        public static void Parse(COMConnect gasEmissionCom)
        { 
            // Tìm vị trí đầu tiên của byte 0x06
            int index = gasEmissionCom.dataBuffer.IndexOf(0x06);
            if (index >= 0)
            {
                gasEmissionCom.dataBuffer = gasEmissionCom.dataBuffer.GetRange(index, gasEmissionCom.dataBuffer.Count - index);
            }

            if (gasEmissionCom.dataBuffer.Count >= FrameLength)
            {
                byte[] completeData = gasEmissionCom.dataBuffer.Take(FrameLength).ToArray();
                var data = Process(completeData);
                if (data != null)
                {
                    GlobalVariables.UpdateNHA506(data);
                    OnDataReceived?.Invoke(data);
                }    
                gasEmissionCom.dataBuffer.RemoveRange(0, FrameLength);
            }
        }

        public static NHA506PacketData Process(byte[] data)
        {
            if (data.Length >= 21 && data[0] == 0x06)
            {
                // Xử lý từng giá trị từ gói dữ liệu
                double? hcValue = ConvertToDouble(data[1], data[2], 1); // Không chia scale
                double? coValue = ConvertToDouble(data[3], data[4], 100);
                double? co2Value = ConvertToDouble(data[5], data[6], 100);
                double? o2Value = ConvertToDouble(data[7], data[8], 100);
                double? noValue = ConvertToDouble(data[9], data[10], 100);
                double? otValue = ConvertToDouble(data[11], data[12], 1); // Không chia scale
                double? rpmValue = ConvertToDouble(data[13], data[14], 1); // Không chia scale
                double? lambdaValue = data.Length >= 17 ? ConvertToDouble(data[15], data[16], 100) : null;

                return new NHA506PacketData()
                {
                    HC = hcValue,
                    CO = coValue,
                    CO2 = co2Value,
                    O2 = o2Value,
                    NO = noValue,
                    OT = otValue,
                    RPM = rpmValue,
                    Lambda = lambdaValue
                };
            }
            return null;
        }

        private static double? ConvertToDouble(byte highByte, byte lowByte, double scale)
        {
            // Kết hợp hai byte để tạo ra một số nguyên
            int value = (highByte << 8) | lowByte;

            // Kiểm tra nếu số là âm (nếu high byte là 0xFF)
            if (highByte == 0xFF)
            {
                // Nếu là số âm, tính lại giá trị
                value = value - 0x10000;
            }
            // Kiểm tra nếu giá trị là -256 (giá trị lỗi)
            if (value == -256)
            {
                return null; // Trả về null nếu gặp giá trị lỗi
            }

            // Chia giá trị theo scale (ví dụ 100) để ra giá trị thực tế
            return value / scale;
        }
    }

    public class NHA506PacketData
    {
        public double? HC { set; get; }
        public double? CO { set; get; }
        public double? CO2 { set; get; }
        public double? O2 { set; get; }
        public double? NO { set; get; }
        public double? OT { set; get; }
        public double? RPM { set; get; }
        public double? Lambda { set; get; }
    }
}
