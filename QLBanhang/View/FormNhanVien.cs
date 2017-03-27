using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanhang.Object;
using QLBanhang.Control;

namespace QLBanhang.View
{
    public partial class FormNhanVien : Form
    {
        NhanVienKhoControl NvCtrl = new NhanVienKhoControl();
        int TempID;
        Random ran = new Random();
        int iflag = 0, find, findsdt, findten, findId;
        public FormNhanVien()
        {
            InitializeComponent();
        }

        

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void bingding() //Mapping các thành phần của data source, hiển thị lên textbox hoặc datagridview
        {
            txtId.DataBindings.Clear();
            txtId.DataBindings.Add("Text", dtgvDanhsachNV.DataSource, "MaNV");

            txtTen.DataBindings.Clear();
            txtTen.DataBindings.Add("Text", dtgvDanhsachNV.DataSource, "TenNV");

            cbGioitinh.DataBindings.Clear();
            cbGioitinh.DataBindings.Add("Text", dtgvDanhsachNV.DataSource, "GioiTinh");

            dtNgaysinh.DataBindings.Clear();
            dtNgaysinh.DataBindings.Add("Text", dtgvDanhsachNV.DataSource, "NamSinh");

            txtDiachi.DataBindings.Clear();
            txtDiachi.DataBindings.Add("Text", dtgvDanhsachNV.DataSource, "DiaChi");

            txtSdt.DataBindings.Clear();
            txtSdt.DataBindings.Add("Text", dtgvDanhsachNV.DataSource, "SDT");

            txtEmail.DataBindings.Clear();
            txtEmail.DataBindings.Add("Text", dtgvDanhsachNV.DataSource, "Email");

            dtDateBegin.DataBindings.Clear();
            dtDateBegin.DataBindings.Add("Text", dtgvDanhsachNV.DataSource, "NgayVaoLamViec");

        }
        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            find = findsdt = findten = findId = 0;
            dtgvDanhsachNV.Enabled = true;
            DataTable DtDanhSach = new System.Data.DataTable();
            DtDanhSach = NvCtrl.GetData();
            dtgvDanhsachNV.DataSource = DtDanhSach;
            bingding();
            Disp_Enable(false);
            lbLoiNhac.Visible = btnFind.Visible = false;
        }


        private void Disp_Enable(bool B)//Method to display buttons and textbox: Them, Sua, Xoa, Luu, Huy, Ten,... 
        {
            if (find == 1)
            {
                btnThem.Enabled = MNSThem.Enabled = B;
                btnSua.Enabled = B;
                btnXoa.Enabled = B;
                btnLuu.Enabled = MNSLuu.Enabled = B;
                btnHuy.Enabled = !B;
            }
            else
            {
                btnThem.Enabled = MNSThem.Enabled = !B;
                btnSua.Enabled = !B;
                btnXoa.Enabled = !B;
                btnLuu.Enabled = MNSLuu.Enabled = B;
                btnHuy.Enabled = B;
            }
            
            MNSTim.Enabled = !B;
            txtTen.Enabled = B;
            txtDiachi.Enabled = B;
            txtSdt.Enabled = txtEmail.Enabled = B;
            cbGioitinh.Enabled = B;
            dtDateBegin.Enabled = dtNgaysinh.Enabled = B;
        }
        private void ClearData(){
            txtTen.Text = txtSdt.Text = txtDiachi.Text = txtEmail.Text = "";
            dtNgaysinh.Value = DateTime.Now.Date;
            dtDateBegin.Value = DateTime.Now.Date;
            //clear Gioi tinh:
            //cbGioitinh.Items.Clear();
            //cbGioitinh.Items.Add("Nam");
            //cbGioitinh.Items.Add("Nữ");
            cbGioitinh.SelectedItem = 0;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            iflag = 0;
            ClearData();
            Disp_Enable(true);
            dtDateBegin.Enabled = false;
            int ID = ran.Next(1000000, 9999999);
            txtId.Text = "NVK" + ID.ToString();
            dtgvDanhsachNV.Enabled = false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            iflag = 1;
            if (find == 1) find = 0;
            Disp_Enable(true);
            lbLoiNhac.Visible = btnFind.Visible = false;
            dtDateBegin.Enabled = true;
            //cbGioitinh.Items.Clear();
            //cbGioitinh.Items.Add("Nam");
            //cbGioitinh.Items.Add("Nữ");
            cbGioitinh.SelectedItem = 0;
        }
        private void button4_Click(object sender, EventArgs e) //Button Xoa
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xóa???", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                
                if (NvCtrl.DelData(txtId.Text.Trim()))
                {
                    MessageBox.Show("Đã xóa thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thực hiện xóa! Vui lòng kiểm tra lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                FormNhanVien_Load(sender, e);//Load lại form
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            NhanvienObj NvObject = new NhanvienObj();
            NvObject.MaNhanVien = txtId.Text.Trim();
            if (cbGioitinh.SelectedIndex == 0) { NvObject.GioiTinh = "Nam"; }
            else { NvObject.GioiTinh = "Nữ"; }
            NvObject.TenNhanVien = txtTen.Text.Trim();
            NvObject.NamSinh = dtNgaysinh.Text.Trim();
            NvObject.DiaChi = txtDiachi.Text.Trim();
            NvObject.SoDienThoai = txtSdt.Text.Trim();
            NvObject.Day_Begin_Working = dtDateBegin.Text.Trim();
            NvObject.MaNhanVien = txtId.Text.Trim();
            NvObject.Email = txtEmail.Text.Trim();
            //_____Them moi_____
            if (iflag == 0)
            {
                //int ID = ran.Next(10000000, 99999999); //ID = Int32.Parse(txtId.Text);

                //NvObject.MaNhanVien = ID.ToString();
                if (txtTen.Text != "" && txtSdt.Text != "" && txtDiachi.Text != "")
                {
                    if (NvCtrl.AddData(NvObject))
                    {
                        MessageBox.Show("Thêm nhân viên mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormNhanVien_Load(sender, e); //Load lại form
                    }
                    else MessageBox.Show("Thêm nhân viên mới không thành công! Vui lòng kiểm tra lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else { MessageBox.Show("Thêm nhân viên mới không thành công! Vui lòng kiểm tra lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            //_____Sua thong tin_____
            else
            {
                if (txtTen.Text != "" && txtSdt.Text != "" && txtDiachi.Text != "")
                {
                    if (NvCtrl.UpdateData(NvObject))
                    {
                        MessageBox.Show("Sửa thông  tin thành công", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormNhanVien_Load(sender, e); //Load lại form
                    }
                    else MessageBox.Show("Sửa thông  tin không thành công!  Vui lòng kiểm tra lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else { MessageBox.Show("Sửa thông  tin không thành công!  Vui lòng kiểm tra lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
           
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy???", "Hủy???", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MNSThem.Enabled = true;
                btnThem.Enabled = true;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                FormNhanVien_Load(sender, e);
            }
            else return;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có muốn thoát khỏi cửa sổ hiện hành???", "Thoát???", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
            {
                this.Hide();
                //FormKhachHang frmKH = new FormKhachHang();
                //frmKH.Show();
            }
            else return;
        }

        /// <summary>
        /// don't input key a->z into this textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void cbGioitinh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtNgaysinh_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtDiachi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dtgvDanhsachNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtSdt_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MNSThem_Click(object sender, EventArgs e)
        {
            iflag = 0;
            ClearData();
            Disp_Enable(true);
            dtDateBegin.Enabled = false;
            int ID = ran.Next(1000000, 9999999);
            txtId.Text = "NVK" + ID.ToString();
            dtgvDanhsachNV.Enabled = false;
        }

        private void MNSLuu_Click(object sender, EventArgs e)
        {
            NhanvienObj NvObject = new NhanvienObj();
            NvObject.MaNhanVien = txtId.Text.Trim();
            if (cbGioitinh.SelectedIndex == 0) { NvObject.GioiTinh = "Nam"; }
            else { NvObject.GioiTinh = "Nữ"; }
            NvObject.TenNhanVien = txtTen.Text.Trim();
            NvObject.NamSinh = dtNgaysinh.Text.Trim();
            NvObject.DiaChi = txtDiachi.Text.Trim();
            NvObject.SoDienThoai = txtSdt.Text.Trim();
            NvObject.MaNhanVien = txtId.Text.Trim();
            NvObject.Email = txtEmail.Text.Trim();
            //_____Them moi_____
            if (iflag == 0)
            {
                //int ID = ran.Next(10000000, 99999999); //ID = Int32.Parse(txtId.Text);

                //NvObject.MaNhanVien = ID.ToString();
                if (txtTen.Text != "" && txtSdt.Text != "" && txtDiachi.Text != "")
                {
                    if (NvCtrl.AddData(NvObject))
                    {
                        MessageBox.Show("Thêm nhân viên mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormNhanVien_Load(sender, e); //Load lại form
                    }
                    else MessageBox.Show("Thêm nhân viên mới không thành công! Vui lòng kiểm tra lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else { MessageBox.Show("Thêm nhân viên mới không thành công! Vui lòng kiểm tra lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }

            //_____Sua thong tin_____
            else 
            {
                if ( txtTen.Text != "" && txtSdt.Text != "" && txtDiachi.Text != "")
                {
                    if (NvCtrl.UpdateData(NvObject))
                    {
                        MessageBox.Show("Sửa thông  tin thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormNhanVien_Load(sender, e); //Load lại form
                    }
                    else MessageBox.Show("Sửa thông  tin không thành công!  Vui lòng kiểm tra lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else { MessageBox.Show("Sửa thông  tin không thành công!  Vui lòng kiểm tra lại.", "Lỗi!!!", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            //FormNhanVien_Load(sender, e); //Load lại form
        }

        private void MNSThoat_Click(object sender, EventArgs e)
        {
            //DialogResult re = MessageBox.Show("Bạn có muốn thoát khỏi cửa sổ hiện hành???", "Thoát???", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (re == DialogResult.Yes)
            //{

                this.Close();
                //FormKhachHang frmKH = new FormKhachHang();
                //frmKH.Show();
            //}
            //else return;
        }

        private void FormNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Thoát!", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else e.Cancel = false;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lbGio.Text = DateTime.Now.ToString("dd-MM-20yy hh:mm:ss tt");
        }

        //<===========================================>
        //================= Tìm kiếm ==================
        //=============================================
        private void MNSTimsdt_Click(object sender, EventArgs e)
        {
            lbLoiNhac.Text = "";
            find = findsdt = 1;
            findten = findId = 0;
            Disp_Enable(false);
            txtSdt.Enabled = lbLoiNhac.Visible = btnFind.Visible = true;//Showing btn 'Find' at this form
            btnLuu.Enabled = MNSLuu.Enabled = false;
            lbLoiNhac.Text = "Nhập số điện thoại khách hàng cần tìm vào ô 'Số điện thoại'!";
        }
        private void MNSTimten_Click(object sender, EventArgs e)
        {
            lbLoiNhac.Text = "";
            find = findten = 1;
            findsdt = findId = 0;
            Disp_Enable(false);
            txtTen.Enabled = true; lbLoiNhac.Visible = btnFind.Visible = true;
            btnLuu.Enabled = MNSLuu.Enabled = false;
            lbLoiNhac.Text = "Nhập tên khách hàng cần tìm vào ô 'Tên khách hàng'!";
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            //Tìm theo số điện thoại
            if (findsdt == 1)
            {
                DT = NvCtrl.Find_by_Sdt(txtSdt.Text.Trim());
                if (DT.Rows.Count <= 0)
                {
                    MessageBox.Show("Không tìm thấy số điện thoại cần tìm! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtSdt.Text == "") { MessageBox.Show("Không tìm thấy số điện thoại cần tìm! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    dtgvDanhsachNV.DataSource = DT;
                    bingding();
                }
            }
            else if (findten == 1)
            {
                DT = NvCtrl.Find_by_Name(txtTen.Text.Trim());
                if (DT.Rows.Count <= 0)
                {
                    MessageBox.Show("Không tìm thấy tên nhân viên bạn cần tìm! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtTen.Text == "") { MessageBox.Show("Không tìm thấy tên nhân viên bạn cần tìm! Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                else
                {
                    btnSua.Enabled = true;
                    btnXoa.Enabled = true;
                    dtgvDanhsachNV.DataSource = DT;
                    bingding();
                }
            }

            //</==============================================>
        }

        //private void MNSTimId_Click(object sender, EventArgs e)
        //{
        //    find = findId = 1;
        //    findten = findsdt = 0;
        //    Disp_Enable(false);
        //    lbLoiNhac.Visible = btnFind.Visible = true;//Showing btn 'Find' at this form
        //    btnLuu.Enabled = MNSLuu.Enabled = false;
        //    lbLoiNhac.Text = "Nhập số điện thoại khách hàng cần tìm vào ô 'Số điện thoại'!";

        //}
       

    }
}
