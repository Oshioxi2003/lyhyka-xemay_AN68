using Lyhyka.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lyhyka.UCT
{
    public partial class SwitchFourUC : UserControl
    { 
        string deviceTag,switchTag1, switchTag2, switchTag3, switchTag4;
        string _buttonName = string.Empty;
        public SwitchFourUC()
        {
            InitializeComponent();
            switchUC1.StateChanged += (s, e) => {
                switchUC1StateChanged(e);
            };
            switchUC2.StateChanged += (s, e) => {
                switchUC2StateChanged(e);
            };
            switchUC3.StateChanged += (s, e) => {
                switchUC3StateChanged(e);
            };
            switchUC4.StateChanged += (s, e) => {
                switchUC4StateChanged(e);
            };
        }
        void switchUC1StateChanged(bool isClamped)
        {
            if (!OPCManager.SetOPCValue(switchTag1, isClamped ? 1 : 0))
            {
                Trigger(1, !isClamped);
            }    
        }
        void switchUC2StateChanged(bool isClamped)
        { 
            if(!OPCManager.SetOPCValue(switchTag2, isClamped?1:0))
            {
                Trigger(2, !isClamped);
            }    
        }
        void switchUC3StateChanged(bool isClamped)
        {
            if(!OPCManager.SetOPCValue(switchTag3, isClamped ? 1 : 0))
            {
                Trigger(3, !isClamped);
            }    
        }
        void switchUC4StateChanged(bool isClamped)
        {
            if (!OPCManager.SetOPCValue(switchTag4, isClamped ? 1 : 0))
            {
                Trigger(4, !isClamped);
            }    
        }
        public void Trigger(int index,bool value)
        {
            switch(index)
            {
                case 1:
                    switchUC1.Trigger(value);
                    break;
                case 2:
                    switchUC2.Trigger(value);
                    break;
                case 3:
                    switchUC3.Trigger(value);
                    break;
                case 4:
                    switchUC4.Trigger(value);
                    break;
            }    
        }
        public void UpdateSwitch(string buttonName)
        {
            // Need to set value
            _buttonName = buttonName;
            switch (buttonName.ToLower())
            {
                case MenuConstants.Speed:
                    switchUC1.UpdateTitle("NẸP TRƯỚC", "NHÁ", "KẸP"); 
                    switchUC2.UpdateTitle("NẸP SAU", "NHÁ", "KẸP"); 
                    switchUC2.Visible = false;
                    switchUC3.UpdateTitle("MÔ TƠ RU LƠ", "DỪNG", "CHẠY"); 
                    switchUC4.UpdateTitle("BỆ ĐỠ", "NÂNG", "HẠ");
                    deviceTag = TagConstants.speedDevice; 
                    switchTag3 = $"{TagConstants.chanel}.{deviceTag}.motorulo_dk";
                    break;
                case MenuConstants.BrakeForce:
                    switchUC1.UpdateTitle("NẸP TRƯỚC", "NHÁ", "KẸP"); 
                    switchUC2.UpdateTitle("NẸP SAU", "NHÁ", "KẸP"); 
                    switchUC3.UpdateTitle("MÔ TƠ RU LƠ", "DỪNG", "CHẠY");
                    switchUC4.UpdateTitle("BỆ ĐỠ", "NÂNG", "HẠ");
                    deviceTag = TagConstants.brakeForceDevice; 
                    switchTag3 = $"{TagConstants.chanel}.{deviceTag}.motorulo_dk";
                    break;
                case MenuConstants.Weight:
                    switchUC1.UpdateTitle("NẸP TRƯỚC", "NHÁ", "KẸP"); 
                    switchUC2.UpdateTitle("NẸP SAU", "NHÁ", "KẸP");
                    switchUC3.UpdateTitle("MÔ TƠ RU LƠ", "DỪNG", "CHẠY");
                    switchUC4.UpdateTitle("BỆ ĐỠ", "NÂNG", "HẠ");

                    deviceTag = TagConstants.weightDevice; 
                    switchTag3 = $"{TagConstants.chanel}.{deviceTag}.motorulo_dk";
                    break;
                case MenuConstants.SlideSlip:
                    switchUC1.UpdateTitle("NẸP TRƯỚC", "NHÁ", "KẸP");
                    switchUC2.UpdateTitle("NẸP SAU", "NHÁ", "KẸP");
                    switchUC3.UpdateTitle("CHỐT BÀN", "KHÓA", "MỞ");
                    switchUC4.UpdateTitle("BỆ ĐỠ", "NÂNG", "HẠ");
                    switchUC4.Visible = false;

                    deviceTag = TagConstants.slideSlipDevice;

                    switchTag3 = $"{TagConstants.chanel}.{deviceTag}.chotban_dk";
                    break;
            }
            switchTag1 = $"{TagConstants.chanel}.{deviceTag}.neptruoc_dk"; 
            switchTag2 = $"{TagConstants.chanel}.{deviceTag}.nepsau_dk";
            switchTag4 = $"{TagConstants.chanel}.{deviceTag}.bedo_dk";
        }
    }
}
