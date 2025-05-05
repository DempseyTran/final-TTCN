using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTCN
{
    public partial class frmQuenMatKhau : Form
    {
        public frmQuenMatKhau()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string sdt = guna2TextBox1.Text.Trim();

            if (string.IsNullOrEmpty(sdt))
            {
                label2.Text = "Vui lòng nhập số điện thoại.";
                return;
            }

            try
            {
                DAO.Connect(); // Đảm bảo DAO.conn đã mở sẵn kết nối SQL
                using (SqlConnection cn = DAO.conn)
                {
                    string sql = "SELECT MatKhau FROM TaiKhoan " +
                                 "JOIN NhanVien ON NhanVien.MaNhanVien = TaiKhoan.MaNhanVien " +
                                 "WHERE NhanVien.SoDienThoai = @sdt";

                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = sdt;

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string matKhau = result.ToString();
                            label2.Text = "Mật khẩu của bạn là: " + matKhau;
                        }
                        else
                        {
                            label2.Text = "Không tồn tại tài khoản.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối CSDL: " + ex.Message);
            }
            finally
            {
                DAO.Close(); // Đảm bảo đóng kết nối
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQuenMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
