using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanhang.Object
{
    class ChiTietObj
    {
        string MaHD, MaHH;

        public string MaHoaDon
        {
            get { return MaHD; }
            set { MaHD = value; }
        }

        public string MaHang
        {
            get { return MaHH; }
            set { MaHH = value; }
        }
        int Soluong, Dongia, TongTien;

        public int SoLuong
        {
            get { return Soluong; }
            set { Soluong = value; }
        }

        public int DonGia
        {
            get { return Dongia; }
            set { Dongia = value; }
        }

        public int ThanhTien
        {
            get { return TongTien; }
            set { TongTien = value; }
        }
        public ChiTietObj(){}
        public ChiTietObj(string maHD, string maHH, int soluong, int dongia, int tongtien){
            this.MaHD = maHD;
            this.MaHH = maHH;
            this.Soluong = soluong;
            this.Dongia = dongia;
            this.TongTien = tongtien;
        }
    }
}
