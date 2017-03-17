using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanhang.Object
{
    class KhachHangObj
    {
        string ID, Ten, Gioitinh, Namsinh, Sdt, Diachi, Email, Ngaythemvao;

        
        int DiemTL;
        public string DiachiKH
        {
            get { return Diachi; }
            set { Diachi = value; }
        }
        
        public string MaKhachHang
        {
            get { return ID; }
            set { ID = value; }
        }

        public string TenKhachHang
        {
            get { return Ten; }
            set { Ten = value; }
        }

        public string GioiTinh
        {
            get { return Gioitinh; }
            set { Gioitinh = value; }
        }

        public string NamSinh
        {
            get { return Namsinh; }
            set { Namsinh = value; }
        }

        public string SoDienThoai
        {
            get { return Sdt; }
            set { Sdt = value; }
        }

        public string DiaChiEmail
        {
            get { return Email; }
            set { Email = value; }
        }
        
        public int DiemTichLuy
        {
            get { return DiemTL; }
            set { DiemTL = value; }
        }
        public string Ngay_them_vao
        {
            get { return Ngaythemvao; }
            set { Ngaythemvao = value; }
        }
        public KhachHangObj() { }
        public KhachHangObj(string id, string ten, string gioitinh, string diachi, string sdt, string namsinh, string email, int diemmuahang, string adddate)
        {
            this.ID = id;
            this.Ten = ten;
            this.Gioitinh = gioitinh;
            this.Diachi = diachi;
            this.Sdt = sdt;
            this.Namsinh = namsinh;
            this.Email = email;
            this.DiemTL = diemmuahang;
            this.Ngaythemvao = adddate;
        }
    }
}
