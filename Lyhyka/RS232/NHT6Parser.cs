using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyhyka.RS232
{
    public  class NHT6Parser
    {
        public static Action OnDataReceived; // Delegate to call the form 
        static decimal minSpeed1;
        static decimal minSpeed2;
        static decimal minSpeed3;
        static decimal maxSpeed1;
        static decimal maxSpeed2;
        static decimal maxSpeed3;
        static decimal hsu1;
        static decimal hsu2;
        static decimal hsu3;
        static decimal avgHsu;
        static bool isRequestInProgress = false;  // To prevent sending multiple requests simultaneously
        static int currentDataRequest = 1;        // Keep track of the current request count


        public static void Parse(COMConnect dieselCom)
        {
            if (dieselCom.dataBuffer.Count >= 9 && dieselCom.dataBuffer[0] == 0xA5)
            {
                byte[] completeData = dieselCom.dataBuffer.Take(9).ToArray();   
                Process(dieselCom,completeData);
                // dataBuffer.RemoveRange(0, 9);
                dieselCom.dataBuffer.Clear();
            }
            else if (dieselCom.dataBuffer.Count >= 7 && dieselCom.dataBuffer[0] == 0xA6)
            {
                byte[] completeData = dieselCom.dataBuffer.Take(7).ToArray();
                ProcessMax(completeData);
                //dataBuffer.RemoveRange(0, 7);
                dieselCom.dataBuffer.Clear();
            }
            else // Nếu không đủ dữ liệu
            {
                dieselCom.dataBuffer.Clear(); // Xóa dữ liệu hiện tại trong buffer

                byte[] commandA5 = { 0xA5, 0x5B };
                byte[] commandA6 = { 0xA6, 0x5A };
                dieselCom.SendRequest(commandA5);
                //SendRequest(commandA6);
            }
        }
        static async void ProcessMax(byte[] data)
        {
            if (data.Length >= 7 && data[0] == 0xA6)
            {
                int maxRpm = (data[5] << 8) + data[6]; // Max Speed (revolving speed)
                 
                switch (currentDataRequest)
                {
                    case 1: 
                        maxSpeed1 = Convert.ToDecimal(maxRpm);
                        break;
                    case 2:
                        maxSpeed2 = Convert.ToDecimal(maxRpm);
                        break;
                    case 3: 
                        maxSpeed3 = Convert.ToDecimal(maxRpm);
                        break;
                } 
                currentDataRequest++;
                isRequestInProgress = false;
                OnDataReceived?.Invoke();
                await Task.Delay(5000);
            }
        }
        static void Process(COMConnect dieselCom,byte[] data)
        {
            if (data.Length >= 9 && data[0] == 0xA5)
            {
                // Xử lý dữ liệu MinSpeed và OilTemp
                int rpm = (data[5] << 8) + data[6];
                int oilTempRaw = (data[7] << 8) + data[8];
                string oilTemperature;
                int oilTempCelsius = 0;
                if (oilTempRaw == 0xFFFF)
                {
                    oilTemperature = "--";  // Không có cảm biến nhiệt độ
                    oilTempCelsius = 0;
                }
                else
                {
                    oilTempCelsius = oilTempRaw;
                    oilTemperature = oilTempCelsius.ToString();
                } 
                switch (currentDataRequest)
                {
                    case 1:  
                        minSpeed1 = Convert.ToDecimal(rpm);
                        hsu1 = oilTempCelsius;
                        break;
                    case 2:
                        minSpeed2 = Convert.ToDecimal(rpm);
                        hsu2 = oilTempCelsius;
                        break;
                    case 3:
                        minSpeed3 = Convert.ToDecimal(rpm);
                        hsu3 = oilTempCelsius;
                        break;
                }

                OnDataReceived?.Invoke();
                byte[] commandA6 = { 0xA6, CalculateCheckCode(0xA6) };
                dieselCom.SendRequest(commandA6); 
            }
        }
        static byte CalculateCheckCode(byte command)
        {
            int sum = command;
            return (byte)(~sum + 1);
        }
    } 
}
