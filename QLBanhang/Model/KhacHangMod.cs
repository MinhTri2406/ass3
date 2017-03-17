using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLBanhang.Object;

namespace QLBanhang.Model
{
    class KhacHangMod
    {
        ConnectToSQL sqlcon = new ConnectToSQL();
        SqlCommand sqlcmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            sqlcmd.CommandText = "select MaKH, TenKH, GioiTinh, NamSinh, DiaChi, SDT, Email, Diem, NgayThemVao from tb_KhachHang";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = sqlcon.Connection;
            try
            {
                sqlcon.OpenConn();
                SqlDataAdapter sqlDA = new SqlDataAdapter(sqlcmd);
                sqlDA.Fill(dt);
            }
            catch (Exception ex)
            {
                string es = ex.Message;
                sqlcmd.Dispose();
                sqlcon.CloseConn();
            }
            return dt;
        }
        public bool AddData(KhachHangObj KH_Obj)
        {
            sqlcmd.CommandText = "Insert into tb_KhachHang values('" + KH_Obj.MaKhachHang + "', N'" + KH_Obj.TenKhachHang + "', N'" + KH_Obj.GioiTinh + "', CONVERT(DATE, '" + KH_Obj.NamSinh + "', 103), N'" + KH_Obj.SoDienThoai + "', N'" + KH_Obj.DiachiKH + "','" + KH_Obj.DiaChiEmail + "',0, CONVERT(DATE, '" + KH_Obj.Ngay_them_vao + "', 103))";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = sqlcon.Connection;
            try
            {
                sqlcon.OpenConn();
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mes = ex.Message;

                sqlcmd.Dispose();
                sqlcon.CloseConn();
            }
            return false;
        }
        public bool UpdateData(KhachHangObj KH_Obj)
        {
            sqlcmd.CommandText = "Update tb_KhachHang set TenKH = N'" + KH_Obj.TenKhachHang + "', GioiTinh = N'" + KH_Obj.GioiTinh + "', NamSinh = CONVERT(DATE, '" + KH_Obj.NamSinh + "', 103), SDT = '" + KH_Obj.SoDienThoai + "', DiaChi = N'" + KH_Obj.DiachiKH + "', Diem = '" + KH_Obj.DiemTichLuy + "', Email = '" + KH_Obj.DiaChiEmail + "' Where MaKH = '" + KH_Obj.MaKhachHang + "'";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = sqlcon.Connection;

            try
            {
                sqlcon.OpenConn();
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                sqlcmd.Dispose();
                sqlcon.CloseConn();
            }
            return false;
        }

        //FIND DATA FROM DATABASE
        public DataTable Find(string commandtext)
        {
            DataTable dt = new DataTable();
            sqlcmd.CommandText = commandtext;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = sqlcon.Connection;
            try
            {
                sqlcon.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                sqlcon.Error = ex.Message;
                sqlcmd.Dispose();
                sqlcon.CloseConn();
            }
            return dt;
        }
        public bool DelData(string MaKH)//Xóa Khách hàng theo mã khách hàng.
        {
            sqlcmd.CommandText = "Delete tb_KhachHang Where MaKH = '" + MaKH + "' ";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = sqlcon.Connection;

            try
            {
                sqlcon.OpenConn();
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //string mes = ex.Message;
                sqlcmd.Dispose();
                sqlcon.CloseConn();
            }
            return false;
        }
        public bool UpDiemMuaHang(KhachHangObj KH_Obj)
        {
            sqlcmd.CommandText = "Update tb_KhachHang set Diem = '" + KH_Obj.DiemTichLuy + "' Where MaKH = '" + KH_Obj.MaKhachHang + "' ";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = sqlcon.Connection;

            try
            {
                sqlcon.OpenConn();
                sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                //string mes = ex.Message;
                sqlcmd.Dispose();
                sqlcon.CloseConn();
            }
            return false;
        }
    }
}
