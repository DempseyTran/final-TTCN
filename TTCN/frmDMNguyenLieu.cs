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
    public partial class frmDMNguyenLieu : Form
    {
        DataTable tblNhanvien = new DataTable();
        SqlConnection conn = DAO.conn;

        public frmDMNguyenLieu()
        {
            InitializeComponent();
        }

        

        

        private void nhậpKhoNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapNguyenLieu frmNhapNL = new frmNhapNguyenLieu();
            frmNhapNL.ShowDialog();
        }

        private void xuấtKhoNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXuatNguyenLieu frmpXuatNL = new frmXuatNguyenLieu();
            frmpXuatNL.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDMNguyenLieu_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            LoadDataToGridView();
            dgvDMNguyenLieu.AllowUserToAddRows = false;
            dgvDMNguyenLieu.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void LoadDataToGridView()
        {
            dgvDMNguyenLieu.DataSource = null;
            string HienThiNguyenLieuQuery = "select * from NguyenLieu";
            DataTable dt = DAO.LoadDataToTable(HienThiNguyenLieuQuery);
            dgvDMNguyenLieu.DataSource = dt;

        }
        private Boolean check()
        {
            if (txtMaNguyenLieu.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống mã nhân viên");
                txtMaNguyenLieu.Focus();
                return false;
            }
            if (txtTenNguyenLieu.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống tên nhân viên");
                txtTenNguyenLieu.Focus();
                return false;
            }
            if (txtLoaiNguyenLieu.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống địa chỉ");
                txtLoaiNguyenLieu.Focus();
                return false;
            }
            if (txtDonGiaNhap.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống số điện thoại");
                txtDonGiaNhap.Focus();
                return false;
            }
            if (txtDVT.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống ngày sinh");
                txtDVT.Focus();
                return false;
            }
            if (txtSoLuong.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống chức vụ");
                txtSoLuong.Focus();
                return false;
            }
            if (txtDMSX.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống chức vụ");
                txtDMSX.Focus();
                return false;
            }
            return true;
        }
        private void resetvalues()
        {
            txtMaNguyenLieu.Text = "";
            txtTenNguyenLieu.Text = "";
            txtLoaiNguyenLieu.Text = "";
            txtDonGiaNhap.Text = "";
            txtDVT.Text = "";
            txtSoLuong.Text = "";
            txtDMSX.Text = "";
        }

      

        private void BtnThem_Click(object sender, EventArgs e)
        {
            resetvalues();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnXuatPhieu.Enabled = false;
            btnLuu.Enabled = true;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            resetvalues();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnXuatPhieu.Enabled = true;

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (check())
            {
                string Manguyenlieu = txtMaNguyenLieu.Text.Trim();
                string Tennguyenlieu = txtTenNguyenLieu.Text.Trim();
                string Loainguyenlieu = txtLoaiNguyenLieu.Text.Trim();
                string Gianhap = txtDonGiaNhap.Text.Trim();
                string DVT = txtDVT.Text.Trim();
                string Soluong = txtSoLuong.Text.Trim();
                string DMSX = txtDMSX.Text.Trim();


                string sqlInsert = "INSERT INTO NguyenLieu (manguyenlieu, tennguyenlieu, loainguyenlieu, gianhap, donvitinh, soluong, dinhmucsanxuat) VALUES (" +
                    "N'" + Manguyenlieu + "', " +
                    "N'" + Tennguyenlieu + "', " +
                    "N'" + Loainguyenlieu + "', " +
                    "N'" + Gianhap + "', " +
                    "N'" + DVT + "', " +
                    "N'" + Soluong + "', " +
                    "N'" + DMSX + "')";


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
    }
}
