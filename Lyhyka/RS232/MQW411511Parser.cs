using Lyhyka.Core;
using System;
using System.Linq;

namespace Lyhyka.RS232
{
    public class MQW411511Parser
    {
        public static Action<bool> OnDataReceived; // Delegate to notify listeners (UI)

        public static void Parse(COMConnect gasEmissionCom)
        {
            while (true)
            {
                // Find first position of 0x06 ACK byte
                int index = gasEmissionCom.dataBuffer.IndexOf(0x06);
                if (index < 0)
                {
                    gasEmissionCom.dataBuffer.Clear();
                    break;
                }

                // Align buffer to start with 0x06
                if (index > 0)
                {
                    gasEmissionCom.dataBuffer.RemoveRange(0, index);
                }

                if (gasEmissionCom.dataBuffer.Count < 17)
                {
                    break;
                }

                byte[] data = gasEmissionCom.dataBuffer.ToArray();

                // Check if it matches 17-byte packet (4-gas model)
                bool is17 = VerifyChecksum(data, 17);
                bool is19 = gasEmissionCom.dataBuffer.Count >= 19 && VerifyChecksum(data, 19);

                if (is17)
                {
                    var packetData = Process17Byte(data);
                    if (packetData != null)
                    {
                        GlobalVariables.UpdateNHA506(packetData);
                        OnDataReceived?.Invoke(false);
                        gasEmissionCom.dataBuffer.RemoveRange(0, 17);
                        continue; // Look for next packet
                    }
                }

                // Check if we have at least 19 bytes and if it matches 19-byte packet (5-gas model)
                if (is19)
                {
                    var packetData = Process19Byte(data);
                    if (packetData != null)
                    {
                        GlobalVariables.UpdateNHA506(packetData);
                        OnDataReceived?.Invoke(false);
                        gasEmissionCom.dataBuffer.RemoveRange(0, 19);
                        continue; // Look for next packet
                    }
                }

                // If we have at least 19 bytes and neither matched, the current 0x06 is likely a false start/corrupt byte
                if (gasEmissionCom.dataBuffer.Count >= 19)
                {
                    gasEmissionCom.dataBuffer.RemoveAt(0); // Discard bad 0x06 and search again
                    continue;
                }

                // If we don't have 19 bytes yet, we cannot discard the 0x06 because it might be the start of a 19-byte packet
                // which is still arriving. Break and wait for more data.
                break;
            }
        }

        public static bool VerifyChecksum(byte[] data, int length)
        {
            if (data.Length < length) return false;
            int sum = 0x06;
            // Sum 2-byte fields up to index length-3
            for (int i = 1; i <= length - 3; i += 2)
            {
                sum += (data[i] << 8) | data[i + 1];
            }
            int checksum = (data[length - 2] << 8) | data[length - 1];
            return (sum & 0xFFFF) == checksum;
        }

        public static NHA506PacketData Process17Byte(byte[] data)
        {
            // MQW-411511 4-gas layout (17 bytes):
            // 0: ACK (0x06)
            // 1,2: HC
            // 3,4: CO
            // 5,6: CO2
            // 7,8: O2
            // 9,10: RPM
            // 11,12: OT
            // 13,14: Lambda
            // 15,16: Checksum
            double? hcValue = ConvertToDouble(data[1], data[2], 1);
            double? coValue = ConvertToDouble(data[3], data[4], 100);
            double? co2Value = ConvertToDouble(data[5], data[6], 100);
            double? o2Value = ConvertToDouble(data[7], data[8], 100);
            double? noValue = 0; // 4-gas has no NO sensor
            double? rpmValue = ConvertToDouble(data[9], data[10], 1);
            double? otValue = ConvertToDouble(data[11], data[12], 1);
            double? lambdaValue = ConvertToDouble(data[13], data[14], 100);

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

        public static NHA506PacketData Process19Byte(byte[] data)
        {
            // MQW-411511 5-gas layout (19 bytes):
            // 0: ACK (0x06)
            // 1,2: HC
            // 3,4: CO
            // 5,6: CO2
            // 7,8: O2
            // 9,10: NO
            // 11,12: RPM
            // 13,14: OT
            // 15,16: Lambda
            // 17,18: Checksum
            double? hcValue = ConvertToDouble(data[1], data[2], 1);
            double? coValue = ConvertToDouble(data[3], data[4], 100);
            double? co2Value = ConvertToDouble(data[5], data[6], 100);
            double? o2Value = ConvertToDouble(data[7], data[8], 100);
            double? noValue = ConvertToDouble(data[9], data[10], 1); // no scale
            double? rpmValue = ConvertToDouble(data[11], data[12], 1);
            double? otValue = ConvertToDouble(data[13], data[14], 1);
            double? lambdaValue = ConvertToDouble(data[15], data[16], 100);

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

        private static double? ConvertToDouble(byte highByte, byte lowByte, double scale)
        {
            int value = (highByte << 8) | lowByte;
            if (highByte == 0xFF)
            {
                value = value - 0x10000;
            }
            if (value == -256)
            {
                return null;
            }
            return value / scale;
        }
    }
}
