using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanhang.View
{
    public partial class FormFind : Form
    {

        FormKhachHang fmKH = new FormKhachHang();
        public FormFind()
        {
            InitializeComponent();
        }

        private void FormFind_Load(object sender, EventArgs e)
        {
            cbTuychontimkiem.Text = "Số điện thoại";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbTuychontimkiem.Text == "Số điện thoại")
            {
                fmKH.TuychonTimkiem = cbTuychontimkiem.Text.Trim();
                this.Hide();
            }
            else if (cbTuychontimkiem.Text == "Tên")
            {
                fmKH.TuychonTimkiem = cbTuychontimkiem.Text.Trim();
                this.Hide();
            }
            
        }
    }
}
