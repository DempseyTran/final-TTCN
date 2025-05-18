using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTCN
{
    public partial class frmChiTietNhanVien : Form
    {
        string selectedImagePath = ""; // Biến toàn cục lưu đường dẫn ảnh được chọn
        public frmChiTietNhanVien(string maNV, string tenNV, string gioiTinh, string email,
                             string diaChi, string chucVu, string sdt, string imagePath)
        {
            InitializeComponent();
            txtMaNV.Text = maNV;
            txtMaNV.Text = maNV;
            txtTenNV.Text = tenNV;
            txtGioiTinh.Text = gioiTinh;
            txtEmail.Text = email;
            //dtpNgaySinh.Value = ngaySinh;
            txtDiaChi.Text = diaChi;
            txtChucVu.Text = chucVu;
            mskDienthoai.Text = sdt;
            //hiển thị ảnh
            try
            {
                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    picNV.Image = Image.FromFile(imagePath);
                    picNV.SizeMode = PictureBoxSizeMode.Zoom; // ảnh sẽ được phóng to/thu nhỏ vừa khung picNV
                }
                else
                {
                    picNV.Image = null; // hoặc gán ảnh mặc định nếu muốn
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message);
            }
        }
        
        private void frmChiTietNhanVien_Load(object sender, EventArgs e)
        {
            DAO.Connect();
            LoadThongTinNhanVien();
        }
        private void LoadThongTinNhanVien()
        {
            
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh nhân viên";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.InitialDirectory = @"D:\"; // Mở trực tiếp ổ D

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = openFileDialog.FileName;
                picNV.Image = Image.FromFile(selectedImagePath);
                //set ảnh trung tâm
                picNV.SizeMode = PictureBoxSizeMode.StretchImage;
                picNV.Dock = DockStyle.None; // Không kéo dài PictureBox theo form
                picNV.Anchor = AnchorStyles.None; // Cố định vị trí
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //lưu ảnh từ picNV
            if (string.IsNullOrEmpty(selectedImagePath))
            {
                MessageBox.Show("Bạn chưa chọn ảnh.");
                return;
            }

            string maNhanVien = txtMaNV.Text; // Hoặc lấy từ control nào đó
            string imagePathToSave = selectedImagePath;

            // Kết nối và lưu đường dẫn ảnh vào DB
            try
            {
                DAO.Connect();  // Mở kết nối

                string query = "UPDATE NhanVien SET Anh = @DuongDanAnh WHERE MaNhanVien = @MaNhanVien";

                using (SqlCommand cmd = new SqlCommand(query, DAO.conn))
                {
                    cmd.Parameters.AddWithValue("@DuongDanAnh", imagePathToSave);
                    cmd.Parameters.AddWithValue("@MaNhanVien", maNhanVien);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Lưu ảnh thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Lưu ảnh thất bại hoặc không tìm thấy nhân viên!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message);
            }
            finally
            {
                DAO.Close(); // Đóng kết nối dù có lỗi hay không
            }


        }
    }
}
