﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLBanhang.Object;

namespace QLBanhang.Model
{
    class HoadonNhapHangMod
    {
        ConnectToSQL sqlcon = new ConnectToSQL();
        SqlCommand sqlcmd = new SqlCommand();
       
        public DataTable GetData()
        {
            DataTable DT = new DataTable();
            sqlcmd.CommandText = @"select hd.MaHD, hd.NgayLap, nv.TenNV, nv.SDT SDTNhanVien, ngh.TenNGH TenNguoiGiaoHang, ngh.SDT SDTNguoiGiaoHang, ngh.CongTy  from tb_HoaDonNhap hd, tb_NguoiGiaoHang ngh, tb_NhanVienKho nv where ngh.MaNGH = hd.MaNguoiGiaoHang and nv.MaNV = hd.MaNguoiLap";
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = sqlcon.Connection;
            try
            {
                sqlcon.OpenConn();
                SqlDataAdapter SDA = new SqlDataAdapter(sqlcmd);
                SDA.Fill(DT);
            }
            catch (Exception ex)
            {
                string mes = ex.Message;
                sqlcmd.Dispose();
                sqlcon.CloseConn();
            }
            return DT;
        }
        public bool AddData(HoaDonNhapHangObj HD_Obj)
        {
            sqlcmd.CommandText = "insert into tb_HoaDon values('" + HD_Obj.MaSoHoadon + "', CONVERT(DATE, '" + HD_Obj.NgayLapHoaDon + "', 103), '" + HD_Obj.MaSoNguoilap + "', '" + HD_Obj.SdtNguoiLap + "', '" + HD_Obj.MaNguoiGiaoHang + "', '" + HD_Obj.SdtNguoiGiaoHang + "')";
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
        public DataTable Find(string Key)
        {
            DataTable DT = new DataTable();
            sqlcmd.CommandText = Key;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = sqlcon.Connection;
            try
            {
                sqlcon.OpenConn();
                SqlDataAdapter SDA = new SqlDataAdapter(sqlcmd);
                SDA.Fill(DT);
            }
            catch (Exception ex)
            {
                sqlcon.Error = ex.Message;
                sqlcmd.Dispose();
                sqlcon.CloseConn();
            }
            return DT;
        }
        
        public bool DelData(string MaHoaDon)
        {
            sqlcmd.CommandText = "Delete tb_HoaDonNhap Where MaHD = '" + MaHoaDon + "'";
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
    }
}
