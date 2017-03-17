using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanhang.Object
{
    class HoaDonObj
    {
        string MaHoadon, MaNguoilap, sdtNguoilap, MaKhachhang, sdtKhachhang, NgayLapHoadon;

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

        public string MaKhachHang
        {
            get { return MaKhachhang; }
            set { MaKhachhang = value; }
        }

        public string SdtKhachHang
        {
            get { return sdtKhachhang; }
            set { sdtKhachhang = value; }
        }

        public string NgayLapHoaDon
        {
            get { return NgayLapHoadon; }
            set { NgayLapHoadon = value; }
        }

        HoaDonObj() { }
        HoaDonObj(string MasoHD, string MasoNguoilap, string SdtNguoiLap, string MasoKH, string SdtKH, string NgaylapHD)
        {
            this.MaHoadon = MasoHD;
            //this.MaHanghoa = MasoHH;
            this.MaNguoilap = MasoNguoilap;
            this.sdtNguoilap = SdtNguoiLap;
            this.MaKhachhang = MasoKH;
            this.sdtKhachhang = SdtKH;
            this.NgayLapHoadon = NgaylapHD;
        }
    }
}
