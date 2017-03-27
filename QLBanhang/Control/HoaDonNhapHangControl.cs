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
    class HoaDonNhapHangControl
    {
        HoadonNhapHangMod HD_Mod = new HoadonNhapHangMod();
        public DataTable GetData()
        {
            return HD_Mod.GetData();
        }
        public bool AddData(HoaDonNhapHangObj HD_Obj)
        {
            return HD_Mod.AddData(HD_Obj);
        }
        public DataTable Find(string sqlcmd)
        {
            return HD_Mod.Find(sqlcmd);
        }
        public DataTable Find_by_SDT_KH(string Sdt)
        {
            return HD_Mod.Find("select TenNGH from tb_NguoiGiaoHang where SDT like '%" + Sdt + "%' ");
        }
        public bool DelData(string MaHD)
        {
            return HD_Mod.DelData(MaHD);
        }
    }
}
