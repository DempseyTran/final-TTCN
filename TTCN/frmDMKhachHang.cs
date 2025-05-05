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
    public partial class FrmDMKhachHang : Form
    {
        DataTable dtKhachHang;
        SqlConnection conn = DAO.conn;

        public FrmDMKhachHang()
        {
            InitializeComponent();
        }

        private void FrmDMKhachHang_Load(object sender, EventArgs e)
        {
            LoadDataToGridView();
        }

        private void LoadDataToGridView()
        {
            string sql = "SELECT MaKhachHang, TenKhachHang, SoDienThoai, DiemTichLuy FROM KhachHang";
            dtKhachHang = DAO.LoadDataToTable(sql);
            dataGridView.DataSource = dtKhachHang;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaKhach.Clear();
            txtTenKhach.Clear();
            mskDienThoai.Clear();
            txtMaKhach.Focus();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (check())
            {
                string MaKhach = txtMaKhach.Text.Trim();
                string TenKhach = txtTenKhach.Text.Trim();
                string DienThoai = mskDienThoai.Text.Trim();

                string sqlInsert = "INSERT INTO KhachHang (MaKhachHang, TenKhachHang, SoDienThoai, DiemTichLuy) " +
                                   "VALUES (N'" + MaKhach + "', N'" + TenKhach + "', N'" + DienThoai + "', 0)";

                try
                {
                    DAO.Connect();
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
                    DAO.Close();
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                string MaKhach = dataGridView.CurrentRow.Cells["MaKhachHang"].Value.ToString();

                string sqlDelete = "DELETE FROM KhachHang WHERE MaKhachHang = N'" + MaKhach + "'";

                try
                {
                    DAO.Connect();
                    SqlCommand command = new SqlCommand(sqlDelete, DAO.conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Xóa thành công!");
                    LoadDataToGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi: " + ex.Message);
                }
                finally
                {
                    DAO.Close();
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow != null)
            {
                string MaKhach = txtMaKhach.Text.Trim();
                string TenKhach = txtTenKhach.Text.Trim();
                string DienThoai = mskDienThoai.Text.Trim();

                string sqlUpdate = "UPDATE KhachHang SET " +
                                   "TenKhachHang = N'" + TenKhach + "', " +
                                   "SoDienThoai = N'" + DienThoai + "' " +
                                   "WHERE MaKhachHang = N'" + MaKhach + "'";

                try
                {
                    DAO.Connect();
                    SqlCommand command = new SqlCommand(sqlUpdate, DAO.conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Sửa thành công!");
                    LoadDataToGridView();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi: " + ex.Message);
                }
                finally
                {
                    DAO.Close();
                }
            }
        }
      

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private bool check()
        {
            // Bạn thêm phần kiểm tra nhập liệu ở đây nếu muốn
            if (string.IsNullOrEmpty(txtMaKhach.Text) || string.IsNullOrEmpty(txtTenKhach.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ Mã khách và Tên khách!");
                return false;
            }
            return true;
        }

       

        private void dataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                txtMaKhach.Text = row.Cells["MaKhachHang"].Value.ToString();
                txtTenKhach.Text = row.Cells["TenKhachHang"].Value.ToString();
                mskDienThoai.Text = row.Cells["SoDienThoai"].Value.ToString();
            }
        }
    }
}
