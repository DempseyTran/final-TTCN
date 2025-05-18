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
    public partial class frmDMNhaCungCap : Form
    {
        DataTable tblNCC = new DataTable();
        SqlConnection conn = DAO.conn;
        public frmDMNhaCungCap()
        {
            InitializeComponent();
        }

        private void frmDMNhaCungCap_Load(object sender, EventArgs e)
        {
            btnLuu.Enabled = false;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            LoadDataToGridView();
            dgvNCC.AllowUserToAddRows = false;
            dgvNCC.EditMode = DataGridViewEditMode.EditProgrammatically;

        }
        private void LoadDataToGridView()
        {
            dgvNCC.DataSource = null;
            string HienThiNCC = "select * from NhaCungCap";
            DataTable dt = DAO.LoadDataToTable(HienThiNCC);
            dgvNCC.DataSource = dt;

        }
        private Boolean check()
        {
            if (txtMaNCC.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống mã nhân viên");
                txtMaNCC.Focus();
                return false;
            }
            if (txtTenNCC.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống tên nhân viên");
                txtTenNCC.Focus();
                return false;
            }
            if (txtDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống địa chỉ");
                txtDiaChi.Focus();
                return false;
            }
            if (mskDienThoai.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống số điện thoại");
                mskDienThoai.Focus();
                return false;
            }
            return true;
        }
        private void resetvalues()
        {
            txtMaNCC.Text = "";
            txtTenNCC.Text = "";
            txtDiaChi.Text = "";
            mskDienThoai.Text = "";
        }
        private void BtnThem_Click(object sender, EventArgs e)
        {
            resetvalues();
            if(txtMaNCC.ReadOnly == true) txtMaNCC.ReadOnly = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            if (btnLuu.Checked == false) btnLuu.Enabled = true;
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            resetvalues();
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            LoadDataToGridView();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (check())
            {
                string MaNCC = txtMaNCC.Text.Trim();
                string TenNCC = txtTenNCC.Text.Trim();
                string Diachi = txtDiaChi.Text.Trim();
                string Sodienthoai = mskDienThoai.Text.Trim();


                string sqlInsert = "INSERT INTO NhaCungCap (manhacungcap, tennhacungcap, diachi, sodienthoai) VALUES (" +
                                    "N'" + MaNCC + "', " +
                                    "N'" + TenNCC + "', " +
                                    "N'" + Diachi + "', " +
                                    "N'" + Sodienthoai + "')";

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

        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNCC.ReadOnly = true;
            if (dgvNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để chọn");
            }
            else
            {
                txtMaNCC.Text = dgvNCC.CurrentRow.Cells[0].Value.ToString();
                txtTenNCC.Text = dgvNCC.CurrentRow.Cells[1].Value.ToString();
                txtDiaChi.Text = dgvNCC.CurrentRow.Cells[2].Value.ToString();
                mskDienThoai.Text = dgvNCC.CurrentRow.Cells[3].Value.ToString();
            }
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            string keyword = txtTraCuu.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tra cứu!");
                return;
            }

            string query = $"SELECT * FROM NhaCungCap WHERE TenNhaCungCap LIKE N'%{keyword}%'";


            try
            {
                DAO.Connect(); // Đảm bảo kết nối mở
                DataTable dt = DAO.LoadDataToTable(query); // Sử dụng phương thức DAO
                dgvNCC.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                DAO.Close(); // Đóng kết nối
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        { 
            string TenNCC = txtTenNCC.Text.Trim();
            string Diachi = txtDiaChi.Text.Trim();
            string Sodienthoai = mskDienThoai.Text.Trim();
           


            string sqlUpdate = "UPDATE NhaCungCap SET tennhacungcap = N'" + TenNCC + "', diachi = N'" + Diachi +
                         "', sodienthoai = N'" + Sodienthoai + "' WHERE MaNhaCungCap = N'" + txtMaNCC.Text.Trim() + "'";

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //đảm bảo rằng bạn đã kết nối đến cơ sở dữ liệu
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            // Xóa nhà cung cấp
            string sql = "DELETE FROM NhaCungCap WHERE MaNhaCungCap = '" + txtMaNCC.Text.Trim() + "'";
            if (dgvNCC.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa");
                return;
            }

            if (txtMaNCC.Text == "")
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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}