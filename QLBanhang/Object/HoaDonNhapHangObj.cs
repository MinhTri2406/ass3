using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanhang.Object
{
    class HoaDonNhapHangObj
    {
        string MaHoadon, MaNguoilap, sdtNguoilap, MaNguoigiaohang, sdtnguoigiaohang, NgayLapHoadon;

        public string MaSoHoadon
        {
            get { return MaHoadon; }
            set { MaHoadon = value; }
        }

        //public string MaSoHanghoa
        //{
        //    get { return MaHanghoa; }
        //    set { MaHanghoa = value; }
        //}

        public string MaSoNguoilap
        {
            get { return MaNguoilap; }
            set { MaNguoilap = value; }
        }

        public string SdtNguoiLap
        {
            get { return sdtNguoilap; }
            set { sdtNguoilap = value; }
        }

        public string MaNguoiGiaoHang
        {
            get { return MaNguoigiaohang; }
            set { MaNguoigiaohang = value; }
        }

        public string SdtNguoiGiaoHang
        {
            get { return sdtnguoigiaohang; }
            set { sdtnguoigiaohang = value; }
        }

        public string NgayLapHoaDon
        {
            get { return NgayLapHoadon; }
            set { NgayLapHoadon = value; }
        }

        HoaDonNhapHangObj() { }
        HoaDonNhapHangObj(string MasoHD, string MasoNguoilap, string SdtNguoiLap, string MasoNGH, string SdtNGH, string NgaylapHD)
        {
            this.MaHoadon = MasoHD;
            //this.MaHanghoa = MasoHH;
            this.MaNguoilap = MasoNguoilap;
            this.sdtNguoilap = SdtNguoiLap;
            this.MaNguoigiaohang = MasoNGH;
            this.sdtnguoigiaohang = SdtNGH;
            this.NgayLapHoadon = NgaylapHD;
        }
    }
}
