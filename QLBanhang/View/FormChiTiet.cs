using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanhang.View;
namespace QLBanhang.View
{
    public partial class FormChiTiet : Form
    {
        string MaDonHang;

        public string MaDonhang
        {
            get { return MaDonHang; }
            set { MaDonHang = value; }
        }
        public FormChiTiet()
        {
            InitializeComponent();
        }
        
        private void FormChiTiet_Load(object sender, EventArgs e)
        {
            txtMaDonHang.Text = MaDonHang;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToString("dd-MM-20yy hh:mm:ss tt");
        }

        private void lbGio_Click(object sender, EventArgs e)
        {
            lbDate.Text = DateTime.Now.ToString("dd-MM-20yy hh:mm:ss tt");
        }

        private void FormChiTiet_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else e.Cancel = false;
        }

        private void txtMaDonHang_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
