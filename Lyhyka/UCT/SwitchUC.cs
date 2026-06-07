using DevExpress.XtraEditors;
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
    public partial class SwitchUC : UserControl
    {
        public event EventHandler<bool> StateChanged;
        public SwitchUC()
        {
            InitializeComponent(); 
            clampSwitchUC.StateChanged += (s, e) =>
            { 
                StateChanged?.Invoke(this, e); 
            };
        }
        public void UpdateTitle(string title, string offText,string  onText)
        {
            Title = title;
            Ontext = onText;
            Offtext = offText;
        }
        public void Trigger(bool value)
        {
            clampSwitchUC.Trigger(value); 
        }
        private string _title = "NẸP";
        [Browsable(true)]
        [Category("Custom Properties")]
        [Description("Sets the title of the control.")]
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                lblTitle.Text = value;
            }
        } 
        private string _offText; 
        [Browsable(true)]
        [Category("Custom Properties")]
        [Description("Sets the offtext of the control.")]
        public string Offtext
        {
            get => _offText;
            set
            {
                _offText = value;
                clampSwitchUC.SetOffText(value); 
            }
        }
        private string _onText;

        [Browsable(true)]
        [Category("Custom Properties")]
        [Description("Sets the ontext of the control.")]
        public string Ontext
        {
            get => _onText;
            set
            {
                _onText = value;
                clampSwitchUC.SetOnText(value);
            }
        }

        public void SetToggleSwitchState(bool state)
        {
            //toggleSwitch.IsOn = state;
        }


    }
}
