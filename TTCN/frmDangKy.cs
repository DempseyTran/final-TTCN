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
    public partial class frmDangKy : Form
    {
        string connectionString = "Data Source=NGU\\SQLEXPRESS01;Initial Catalog=QlyBanHang;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public frmDangKy()
        {
            InitializeComponent();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmDangKy_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string maNV = guna2TextBox3.Text.Trim();
            string tenDN = guna2TextBox5.Text.Trim();
            DateTime ngayDK = guna2DateTimePicker1.Value;
            string matKhau = guna2TextBox4.Text.Trim();

            if (maNV == "" || tenDN == "" || matKhau == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string queryCheckNV = "SELECT COUNT(*) FROM NhanVien WHERE MaNhanVien = @MaNV";
                    SqlCommand cmdCheckNV = new SqlCommand(queryCheckNV, conn);
                    cmdCheckNV.Parameters.AddWithValue("@MaNV", maNV);
                    int existsNV = (int)cmdCheckNV.ExecuteScalar();

                    if (existsNV == 0)
                    {
                        MessageBox.Show("Mã nhân viên không tồn tại!");
                        return;
                    }

                    string queryCheckTK = "SELECT COUNT(*) FROM TaiKhoan WHERE MaNhanVien = @MaNV";
                    SqlCommand cmdCheckTK = new SqlCommand(queryCheckTK, conn);
                    cmdCheckTK.Parameters.AddWithValue("@MaNV", maNV);
                    int existsTK = (int)cmdCheckTK.ExecuteScalar();

                    if (existsTK > 0)
                    {
                        MessageBox.Show("Tài khoản cho nhân viên này đã tồn tại!");
                        return;
                    }

                    string queryInsert = "INSERT INTO TaiKhoan (MaNhanVien, TenDangNhap, NgayDangKi, MatKhau) VALUES (@MaNV, @TenDN, @NgayDK, @MatKhau)";
                    SqlCommand cmdInsert = new SqlCommand(queryInsert, conn);
                    cmdInsert.Parameters.AddWithValue("@MaNV", maNV);
                    cmdInsert.Parameters.AddWithValue("@TenDN", tenDN);
                    cmdInsert.Parameters.AddWithValue("@NgayDK", ngayDK);
                    cmdInsert.Parameters.AddWithValue("@MatKhau", matKhau);

                    int result = cmdInsert.ExecuteNonQuery();

                    if (result > 0)
                        MessageBox.Show("Tạo tài khoản thành công!");
                    else
                        MessageBox.Show("Tạo tài khoản thất bại!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}