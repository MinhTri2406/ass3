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
using QLBanhang.Model;
using QLBanhang.Object;

using QLBanhang.View;
namespace QLBanhang.View
{
    public partial class FormKhachHang : Form
    {
        KhachHangControl KH_Control = new KhachHangControl();
        int iflag;
        int find, findsdt, findten;
        string TuyChonTimKiem;

        public string TuychonTimkiem
        {
            get { return TuyChonTimKiem; }
            set { TuyChonTimKiem = value; }
        }
        Random ran = new Random();
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            find = findsdt = findten = 0;
            dtgvDanhsachKH.Enabled = true;
            DataTable DTb = new System.Data.DataTable();
            DTb = KH_Control.GetData();
            dtgvDanhsachKH.DataSource = DTb;
            bingding();
            Disp_Enable(false); MNSTimkiem.Enabled = true; lbLoiNhac.Visible = btnFind.Visible = false;
            if (txtId.Text == null)
            {
                btnSua.Enabled = false;
                btnSuaDiem.Enabled = false;
            }
            else {
                btnSua.Enabled = true;
                btnSuaDiem.Enabled = true;
            }
        }
        private void bingding()//Mapping the table in Datagridview khách hàng
        {
            txtId.DataBindings.Clear();
            txtId.DataBindings.Add("Text", dtgvDanhsachKH.DataSource, "MaKH");

            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", dtgvDanhsachKH.DataSource, "TenKH");

            cbGioitinh.DataBindings.Clear();
            cbGioitinh.DataBindings.Add("Text", dtgvDanhsachKH.DataSource, "GioiTinh");

            dtNgaysinh.DataBindings.Clear();
            dtNgaysinh.DataBindings.Add("Text", dtgvDanhsachKH.DataSource, "NamSinh");

            txtSdt.DataBindings.Clear();
            txtSdt.DataBindings.Add("Text", dtgvDanhsachKH.DataSource, "SDT");

            txtDiachi.DataBindings.Clear();
            txtDiachi.DataBindings.Add("Text", dtgvDanhsachKH.DataSource, "DiaChi");

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dtgvDanhsachKH.DataSource, "Email");

            txtDiem.DataBindings.Clear();
            txtDiem.DataBindings.Add("Text", dtgvDanhsachKH.DataSource, "Diem");

            dtNgaythemvao.DataBindings.Clear();
            dtNgaythemvao.DataBindings.Add("Text", dtgvDanhsachKH.DataSource, "NgayThemVao");
        }
        private void Disp_Enable(bool B) //Enable/Disable các textbox & button khi hiển thị trên form
        {
            txtTen.Enabled = dtNgaysinh.Enabled = txtDiachi.Enabled = txtSdt.Enabled = txtEmail.Enabled = txtDiem.Enabled = B;
            cbGioitinh.Enabled = B;
            if (find == 1)
            {
                MNSThem.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnSuaDiem.Enabled = btnHuy.Enabled = B;
                MNSLuu.Enabled = MNSPrint.Enabled = B;
                btnHuy.Enabled = lbLoiNhac.Visible = btnFind.Visible = !B;
            }
            else
            {
                MNSThem.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnSuaDiem.Enabled = MNSPrint.Enabled = !B;
                MNSLuu.Enabled = btnLuu.Enabled = btnHuy.Enabled =  B;
            }
        }
        private void CleanData_Display()
        {
            txtId.Text = txtTen.Text = txtDiachi.Text = txtSdt.Text = txtEmail.Text = "";
            txtDiem.Text = "0";

            //cbGioitinh.Items.Clear();
            //cbGioitinh.Items.Add("Nam");
            //cbGioitinh.Items.Add("Nữ");
            cbGioitinh.SelectedItem = 0;

            dtNgaysinh.Value = DateTime.Now.Date;
            dtNgaythemvao.Value = DateTime.Now.Date;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            iflag = 0;
            Disp_Enable(true);
            MNSTimkiem.Enabled = false;
            txtDiem.Enabled = false;
            CleanData_Display();
            int ID = ran.Next(1000000, 9999999);
            txtId.Text = "KH99" + ID.ToString();
            dtgvDanhsachKH.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            iflag = 1;
            if (find == 1) find = 0; 
            Disp_Enable(true);
            lbLoiNhac.Visible = btnFind.Visible = false;
            //CleanData_Display();
            cbGioitinh.Items.Clear();
            cbGioitinh.Items.Add("Nam");
            cbGioitinh.Items.Add("Nữ");
            cbGioitinh.SelectedItem = 0;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult DialogR = MessageBox.Show("Bạn có thực sự muốn xóa khách hàng này?", "Xóa???", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogR == DialogResult.Yes)
            {
                if (KH_Control.DelData(txtId.Text.Trim()))
                {
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else { MessageBox.Show("Xóa không thành công! Vui lòng kiểm tra và thử lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            FormKhachHang_Load(sender, e);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            KhachHangObj KH_Obj = new KhachHangObj();
            KH_Obj.MaKhachHang = txtId.Text.Trim();
            if (cbGioitinh.SelectedIndex == 0)
            {
                KH_Obj.GioiTinh = "Nam";
            }
            else { KH_Obj.GioiTinh = "Nữ"; }
            KH_Obj.TenKhachHang = txtTen.Text.Trim();
            KH_Obj.NamSinh = dtNgaysinh.Text;
            KH_Obj.SoDienThoai = txtSdt.Text.Trim();
            KH_Obj.DiachiKH = txtDiachi.Text.Trim();
            KH_Obj.DiaChiEmail = txtEmail.Text.Trim();
            KH_Obj.DiemTichLuy = int.Parse(txtDiem.Text.Trim());
            KH_Obj.Ngay_them_vao = dtNgaythemvao.Text;
            KH_Obj.MaKhachHang = txtId.Text.Trim();
            if (KH_Obj.TenKhachHang == "" || KH_Obj.SoDienThoai == "")
            {
                MessageBox.Show("Thiếu thông tin cơ bản! Vui lòng kiểm tra và nhập lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //_____Thêm mới_____
            else
            {
                if (iflag == 0)
                {
                    //int ID = ran.Next(1000000, 9999999);
                    //KH_Obj.MaKhachHang = ID.ToString();
                    if (KH_Control.AddData(KH_Obj))
                    {
                        MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormKhachHang_Load(sender, e);
                    }
                    else { MessageBox.Show("Thêm khách hàng mới không thành công! Vui lòng kiểm tra và thử lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }

            //_____Sửa thông tin_____
                else if (iflag == 1)
                {
                    if (KH_Control.UpdateData(KH_Obj))
                    {
                        MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormKhachHang_Load(sender, e);
                    }
                    else { MessageBox.Show("Sửa thông tin khách hàng không thành công! Vui lòng kiểm tra và thử lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {
                    
                    KH_Obj.MaKhachHang = txtId.Text.Trim();
                    
                    if (KH_Control.UpDiemMuaHang(KH_Obj))
                    {
                        MessageBox.Show("Đã sửa điểm tích lũy! Vui lòng kiểm tra lại.", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormKhachHang_Load(sender, e);
                    }
                    else { MessageBox.Show("Sửa điểm tích của khách hàng không thành công! Vui lòng kiểm tra và thử lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                    
                }
              
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult DR = MessageBox.Show("Bạn có thực sự muốn thoát cửa sổ hiện hành?", "Thoát???", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else return;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult DiaRe = MessageBox.Show("Bạn chắc chắn muốn hủy?", "Hủy???", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DiaRe == DialogResult.Yes)
                FormKhachHang_Load(sender, e);
            else
                return;
        }

        

        private void btnSuaDiem_Click(object sender, EventArgs e)
        {
            iflag = 2;
            txtDiem.Enabled = true;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }
       
        private void txtSdt_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtDiem_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtSdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnn_Click(object sender, EventArgs e)
        {
            FormNhanVien frmNV = new FormNhanVien();
            frmNV.ShowDialog();
            FormKhachHang_Load(sender, e);
            //this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbGio.Text = DateTime.Now.ToString("dd-MM-20yy hh:mm:ss tt");
        }


        /*private void MNSLuu_Click(object sender, EventArgs e)
        {
            KhachHangObj KH_Obj = new KhachHangObj();
            KH_Obj.MaKhachHang = txtId.Text.Trim();
            if (cbGioitinh.SelectedIndex == 0)
            {
                KH_Obj.GioiTinh = "Nam";
            }
            else { KH_Obj.GioiTinh = "Nữ"; }
            KH_Obj.TenKhachHang = txtTen.Text.Trim();
            KH_Obj.NamSinh = dtNgaysinh.Text;
            KH_Obj.SoDienThoai = txtSdt.Text.Trim();
            KH_Obj.DiachiKH = txtDiachi.Text.Trim();
            KH_Obj.DiaChiEmail = txtEmail.Text.Trim();
            KH_Obj.DiemTichLuy = int.Parse(txtDiem.Text.Trim());
            KH_Obj.Ngay_them_vao = dtNgaythemvao.Text;
            KH_Obj.MaKhachHang = txtId.Text.Trim();
            if (KH_Obj.TenKhachHang == "" || KH_Obj.SoDienThoai == "")
            {
                MessageBox.Show("Thiếu thông tin cơ bản! Vui lòng kiểm tra và nhập lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //_____Thêm mới_____
            else
            {
                if (iflag == 0)
                {
                    //int ID = ran.Next(1000000, 9999999);
                    //KH_Obj.MaKhachHang = ID.ToString();
                    if (KH_Control.AddData(KH_Obj))
                    {
                        MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else { MessageBox.Show("Thêm khách hàng mới không thành công! Vui lòng kiểm tra và thử lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }

            //_____Sửa thông tin_____
                else if (iflag == 1)
                {
                    if (KH_Control.UpdateData(KH_Obj))
                    {
                        MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else { MessageBox.Show("Sửa thông tin khách hàng không thành công! Vui lòng kiểm tra và thử lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {

                    KH_Obj.MaKhachHang = txtId.Text.Trim();

                    if (KH_Control.UpDiemMuaHang(KH_Obj))
                    {
                        MessageBox.Show("Đã sửa điểm tích lũy! Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else { MessageBox.Show("Sửa điểm tích của khách hàng không thành công! Vui lòng kiểm tra và thử lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }
                FormKhachHang_Load(sender, e);
            }
            
        }*/


        private void FormKhachHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Thông báo!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else e.Cancel = false;
        }

        private void MNSThem_Click_1(object sender, EventArgs e)
        {
            iflag = find = 0;
            Disp_Enable(true);
            MNSTimkiem.Enabled = false;
            txtDiem.Enabled = false;
            CleanData_Display();
            int ID = ran.Next(1000000, 9999999);
            txtId.Text = "KH99" + ID.ToString();
            dtgvDanhsachKH.Enabled = false;
        }

        private void MNSLuu_Click_1(object sender, EventArgs e)
        {
            KhachHangObj KH_Obj = new KhachHangObj();
            KH_Obj.MaKhachHang = txtId.Text.Trim();
            if (cbGioitinh.SelectedIndex == 0)
            {
                KH_Obj.GioiTinh = "Nam";
            }
            else { KH_Obj.GioiTinh = "Nữ"; }
            KH_Obj.TenKhachHang = txtTen.Text.Trim();
            KH_Obj.NamSinh = dtNgaysinh.Text;
            KH_Obj.SoDienThoai = txtSdt.Text.Trim();
            KH_Obj.DiachiKH = txtDiachi.Text.Trim();
            KH_Obj.DiaChiEmail = txtEmail.Text.Trim();
            KH_Obj.DiemTichLuy = int.Parse(txtDiem.Text.Trim());
            KH_Obj.Ngay_them_vao = dtNgaythemvao.Text;
            KH_Obj.MaKhachHang = txtId.Text.Trim();
            if (KH_Obj.TenKhachHang == "" || KH_Obj.SoDienThoai == "")
            {
                MessageBox.Show("Thiếu thông tin cơ bản! Vui lòng kiểm tra và nhập lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //_____Thêm mới_____
            else
            {
                if (iflag == 0)
                {
                    //int ID = ran.Next(1000000, 9999999);
                    //KH_Obj.MaKhachHang = ID.ToString();
                    if (KH_Control.AddData(KH_Obj))
                    {
                        MessageBox.Show("Thêm khách hàng mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormKhachHang_Load(sender, e);
                    }
                    else { MessageBox.Show("Thêm khách hàng mới không thành công! Vui lòng kiểm tra và thử lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }

            //_____Sửa thông tin_____
                else if (iflag == 1)
                {
                    if (KH_Control.UpdateData(KH_Obj))
                    {
                        MessageBox.Show("Sửa thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormKhachHang_Load(sender, e);
                    }
                    else { MessageBox.Show("Sửa thông tin khách hàng không thành công! Vui lòng kiểm tra và thử lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
                else
                {

                    KH_Obj.MaKhachHang = txtId.Text.Trim();

                    if (KH_Control.UpDiemMuaHang(KH_Obj))
                    {
                        MessageBox.Show("Đã sửa điểm tích lũy! Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormKhachHang_Load(sender, e);
                    }
                    else { MessageBox.Show("Sửa điểm tích của khách hàng không thành công! Vui lòng kiểm tra và thử lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }

                }
                
            }
            
        }

        private void MNSThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Thông báo!", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                Application.ExitThread();
            }
        }

        private void MNSTimSDT_Click(object sender, EventArgs e)
        {
            lbLoiNhac.Text = "";
            find = findsdt = 1;
            findten = 0;
            Disp_Enable(false);
            txtSdt.Enabled = true;
            lbLoiNhac.Text = "Nhập số điện thoại khách hàng cần tìm vào ô 'Số điện thoại'!";
        }
        private void MNSTimTen_Click_1(object sender, EventArgs e)
        {
            lbLoiNhac.Text = "";
            find = findten = 1;
            findsdt = 0;
            Disp_Enable(false);
            txtTen.Enabled = true;
            lbLoiNhac.Text = "Nhập tên khách hàng cần tìm vào ô 'Tên khách hàng'!";
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            //Tìm theo số điện thoại
            if (findsdt == 1)
            {
                DT = KH_Control.Find_by_Sdt(txtSdt.Text.Trim());
                if (DT.Rows.Count <= 0)
                {
                    MessageBox.Show("Không tìm thấy số điện thoại cần tìm! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtSdt.Text == "") { MessageBox.Show("Không tìm thấy số điện thoại cần tìm! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }  
                else
                {
                    btnSua.Enabled = btnSuaDiem.Enabled = true;
                    dtgvDanhsachKH.DataSource = DT;
                    bingding();
                }
            }
            else if(findten == 1){
                 DT = KH_Control.Find_by_Name(txtTen.Text.Trim());
                if (DT.Rows.Count <= 0)
                {
                    MessageBox.Show("Không tìm thấy tên khách hàng bạn cần tìm! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtTen.Text == "") { MessageBox.Show("Không tìm thấy tên khách hàng bạn cần tìm! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }  
                else
                {
                    btnSua.Enabled = btnSuaDiem.Enabled = true;
                    dtgvDanhsachKH.DataSource = DT;
                    bingding();
                }
            }
        }

        private void MNSTimId_Click(object sender, EventArgs e)
        {

        }

      

        
    }
}
