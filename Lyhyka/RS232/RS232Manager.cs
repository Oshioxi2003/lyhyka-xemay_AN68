using Lyhyka;
using OPCAutomation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Lyhyka.RS232
{
    public class RS232Manager
    {
        public static Action OnDataReceived; // Delegate to call the form 
        //Headlights, dieseEmission,gasEmission, noise
        public static COMConnect headlightsCom, whistleCom, dieselCom, gasEmissionCom, headlightsMQD3BCom, headlightsMQD6ACom;
        public static bool UsingMQD6A = bool.Parse(ConfigurationManager.AppSettings["UsingMQD6A"]);
        public static bool ShowLowBeamLightIntensity = bool.Parse(ConfigurationManager.AppSettings["ShowLowBeamLightIntensity"]);
        public static bool ShowLowBeamLightDeviationLR = bool.Parse(ConfigurationManager.AppSettings["ShowLowBeamLightDeviationLR"]);
        public static void InitializeCOMConnections()
        {
            try
            {

                // Initialize COM connections for each component
                //headlightsCom = new COMConnect("COM1", 9600, null, new SerialDataReceivedEventHandler(HeadlightsComDataReceivedHandler)); // Replace with actual port and baud rate
                //whistleCom = new COMConnect("COM2", 9600, null, new SerialDataReceivedEventHandler(WhistleComComDataReceivedHandler)); // Replace with actual port and baud rate
                //dieselCom = new COMConnect("COM3", 9600, null, new SerialDataReceivedEventHandler(DieselComDataReceivedHandler)); // Replace with actual port and baud rate
                //gasEmissionCom = new COMConnect("COM4", 9600, null, new SerialDataReceivedEventHandler(GasEmissionComComDataReceivedHandler)); // Replace with actual port and baud rate
                
                string headLightCOM = ConfigurationManager.AppSettings["HeadLightCOM"];

             
                if (UsingMQD6A)
                {
                    headlightsMQD6ACom = new COMConnect(headLightCOM, 9600, null, new SerialDataReceivedEventHandler(HeadlightsMQD6AComDataReceivedHandler)); // Replace with actual port and baud rate
                    headlightsMQD6ACom.OpenConnection();
                    //headlightsMQD6ACom.SendRequest(new byte[]
                    //{
                    //0x02,
                    //0x01,
                    //0x32,
                    //0x44,
                    //0x43,
                    //0x44
                    //});
                }
                else
                {
                    headlightsMQD3BCom = new COMConnect(headLightCOM, 9600, null, new SerialDataReceivedEventHandler(HeadlightsMQD3BComDataReceivedHandler)); // Replace with actual port and baud rate
                    headlightsMQD3BCom.OpenConnection();
                }
                // Open all connections
                //headlightsCom.OpenConnection();
                //whistleCom.OpenConnection();
                //dieselCom.OpenConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kết nối cổng COM: {ex.Message}");
            }
            //gasEmissionCom.OpenConnection();
        }
        public static void CloseConnections()
        {
            if (UsingMQD6A)
                headlightsMQD6ACom.CloseConnection();
            else
                headlightsMQD3BCom.CloseConnection();

            // Open all connections
            //headlightsCom.CloseConnection();
            //whistleCom.CloseConnection();
            //dieselCom.CloseConnection();
            //gasEmissionCom.CloseConnection();
        }
        private static void HeadlightsMQD3BComDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string incoming = headlightsMQD3BCom.serialPort.ReadExisting();
                //File.AppendAllText("C:\\Users\\HLC\\Documents\\log.text", incoming);
                headlightsMQD3BCom.buffer.Append(incoming);
                MQD3BParser.Process(headlightsMQD3BCom);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi nhận dữ liệu:  " + ex.Message);
            }
        }

        #region MQD6A
        private static void HeadlightsMQD6AComDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string incoming = headlightsMQD6ACom.serialPort.ReadExisting();
                //File.AppendAllText("C:\\Users\\HLC\\Documents\\log.text", incoming);
                headlightsMQD6ACom.buffer.Append(incoming);
                MQD6AParser.Process(headlightsMQD6ACom, IsHighMeasuring, IsLowMeasuring);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Lỗi nhận dữ liệu:  " + ex.Message);
            }
        }
        const int DelayInSeconds = 2;
        public static bool IsHighMeasuring = false;
        public static bool IsLowMeasuring = false;
        public static void SendHeadlightMQD6AHigh(System.Windows.Forms.Button stop)
        {
            SendHeadlightMQD6ARequest(new byte[]
            {
                0x02, 0x01, 0x32, 0x53, 0x33, 0x45
            });
            Thread.Sleep(1000 * DelayInSeconds);
            SendHeadlightMQD6ARequest(new byte[]
            {
                0x02,0x01,0x32,0x54,0x51,0x26
            });
            IsLowMeasuring = false;
            IsHighMeasuring = true;
            stop.Enabled = true;
        }
       
        public static void SendHeadlightMQD6Low(System.Windows.Forms.Button stop)
        {
            SendHeadlightMQD6ARequest(new byte[]
            {
                0x02,0x01,0x32,0x53,0x34,0x44
            });
            Thread.Sleep(1000 * DelayInSeconds);
            SendHeadlightMQD6ARequest(new byte[]
            {
                0x02,0x01,0x32,0x54,0x51,0x26
            });
            IsHighMeasuring = false;
            IsLowMeasuring = true;
            stop.Enabled = true;
        }

        public static void SendHeadlightMQD6AStop()
        {
            SendHeadlightMQD6ARequest(new byte[]
            {
                0x02,0x01,0x32,0x54,0x54,0x23
            });

            IsHighMeasuring=IsLowMeasuring = false;
        }
        static void SendHeadlightMQD6ARequest(byte[] command)
        {
            if (headlightsMQD6ACom != null && headlightsMQD6ACom.serialPort.IsOpen)
            {
                headlightsMQD6ACom.SendRequest(command);
            }
        }
        #endregion
        private static void HeadlightsComDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //Đọc các byte dữ liệu có sẵn
                while (headlightsCom.serialPort.BytesToRead > 0)
                {
                    byte[] buffer = new byte[headlightsCom.serialPort.BytesToRead];
                    headlightsCom.serialPort.Read(buffer, 0, buffer.Length);
                    headlightsCom.dataBuffer.AddRange(buffer);
                    string receivedData = BitConverter.ToString(buffer);
                    Console.WriteLine("Received (Hex): " + receivedData); 
                    if (headlightsCom.dataBuffer.Contains(0x47))
                    {
                        headlightsCom.respone47H = true;
                    }
                    if (headlightsCom.dataBuffer.Count >= 68 && headlightsCom.dataBuffer[0] == 0x01 && headlightsCom.dataBuffer[1] == 0x12 && headlightsCom.dataBuffer[34] == 0x01)
                    {
                        byte[] completeData = headlightsCom.dataBuffer.Take(68).ToArray();
                        //new frmHeadlights().ProcessNHD6109Data(completeData);
                        //((frmHeadlights)activeForm).ProcessNHD6109Data(completeData);
                        headlightsCom.dataBuffer.RemoveRange(0, 68);
                    }
                    else
                        headlightsCom.dataBuffer.RemoveAt(0);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhận dữ liệu:  " + ex.Message);
            }
        }
        private static void WhistleComComDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //Đọc các byte dữ liệu có sẵn
                while (headlightsCom.serialPort.BytesToRead > 0)
                {
                    byte[] buffer = new byte[headlightsCom.serialPort.BytesToRead];
                    headlightsCom.serialPort.Read(buffer, 0, buffer.Length);
                    headlightsCom.dataBuffer.AddRange(buffer);
                    string receivedData = BitConverter.ToString(buffer);
                    Console.WriteLine("Received (Hex): " + receivedData);
                    // Xử lý gói dữ liệu trả về từ HY114 (nếu có) 
                    if (headlightsCom.dataBuffer.Count > 0 && headlightsCom.dataBuffer[0] == 0x06)
                    {
                        headlightsCom.dataBuffer.RemoveAt(0);
                    }
                    if (headlightsCom.dataBuffer.Count >= 9 && headlightsCom.dataBuffer[0] == 0x01)
                    {
                        byte[] completeData = headlightsCom.dataBuffer.Take(9).ToArray();
                        //((frmNoise)activeForm).ProcessNoiseData(completeData);
                        //new frmNoise().ProcessNoiseData(completeData);
                        headlightsCom.dataBuffer.RemoveRange(0, 9);
                    }

                    if (headlightsCom.dataBuffer.Count > 0 && headlightsCom.dataBuffer[0] == 0x06)
                    {
                        headlightsCom.dataBuffer.RemoveAt(0);
                    }
                    if (headlightsCom.dataBuffer.Count >= 9 && headlightsCom.dataBuffer[0] == 0x01)
                    {
                        byte[] completeData = headlightsCom.dataBuffer.Take(9).ToArray();
                        //((frmWhistle)activeForm).ProcessMaxSoundData(completeData);
                        //new frmWhistle().ProcessMaxSoundData(completeData);
                        headlightsCom.dataBuffer.RemoveRange(0, 9);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhận dữ liệu:  " + ex.Message);
            }
        }
        private static void DieselComDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //Đọc các byte dữ liệu có sẵn
                while (dieselCom.serialPort.BytesToRead > 0)
                {
                    byte[] buffer = new byte[dieselCom.serialPort.BytesToRead];
                    dieselCom.serialPort.Read(buffer, 0, buffer.Length);
                    dieselCom.dataBuffer.AddRange(buffer);
                    string receivedData = BitConverter.ToString(buffer);
                    Console.WriteLine("Received (Hex): " + receivedData);
                    NHT6Parser.Parse(dieselCom);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhận dữ liệu:  " + ex.Message);
            }
        }
        private static void GasEmissionComComDataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                //Đọc các byte dữ liệu có sẵn
                while (gasEmissionCom.serialPort.BytesToRead > 0)
                {
                    byte[] buffer = new byte[gasEmissionCom.serialPort.BytesToRead];
                    gasEmissionCom.serialPort.Read(buffer, 0, buffer.Length);
                    gasEmissionCom.dataBuffer.AddRange(buffer);
                    string receivedData = BitConverter.ToString(buffer);
                    Console.WriteLine("Received (Hex): " + receivedData);
                    NHA506Parser.Parse(gasEmissionCom);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhận dữ liệu:  " + ex.Message);
            }
        }
    }
}
