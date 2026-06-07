using Lyhyka.Core;
using Lyhyka.DBCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lyhyka.RS232
{
    public class MQD6AParser
    {
        public static Action OnDataReceived; // Delegate to call the form 
        public static void Process()
        {
            string msg = "\u0002M-626 +427 00700810N";
            // Split by STX (0x02)
            string[] frames = msg.Split((char)0x02, (char)StringSplitOptions.RemoveEmptyEntries);

            // Get the last frame
            string last = frames.Last().Trim();
            // remove ALL control chars (ASCII < 32)
            var raw = new string(last.Where(c => !char.IsControl(c)).ToArray());

            // trim normal spaces
            raw = raw.Trim();

            // collapse multiple spaces into single
            raw = Regex.Replace(raw, @"\s+", " ");

            // Remove starting 'M'
            raw = raw.Substring(1);

            // 1) LR: until first space
            int space1 = raw.IndexOf(' ');
            string LR = raw.Substring(0, space1);

            // Move forward past space
            raw = raw.Substring(space1 + 1);

            // 2) UP: until next space
            int space2 = raw.IndexOf(' ');
            string UP = raw.Substring(0, space2);

            // Move forward
            raw = raw.Substring(space2 + 1);

            // Now raw = "00700810N"

            // 3) I = first 4 chars
            string I = raw.Substring(0, 4);


            GlobalVariables.TestVehicle.LongRangeNearLightIntensity = float.Parse(I);
            GlobalVariables.TestVehicle.NearLightDeviationUD = float.Parse(UP);
            GlobalVariables.TestVehicle.NearLightDeviationLR = float.Parse(LR);

        }
        public static void Process(COMConnect cOM, bool isHigh, bool isLow)
        {
            string data = cOM.buffer.ToString();
            // Split by STX (0x02)
            string[] frames = data.Split((char)0x02, (char)StringSplitOptions.RemoveEmptyEntries);

            // Get the last frame
            string last = frames.Last().Trim();
            // remove ALL control chars (ASCII < 32)
            var raw = new string(last.Where(c => !char.IsControl(c)).ToArray());

            // trim normal spaces
            raw = raw.Trim();

            // collapse multiple spaces into single
            raw = Regex.Replace(raw, @"\s+", " ");

            // Remove starting 'M'
            raw = raw.Substring(1);

            // 1) LR: until first space
            int space1 = raw.IndexOf(' ');
            string LR = raw.Substring(0, space1);

            // Move forward past space
            raw = raw.Substring(space1 + 1);

            // 2) UP: until next space
            int space2 = raw.IndexOf(' ');
            string UP = raw.Substring(0, space2);

            // Move forward
            raw = raw.Substring(space2 + 1);

            // Now raw = "00700810N"

            // 3) I = first 4 chars
            string I = raw.Substring(0, 4);
            var intensity = float.Parse(I);
            isLow = (intensity == 0);
            if (isLow)
            {
                
                GlobalVariables.TestVehicle.LongRangeNearLightIntensity = 100* intensity;
                GlobalVariables.TestVehicle.NearLightDeviationUD = float.Parse(UP);
                GlobalVariables.TestVehicle.NearLightDeviationLR = float.Parse(LR);
                if(GlobalVariables.HeadLightUnitIsPercentage)
                {
                    GlobalVariables.TestVehicle.NearLightDeviationUD = GlobalVariables.TestVehicle.NearLightDeviationUD / 100;
                    GlobalVariables.TestVehicle.NearLightDeviationLR = GlobalVariables.TestVehicle.NearLightDeviationLR / 100;
                }    
            }
            else
            {
                GlobalVariables.TestVehicle.LongRangeLightIntensity = 100 * intensity;
                GlobalVariables.TestVehicle.LightDeviationUD = float.Parse(UP);
                GlobalVariables.TestVehicle.LightDeviationLR = float.Parse(LR);
                if (GlobalVariables.HeadLightUnitIsPercentage)
                {
                    GlobalVariables.TestVehicle.LightDeviationUD = GlobalVariables.TestVehicle.LightDeviationUD / 100;
                    GlobalVariables.TestVehicle.LightDeviationLR = GlobalVariables.TestVehicle.LightDeviationLR / 100;
                }
            }
            OnDataReceived?.Invoke();

            cOM.buffer.Clear();
        }
    }
}
