using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanhang.Control;

namespace QLBanhang.View
{
    public partial class FormTimKiem : Form
    {
        /// <summary>
        /// Tìm kiếm thông tin theo số điện thoại hoặc theo tên
        /// </summary>
        int QuyenTruyCap;
        /* ------------   QuyenTruyCap = 0 Nếu người dùng là nhân viên
        // ------------   QuyenTruyCap = 1 Nếu người dùng là quản lí
         */
        public FormTimKiem()
        {
            InitializeComponent();
        }
        object[] parameter;
        FormTimKiem(object[] _parameter = null)
        {
            this.parameter = _parameter;
        }
      //  FormTimKiem fmF = new FormTimKiem(FormKhachHang.ActiveForm);
        KhachHangControl KH_ctrl = new KhachHangControl();
        //FormHoaDon fmHD = new FormHoaDon();
        HoaDonControl HD_Ctrl = new HoaDonControl();
        private void FormTimKiem_Load(object sender, EventArgs e)
        {
            cbTimKiem.Text = "Số điện thoại";
           // DataTable DT = new System.Data.DataTable();
            
        }
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            
            QuyenTruyCap = 0;
            if (txtKeyTimKiem.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập từ khóa cần tìm kiếm! Vui lòng nhập lại!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (QuyenTruyCap == 0 && cbTimKiem.Text == "Số điện thoại")
            {
                dtgvDSTimKiem.DataSource = HD_Ctrl.Find("select * from tb_KhachHang where SDT like '%" + txtKeyTimKiem.Text.Trim() + "%'");
                Bingding();
            }
            else if (QuyenTruyCap == 1 && cbTimKiem.Text == "Số điện thoại")
            {
                dtgvDSTimKiem.DataSource = HD_Ctrl.Find("select * from tb_KhachHang where SDT like '%" + txtKeyTimKiem.Text.Trim() + "%'");
                Bingding();
            }
            else if (QuyenTruyCap == 0 && cbTimKiem.Text == "Tên")
            {
                dtgvDSTimKiem.DataSource = HD_Ctrl.Find("select * from tb_KhachHang where TenKH like '%" + txtKeyTimKiem.Text.Trim() + "%'");
                Bingding();
            }
            if (txtTen.Text != "")
            {
                btnXong.Enabled = true;
               
            }
            txtKeyTimKiem.Text = "";
        }
        private void Bingding()
        {
            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", dtgvDSTimKiem.DataSource, "TenKH");
            txtSdt.DataBindings.Clear();
            txtSdt.DataBindings.Add("Text", dtgvDSTimKiem.DataSource, "SDT");
        }

        private void FormTimKiem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chức năng tìm kiếm?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else e.Cancel = false;
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            //fmHD.ShowDialog();
            ////fmHD.TenKH_after_find;
            //Application.ExitThread();
        }
    }
}
