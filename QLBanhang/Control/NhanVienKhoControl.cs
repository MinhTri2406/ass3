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
    class NhanVienKhoControl
    {
        /// <summary>
        /// Nhan vien kho control
        /// </summary>
        
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

        /// <summary>
        /// Find nhan vien nhap kho by sdt
        /// </summary>
        /// <param name="sdt"></param>
        /// <returns></returns>
        public DataTable Find_by_Sdt(string sdt)
        {
            return NvModel.Find("select * from tb_NhanVienKho where SDT like '%" + sdt + "%'");
        }

        /// <summary>
        /// Find nhan vien nhap kho by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public DataTable Find_by_Name(string name)
        {
            return NvModel.Find("select * from tb_NhanVienKho where TenNV like N'%" + name + "%'");
        }

        //Update password from user
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
