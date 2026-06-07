using Lyhyka.Core;
using OPCAutomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lyhyka.OPC
{
    public class OPCGroupInfo
    {
        public Dictionary<int, OPCTag> Tags { get; set; } = new Dictionary<int, OPCTag>();
        public string Name { get; set; }
        public List<float>  Max1s { get; set; } = new List<float>();
        public List<float> Max2s { get; set; } = new List<float>();
    }
    public class OPCTag
    {
        public string Tag { get; set; }
        public bool IsBoolean { get; set; } = false; // Default to false, can be set to true if the tag is boolean
        public OPCItem Item { get; set; }
        public object Value { get; set; }
        public OPCTag(string device,string tag,Boolean isBoolean = false)
        {
            Tag = $"{TagConstants.chanel}.{device}.{tag}";
            IsBoolean = isBoolean;
        }

        public void WriteValue(float value)
        {
            Value = value;
            if (Item != null)
            {
                Item.Write(value);
            }
            else
            {
                MessageBox.Show("OPC Item is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw new InvalidOperationException("OPC Item is not initialized.");
            }
        }
        public void WriteValue(bool value)
        {
            Value = value;
            if (Item != null)
            {
                Item.Write(value);
            }
            else
            {
                MessageBox.Show("OPC Item is not initialized.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //throw new InvalidOperationException("OPC Item is not initialized.");
            }
        }
    }
}
