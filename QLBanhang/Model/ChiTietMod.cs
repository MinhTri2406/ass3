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
    class ChiTietMod
    {
        ConnectToSQL Sqlcon = new ConnectToSQL();
        SqlCommand Sqlcmd = new SqlCommand();
        public DataTable GetData(string MaHD)
        {
            DataTable DT = new DataTable();
            Sqlcmd.CommandText = @"select chitiet.MaHD, hanghoa.TenHang TenHangHoa, chitiet.SoLuong, chitiet.DonGia, chitiet.ThanhTien from tb_CTHD chitiet, tb_HangHoa hanghoa where chitiet.MaHH = hanghoa.MaHang and chitiet.MaHD = '" + MaHD + "'";
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.Connection = Sqlcon.Connection;
            try {
                Sqlcon.OpenConn();
                SqlDataAdapter SDA = new SqlDataAdapter(Sqlcmd);
                SDA.Fill(DT);
            }
            catch (Exception ex)
            {
                Sqlcon.Error = ex.Message;
                Sqlcmd.Dispose();
                Sqlcon.CloseConn();
            }
            return DT;
        }
        public bool AddData(DataTable DT) // Chỉnh sửa dữ liệu số lượng, đơn giá từ bảng hóa đơn có sẵn. 
        {
            try
            {
                int i;
                for (i = 0; i < DT.Rows.Count; i++)
                {
                    Sqlcmd.CommandText = "insert into tb_CTHD values('')";
                }


                return true;
            }
            catch (Exception Ex)
            {
                Sqlcon.Error = Ex.Message;
                Sqlcmd.Dispose();
                Sqlcon.CloseConn();
            }
            return false;
        }
        public bool DelData(string Ma)
        {
            Sqlcmd.CommandText = "Delete tb_CTHD where MaHD = '" + Ma + "'";
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.Connection = Sqlcon.Connection;
            try {
                Sqlcon.OpenConn();
                Sqlcmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception Ex)
            {
                Sqlcon.Error = Ex.Message;
                Sqlcmd.Dispose();
                Sqlcon.CloseConn();
                //return false;
            }
            return false;
        }
    }
}
