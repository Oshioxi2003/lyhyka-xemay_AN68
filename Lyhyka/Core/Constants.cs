using Lyhyka.OPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lyhyka.Core
{
    public class Constants
    {
        public const string AppName = "Lyhyka";
        public const string AppVersion = "1.0.0";
        public const string AppDescription = "A versatile application for managing and interacting with various data types.";
        public const int SlideSlipDelta = 5;
    }
    public class MenuConstants
    { 
        public const string Speed = "tốc độ";
        public const string BrakeForce = "lực phanh";
        public const string SlideSlip = "trùng vết";
        public const string Weight = "trọng lượng";
        public const string Print = "in phiếu";
        public const string Home = "trang chủ";
        public const string Exit = "thoát";
        public const string Calibrate = "hiệu chuẩn";
        public const string Setting = "cài đặt";
        public const string Search = "tra cứu";
        public const string Noise = "Noise";
        public const string Headlight = "đèn pha";
    }

    public class TagConstants
    {
        public const string chanel = "maykiemdinh.LK3U";
        public const string speedDevice = "TocDo";
        public const string brakeForceDevice = "LucPhanh";
        public const string slideSlipDevice = "DoLech";
        public const string weightDevice = "TrongLuong";
        public const string noiseDevice = "DoOn";

        public const int tocdo_tocdo = 1;
        public const int tocdo_max = 2;
        public const int tocdo_thoigian = 3;
        public const int tocdo_nepsau = 4;
        public const int tocdo_neptruoc = 5;
        public const int tocdo_motorulo = 6;
        public const int tocdo_bedo = 7; 
        public const int tocdo_max_batdau = 8; 
        public const int tocdo_max_ketthuc = 9;

        public const int lucphanh_phanhtruoc = 1;
        public const int lucphanh_phanhsau = 2;
        public const int lucphanh_phanhtruoc_max = 3;
        public const int lucphanh_phanhsau_max = 4;
        public const int lucphanh_nepsau = 5;
        public const int lucphanh_neptruoc = 6;
        public const int lucphanh_motorulo = 7;
        public const int lucphanh_bedo = 8;
        public const int lucphanh_phanhtruoc_max_batdau = 9;
        public const int lucphanh_phanhtruoc_max_ketthuc = 10;
        public const int lucphanh_phanhsau_max_batdau = 11;
        public const int lucphanh_phanhsau_max_ketthuc = 12;


        public const int trungvet_trungvet = 1;
        public const int trungvet_max = 2; 
        public const int trungvet_nepsau = 3;
        public const int trungvet_neptruoc = 4;
        public const int trungvet_chotban = 5;
        public const int trungvet_max_batdau = 6;
        public const int trungvet_max_ketthuc = 7;

        public const int doon_doon = 1; 
        public const int doon_doon_batdau = 2; 
        public const int doon_doon_ketthuc = 3;
    }

    public class ColorConstants
    {
        public static readonly System.Drawing.Color LowerColor = System.Drawing.Color.FromArgb(255, 191, 0); 
        public static readonly System.Drawing.Color InRangeColor = System.Drawing.Color.FromArgb(155, 187, 89); // Màu xám
        public static readonly System.Drawing.Color HigherColor = System.Drawing.Color.FromArgb(231, 49, 65); // Màu xanh lá
    }
}