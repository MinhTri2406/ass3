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
    class NhanVienMod
    {
        ConnectToSQL sqlcon = new ConnectToSQL(); //Class ConnectToSQL.
        SqlCommand sqlcmd = new SqlCommand();

        public DataTable GetData()
        {
            DataTable dt = new DataTable();
            
            sqlcmd.CommandText = "select MaNV, TenNV, GioiTinh, NamSinh, DiaChi, Email, SDT, NgayVaoLamViec from tb_NhanVien";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = sqlcon.Connection; //"sqlcmd.Connection = sqlcon" if there is not constructor Connection of class ConnectToSQL.
            try
            {
                sqlcon.OpenConn();
                SqlDataAdapter SDA = new SqlDataAdapter(sqlcmd);
                SDA.Fill(dt); //Fill data into table.
                //sqlcmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                sqlcmd.Dispose();
                sqlcon.CloseConn();
            }
            return dt;
        }

        //Add new data into the database:
        public bool AddData(NhanvienObj NvObj)
        {
            sqlcmd.CommandText = "Insert into tb_NhanVien values('" + NvObj.MaNhanVien + "',N'" + NvObj.TenNhanVien + "',N'" + NvObj.GioiTinh + "',CONVERT(DATE,'" + NvObj.NamSinh + "', 103),N'" + NvObj.DiaChi + "', '" + NvObj.SoDienThoai + "','"+ NvObj.Email +"', '" + NvObj.MatKhau + "', CONVERT(DATE,'" + NvObj.Day_Begin_Working + "', 103))";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = sqlcon.Connection; //"sqlcmd.Connection = sqlcon" if there is not constructor Connection of class ConnectToSQL.
            try { 
                sqlcon.OpenConn();
                sqlcmd.ExecuteNonQuery();//Update  new data in database.
                return true;
            }
            catch(Exception ex){
                string mes = ex.Message;
                sqlcmd.Dispose();
                sqlcon.CloseConn();
            }
            return false;
        }

        //Update data in dataabase:
        public bool UpdateData(NhanvienObj NvObj)
        {
            sqlcmd.CommandText = "Update tb_NhanVien set TenNV = N'" + NvObj.TenNhanVien + "', GioiTinh = N'" + NvObj.GioiTinh + "', Namsinh = CONVERT(DATE, '" + NvObj.NamSinh + "', 103), DiaChi = N'" + NvObj.DiaChi + "', SDT = '" + NvObj.SoDienThoai + "', Email = '"+ NvObj.Email +"', NgayVaoLamViec = CONVERT(DATE, '" + NvObj.Day_Begin_Working + "', 103) Where MaNV = '" + NvObj.MaNhanVien + "'";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = sqlcon.Connection; //"sqlcmd.Connection = sqlcon" if there is not constructor Connection of class ConnectToSQL.
            try {
                sqlcon.OpenConn();
                sqlcmd.ExecuteNonQuery();//Update this data in database.
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
        //Update password:
        public bool UpdatePass(NhanvienObj NvObj)
        {
            sqlcmd.CommandText = "Update tb_NhanVien set MatKhau = '"+NvObj.MatKhau+"' Where MaNV = '"+NvObj.MaNhanVien+"'";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = sqlcon.Connection;
            try {
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

        //Delete data:
        public bool DelData(string ID)
        {
            sqlcmd.CommandText = "Delete tb_NhanVien Where MaNV = '" + ID + "'";
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
    }
}
