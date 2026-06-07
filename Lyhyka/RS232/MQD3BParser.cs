using Lyhyka.Core;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lyhyka.RS232
{
    public class MQD3BParser
    {
        public static Action OnDataReceived; // Delegate to call the form 
        public static void Process(COMConnect cOM)
        {
            string data = cOM.buffer.ToString();

            // Optional: support multiple packets in buffer
            while (true)
            {
                int startIdx = data.IndexOf("SL");
                if (startIdx < 0) startIdx = data.IndexOf("R");
                if (startIdx < 0) break;

                int endIdx = data.IndexOf("P", startIdx);
                if (endIdx < 0) break; // incomplete packet, wait for more data

                string packet = data.Substring(startIdx, endIdx - startIdx + 1);

                // Handle the full packet
                var parsed = Parse(packet);
                if (parsed != null)
                {
                    if (parsed.Count >= 1)
                    {
                        var nearLight = parsed[0];
                        GlobalVariables.TestVehicle.LongRangeNearLightIntensity = 100*nearLight.I2;
                        GlobalVariables.TestVehicle.NearLightDeviationUD = nearLight.V2;
                        GlobalVariables.TestVehicle.NearLightDeviationLR = nearLight.H2;
                       
                        GlobalVariables.TestVehicle.LongRangeLightIntensity = 100 * nearLight.I;
                        GlobalVariables.TestVehicle.LightDeviationUD = nearLight.V;
                        GlobalVariables.TestVehicle.LightDeviationLR = nearLight.H; 
                        
                        OnDataReceived?.Invoke();
                    }
                }
                // Remove processed part from buffer
                data = data.Substring(endIdx + 1);
                cOM.buffer.Clear();
                cOM.buffer.Append(data);
            }
        }

        public static void Process()
        {
            string data = "SL0115+158+00908000000+000+00000000112+151+323080000.00000+0000000R0116+165-17308000000+000+00000000111+138+359080000.00000+0000000P\r\n";

            // Optional: support multiple packets in buffer
            while (true)
            {
                int startIdx = data.IndexOf("SL");
                if (startIdx < 0) startIdx = data.IndexOf("R");
                if (startIdx < 0) break;

                int endIdx = data.IndexOf("P", startIdx);
                if (endIdx < 0) break; // incomplete packet, wait for more data

                string packet = data.Substring(startIdx, endIdx - startIdx + 1);

                // Handle the full packet
                var parsed = Parse(packet);
                if (parsed != null)
                {
                    if (parsed.Count >= 1)
                    {
                        var nearLight = parsed[parsed.Count - 1];
                        GlobalVariables.TestVehicle.LongRangeNearLightIntensity = 100 * nearLight.I;
                        GlobalVariables.TestVehicle.NearLightDeviationUD = nearLight.H;
                        GlobalVariables.TestVehicle.NearLightDeviationLR = nearLight.V;
                        if (parsed.Count >= 2)
                        {
                            var headLight = parsed[parsed.Count - 2];
                            GlobalVariables.TestVehicle.LongRangeLightIntensity = 100 * headLight.I;
                            GlobalVariables.TestVehicle.LightDeviationUD = headLight.H;
                            GlobalVariables.TestVehicle.LightDeviationLR = headLight.V;
                        }
                        OnDataReceived?.Invoke();
                    }
                }
                // Remove processed part from buffer
                data = data.Substring(endIdx + 1);
             
            }
        }

        public static List<MQD3BPacketData> Parse(string data)
        {
            var packets = new List<MQD3BPacketData>();

            // Step 1: Extract all sections that start with L or R
            var sections = Regex.Matches(data, @"[LR][^LRP]+");

            foreach (Match section in sections)
            {
                try
                {
                    // Step 2: Remove the leading L or R
                    string body = section.Value.Substring(1);
                    // 0072-609+00408000000+000+00000000060-706+305080000.000 00 + 0000000
                    var v1 = body.Substring(0, 4);
                    var v2 = body.Substring(4, 4);
                    var v3 = body.Substring(8, 4);


                    var v4 = body.Substring(32, 4);
                    var v5 = body.Substring(32 + 4, 4);
                    var v6 = body.Substring(32 + 8, 4);


                    packets.Add(new MQD3BPacketData
                    {
                        Side = "L" + section.Value[0], // L or R
                        I = float.Parse(v1),
                        H = float.Parse(v2),
                        V = float.Parse(v3),
                        I2 = float.Parse(v4),
                        H2 = float.Parse(v5),
                        V2 = float.Parse(v6)
                    });
                }
                catch (Exception)
                {
                     
                }
            }

            return packets;
        } 
    }
    public class MQD3BPacketData
    {
        public string Side { get; set; } // L or R
        public float I { get; set; }
        public float H { get; set; }
        public float V { get; set; }

        public float I2 { get; set; }
        public float H2 { get; set; }
        public float V2 { get; set; }
        public float Height { get; set; }
        public float ILow { get; set; }
        public float HLow { get; set; }
        public float VLow { get; set; }
        public float HeightLow { get; set; }
    }   
}
