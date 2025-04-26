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

namespace TTCN
{
    public partial class frmDMNhanVien : Form
    {
        DataTable tblNhanvien = new DataTable();
        SqlConnection conn = DAO.conn;
        public frmDMNhanVien()
        {
            InitializeComponent();
        }

        private void frmDMNhanVien_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            LoadDataToGridView();
            dgvNhanVien.AllowUserToAddRows = false;
            dgvNhanVien.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadDataToGridView()
        {
            dgvNhanVien.DataSource = null;
            string HienThiNhanVienQuery = "select * from NhanVien";
            DataTable dt = DAO.LoadDataToTable(HienThiNhanVienQuery);
            dgvNhanVien.DataSource = dt;

        }
        private Boolean check()
        {
            if (txtMaNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống mã nhân viên");
                txtMaNhanVien.Focus();
                return false;
            }
            if (txtTenNhanVien.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống tên nhân viên");
                txtTenNhanVien.Focus();
                return false;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống địa chỉ");
                txtDiaChi.Focus();
                return false;
            }
            if (mskDienthoai.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống số điện thoại");
                mskDienthoai.Focus();
                return false;
            }
            if (mskNgaysinh.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống ngày sinh");
                mskNgaysinh.Focus();
                return false;
            }
            if (txtChucVu.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống chức vụ");
                txtDiaChi.Focus();
                return false;
            }
            return true;
        }
        private void resetvalues()
        {
            txtMaNhanVien.Text = "";
            txtTenNhanVien.Text = "";
            rabtnNam.Checked = false;
            rabtnNu.Checked = false;
            txtDiaChi.Text = "";
            mskDienthoai.Text = "";
            mskNgaysinh.Text = "";
            txtChucVu.Text = "";

        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
            resetvalues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
       

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            resetvalues();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (check())
            {
                string Manhanvien = txtMaNhanVien.Text.Trim();
                string Tennhanvien = txtTenNhanVien.Text.Trim();
                string Gioitinh = rabtnNam.Checked ? "Nam" : "Nữ";
                string Diachi = txtDiaChi.Text.Trim();
                string Sodienthoai = mskDienthoai.Text.Trim();
                string Ngaysinh = mskNgaysinh.Text.Trim();
                string Chucvu = txtChucVu.Text.Trim();

                string sqlInsert = "INSERT INTO NhanVien (manhanvien, tennhanvien, gioitinh, ngaysinh, diachi, sodienthoai, chucvu) VALUES (" +
                                    "N'" + Manhanvien + "', " +
                                    "N'" + Tennhanvien + "', " +
                                    "N'" + Gioitinh + "', " +
                                    "N'" + Ngaysinh + "', " +
                                    "N'" + Diachi + "', " +
                                    "N'" + Sodienthoai + "', " +
                                    "N'" + Chucvu + "')";

                try
                {
                    DAO.Connect(); // 👉 Đảm bảo kết nối mở trước
                    SqlCommand command = new SqlCommand(sqlInsert, DAO.conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Lưu thành công!");
                    LoadDataToGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi: " + ex.Message);
                }
                finally
                {
                    DAO.Close(); // 👉 Luôn đóng lại kết nối
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string Tennhanvien = txtTenNhanVien.Text.Trim();
            string Gioitinh = rabtnNam.Checked ? "Nam" : "Nữ";
            string Diachi = txtDiaChi.Text.Trim();
            string Sodienthoai = mskDienthoai.Text.Trim();
            string Ngaysinh = mskNgaysinh.Text.Trim();
            string Chucvu = txtChucVu.Text.Trim();


            string sqlUpdate = "UPDATE Nhanvien SET tennhanvien = N'" + Tennhanvien + "', gioitinh = N'" + Gioitinh + "', diachi = N'" + Diachi +
                         "', sodienthoai = N'" + Sodienthoai + "', ngaysinh = N'" + Ngaysinh + "', chucvu = N'" + Chucvu + "' WHERE manhanvien = N'" + txtMaNhanVien.Text.Trim() + "'";

            SqlCommand cmd = new SqlCommand(sqlUpdate, DAO.conn);

            try
            {
                DAO.Connect(); // dùng DAO chuẩn
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dữ liệu được sửa thành công");
                LoadDataToGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi: " + ex.Message);
            }
            finally
            {
                DAO.Close(); // Đóng sau khi dùng
            }

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để chọn");
            }
            else
            {
                txtMaNhanVien.Text = dgvNhanVien.CurrentRow.Cells[0].Value.ToString();
                txtTenNhanVien.Text = dgvNhanVien.CurrentRow.Cells[1].Value.ToString();
                string gioitinh = dgvNhanVien.CurrentRow.Cells[2].Value.ToString();
                rabtnNam.Checked = gioitinh == "Nam";
                rabtnNu.Checked = gioitinh == "Nữ";
                mskNgaysinh.Text = dgvNhanVien.CurrentRow.Cells[3].Value.ToString();
                txtDiaChi.Text = dgvNhanVien.CurrentRow.Cells[4].Value.ToString();
                mskDienthoai.Text = dgvNhanVien.CurrentRow.Cells[5].Value.ToString();
                txtChucVu.Text = dgvNhanVien.CurrentRow.Cells[6].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM NhanVien WHERE manhanvien = '" + txtMaNhanVien.Text.Trim() + "'";
            if (dgvNhanVien.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa");
                return;
            }

            if (txtMaNhanVien.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xóa");
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công");
                    LoadDataToGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa dữ liệu không thành công vì: " + ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
