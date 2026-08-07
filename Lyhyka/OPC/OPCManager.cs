using DevExpress.Utils.Html.Internal;
using Lyhyka;
using Lyhyka.Core;
using Lyhyka.OPC;
using Newtonsoft.Json.Linq;
using OPCAutomation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static DevExpress.Utils.Diagnostics.GUIResources;

namespace Lyhyka
{
    public class OPCManager
    {
        public static Action<string> OnDataReceived; // Delegate to call the form 
        public static Action<string, float> OnCalibDataReceived; // Delegate to call the form 

        const string OPC_SERVER_NAME = "Kepware.KEPServerEX.V6"; // Tên OPC server
        private static OPCServer opcServer;

        private static OPCGroup _opcGroup;
        private static OPCGroup _slideSlipGroup;
        private static OPCGroup _speedGroup;
        private static OPCGroup _brakeGroup;
        private static OPCGroup _noiseGroup;

        public static float MaxNoise { set; get; } = float.MinValue;

        // doon_reset trên KEPServer là kiểu Short (D0009), không phải Boolean -> ghi số, không ghi bool.
        // Tag này giữ mức (level-hold), không tự pulse: phải ghi 1 rồi ghi lại 0
        // để PLC nhả chốt còi, nếu không PLC sẽ tiếp tục trả về giá trị đỉnh cũ.
        public static void ResetMaxNoise()
        {
            NoiseGroupInfo.Tags[TagConstants.doon_reset].WriteValue(1f);
            Thread.Sleep(300); // > chu kỳ quét PLC
            NoiseGroupInfo.Tags[TagConstants.doon_reset].WriteValue(0f);
            MaxNoise = float.MinValue;
        }

        private static readonly object _logLock = new object();

        private static void LogToFile(string fileName, string message)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
                lock (_logLock)
                {
                    File.AppendAllText(path, $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff}] {message}{Environment.NewLine}");
                }
            }
            catch
            {
                // Không để lỗi ghi log làm crash luồng OPC
            }
        }
        private static void LogTagError(string message) => LogToFile("opc_tag_errors.log", message);

        private static bool opcErrorShown = false;
        public static bool isConnected = false;
        public bool IsConnected => isConnected;
        private static int retryCount = 0;

        public OPCManager()
        {
            //ConnectToOPCServer();
            ConnectOPCServer();
        }
        public void ConnectToOPCServer()
        {
            try
            {
                if (retryCount >= 3)
                {
                    if (!opcErrorShown)
                    {
                        MessageBox.Show("Không thể kết nối tới OPC server sau nhiều lần thử. Dừng kết nối.");
                        opcErrorShown = true;
                    }
                    return;
                }
                opcServer = new OPCServer();
                opcServer.Connect(OPC_SERVER_NAME); // Kết nối tới OPC server

                _opcGroup = opcServer.OPCGroups.Add("Group1");
                _opcGroup.IsActive = true;
                _opcGroup.IsSubscribed = true;
                _opcGroup.UpdateRate = 200;
                isConnected = true; // Đánh dấu kết nối thành công
                opcErrorShown = false; // Reset cờ lỗi
                retryCount = 0; // Reset lại số lần thử nếu kết nối thành công


            }
            catch (Exception ex)
            {
                isConnected = false; // Đánh dấu không kết nối được
                retryCount++; // Tăng số lần thử
                if (!opcErrorShown)
                {
                    MessageBox.Show($"Kết nối đến OPC server thất bại: {ex.Message}");
                    opcErrorShown = true; // Đánh dấu đã hiển thị lỗi
                }
            }
        }

        public static void AddItem(string itemName, int clientHandle)
        {
            try
            {
                if (isConnected)
                {
                    _opcGroup.OPCItems.AddItem(itemName, clientHandle);
                }
            }
            catch (Exception)
            {
            }
        }
        public static void DisconnectOPC()
        {
            try
            {
                if (opcServer != null && isConnected)
                {
                    // Hủy kích hoạt Group nếu cần
                    if (_opcGroup != null)
                    {
                        _opcGroup.IsActive = false;
                        _opcGroup = null; // Giải phóng Group
                    }

                    // Ngắt kết nối OPC server
                    opcServer.Disconnect();
                    opcServer = null; // Giải phóng server
                    isConnected = false; // Đánh dấu đã ngắt kết nối
                }
            }
            catch (Exception)
            {
            }
        }
        public int GetOPCValue(string opcItem)
        {
            try
            {
                if (!isConnected)
                {
                    if (!opcErrorShown)
                    {
                        opcErrorShown = true;
                    }
                    return 0; // Giá trị mặc định
                }
                OPCItem item = _opcGroup.OPCItems.AddItem(opcItem, 1);
                object value;
                item.Read((short)OPCDataSource.OPCDevice, out value, out _, out _);
                int opcValue = Convert.ToInt32(value);
                return opcValue;
            }
            catch (Exception ex)
            {
                if (!opcErrorShown)
                {
                    opcErrorShown = true;
                    MessageBox.Show($"Đọc giá trị OPC item {opcItem} thất bại: {ex.Message}");
                }
                return 0; // Trả về giá trị mặc định nếu đọc thất bại
            }
        }
        public static float GetOPCValueAsFloat(string opcItem)
        {
            try
            {
                if (!isConnected)
                {
                    if (!opcErrorShown)
                    {
                        opcErrorShown = true;
                    }
                    return 0; // Giá trị mặc định
                }
                OPCItem item = _opcGroup.OPCItems.AddItem(opcItem, 1);
                object value;
                item.Read((short)OPCDataSource.OPCDevice, out value, out _, out _);
                float opcValue = float.Parse(value.ToString());
                return opcValue;
            }
            catch (Exception ex)
            {
                if (!opcErrorShown)
                {
                    opcErrorShown = true;
                    MessageBox.Show($"Đọc giá trị OPC item {opcItem} thất bại: {ex.Message}");
                }
                return 0; // Trả về giá trị mặc định nếu đọc thất bại
            }
        }

        public  void SetOPCValue(string opcItem, int value)
        {
            try
            {
                OPCItem item = _opcGroup.OPCItems.AddItem(opcItem, 1);
                item.Write(value);
            }
            catch (Exception ex)
            {
                if (!opcErrorShown)
                {
                    MessageBox.Show($"Ghi giá trị OPC item {opcItem} thất bại: {ex.Message}");
                    opcErrorShown = true;
                }
            }
        }
        public static bool SetOPCValue(string opcItem, bool value)
        {
            try
            {
                OPCItem item = _opcGroup.OPCItems.AddItem(opcItem, 1);
                item.Write(value);
                return true;
            }
            catch (Exception ex)
            {
                if (!opcErrorShown)
                {
                    MessageBox.Show($"Ghi giá trị OPC item {opcItem} thất bại: {ex.Message}");
                    opcErrorShown = true;
                }
            }
            return false;
        }
        public static bool SetOPCValue(string opcItem, float value)
        {
            try
            {
                OPCItem item = _opcGroup.OPCItems.AddItem(opcItem, 1);
                item.Write(value);
                return true;
            }
            catch (Exception ex)
            {
                if (!opcErrorShown)
                {
                    MessageBox.Show($"Ghi giá trị OPC item {opcItem} thất bại: {ex.Message}");
                    opcErrorShown = true;
                }
                return false; // Trả về false nếu ghi thất bại
            }
        }
        public Dictionary<string, decimal> GetMultipleOPCValues(List<string> opcItems)
        {
            var result = new Dictionary<string, decimal>();

            foreach (var item in opcItems)
            {
                try
                {
                    result[item] = GetOPCValue(item);
                }
                catch
                {
                    result[item] = -1; // Trả về giá trị mặc định khi lỗi
                }
            }

            return result;
        }


        public static OPCGroupInfo SpeedGroupInfo = new OPCGroupInfo()
        {
            Name = TagConstants.speedDevice,
            Tags = new Dictionary<int, OPCTag>()
            {
                { TagConstants.tocdo_tocdo, new  OPCTag(TagConstants.speedDevice,"tocdo") },
                { TagConstants.tocdo_max, new  OPCTag(TagConstants.speedDevice,"tocdo_max") },
                //{ TagConstants.tocdo_thoigian, new  OPCTag(TagConstants.speedDevice,"thoigian" )},
                { TagConstants.tocdo_nepsau, new  OPCTag(TagConstants.speedDevice,"nepsau",true) },
                { TagConstants.tocdo_neptruoc, new  OPCTag(TagConstants.speedDevice,"neptruoc" ,true)},
                { TagConstants.tocdo_motorulo, new  OPCTag(TagConstants.speedDevice,"motorulo",true )},
                { TagConstants.tocdo_bedo, new  OPCTag(TagConstants.speedDevice,"bedo",true )},
                { TagConstants.tocdo_max_batdau, new  OPCTag(TagConstants.speedDevice,"tocdo_max_batdau",true) },
                { TagConstants.tocdo_max_ketthuc, new  OPCTag(TagConstants.speedDevice,"tocdo_max_ketthuc",true) }
            }
        };
        public static OPCGroupInfo BrakeForceGroupInfo = new OPCGroupInfo()
        {
            Name = TagConstants.brakeForceDevice,
            Tags = new Dictionary<int, OPCTag>()
            {
                { TagConstants.lucphanh_phanhtruoc, new  OPCTag(TagConstants.brakeForceDevice,"phanhtruoc") },
                { TagConstants.lucphanh_phanhtruoc_max , new OPCTag(TagConstants.brakeForceDevice, "phanhtruoc_max") },
                //{ TagConstants.lucphanh_phanhsau , new OPCTag(TagConstants.speedDevice, "phanhsau") },
                { TagConstants.lucphanh_phanhsau_max , new OPCTag(TagConstants.brakeForceDevice, "phanhsau_max") },
                { TagConstants.lucphanh_nepsau, new  OPCTag(TagConstants.brakeForceDevice, "nepsau",true) },
                { TagConstants.lucphanh_neptruoc, new  OPCTag(TagConstants.brakeForceDevice, "neptruoc",true )},
                { TagConstants.lucphanh_motorulo, new  OPCTag(TagConstants.brakeForceDevice, "motorulo",true )},
                { TagConstants.lucphanh_bedo, new  OPCTag(TagConstants.brakeForceDevice,"bedo",true )},
                { TagConstants.lucphanh_phanhtruoc_max_batdau, new  OPCTag(TagConstants.brakeForceDevice,"phanhtruoc_max_batdau",true) },
                { TagConstants.lucphanh_phanhtruoc_max_ketthuc, new  OPCTag(TagConstants.brakeForceDevice,"phanhtruoc_max_ketthuc",true) },
                { TagConstants.lucphanh_phanhsau_max_batdau, new  OPCTag(TagConstants.brakeForceDevice,"phanhsau_max_batdau",true) },
                { TagConstants.lucphanh_phanhsau_max_ketthuc, new  OPCTag(TagConstants.brakeForceDevice,"phanhsau_max_ketthuc",true) }
            }
        };
        public static OPCGroupInfo SlideSlipGroupInfo = new OPCGroupInfo()
        {
            Name = TagConstants.slideSlipDevice,
            Tags = new Dictionary<int, OPCTag>()
            {
            { TagConstants.trungvet_trungvet , new OPCTag(TagConstants.slideSlipDevice, "trungvet")},
            { TagConstants.trungvet_neptruoc, new  OPCTag(TagConstants.slideSlipDevice,"neptruoc",true )},
            { TagConstants.trungvet_nepsau, new  OPCTag(TagConstants.slideSlipDevice,"nepsau",true) },
            { TagConstants.trungvet_max, new  OPCTag(TagConstants.slideSlipDevice,"trungvet_max" )},
            { TagConstants.trungvet_chotban, new  OPCTag(TagConstants.slideSlipDevice,"chotban" )},
            { TagConstants.trungvet_max_batdau, new  OPCTag(TagConstants.slideSlipDevice,"trungvet_max_batdau",true) },
            { TagConstants.trungvet_max_ketthuc, new  OPCTag(TagConstants.slideSlipDevice,"trungvet_max_ketthuc",true) }
            }
        };
        public static OPCGroupInfo NoiseGroupInfo = new OPCGroupInfo()
        {
            Name = TagConstants.noiseDevice,
            Tags = new Dictionary<int, OPCTag>()
            {
            { TagConstants.doon_doon , new OPCTag(TagConstants.noiseDevice, "doon")},
               { TagConstants.doon_doon_batdau , new OPCTag(TagConstants.noiseDevice, "doon_batdau",true)},
                  { TagConstants.doon_doon_ketthuc , new OPCTag(TagConstants.noiseDevice, "doon_ketthuc",true)},
                  { TagConstants.doon_reset , new OPCTag(TagConstants.noiseDevice, "doon_reset")},
                  { TagConstants.doon_max , new OPCTag(TagConstants.noiseDevice, "doon_max")}
            }
        };
        public void ConnectOPCServer()
        {
            try
            {
                try
                {
                    opcServer = new OPCServer();
                    opcServer.Connect(OPC_SERVER_NAME, "");
                    _opcGroup = opcServer.OPCGroups.Add("CalibGroup");
                    _opcGroup.IsActive = true;
                    _opcGroup.IsSubscribed = true;
                    _opcGroup.UpdateRate = 1000;
                    isConnected = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi khởi động OPC: {ex.Message}");
                }

                StartOPCListenerSlideSlip();
                StartOPCListenerSpeed();
                StartOPCListenerBrake();
                StartOPCListenerNoise();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi động OPC listener: {ex.Message}");
            }
        }
        private OPCGroup InitOPCGroup(OPCGroup opcGroup, string groupName)
        {
            opcGroup = opcServer.OPCGroups.Add(groupName);
            opcGroup.IsSubscribed = true;
            opcGroup.UpdateRate = 1000;
            opcGroup.IsActive = true;
            return opcGroup;
        }
        void AddTags(OPCGroupInfo opcGroupInfo, OPCGroup oPCGroup)
        {
            foreach (var tag in opcGroupInfo.Tags)
            {
                try
                {
                    if (tag.Value.IsBoolean)
                        tag.Value.Value = false;
                    else
                        tag.Value.Value = 0;
                    // Thêm từng tag vào OPC group 
                    tag.Value.Item = oPCGroup.OPCItems.AddItem(tag.Value.Tag, tag.Key);
                    tag.Value.Item.IsActive = true;

                }
                catch (Exception ex)
                {
                    LogTagError($"AddItem lỗi cho tag '{tag.Value.Tag}' (nhóm={opcGroupInfo.Name}, handle={tag.Key}): {ex.Message}");
                }
            }
        }
        private void StartOPCListenerSlideSlip()
        {
            _slideSlipGroup = InitOPCGroup(_slideSlipGroup, SlideSlipGroupInfo.Name);
            _slideSlipGroup.DataChange += OnDataChangeSlideSlip;
            AddTags(SlideSlipGroupInfo, _slideSlipGroup);
        }
        private void StartOPCListenerSpeed()
        {
            _speedGroup = InitOPCGroup(_speedGroup, SpeedGroupInfo.Name);
            _speedGroup.DataChange += OnDataChangeSpeed;
            AddTags(SpeedGroupInfo, _speedGroup);
        }
        private void StartOPCListenerBrake()
        {
            _brakeGroup = InitOPCGroup(_brakeGroup, BrakeForceGroupInfo.Name);
            _brakeGroup.DataChange += OnDataChangeBrakeForce;
            AddTags(BrakeForceGroupInfo, _brakeGroup);
        }
        private void StartOPCListenerNoise()
        {
            _noiseGroup = InitOPCGroup(_brakeGroup, NoiseGroupInfo.Name);
            _noiseGroup.DataChange += OnDataChangeNoise;
            AddTags(NoiseGroupInfo, _noiseGroup);
        }
        // 🔔 DataChange event fires when any subscribed item value changes
        private void OnDataChangeSpeed(int TransactionID, int NumItems,
            ref Array ClientHandles, ref Array ItemValues,
            ref Array Qualities, ref Array TimeStamps)
        {
            FrmMotobikeMain form = GetActiveForm();
            if (form != null)
            {
                for (int i = 1; i <= NumItems; i++)
                {
                    int handle = (int)ClientHandles.GetValue(i);
                    string value = ItemValues.GetValue(i)?.ToString();

                    switch (handle)
                    {
                        case TagConstants.tocdo_tocdo:
                            var speed = (float)Math.Round(GlobalFunctions.ConvertIntToFloat(value) - GlobalVariables.SpeedZero,1);
                            SpeedGroupInfo.Tags[handle].Value = speed;
                            form.speedUC.SetValue(speed);
                            OnCalibDataReceived?.Invoke(MenuConstants.Speed, speed); // Gọi sự kiện để cập nhật dữ liệu
                            break;
                        case TagConstants.tocdo_max:
                            var maxSpeed = (float)Math.Round(GlobalFunctions.ConvertIntToFloat(value) - GlobalVariables.SpeedZero,1);
                            SpeedGroupInfo.Tags[TagConstants.tocdo_max].Value = maxSpeed;
                            form.speedUC.SetConfirmValue1(maxSpeed);
                            GlobalVariables.TestVehicle.Speed = maxSpeed;
                            OnDataReceived?.Invoke(MenuConstants.Speed); 
                            break;
                        case TagConstants.tocdo_thoigian:
                            SpeedGroupInfo.Tags[handle].Value = float.Parse(value);
                            form.speedUC.SetConfirmValue2((float)SpeedGroupInfo.Tags[handle].Value);
                            break;
                        case TagConstants.tocdo_nepsau:
                            form.OpenFromOPC(MenuConstants.Speed);
                            SpeedGroupInfo.Tags[handle].Value = bool.Parse(value);
                            form.switchFourSpeedUC.Trigger(2, (bool)SpeedGroupInfo.Tags[handle].Value);
                            break;
                        case TagConstants.tocdo_neptruoc:
                            form.OpenFromOPC(MenuConstants.Speed);
                            SpeedGroupInfo.Tags[handle].Value = bool.Parse(value);
                            form.switchFourSpeedUC.Trigger(1, (bool)SpeedGroupInfo.Tags[handle].Value);
                            break;
                        case TagConstants.tocdo_motorulo:
                            form.OpenFromOPC(MenuConstants.Speed);
                            SpeedGroupInfo.Tags[handle].Value = bool.Parse(value);
                            form.switchFourSpeedUC.Trigger(3, (bool)SpeedGroupInfo.Tags[handle].Value);
                            break;
                        case TagConstants.tocdo_bedo:
                            form.OpenFromOPC(MenuConstants.Speed);
                            SpeedGroupInfo.Tags[handle].Value = bool.Parse(value);
                            form.switchFourSpeedUC.Trigger(4, (bool)SpeedGroupInfo.Tags[handle].Value);
                            break;

                        case TagConstants.tocdo_max_batdau:
                            //MessageBox.Show("tocdo_max_batdau: " + value); 
                            break;
                        case TagConstants.tocdo_max_ketthuc:
                            //MessageBox.Show("tocdo_max_ketthuc: " + value);
                            break;
                        default:
                            break;
                    }

                }
            }
        }
        // 🔔 DataChange event fires when any subscribed item value changes
        private void OnDataChangeSlideSlip(int TransactionID, int NumItems,
            ref Array ClientHandles, ref Array ItemValues,
            ref Array Qualities, ref Array TimeStamps)
        {

            FrmMotobikeMain form = GetActiveForm();
            if (form != null)
            {
                for (int i = 1; i <= NumItems; i++)
                {
                    int handle = (int)ClientHandles.GetValue(i);
                    string value = ItemValues.GetValue(i)?.ToString();

                    switch (handle)
                    {
                        case TagConstants.trungvet_trungvet:
                            //MessageBox.Show("Trung vet goc :" + value);
                            var valueSlideSlip = GlobalFunctions.ConvertIntToFloat(value)-GlobalVariables.SlideSlipZero;
                            //MessageBox.Show("Trung vet :" + valueSlideSlip.ToString());
                            SlideSlipGroupInfo.Tags[handle].Value = valueSlideSlip;
                            form.slideSlipUC.SetValue(valueSlideSlip);
                            OnCalibDataReceived?.Invoke(MenuConstants.SlideSlip, valueSlideSlip); // Gọi sự kiện để cập nhật dữ liệu
                            break;
                        case TagConstants.trungvet_nepsau:
                            form.OpenFromOPC(MenuConstants.SlideSlip);
                            SlideSlipGroupInfo.Tags[handle].Value = bool.Parse(value);
                            form.switchFourSlideSlipUC.Trigger(2, (bool)SlideSlipGroupInfo.Tags[handle].Value);
                            break;
                        case TagConstants.trungvet_neptruoc:
                            form.OpenFromOPC(MenuConstants.SlideSlip);
                            SlideSlipGroupInfo.Tags[handle].Value = bool.Parse(value);
                            form.switchFourSlideSlipUC.Trigger(1, (bool)SlideSlipGroupInfo.Tags[handle].Value);
                            break;
                        case TagConstants.trungvet_chotban:
                            form.OpenFromOPC(MenuConstants.SlideSlip);
                            SlideSlipGroupInfo.Tags[handle].Value = bool.Parse(value);
                            form.switchFourSlideSlipUC.Trigger(3, (bool)SlideSlipGroupInfo.Tags[handle].Value);
                            break;

                        case TagConstants.trungvet_max:
                            var average = GlobalFunctions.ConvertIntToFloat(value) - GlobalVariables.SlideSlipZero; 
                            SlideSlipGroupInfo.Tags[TagConstants.trungvet_max].Value = average;
                            form.slideSlipUC.SetConfirmValue1(average);
                            GlobalVariables.TestVehicle.SlideSlip = average;
                            OnDataReceived?.Invoke(MenuConstants.SlideSlip); 
                            break;
                        case TagConstants.trungvet_max_batdau:
                            if (bool.Parse(value))
                                SlideSlipGroupInfo.Max1s = new List<float>();
                            break;
                        case TagConstants.trungvet_max_ketthuc:
                            if (bool.Parse(value))
                            {
                                //MessageBox.Show("Trùng vết: " + string.Join(",", SlideSlipGroupInfo.Max1s));
                                //var average = SlideSlipGroupInfo.Max1s.Average();
                                //SlideSlipGroupInfo.Tags[TagConstants.trungvet_max].Value = average;
                                //form.slideSlipUC.SetConfirmValue1(average);
                                //GlobalVariables.TestVehicle.SlideSlip = average;
                                //OnDataReceived?.Invoke(MenuConstants.SlideSlip);
                                //SlideSlipGroupInfo.Max1s = new List<float>();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        float phanhtruoc_max = float.MinValue;
        float phanhsau_max = float.MinValue;

        // 🔔 DataChange event fires when any subscribed item value changes
        private void OnDataChangeBrakeForce(int TransactionID, int NumItems,
            ref Array ClientHandles, ref Array ItemValues,
            ref Array Qualities, ref Array TimeStamps)
        {
            FrmMotobikeMain form = GetActiveForm();
            if (form != null)
            {
                for (int i = 1; i <= NumItems; i++)
                {
                    int handle = (int)ClientHandles.GetValue(i);
                    string value = ItemValues.GetValue(i)?.ToString();
                    switch (handle)
                    {
                        case TagConstants.lucphanh_phanhtruoc:
                            BrakeForceGroupInfo.Tags[handle].Value = (float)Math.Round(GlobalFunctions.ConvertIntToFloat(value) - GlobalVariables.BrakeForceZero, 1);
                            form.brakeForceBothUC.SetValue((float)BrakeForceGroupInfo.Tags[handle].Value);
                            form.brakeForceBothUC.UpdateBrakeRange(true);
                            OnCalibDataReceived?.Invoke(MenuConstants.BrakeForce, (float)BrakeForceGroupInfo.Tags[handle].Value); // Gọi sự kiện để cập nhật dữ liệu
                            break;
                        case TagConstants.lucphanh_phanhsau:
                            BrakeForceGroupInfo.Tags[handle].Value = (float)Math.Round(GlobalFunctions.ConvertIntToFloat(value) - GlobalVariables.BrakeForceZero,1);
                            form.brakeForceBothUC.SetValue((float)BrakeForceGroupInfo.Tags[handle].Value);
                            form.brakeForceBothUC.UpdateBrakeRange(false);
                            OnCalibDataReceived?.Invoke(MenuConstants.BrakeForce, (float)BrakeForceGroupInfo.Tags[handle].Value); // Gọi sự kiện để cập nhật dữ liệu
                            break;

                        case TagConstants.lucphanh_nepsau:
                            form.OpenFromOPC(MenuConstants.BrakeForce);
                            BrakeForceGroupInfo.Tags[handle].Value = bool.Parse(value);
                            form.switchFourBrakeUC.Trigger(2, (bool)BrakeForceGroupInfo.Tags[handle].Value);
                            break;
                        case TagConstants.lucphanh_neptruoc:
                            form.OpenFromOPC(MenuConstants.BrakeForce);
                            BrakeForceGroupInfo.Tags[handle].Value = bool.Parse(value);
                            form.switchFourBrakeUC.Trigger(1, (bool)BrakeForceGroupInfo.Tags[handle].Value);
                            break;
                        case TagConstants.lucphanh_motorulo:
                            form.OpenFromOPC(MenuConstants.BrakeForce);
                            BrakeForceGroupInfo.Tags[handle].Value = bool.Parse(value);
                            form.switchFourBrakeUC.Trigger(3, (bool)BrakeForceGroupInfo.Tags[handle].Value);
                            break;

                        case TagConstants.lucphanh_bedo:
                            form.OpenFromOPC(MenuConstants.BrakeForce);
                            BrakeForceGroupInfo.Tags[handle].Value = bool.Parse(value);
                            form.switchFourBrakeUC.Trigger(4, (bool)BrakeForceGroupInfo.Tags[handle].Value);
                            break;

                        case TagConstants.lucphanh_phanhtruoc_max:
                            var brakeFront = (float)Math.Round(GlobalFunctions.ConvertIntToFloat(value) - GlobalVariables.BrakeForceZero,1);
                            if (brakeFront < 0) brakeFront = 0;
                            BrakeForceGroupInfo.Tags[handle].Value = brakeFront;
                            //BrakeForceGroupInfo.Max1s.Add(brakeFront);
                            if(brakeFront>phanhtruoc_max)
                            {
                                phanhtruoc_max = brakeFront;
                                form.brakeForceBothUC.SetConfirmValue1(phanhtruoc_max);
                                GlobalVariables.TestVehicle.BrakeForceFront = phanhtruoc_max;
                                OnDataReceived?.Invoke(MenuConstants.BrakeForce);
                            }    
                            break;
                        case TagConstants.lucphanh_phanhtruoc_max_batdau:
                            if (bool.Parse(value))
                            {
                                phanhtruoc_max = float.MinValue;
                                BrakeForceGroupInfo.Max1s = new List<float>();
                                form.brakeForceBothUC.SetConfirmValue1(0);
                                GlobalVariables.TestVehicle.BrakeForceFront = 0;
                            }
                            break;
                        case TagConstants.lucphanh_phanhtruoc_max_ketthuc:
                            if (bool.Parse(value))
                            {
                                //var average = BrakeForceGroupInfo.Max1s.Average();
                                //BrakeForceGroupInfo.Tags[TagConstants.lucphanh_phanhtruoc_max].Value = average;
                                //form.brakeForceBothUC.SetConfirmValue1(average);
                                //GlobalVariables.TestVehicle.BrakeForceFront = average;
                                //OnDataReceived?.Invoke(MenuConstants.BrakeForce);
                                //BrakeForceGroupInfo.Max1s = new List<float>();
                            }
                            break;

                        case TagConstants.lucphanh_phanhsau_max:
                            var brakeRear = (float)Math.Round(GlobalFunctions.ConvertIntToFloat(value) - GlobalVariables.BrakeForceZero,1);
                            if (brakeRear < 0) brakeRear = 0;
                            BrakeForceGroupInfo.Tags[handle].Value = brakeRear;
                            //BrakeForceGroupInfo.Max2s.Add(brakeRear);
                            if(brakeRear > phanhsau_max)
                            {
                                phanhsau_max = brakeRear;
                                form.brakeForceBothUC.SetConfirmValue2(phanhsau_max);
                                GlobalVariables.TestVehicle.BrakeForceRear = phanhsau_max;
                                OnDataReceived?.Invoke(MenuConstants.BrakeForce);
                            }
                            break;
                        case TagConstants.lucphanh_phanhsau_max_batdau:
                            if (bool.Parse(value))
                            {
                                phanhsau_max = float.MinValue;
                                BrakeForceGroupInfo.Max2s = new List<float>();
                                form.brakeForceBothUC.SetConfirmValue2(0);
                                GlobalVariables.TestVehicle.BrakeForceRear = 0;
                            }
                            break;
                        case TagConstants.lucphanh_phanhsau_max_ketthuc:
                            if (bool.Parse(value))
                            {
                                //var average = BrakeForceGroupInfo.Max2s.Average();
                                //BrakeForceGroupInfo.Tags[TagConstants.lucphanh_phanhsau_max].Value = average;
                                //form.brakeForceBothUC.SetConfirmValue2(average);
                                //GlobalVariables.TestVehicle.BrakeForceRear = average;
                                //OnDataReceived?.Invoke(MenuConstants.BrakeForce);
                                //BrakeForceGroupInfo.Max2s = new List<float>();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static void OnDataChangeNoise(int TransactionID, int NumItems,
         ref Array ClientHandles, ref Array ItemValues,
         ref Array Qualities, ref Array TimeStamps)
        {
            FrmMotobikeMain form = Program.MainFormInstance;
            if (form != null)
            {
                for (int i = 1; i <= NumItems; i++)
                {
                    int handle = (int)ClientHandles.GetValue(i);
                    string value = ItemValues.GetValue(i)?.ToString();
                    switch (handle)
                    {
                        case TagConstants.doon_doon_batdau:
                            if (bool.Parse(value))
                                NoiseGroupInfo.Max1s = new List<float>();
                            break;
                        case TagConstants.doon_doon_ketthuc:
                            //if (bool.Parse(value))
                            //{
                            //    // Tính giá trị trung bình của tiếng còi
                            //    var averageWhistle = NoiseGroupInfo.Max1s.Average();
                            //    NoiseGroupInfo.Tags[TagConstants.doon_doon].Value = averageWhistle;
                            //    GlobalVariables.TestVehicle.Whistle = averageWhistle;

                            //    OnDataReceived?.Invoke(MenuConstants.Noise);
                            //    NoiseGroupInfo.Max1s = new List<float>();
                            //}
                            break;
                        case TagConstants.doon_doon:
                            var whistle = GlobalFunctions.ConvertIntToFloat(value);
                            NoiseGroupInfo.Tags[TagConstants.doon_doon].Value = whistle;
                            //var averageWhistle = whistle;
                            //NoiseGroupInfo.Tags[TagConstants.doon_doon].Value = averageWhistle;
                            //GlobalVariables.TestVehicle.Whistle = averageWhistle;
                            //OnDataReceived?.Invoke(MenuConstants.Noise);
                            break;
                        case TagConstants.doon_max:
                            // PLC tự giữ đỉnh còi, đọc trực tiếp thay vì client tự dò max
                            var maxNoise = GlobalFunctions.ConvertIntToFloat(value);
                            NoiseGroupInfo.Tags[TagConstants.doon_max].Value = maxNoise;
                            MaxNoise = maxNoise;
                            break;
                        default:
                            break;
                    }
                }
            }
        }


        private FrmMotobikeMain GetActiveForm()
        {
            return Program.MainFormInstance;
        }
    }
}
