using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Collections.Specialized.BitVector32;

namespace TTCN
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public static class Session
        {
            public static string TenDangNhap;
            public static string MaNhanVien;
            public static string ChucVu; // Lưu chức vụ từ bảng NhanVien
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string tentk = guna2TextBox1.Text.Trim();
            string matkhau = guna2TextBox2.Text.Trim();

            if (string.IsNullOrEmpty(tentk))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản!");
                return;
            }

            if (string.IsNullOrEmpty(matkhau))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                return;
            }

            DAO.Connect(); // Gọi kết nối

            try
            {
                string query = @"
                    SELECT TaiKhoan.MaNhanVien, NhanVien.ChucVu
                    FROM TaiKhoan
                    JOIN NhanVien ON TaiKhoan.MaNhanVien = NhanVien.MaNhanVien
                    WHERE TaiKhoan.TenDangNhap = @tentk AND TaiKhoan.MatKhau = @matkhau";

                using (SqlCommand cmd = new SqlCommand(query, DAO.conn))
                {
                    cmd.Parameters.AddWithValue("@tentk", tentk);
                    cmd.Parameters.AddWithValue("@matkhau", matkhau);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Session.MaNhanVien = reader["MaNhanVien"].ToString();
                            Session.ChucVu = reader["ChucVu"].ToString();
                            frmMain.Session.ChucVu = reader["ChucVu"].ToString();

                            frmMain mainForm = new frmMain();
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
            finally
            {
                DAO.Close(); // Đóng kết nối
            }
        }
        


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmQuenMatKhau qmkForm = new frmQuenMatKhau();
            qmkForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.PasswordChar == '*')
            {
                button1.BringToFront();
                guna2TextBox2.PasswordChar = '\0';

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.PasswordChar == '\0')
            {
                button2.BringToFront();
                guna2TextBox2.PasswordChar = '*';

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}


