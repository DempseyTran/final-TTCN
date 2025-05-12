using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace TTCN
{
    public partial class frmDMSanPham : Form
    {
        string fileAnh;
        public frmDMSanPham()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            dgvSanPham.DataSource = null;
            string HienThiSanPham = "select * from SanPham";
            DataTable dt = DAO.LoadDataToTable(HienThiSanPham);
            dgvSanPham.DataSource = dt;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string[] image;
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "JPES Images|*jpg|PNG Images|*.png|All files|*.*";
            openFile.FilterIndex = 1;
            openFile.InitialDirectory = Application.StartupPath;
            if (openFile.ShowDialog() == DialogResult.OK) {
                pAnh.Image = Image.FromFile(openFile.FileName);
                image = openFile.FileName.ToString().Split('\\');
                fileAnh = image[image.Length-1];
                MessageBox.Show(fileAnh);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmDanhMucSanPham_Load(object sender, EventArgs e)
        {
            LoadData(); // <--- phải gọi trước
            dgvSanPham.Columns[0].HeaderText = "Mã sản phẩm";
            dgvSanPham.Columns[1].HeaderText = "Tên sản phẩm";
            dgvSanPham.Columns[2].HeaderText = "Giá Bán";
            dgvSanPham.Columns[3].HeaderText = "Ảnh";
            dgvSanPham.Columns[4].HeaderText = "Ghi Chú";
            resetvalues();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSanPham.Text = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
            txtTenSanPham.Text = dgvSanPham.CurrentRow.Cells[1].Value.ToString();
            txtGiaBan.Text = dgvSanPham.CurrentRow.Cells[2].Value.ToString();
            txtGhiChu.Text = dgvSanPham.CurrentRow.Cells[4].Value.ToString();
            fileAnh = dgvSanPham.CurrentRow.Cells[3].Value.ToString();


            string binDebug = Application.StartupPath;

            // Lên 2 cấp để về ...\TTCN
            string projectRoot = Directory.GetParent(Directory.GetParent(binDebug).FullName).FullName;

            // Thư mục ảnh trong project
            string imageFolder = Path.Combine(projectRoot, "Anh");

            // Ghép tên file từ CSDL
            string fullPath = Path.Combine(imageFolder, fileAnh);


            if (File.Exists(fullPath))
            {
                // Dispose ảnh cũ
                if (pAnh.Image != null)
                {
                    pAnh.Image.Dispose();
                    pAnh.Image = null;
                }

                try
                {
                    // 1) Đọc tất cả bytes
                    byte[] bytes = File.ReadAllBytes(fullPath);

                    // 2) Mở MemoryStream
                    using (var ms = new MemoryStream(bytes))
                    {
                        // 3) Load ảnh tạm
                        using (var temp = Image.FromStream(ms))
                        {
                            // 4) Clone vào PictureBox
                            pAnh.Image = new Bitmap(temp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load ảnh: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy ảnh: " + fullPath);
            }

            
            btnSua.Enabled = true;
            btnXoa.Enabled = true;




        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private Boolean check()
        {
            if (txtMaSanPham.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống mã sản phẩm");
                txtMaSanPham.Focus();
                return false;
            }
            if (txtTenSanPham.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống tên sản phẩm");
                txtTenSanPham.Focus();
                return false;
            }
            if (txtGiaBan.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống giá bá");
                txtGiaBan.Focus();
                return false;
            }

            return true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            DataTable dtCheckHang = DAO.LoadDataToTable("SELECT * FROM SanPham WHERE MaSanPham = N'" + txtMaSanPham.Text.Trim() + "'");

            if (dtCheckHang.Rows.Count > 0)
            {
                MessageBox.Show("Mã hàng đã có, mời bạn nhập mã khác");
                txtMaSanPham.Focus();
                return;
            }
            
            if (check())
            {
                string MaSanPham = txtMaSanPham.Text.Trim();
                string TenSanPham = txtTenSanPham.Text.Trim();
                string DonGia = txtGiaBan.Text.Trim();
                string GhiChu = txtGhiChu.Text.Trim();
                string sqlInsert = "INSERT INTO SanPham (maSanPham, tenSanPham, DonGia, Anh, GhiChu) VALUES (" +
                                    "N'" + MaSanPham + "', " +
                                    "N'" + TenSanPham + "', " +
                                    "N'" + DonGia + "', " +                                 
                                    "N'" + fileAnh + "', " +
                                    "N'" + GhiChu + "')";

                try
                {
                    DAO.Connect(); // 👉 Đảm bảo kết nối mở trước
                    SqlCommand command = new SqlCommand(sqlInsert, DAO.conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Lưu thành công!");
                    LoadData();
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
        private void resetvalues()
        {
            txtMaSanPham.Text = "";
            txtTenSanPham.Text = "";
            txtGiaBan.Text = "";
            txtGhiChu.Text = "";
            pAnh.Image = null;
            fileAnh = "";
            txtMaSanPham.Focus();
            btnThem.Enabled=true;
            btnSua.Enabled=false;
            btnXoa.Enabled=false;

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            resetvalues();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
           
            if (dgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xóa");
                return;
            }

            if (txtMaSanPham.Text == "")
            {
                MessageBox.Show("Bạn chưa chọn dữ liệu để xóa");
                return;
            }

            if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string connectionString = "Data Source=NGU\\SQLEXPRESS01;Initial Catalog=QlyBanHang;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = "DELETE FROM SanPham WHERE MaSanPham = @ma";
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.AddWithValue("@ma", txtMaSanPham.Text.Trim());
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Xóa thành công");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Xóa dữ liệu không thành công vì: " + ex.Message);
                    }
                }
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có sản phẩm nào được chọn trong DataGridView hay không
            if (dgvSanPham.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa!");
                return;
            }

            if (check()) // Sử dụng lại hàm kiểm tra dữ liệu đầu vào
            {
                string MaSanPham = txtMaSanPham.Text.Trim();
                string MaSanPhamMoi = txtMaSanPham.Text.Trim();
                string TenSanPham = txtTenSanPham.Text.Trim();
                string DonGia = txtGiaBan.Text.Trim();
                string GhiChu = txtGhiChu.Text.Trim();
                string Anh = fileAnh; // Sử dụng lại biến fileAnh đã chọn

                // Lấy mã sản phẩm gốc từ hàng đã chọn để dùng trong mệnh đề WHERE
                string maSanPhamGoc = dgvSanPham.SelectedRows[0].Cells["MaSanPham"].Value.ToString();

                string sqlUpdate = "UPDATE SanPham SET " +
                                       "MaSanPham = N'" + MaSanPhamMoi + "', " +
                                     "TenSanPham = N'" + TenSanPham + "', " +
                                     "DonGia = N'" + DonGia + "', " +
                                     "Anh = N'" + Anh + "', " +
                                     "GhiChu = N'" + GhiChu + "' " +
                                     "WHERE MaSanPham = N'" + maSanPhamGoc + "'";

                try
                {
                    DAO.Connect(); // 👉 Đảm bảo kết nối mở trước
                    SqlCommand command = new SqlCommand(sqlUpdate, DAO.conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật thành công!");
                    LoadData(); // Tải lại dữ liệu để hiển thị thay đổi
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi cập nhật: " + ex.Message);
                }
                finally
                {
                    DAO.Close(); // 👉 Luôn đóng lại kết nối
                }
            }
        }
    }
}


