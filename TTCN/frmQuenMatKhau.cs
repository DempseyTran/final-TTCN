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
using System.Net;
using System.Net.Mail;

namespace TTCN
{
    public partial class frmQuenMatKhau : Form
    {
        public frmQuenMatKhau()
        {
            InitializeComponent();
            DAO.Connect();
        }

        // Thay chuỗi kết nối phù hợp với máy bạn
        string connectionString = "Data Source=NGU\\SQLEXPRESS01;Initial Catalog=QlyBanHang;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string tenDangNhap = guna2TextBox2.Text.Trim();
            string email = guna2TextBox1.Text.Trim();
            string matKhau;

            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và email đăng ký.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (KiemTraThongTin(tenDangNhap, email, out matKhau))
            {
                GuiEmail(email, matKhau);
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool KiemTraThongTin(string tenDangNhap, string email, out string matKhau)
        {
            matKhau = null;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT TaiKhoan.MatKhau 
                     FROM TaiKhoan 
                     INNER JOIN NhanVien ON TaiKhoan.MaNhanVien = NhanVien.MaNhanVien
                     WHERE TaiKhoan.TenDangNhap = @TenDangNhap AND NhanVien.Email = @Email";


                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TenDangNhap", tenDangNhap);
                    cmd.Parameters.AddWithValue("@Email", email);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            matKhau = reader["MatKhau"].ToString();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private void GuiEmail(string email, string matKhau)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("BUV24102004@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Khôi phục mật khẩu";
                mail.Body = $"Mật khẩu của bạn là: {matKhau}";

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("BUV24102004@gmail.com", "dodxflmwlzukxqgh");

                client.Send(mail);
                MessageBox.Show("Mật khẩu đã được gửi về email của bạn.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Ví dụ: this.Close(); hoặc chuyển form
            this.Close();
        }
        private void frmQuenMatKhau_Load(object sender, EventArgs e)
        {
            // Nếu không cần gì đặc biệt thì có thể để trống
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            // Ẩn form hiện tại
            this.Hide();

            // Mở form đăng nhập
            frmDangNhap loginForm = new frmDangNhap();
            loginForm.Show();
        }
    }
}