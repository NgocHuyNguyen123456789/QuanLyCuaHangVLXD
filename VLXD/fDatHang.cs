using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO.Entity;

namespace VLXD
{
    public partial class fDatHang : Form
    {
        public fDatHang()
        {
            InitializeComponent();
        }

        private void fDatHang_Load(object sender, EventArgs e)
        {
            LoadDatHang();
        }
        #region KhachHang
        //KhachHangBUS kh = new KhachHangBUS();

        ////Hiển thị KH
        //private void LoadKHang()
        //{
        //    dgvKH.AutoGenerateColumns = false;
        //    dgvKH.DataSource = kh.LoadKHBUS();
        //}

        //private void dgvKHang_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int row = e.RowIndex;
        //    if (row >= 0)
        //    {
        //        txtMaKHang.Text = dgvKH.Rows[row].Cells[0].Value.ToString();
        //        txtHoKHang.Text = dgvKH.Rows[row].Cells[1].Value.ToString();
        //        txtTenKhachHang.Text = dgvKH.Rows[row].Cells[2].Value.ToString();

        //        if (dgvKH.Rows[row].Cells[3].Value.ToString() == "Nam")
        //        {
        //            rdbNamKHang.Checked = true;
        //        }
        //        else
        //        {
        //            rdbNuKHang.Checked = true;
        //        }

        //        txtDiaChiKHang.Text = dgvKH.Rows[row].Cells[4].Value.ToString();
        //        txtSdtKHang.Text = dgvKH.Rows[row].Cells[5].Value.ToString();
        //    }
        //}

        //private void tabKH_Click(object sender, EventArgs e)
        //{
        //    LoadKHang();
        //    txtMaKHang.Text = "";
        //    txtHoKHang.Text = "";
        //    txtDiaChiKHang.Text = "";
        //    txtSdtKHang.Text = "";
        //    txtTimKHang.Text = "";
        //}

        ////Thêm KH
        //private void AddKHang()
        //{
        //    KhachHang khToAdd = new KhachHang();
        //    khToAdd.HoKH = txtHoKHang.Text;
        //    khToAdd.TenKH = txtTenKHang.Text;
        //    if (rdbNamKHang.Checked == true)
        //    {
        //        khToAdd.GioiTinh = "Nam";
        //    }
        //    else
        //    {
        //        khToAdd.GioiTinh = "Nữ";
        //    }
        //    khToAdd.DiaChi = txtDiaChiKHang.Text;
        //    khToAdd.DienThoai = txtSdtKHang.Text;

        //    KhachHangBUS khBUS = new KhachHangBUS();
        //    khBUS.AddKHBUS(khToAdd);
        //}

        //private void btnThemKHang_Click(object sender, EventArgs e)
        //{
        //    if (txtMaKHang.Text != "" && txtTenKhachHang.Text != "" && txtDiaChiKHang.Text != "" && txtSdtKHang.Text != "")
        //    {
        //        DialogResult result = MessageBox.Show("Thêm một khách hàng mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        //        switch (result)
        //        {
        //            case DialogResult.Cancel:
        //                break;
        //            case DialogResult.OK:
        //                AddKHang();
        //                LoadKHang();
        //                MessageBox.Show("Đã thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Vui lòng nhập Đúng và Đầy Đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        ////Xóa KH
        //private void DeleteKH()
        //{
        //    string id = txtMaKH.Text;
        //    kh.DeleteKHBUS(id);
        //}

        //private void btnXoaKH_Click(object sender, EventArgs e)
        //{
        //    if (txtMaKH.Text != "")
        //    {
        //        DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khách hàng " + txtMaKH.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        //        switch (result)
        //        {
        //            case DialogResult.Cancel:
        //                break;
        //            case DialogResult.OK:
        //                DeleteKH();
        //                LoadKH();
        //                MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Bạn hãy chọn khách hàng muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        ////Sửa KH
        //private void UpdateKH()
        //{
        //    KhachHang khToUpdate = new KhachHang();
        //    khToUpdate.MaKH = int.Parse(txtMaKH.Text);
        //    khToUpdate.TenKH = txtTenKH.Text;
        //    if (rdbNamKH.Checked == true)
        //    {
        //        khToUpdate.GioiTinh = "Nam";
        //    }
        //    else
        //    {
        //        khToUpdate.GioiTinh = "Nữ";
        //    }
        //    khToUpdate.DiaChi = txtDiaChiKH.Text;
        //    khToUpdate.DienThoai = txtSdtKH.Text;

        //    KhachHangBUS khBUS = new KhachHangBUS();
        //    khBUS.UpdateKHBUS(khToUpdate);
        //}

        //private void btnSuaKH_Click(object sender, EventArgs e)
        //{
        //    if (txtMaKH.Text != "")
        //    {
        //        DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa khách hàng. " + txtMaKH.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        //        switch (result)
        //        {
        //            case DialogResult.Cancel:
        //                break;
        //            case DialogResult.OK:
        //                UpdateKH();
        //                LoadKH();
        //                MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Bạn hãy chọn khách hàng muốn sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        ////Tìm KH
        //private void txtTimKH_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        btnTimKH_Click(sender, e);
        //    }
        //}

        //private void txtTimKH_Click(object sender, EventArgs e)
        //{
        //    txtTimKH.Text = "";
        //    txtTimKH.ForeColor = Color.Black;
        //}

        //private void SearchKH()
        //{
        //    if (rdbTimMaKH.Checked == true)
        //    {
        //        int key = int.Parse(txtTimKH.Text);
        //        dgvKH.DataSource = kh.SearchMaKHBUS(key);
        //    }
        //    else
        //    {
        //        string key = txtTimKH.Text;
        //        dgvKH.DataSource = kh.SearchTenKHBUS(key);
        //    }
        //}

        //private void btnTimKH_Click(object sender, EventArgs e)
        //{
        //    if (txtTimKH.Text != "" && txtTimKH.Text != "Nhập từ khóa............")
        //    {
        //        SearchKH();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Hãy nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        #endregion
        
        #region Đặt hàng

        NhanVienBUS nvBUS = new NhanVienBUS();
        KhachHangBUS khBUS = new KhachHangBUS();
        SanPhamBUS spBUS = new SanPhamBUS();
        HoaDon hd = new HoaDon();
        ChiTietHD cthd = new ChiTietHD();


        private void LoadDatHang()
        {
            dgvSPham.AutoGenerateColumns = false;
            dgvSPham.DataSource = spBUS.LoadSPBUS();

            //dgvHD.AutoGenerateColumns = false;
            //dgvHD.DataSource = hd.LoadHDBUS();

            cbMaKHang.DataSource = khBUS.LoadKHBUS();
            cbMaKHang.DisplayMember = "MaKH";

            cbMaNVien.DataSource = nvBUS.LoadNVBUS();
            cbMaNVien.DisplayMember = "MaNV";

            cbMaSPham.DataSource = spBUS.LoadSPBUS();
            cbMaSPham.DisplayMember = "MaSP";
        }

        private void cbMaKHang_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                KhachHang k = cb.SelectedValue as KhachHang;
                txtTenKHang.Text = k.TenKH.ToString();
            }
        }

        private void cbMaNVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                NhanVien v = cb.SelectedValue as NhanVien;
                txtTenNVien.Text = v.TenNV.ToString();
            }
        }

        private void cbMaSPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedValue != null)
            {
                SanPham s = cb.SelectedValue as SanPham;
                txtTenSPham.Text = s.TenSP.ToString();
            }
        }

        #endregion
    }
}
