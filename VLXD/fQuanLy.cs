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
    public partial class fQuanLy : Form
    {
        public fQuanLy()
        {
            InitializeComponent();
        }
        private void fQuanLy_Load(object sender, EventArgs e)
        {
            dgvNV.AutoGenerateColumns = false;
            LoadNV();
            LoadSP();
            LoadKH();
            LoadLoaiSP();
            LoadUser();
        }

        #region NhanVien
        NhanVienBUS nv = new NhanVienBUS();

        private void LoadNV()
        {
            dgvNV.DataSource = nv.LoadNVBUS();
        }

        private void tabNV_Click(object sender, EventArgs e)
        {
            LoadNV();
            txtMaNV.Text = "";
            txtHoNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChiNV.Text = "";
            txtSdtNV.Text = "";
            txtTimNV.Text = "";
            dtpNgaySinhNV.Value = new DateTime(1998, 1, 1);
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaNV.Text = dgvNV.Rows[row].Cells[0].Value.ToString();
                txtHoNV.Text = dgvNV.Rows[row].Cells[1].Value.ToString();
                txtTenNV.Text = dgvNV.Rows[row].Cells[2].Value.ToString();

                if (dgvNV.Rows[row].Cells[3].Value.ToString() == "Nam")
                {
                    rdbNam.Checked = true;
                }
                else
                {
                    rdbNu.Checked = true;
                }

                if (dgvNV.Rows[row].Cells[4].Value != null)
                {
                    dtpNgaySinhNV.Value = DateTime.Parse(dgvNV.Rows[row].Cells[4].Value.ToString());
                }
                else
                {
                    dtpNgaySinhNV.Value = new DateTime(1998, 1, 1);
                }

                txtDiaChiNV.Text = dgvNV.Rows[row].Cells[5].Value.ToString();
                txtSdtNV.Text = dgvNV.Rows[row].Cells[6].Value.ToString();
            }
        }

    //Them Nhan Vien
        private void AddNV()
        {
            NhanVien nvToAdd = new NhanVien();
            nvToAdd.HoNV = txtHoNV.Text;
            nvToAdd.TenNV = txtTenNV.Text;
            if (rdbNam.Checked == true)
            {
                nvToAdd.GioiTinh = "Nam";
            }
            else
            {
                nvToAdd.GioiTinh = "Nữ";
            }
            nvToAdd.NgaySinh = dtpNgaySinhNV.Value;
            nvToAdd.DiaChi = txtDiaChiNV.Text;
            nvToAdd.DienThoai = txtSdtNV.Text;

            NhanVienBUS nvBUS = new NhanVienBUS();
            nvBUS.AddNVBUS(nvToAdd);
        }
        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "" && txtHoNV.Text != "" && txtTenNV.Text != "" && txtDiaChiNV.Text != "" && txtSdtNV.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn muốn thêm một nhân viên mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        AddNV();
                        LoadNV();
                        MessageBox.Show("Đã thêm thành công.", "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Đúng và Đầy Đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    //Xoa Nhan Vien
        private void DeleteNV()
        {
            int id = int.Parse(txtMaNV.Text);
            nv.DeleteNVBUS(id);
        }
        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên " + txtMaNV.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        DeleteNV();
                        LoadNV();
                        MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn nhân viên muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    //Sua Nhan Vien
        private void UpdateNV()
        {
            NhanVien nvToUpdate = new NhanVien();
            nvToUpdate.MaNV = int.Parse(txtMaNV.Text);
            nvToUpdate.HoNV = txtHoNV.Text;
            nvToUpdate.TenNV = txtTenNV.Text;
            if (rdbNam.Checked == true)
            {
                nvToUpdate.GioiTinh = "Nam";
            }
            else
            {
                nvToUpdate.GioiTinh = "Nữ";
            }
            nvToUpdate.NgaySinh = dtpNgaySinhNV.Value;
            nvToUpdate.DiaChi = txtDiaChiNV.Text;
            nvToUpdate.DienThoai = txtSdtNV.Text;

            NhanVienBUS nvBUS = new NhanVienBUS();
            nvBUS.UpdateNVBUS(nvToUpdate);
        }
        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa nhân viên " + txtMaNV.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        UpdateNV();
                        LoadNV();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn nhân viên muốn sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    //Tim Nhan Vien
        private void txtTimNV_Click(object sender, EventArgs e)
        {
            txtTimNV.Text = "";
            txtTimNV.ForeColor = Color.Black;
        }

        private void txtTimNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimNV_Click(sender, e);
            }
        }

        private void SearchNV()
        {
            
            if (rdbTimMaNV.Checked == true)
            {
                int maNV = int.Parse(txtTimNV.Text);
                dgvNV.DataSource = nv.SearchMaNVBUS(maNV);
            }
            else
            {
                string tenNV = txtTimNV.Text;
                dgvNV.DataSource = nv.SearchTenNVBUS(tenNV);
            }
        }
        private void btnTimNV_Click(object sender, EventArgs e)
        {
            if (txtTimNV.Text != "" && txtTimNV.Text != "Nhập từ khóa............")
            {
                SearchNV();
            }
            else
            {
                MessageBox.Show("Hãy nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region SanPham
        SanPhamBUS sp = new SanPhamBUS();

    //Hien thi San Pham
        private void LoadSP()
        {
            dgvSP.AutoGenerateColumns = false;
            dgvSP.DataSource = sp.LoadSPBUS();
        }

        private void tabSP_Click(object sender, EventArgs e)
        {
            LoadSP();
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDonGia.Text = "";
            txtDonViTinh.Text = "";
            txtMaLoaiSP.Text = "";
            txtMoTa.Text = "";
            txtTimSP.Text = "";
            picSP.Image = null;
        }

        private void dgvSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaSP.Text = dgvSP.Rows[row].Cells[0].Value.ToString();
                txtTenSP.Text = dgvSP.Rows[row].Cells[1].Value.ToString();
                txtDonGia.Text = dgvSP.Rows[row].Cells[2].Value.ToString();
                txtDonViTinh.Text = dgvSP.Rows[row].Cells[3].Value.ToString();
                txtMaLoaiSP.Text = dgvSP.Rows[row].Cells[5].Value.ToString();
                if (dgvSP.Rows[row].Cells[4].Value != null)
                {
                    txtMoTa.Text = dgvSP.Rows[row].Cells[4].Value.ToString();
                }
                else
                {
                    txtMoTa.Text = "";
                }
                if (dgvSP.Rows[row].Cells[6].Value.ToString() != "")
                {
                    picSP.Image = new Bitmap(Application.StartupPath + dgvSP.Rows[row].Cells[6].Value.ToString());
                }
                else
                {
                    picSP.Image = null;
                }
            }
        }

    //Them San Pham
        private void AddSP()
        {
            SanPham spToAdd = new SanPham();
            spToAdd.TenSP = txtTenSP.Text;
            spToAdd.DonGia = decimal.Parse(txtDonGia.Text);
            spToAdd.DonViTinh = txtDonViTinh.Text;
            spToAdd.MoTa = txtMoTa.Text;
            spToAdd.MaLoaiSP = int.Parse(txtMaLoaiSP.Text);
            spToAdd.HinhAnh = txtHinhAnh.Text;
            SanPhamBUS spBUS = new SanPhamBUS();
            spBUS.AddSPBUS(spToAdd);
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text != "" && txtTenSP.Text != "" && txtDonGia.Text != "" && txtDonViTinh.Text != "" && txtMaLoaiSP.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn muốn thêm một sản phẩm mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        AddSP();
                        LoadSP();
                        MessageBox.Show("Đã thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Đúng và Đầy Đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    //Xoa San Pham
        private void DeleteSP()
        {
            int id = int.Parse(txtMaSP.Text);
            sp.DeleteSPBUS(id);
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm " + txtMaSP.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        DeleteSP();
                        LoadSP();
                        MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn sản phẩm muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Sua San Pham
        private void UpdateSP()
        {
            SanPham spToUpdate = new SanPham();

            spToUpdate.MaSP = int.Parse(txtMaSP.Text);
            spToUpdate.TenSP = txtTenSP.Text;
            spToUpdate.DonGia = decimal.Parse(txtDonGia.Text);
            spToUpdate.DonViTinh = txtDonViTinh.Text;
            spToUpdate.MoTa = txtMoTa.Text;
            spToUpdate.MaLoaiSP = int.Parse(txtMaLoaiSP.Text);
            spToUpdate.HinhAnh = txtHinhAnh.Text;

            SanPhamBUS spBUS = new SanPhamBUS();
            spBUS.UpdateSPBUS(spToUpdate);
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            if (txtMaSP.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa sản phẩm " + txtMaSP.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        UpdateSP();
                        LoadSP();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn sản phẩm muốn sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Tim San Pham
        private void txtTimSP_Click(object sender, EventArgs e)
        {
            txtTimSP.Text = "";
            txtTimSP.ForeColor = Color.Black;
        }

        private void txtTimSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimSP_Click(sender, e);
            }
        }

        private void SearchSP()
        {
            
            if (rdbTimMaSP.Checked == true)
            {
                int key = int.Parse(txtTimSP.Text);
                dgvSP.DataSource = sp.SearchMaSPBUS(key);
            }
            else
            {
                string key = txtTimSP.Text;
                dgvSP.DataSource = sp.SearchTenSPBUS(key);
            }
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            if (txtTimSP.Text != "" && txtTimSP.Text != "Nhập từ khóa............")
            {
                SearchSP();
            }
            else
            {
                MessageBox.Show("Hãy nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region KhachHang
        KhachHangBUS kh = new KhachHangBUS();

    //Hiển thị KH
        private void LoadKH()
        {
            dgvKH.AutoGenerateColumns = false;
            dgvKH.DataSource = kh.LoadKHBUS();
        }

        private void tabKH_Click(object sender, EventArgs e)
        {
            LoadKH();
            txtMaKH.Text = "";
            txtHoKH.Text = "";
            txtDiaChiKH.Text = "";
            txtSdtKH.Text = "";
            txtTimKH.Text = "";
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaKH.Text = dgvKH.Rows[row].Cells[0].Value.ToString();
                txtHoKH.Text = dgvKH.Rows[row].Cells[1].Value.ToString() + " " + dgvKH.Rows[row].Cells[2].Value.ToString();

                if (dgvKH.Rows[row].Cells[3].Value.ToString() == "Nam")
                {
                    rdbNamKH.Checked = true;
                }
                else
                {
                    rdbNuKH.Checked = true;
                }

                txtDiaChiKH.Text = dgvKH.Rows[row].Cells[4].Value.ToString();
                txtSdtKH.Text = dgvKH.Rows[row].Cells[5].Value.ToString();
            }
        }

        //Thêm KH
        private void AddKH()
        {
            KhachHang khToAdd = new KhachHang();
            khToAdd.HoKH = txtHoKH.Text;
            khToAdd.TenKH = txtTenKH.Text;
            if (rdbNamKH.Checked == true)
            {
                khToAdd.GioiTinh = "Nam";
            }
            else
            {
                khToAdd.GioiTinh = "Nữ";
            }
            khToAdd.DiaChi = txtDiaChiKH.Text;
            khToAdd.DienThoai = txtSdtKH.Text;

            KhachHangBUS khBUS = new KhachHangBUS();
            khBUS.AddKHBUS(khToAdd);
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "" && txtHoKH.Text != "" && txtTenKH.Text != "" && txtDiaChiKH.Text != "" && txtSdtKH.Text != "")
            {
                DialogResult result = MessageBox.Show("Thêm một khách hàng mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        AddKH();
                        LoadKH();
                        MessageBox.Show("Đã thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Đúng và Đầy Đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Xóa KH
        private void DeleteKH()
        {
            int id = int.Parse(txtMaKH.Text);
            kh.DeleteKHBUS(id);
        }

        private void btnXoaKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khách hàng " + txtMaKH.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        DeleteKH();
                        LoadKH();
                        MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn khách hàng muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Sửa KH
        private void UpdateKH()
        {
            KhachHang khToUpdate = new KhachHang();
            khToUpdate.MaKH = int.Parse(txtMaKH.Text);
            khToUpdate.HoKH = txtHoKH.Text;
            khToUpdate.TenKH = txtTenKH.Text;
            if (rdbNamKH.Checked == true)
            {
                khToUpdate.GioiTinh = "Nam";
            }
            else
            {
                khToUpdate.GioiTinh = "Nữ";
            }
            khToUpdate.DiaChi = txtDiaChiKH.Text;
            khToUpdate.DienThoai = txtSdtKH.Text;

            KhachHangBUS khBUS = new KhachHangBUS();
            khBUS.UpdateKHBUS(khToUpdate);
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa khách hàng. " + txtMaKH.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        UpdateKH();
                        LoadKH();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn khách hàng muốn sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Tìm KH
        private void txtTimKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKH_Click(sender, e);
            }
        }

        private void txtTimKH_Click(object sender, EventArgs e)
        {
            txtTimKH.Text = "";
            txtTimKH.ForeColor = Color.Black;
        }

        private void SearchKH()
        {
            if (rdbTimMaKH.Checked == true)
            {
                int key = int.Parse(txtTimKH.Text);
                dgvKH.DataSource = kh.SearchMaKHBUS(key);
            }
            else
            {
                string key = txtTimKH.Text;
                dgvKH.DataSource = kh.SearchTenKHBUS(key);
            }
            
        }

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            if (txtTimKH.Text != "" && txtTimKH.Text != "Nhập từ khóa............")
            {
                SearchKH();
            }
            else
            {
                MessageBox.Show("Hãy nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region LoaiSanPham
        LoaiSanPhamBUS loaiSP = new LoaiSanPhamBUS();

    //Hien thi Loai SP
        private void LoadLoaiSP()
        {
            dgvLoai.AutoGenerateColumns = false;
            dgvLoai.DataSource = loaiSP.LoadLoaiSPBUS();
        }

        private void tabLoaiSP_Click(object sender, EventArgs e)
        {
            LoadLoaiSP();
            txtMaLoai.Text = "";
            txtTenLoai.Text = "";
        }

        private void dgvLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaLoai.Text = dgvLoai.Rows[row].Cells[0].Value.ToString();
                txtTenLoai.Text = dgvLoai.Rows[row].Cells[1].Value.ToString();
            }
        }

    //Them Loai SP
        private void AddLoaiSP()
        {
            LoaiSanPham loaiToAdd = new LoaiSanPham();
            loaiToAdd.TenLoai = txtTenLoai.Text;

            LoaiSanPhamBUS loaiBUS = new LoaiSanPhamBUS();
            loaiBUS.AddLoaiSPBUS(loaiToAdd);
        }

        private void btnThemLoai_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text != "" && txtTenLoai.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn muốn thêm một loại sản phẩm mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        AddLoaiSP();
                        LoadLoaiSP();
                        MessageBox.Show("Đã thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Đúng và Đầy Đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    //Xoa Loai SP
        private void DeleteLoaiSP()
        {
            int id = int.Parse(txtMaLoai.Text);
            loaiSP.DeleteLoaiSPBUS(id);
        }

        private void btnXoaLoai_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa loại sản phẩm?" + txtMaNV.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        DeleteLoaiSP();
                        LoadLoaiSP();
                        MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn loại sản phẩm muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    //Sua Loai SP
        private void UpdateLoaiSP()
        {
            LoaiSanPham loaiToUpdate = new LoaiSanPham();
            loaiToUpdate.MaLoaiSP = int.Parse(txtMaLoai.Text);
            loaiToUpdate.TenLoai = txtTenLoai.Text;

            LoaiSanPhamBUS loaiBUS = new LoaiSanPhamBUS();
            loaiBUS.UpdateLoaiSPBUS(loaiToUpdate);
        }

        private void btnSuaLoai_Click(object sender, EventArgs e)
        {
            if (txtMaLoai.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa loại sản phẩm." + txtMaNV.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        UpdateLoaiSP();
                        LoadLoaiSP();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn loại sản phẩm muốn sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Tim Loai SP
        private void SearchLoaiSP()
        {
            
            if (rdbTimMaLoai.Checked == true)
            {
                int key = int.Parse(txtTimLoai.Text);
                dgvLoai.DataSource = loaiSP.SearchMaLoaiSPBUS(key);
            }
            else
            {
                string key = txtTimLoai.Text;
                dgvLoai.DataSource = loaiSP.SearchTenLoaiSPBUS(key);
            }
        }

        private void btnTimLoai_Click(object sender, EventArgs e)
        {
            if (txtTimLoai.Text != "" && txtTimLoai.Text != "Nhập từ khóa............")
            {
                SearchLoaiSP();
            }
            else
            {
                MessageBox.Show("Hãy nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtTimLoai_Click(object sender, EventArgs e)
        {
            txtTimLoai.Text = "";
            txtTimLoai.ForeColor = Color.Black;
        }

        private void txtTimLoai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimLoai_Click(sender, e);
            }
        }
        #endregion

        #region TaiKhoan

        TaiKhoanBUS userBUS = new TaiKhoanBUS();
    //Hien thi
        private void LoadUser()
        {
            dgvUser.AutoGenerateColumns = false;
            dgvUser.DataSource = userBUS.LoadUserBUS();
        }

        private void tabUser_Click(object sender, EventArgs e)
        {
            txtMaTaiKhoan.Text = "";
            txtTenDangNhap.Text = "";
            txtMatKhau.Text = "";
        }

        int eyeClick = 1;
        private void lbXemMatKhau_Click(object sender, EventArgs e)
        {
            if (eyeClick % 2 != 0)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
            eyeClick++;
        }

        private void dgvUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != null)
            {
                e.Value = new String('x', e.Value.ToString().Length);
            }
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaTaiKhoan.Text = dgvUser.Rows[row].Cells[0].Value.ToString();
                txtTenDangNhap.Text = dgvUser.Rows[row].Cells[1].Value.ToString();
                txtMatKhau.Text = dgvUser.Rows[row].Cells[2].Value.ToString();
            }
        }

    //Them Tai Khoan
        private void AddUser()
        {
            TaiKhoan userToAdd = new TaiKhoan();
            userToAdd.TenTaiKhoan = txtTenDangNhap.Text;
            userToAdd.MatKhau = txtMatKhau.Text;
            TaiKhoanBUS userBUS = new TaiKhoanBUS();
            userBUS.AddUserBUS(userToAdd);
        }

        private void btnThemUser_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text != "" || txtMatKhau.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn muốn thêm một tài khoản mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        AddUser();
                        LoadUser();
                        MessageBox.Show("Đã thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Đúng và Đầy Đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    //Xoa Tai Khoan
        private void DeleteUser()
        {
            int userId = int.Parse(txtMaTaiKhoan.Text);
            userBUS.DeleteUserBUS(userId);
        }

        private void btnXoaUser_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản." + txtTenDangNhap.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        DeleteUser();
                        LoadUser();
                        MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn tài khoản muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Sua Tai Khoan
        private void UpdateUser()
        {
            TaiKhoan user = new TaiKhoan();
            user.MaTaiKhoan = int.Parse(txtMaTaiKhoan.Text);
            user.TenTaiKhoan = txtTenDangNhap.Text;
            user.MatKhau = txtMatKhau.Text;
            userBUS.UpdateUserBUS(user);
        }

        private void btnSuaUser_Click(object sender, EventArgs e)
        {
            if (txtMaTaiKhoan.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa tài khoản." + txtTenDangNhap.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        UpdateUser();
                        LoadUser();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn tài khoản muốn sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    //Tim Tai Khoan
        #endregion
        
    }
}
