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
    class NhanVienControl
    {
        NhanVienMod NvModel = new NhanVienMod();
        public DataTable GetData()
        {
            return NvModel.GetData();
        }
        public bool AddData(NhanvienObj NvObj)
        {
            return NvModel.AddData(NvObj);
        }
        public bool UpdateData(NhanvienObj NvObj)
        {
            return NvModel.UpdateData(NvObj);
        }
        public DataTable Find_by_Sdt(string sdt)
        {
            return NvModel.Find("select * from tb_NhanVien where SDT like '%" + sdt + "%'");
        }
        public DataTable Find_by_Name(string name)
        {
            return NvModel.Find("select * from tb_NhanVien where TenNV like N'%" + name + "%'");
        }
        public bool UpdatePass(NhanvienObj NvObj)
        {
            return NvModel.UpdatePass(NvObj);
        }
        public bool DelData(string MaNhanVien)
        {
            return NvModel.DelData(MaNhanVien);
        }
    }
}
