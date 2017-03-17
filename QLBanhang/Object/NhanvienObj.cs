using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanhang.Object
{
    class NhanvienObj
    {
        string Ma, Ten, Gioitinh, Sdt, email, Diachi, Matkhau;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        string Namsinh, DayBeginWorking;

        public string Day_Begin_Working
        {
            get { return DayBeginWorking; }
            set { DayBeginWorking = value; }
        }
        
        public string MatKhau
        {
            get { return Matkhau; }
            set { Matkhau = value; }
        }

        public string DiaChi
        {
            get { return Diachi; }
            set { Diachi = value; }
        }

        public string SoDienThoai
        {
            get { return Sdt; }
            set { Sdt = value; }
        }

        public string GioiTinh
        {
            get { return Gioitinh; }
            set { Gioitinh = value; }
        }

        public string TenNhanVien
        {
            get { return Ten; }
            set { Ten = value; }
        }

        public string MaNhanVien
        {
            get { return Ma; }
            set { Ma = value; }
        }
  
        public string NamSinh
        {
            get { return Namsinh; }
            set { Namsinh = value; }
        }

        public NhanvienObj() { }
        public NhanvienObj(string ma, string ten, string gioitinh, string sdt, string namsinh, string email, string diachi, string matkhau, string ngayvaolamviec)
        {
            this.Ma = ma;
            this.Ten = ten;
            this.Gioitinh = gioitinh;
            this.Sdt = sdt;
            this.Namsinh = namsinh;
            this.Diachi = diachi;
            this.Matkhau = matkhau;
            this.DayBeginWorking = ngayvaolamviec;
            this.email = email;
        }
    }
}
