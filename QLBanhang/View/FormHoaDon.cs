using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanhang.Object;
using QLBanhang.Control;
using QLBanhang.Model;
using System.Data;

namespace QLBanhang.View
{
    public partial class FormHoaDon : Form
    {
        bool ChucNangTimKiem;
        int iflag;
        /// <summary>
        /// Nhân viên hiện đang đăng nhập
        /// </summary>
        string MaNV, TenNV, SdtNV;
        FormHoaDon(string maNV, string tenNV, string sdtNV)
        {
            this.MaNV = maNV;
            this.TenNV = tenNV;
            this.SdtNV = sdtNV;
        }
        //public string TenKH_after_find
        //{
        //    get { return TenKH_after_Find; }
        //    set { TenKH_after_Find = value; }
        //}

        //public string SDTKH_after_find
        //{
        //    get { return SDTKH_after_Find; }
        //    set { SDTKH_after_Find = value; }
        //}
        public FormHoaDon()
        {
            InitializeComponent();
        }
        HoaDonNhapHangControl HD_Ctrl = new HoaDonNhapHangControl();
        ChiTietControl CT_Ctrl = new ChiTietControl();
        FormChiTiet FmChiTiet = new FormChiTiet();
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            ChucNangTimKiem = false;
            cbTimKiem.Enabled = btnTimKiemKH.Enabled = false;
            Display_Enable(false);
            if (txtMaDonHang.Text != null)
            {
                btnPrint.Enabled = true;
                btnSuaNgay.Enabled = true;
                btnChiTiet.Enabled = true;
                btnSuaHD.Enabled = true;
            }
            else
            {
                btnPrint.Enabled = false;
                btnSuaNgay.Enabled = false;
                btnChiTiet.Enabled = false;
                btnSuaHD.Enabled = false;
            }
            cbTimKiem.Text = "Số điện thoại";
            DataTable DT = new System.Data.DataTable();
            DT = HD_Ctrl.GetData();
            dtgvDSHoaDon.DataSource = DT;
            //FmChiTiet.MaDonhang = txtMaDonHang.Text.Trim();
            Bingding();
        }
        private void Display_Enable(bool B)
        {
            txtMaDonHang.Enabled = cmbNguoiGiaoHang.Enabled = txtMaNguoiLap.Enabled = txtSdtNguoiLap.Enabled = txtSdtNguoiGiaoHang.Enabled = B;
            btnThem.Enabled = btnSuaHD.Enabled = btnXoa.Enabled = btnChiTiet.Enabled = !B; btnLuu.Enabled = btnHuy.Enabled = B;
            //if (txtMaHoaDon.Text != "")
            //{
            //    btnPrint.Enabled = !B;
            //    btnSuaNgay.Enabled = !B;
            //}
            //else
            //{
            //    btnPrint.Enabled = B;
            //    btnSuaNgay.Enabled = B;
            //}
        }

        private void Bingding()
        {
            txtMaDonHang.DataBindings.Clear();
            txtMaDonHang.DataBindings.Add("Text", dtgvDSHoaDon.DataSource, "MaHD");
            dtNgayLap.DataBindings.Clear();
            dtNgayLap.DataBindings.Add("Text", dtgvDSHoaDon.DataSource, "NgayLap");
            //txtMaNguoiLap.DataBindings.Clear();
            //txtMaNguoiLap.DataBindings.Add("Text", dtgvDSHoaDon.DataSource, "MaNguoiLap");
            txtTenNguoiLap.DataBindings.Clear();
            txtTenNguoiLap.DataBindings.Add("Text", dtgvDSHoaDon.DataSource, "TenNV");
           
            txtSdtNguoiLap.DataBindings.Clear();
            txtSdtNguoiLap.DataBindings.Add("Text", dtgvDSHoaDon.DataSource, "SDTNhanVien");

            cmbNguoiGiaoHang.DataBindings.Clear();
            cmbNguoiGiaoHang.DataBindings.Add("Text", dtgvDSHoaDon.DataSource, "TenNguoiGiaoHang");

            txtSdtNguoiGiaoHang.DataBindings.Clear();
            txtSdtNguoiGiaoHang.DataBindings.Add("Text", dtgvDSHoaDon.DataSource, "SDTNguoiGiaoHang");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbGio.Text = DateTime.Now.ToString("dd-MM-20yy hh:mm:ss tt");
        }

        private void btnChiTiet_Click(object sender, EventArgs e)
        {
            //FormChiTiet FmChiTiet = new FormChiTiet(txtMaDonHang.Text.Trim());
            FmChiTiet.MaDonhang = txtMaDonHang.Text.Trim();
           
            FmChiTiet.ShowDialog();
            
        }
        private void CleanData_Display()
        {
            txtMaDonHang.Text  = txtSdtNguoiGiaoHang.Text = "";
            //txtMaNguoiLap.Text = txtSdtNguoiLap.Text = txtTenNguoiLap.Text = "";
            dtNgayLap.Text = DateTime.Now.Date.ToShortDateString();
            Load_CMBKhachHang();
        }
        //**********************************//
        //*********Them hoa don moi
        private void Load_CMBKhachHang()
        {
            KhachHangControl NGHCtrl = new KhachHangControl();
            cmbNguoiGiaoHang.DataSource = NGHCtrl.GetData();
            cmbNguoiGiaoHang.DisplayMember = "TenNGH";
            cmbNguoiGiaoHang.ValueMember = "MaNGH";
            cmbNguoiGiaoHang.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            Display_Enable(true);
            txtMaNguoiLap.Enabled = txtTenNguoiLap.Enabled = txtSdtNguoiLap.Enabled = false;
            CleanData_Display();
            btnPrint.Enabled = false;
            btnSuaNgay.Enabled = false;
            btnTimKiemKH.Enabled = cbTimKiem.Enabled = true;
            cmbNguoiGiaoHang.Enabled = txtSdtNguoiGiaoHang.Enabled = false;
            ChucNangTimKiem = true;
        }

        private void cmbKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Thông báo!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            //{
            //    Application.ExitThread();
            //}
            this.Close();
            
        }

        private void FormHoaDon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else e.Cancel = false;
        }


        /*..........................................
         * * * *Bingding Tìm kiếm khách hàng * * * *
         ..........................................*/ 
        private void Bingding1()
        {
            cmbNguoiGiaoHang.DataBindings.Clear();
            cmbNguoiGiaoHang.DataBindings.Add("Text", dtgvDSHoaDon.DataSource, "TenNGH");
            txtSdtNguoiGiaoHang.DataBindings.Clear();
            txtSdtNguoiGiaoHang.DataBindings.Add("Text", dtgvDSHoaDon.DataSource, "SDT");
        }
        private void btnTimKiemKH_Click(object sender, EventArgs e)
        {
            //FormTimKiem fmTimKiem = new FormTimKiem();
            //fmTimKiem.ShowDialog();
            //txtSdtNguoiLap.Text = this.TenKH_after_Find;
            //cmbKhachHang.Text = this.TenKH_after_Find;
            if (txtSdtNguoiGiaoHang.Text == "" && cmbNguoiGiaoHang.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập từ khóa cần tìm kiếm! Vui lòng nhập lại!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (cbTimKiem.Text == "Số điện thoại")
            {
                dtgvDSHoaDon.DataSource = HD_Ctrl.Find("select * from tb_NguoiGiaoHang where SDT like '%" + txtSdtNguoiGiaoHang.Text.Trim() + "%'");
                Bingding1();
            }
            else if (/*QuyenTruyCap == 0 &&*/ cbTimKiem.Text == "Tên khách hàng")
            {
                dtgvDSHoaDon.DataSource = HD_Ctrl.Find("select * from tb_NguoiGiaoHang where TenNGH like N'%" + cmbNguoiGiaoHang.Text.Trim() + "%'");
                Bingding1();
            }
            
        }

        private void cbTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTimKiem.Text == "Số điện thoại" && ChucNangTimKiem == true)
            {
                txtSdtNguoiGiaoHang.Enabled = true;
                cmbNguoiGiaoHang.Enabled = false;
            }
            else if (cbTimKiem.Text == "Tên người giao hàng" && ChucNangTimKiem == true)
            {
                txtSdtNguoiGiaoHang.Enabled = false;
                cmbNguoiGiaoHang.Enabled = true;
            }
        }

        private void MenuChucnangkhac_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void cmbKhachHang_TextChanged(object sender, EventArgs e)
        {

        }
        //private void txtMaHoaDon_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt = CT_Ctrl.GetData(txtMaHoaDon.Text.Trim());
        //        dtgvDSHoaDon.DataSource = dt;
        //    }
        //    catch
        //    {
        //        dtgvDSHoaDon.DataSource = null;
        //    }
        //}
    }
}
