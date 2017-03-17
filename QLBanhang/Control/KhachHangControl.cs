using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLBanhang.Model;
using QLBanhang.Object;

namespace QLBanhang.Control
{
    class KhachHangControl
    {
        KhacHangMod KH_Model = new KhacHangMod();

        /// <Get Data>
        /// KhachHangControl
        /// </Get Data>
        
        public DataTable GetData()
        {
            return KH_Model.GetData();
        }
        //========== ADD DATA TO DATABASE tb_KhachHang ==========
        public bool AddData(KhachHangObj KH_Obj)
        {
            return KH_Model.AddData(KH_Obj);
        }

        //========== UPDATE DATA ==========
        public bool UpdateData(KhachHangObj KH_Obj)
        {
            return KH_Model.UpdateData(KH_Obj);
        }

        //==========  FIND DATA  ==========
        public DataTable Find_by_Sdt(string sdt)
        {
            return KH_Model.Find("select * from tb_KhachHang where SDT like '%" + sdt + "%'");
        }
        public DataTable Find_by_Name(string name)
        {
            return KH_Model.Find("select * from tb_KhachHang where TenKH like N'%" + name + "%'");
        }

        //========== DELETE DATA ==========
        public bool DelData(string MaKH)
        {
            return KH_Model.DelData(MaKH);
        }

        //========== UPDATE DIEM ==========
        public bool UpDiemMuaHang(KhachHangObj KH_Obj)
        {
            return KH_Model.UpDiemMuaHang(KH_Obj);
        }
        /// <returns></returns>
    }
}
