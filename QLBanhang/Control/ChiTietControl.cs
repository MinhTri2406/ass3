using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QLBanhang.Object;
using QLBanhang.Model;  

namespace QLBanhang.Control
{
    class ChiTietControl
    {
        ChiTietMod CT_mod = new ChiTietMod();
        public DataTable GetData(string Ma)
        {
            return CT_mod.GetData(Ma);
        }
        public bool AddData(DataTable DT)
        {
            return CT_mod.AddData(DT);
        }
        public bool DelData(string MaHD)
        {
            return CT_mod.DelData(MaHD);
        }
    }
}
