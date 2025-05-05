using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTCN
{
    public partial class frmHoaDonBanHang : Form
    {
        
        public frmHoaDonBanHang()
        {
            InitializeComponent();
        }

        private void FillDataNhanVienToCombo()
        {
            string sql = "SELECT MaNhanVien FROM NhanVien";
            DAO.FillDataToCombo(cbMaNV, sql, "MaNhanVien", "MaNhanVien");
        }

        private void frmHoaDonBanHang_Load(object sender, EventArgs e)
        {
            FillDataNhanVienToCombo();
            dgvChiTietHD.DataSource = null;
            dgvSanPham.DataSource = null;
            btnThemSP.Enabled = false; 
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuuHoaDon.Enabled = false;
            
        }
        private void resetvalues()
        {
            txtMaKH.Text = "";
            cbMaNV.Text = "";
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
            txtDonGia.Text = "";
         
            txtMoTa.Text = "";
            txtTongTien.Text = "";

        }
        private string GenerateNewInvoiceCode()
        {
            string newInvoiceCode = "HD0001"; // Mã mặc định nếu không có dữ liệu
            try
            {
                DAO.Connect(); // Đảm bảo kết nối mở
                string query = "SELECT TOP 1 MaHoaDon FROM HoaDon ORDER BY MaHoaDon DESC";
                DataTable dt = DAO.LoadDataToTable(query);

                if (dt.Rows.Count > 0)
                {
                    string lastInvoiceCode = dt.Rows[0]["MaHoaDon"].ToString();
                    int numberPart = int.Parse(lastInvoiceCode.Substring(2)); // Lấy phần số
                    newInvoiceCode = "HD" + (numberPart + 1).ToString("D4"); // Tăng số và định dạng
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã hóa đơn: " + ex.Message);
            }
            finally
            {
                DAO.Close(); // Đóng kết nối
            }

            return newInvoiceCode;
        }
        private void LoadDataToSanPham()
        {
            dgvSanPham.DataSource = null;
            string HienThiSanPhamQuery = "select * from SanPham";
            DataTable dt = DAO.LoadDataToTable(HienThiSanPhamQuery);
            dgvSanPham.DataSource = dt;
        }
        private void LoadDataToChiTietHD()
        {
            dgvChiTietHD.DataSource = null;
            string maHD = txtMaHD.Text.Trim();

            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn để hiển thị chi tiết!");
                return;
            }

            string HienThiCTHDQuery = "SELECT MaSanPham, SoLuong, DonGia, ThanhTien, MoTa " +
                                      "FROM ChiTietHoaDon " +
                                      "WHERE MaHoaDon = @MaHD";

            try
            {
                DAO.Connect();
                SqlCommand command = new SqlCommand(HienThiCTHDQuery, DAO.conn);
                command.Parameters.AddWithValue("@MaHD", maHD);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvChiTietHD.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải dữ liệu chi tiết hóa đơn: " + ex.Message);
            }
            finally
            {
                DAO.Close();
            }
        }
  

   

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnThemSP.Enabled = true;
            txtSoLuong.Text = "";
            txtSoLuong.Focus();
            if (dgvSanPham.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để chọn");
            }
            else
            {
                txtMaSP.Text = dgvSanPham.CurrentRow.Cells[0].Value.ToString();
                txtTenSP.Text = dgvSanPham.CurrentRow.Cells[1].Value.ToString();
                txtDonGia.Text = dgvSanPham.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void thêmHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Biến
            txtMaHD.Text = GenerateNewInvoiceCode();
            string maHD = txtMaHD.Text.Trim();
            string maKH = txtMaKH.Text.Trim();
            string maNV = cbMaNV.Text.Trim();
            decimal tongTien = 0;
            decimal giamGia = 0;

            //Xu li kiem tra
            if (txtMaKH.Text == "")
            {
                MessageBox.Show("Không để trông mã khách hàng");
                return;
            }
            if (cbMaNV.Text == "")
            {
                MessageBox.Show("Không để trông mã nhân viên");
                return;
            }
            try
            {
                DAO.Connect(); // Đảm bảo kết nối mở
                string sqlDiem = "SELECT DiemTichLuy FROM KhachHang WHERE MaKhachHang = N'" + maKH + "'";
                SqlCommand cmdDiem = new SqlCommand(sqlDiem, DAO.conn);
                object result = cmdDiem.ExecuteScalar();
                int diemTichLuy = result != null ? Convert.ToInt32(result) : 0;

                // Nếu điểm tích lũy chia hết cho 10 -> giảm 20%
                if (diemTichLuy % 10 == 0 && diemTichLuy != 0)
                {
                    MessageBox.Show("Hóa đơn này được khuyến mãi tích điểm! Giảm 20% tổng tiền.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy điểm tích lũy: " + ex.Message);
            }
            finally
            {
                DAO.Close(); // Đóng kết nối
            }

            //Các nút
            btnThemHoaDon.Enabled = false;
            btnLuuHoaDon.Enabled = true; // Bật nút Lưu Hóa Đơn
            txtMaHD.ReadOnly = true; // Đặt txtMaHD thành chỉ đọc
            btnGhiNhanHoaDon.Enabled = true;
            

            // Kiểm tra nếu khách hàng có lần mua chia hết cho 10
            try
            {
                DAO.Connect();
                string query = "SELECT COUNT(*) FROM HoaDon WHERE MaKhachHang = N'" + maKH + "'";
                SqlCommand cmdSoLanMua = new SqlCommand(query, DAO.conn);
                int soLanMua = (int)cmdSoLanMua.ExecuteScalar();

                if (soLanMua > 0 && soLanMua % 10 == 0)
                {
                    giamGia = 20 / 100; // Giảm giá 20%
                    MessageBox.Show("Khách hàng đã mua 10 lần, được giảm giá 20%!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra số lần mua: " + ex.Message);
            }
            finally
            {
                DAO.Close();
            }

            // Thêm hóa đơn vào bảng HoaDon
            string sqlInsertHoaDon = "INSERT INTO HoaDon (MaHoaDon, ThoiGian, MaNhanVien, MaKhachHang, TongTien, GiamGia) VALUES (" +
                                     "N'" + maHD + "', " +
                                     "GETDATE(), " +
                                     "N'" + maNV + "', " +
                                     "N'" + maKH + "', " +
                                     tongTien + ", " +
                                     giamGia + ")";

            try
            {
                DAO.Connect();
                SqlCommand command = new SqlCommand(sqlInsertHoaDon, DAO.conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Thêm hóa đơn thành công!");
                txtMaHD.Text = maHD; // Hiển thị mã hóa đơn vừa tạo
                LoadDataToSanPham();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm hóa đơn: " + ex.Message);
            }
            finally
            {
                DAO.Close();
            }
        }

        

        

        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text.Trim();
            string tongTienText = txtTongTien.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn để lưu!");
                return;
            }

            if (string.IsNullOrEmpty(tongTienText) || !decimal.TryParse(tongTienText, out decimal tongTien))
            {
                MessageBox.Show("Tổng tiền không hợp lệ. Vui lòng kiểm tra lại!");
                return;
            }

            // Câu lệnh SQL để cập nhật TongTien
            string sqlUpdate = "UPDATE HoaDon SET TongTien = @TongTien WHERE MaHoaDon = @MaHD";

            try
            {
                DAO.Connect();
                SqlCommand command = new SqlCommand(sqlUpdate, DAO.conn);
                command.Parameters.AddWithValue("@TongTien", tongTien);
                command.Parameters.AddWithValue("@MaHD", maHD);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật tổng tiền thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn với mã: " + maHD);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi cập nhật tổng tiền: " + ex.Message);
            }
            finally
            {
                DAO.Close();
            }
        }

       

        private void traCứuKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDMKhachHang frmDMKhachHang = new FrmDMKhachHang();
            frmDMKhachHang.ShowDialog();
        }

        private void btnHuyBo_Click(object sender, EventArgs e)
        {
            btnThemHoaDon.Enabled = true;
            btnLuuHoaDon.Enabled = false;
            btnXoaHoaDon.Enabled = true;
            btnGhiNhanHoaDon.Enabled = false;
            dgvChiTietHD.DataSource = null;
            dgvSanPham.DataSource = null;

        }

        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            resetvalues();
            string maHD = txtMaHD.Text.Trim();

            // Kiểm tra nếu mã hóa đơn rỗng
            if (string.IsNullOrEmpty(maHD))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn cần xóa!");
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn này không?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                DAO.Connect();

                // Xóa các chi tiết hóa đơn liên quan trước
                string deleteChiTietQuery = "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = N'" + maHD + "'";
                SqlCommand deleteChiTietCommand = new SqlCommand(deleteChiTietQuery, DAO.conn);
                deleteChiTietCommand.ExecuteNonQuery();

                // Xóa hóa đơn
                string deleteHoaDonQuery = "DELETE FROM HoaDon WHERE MaHoaDon = N'" + maHD + "'";
                SqlCommand deleteHoaDonCommand = new SqlCommand(deleteHoaDonQuery, DAO.conn);
                int rowsAffected = deleteHoaDonCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa hóa đơn thành công!");
                    LoadDataToChiTietHD(); // Cập nhật lại danh sách chi tiết hóa đơn
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn với mã: " + maHD);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xóa hóa đơn: " + ex.Message);
            }
            finally
            {
                DAO.Close();
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            string MaHD = txtMaHD.Text.Trim();
            string MaSP = txtMaSP.Text.Trim();
            string SoLuong = txtSoLuong.Text.Trim();
            string DonGia = txtDonGia.Text.Trim();
            string MoTa = txtMoTa.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(SoLuong))
            {
                MessageBox.Show("Không được bỏ trống số lượng");
                txtSoLuong.Focus();
                return;
            }

            if (string.IsNullOrEmpty(DonGia))
            {
                MessageBox.Show("Không được bỏ trống đơn giá");
                txtDonGia.Focus();
                return;
            }

            // Tính thành tiền
            if (!int.TryParse(SoLuong, out int parsedSoLuong) || !decimal.TryParse(DonGia, out decimal parsedDonGia))
            {
                MessageBox.Show("Số lượng hoặc đơn giá không hợp lệ. Vui lòng kiểm tra lại!");
                return;
            }
            string ThanhTien = (parsedSoLuong * parsedDonGia).ToString();
            
            
            // Câu lệnh SQL
            string sqlInsert = "INSERT INTO ChiTietHoaDon (mahoadon, masanpham, soluong, dongia, thanhtien, mota) VALUES (" +
                                "N'" + MaHD + "', " +
                                "N'" + MaSP + "', " +
                                parsedSoLuong + ", " +
                                parsedDonGia + ", " +
                                ThanhTien + ", " +
                                "N'" + MoTa + "')";

           
            try
            {
                DAO.Connect(); // Đảm bảo kết nối mở trước
                SqlCommand command = new SqlCommand(sqlInsert, DAO.conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Thêm món thành công!");
                LoadDataToSanPham(); 
                LoadDataToChiTietHD();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi: " + ex.Message);
            }
            finally
            {
                DAO.Close(); // Luôn đóng lại kết nối
            }

            //tính tổng tiền
            tinhTongTien();
            
        }
        private void tinhTongTien()
        {
            string MaHD = txtMaHD.Text.Trim();
            string maKH = txtMaKH.Text.Trim();

            string sqlTongTien = "SELECT SUM(ThanhTien) FROM ChiTietHoaDon WHERE MaHoaDon = N'" + MaHD + "'";
            string sqlLayMaKH = "SELECT MaKhachHang FROM HoaDon WHERE MaHoaDon = N'" + MaHD + "'";
            try
            {
                DAO.Connect(); // Đảm bảo kết nối mở

                // Lấy Mã Khách Hàng từ Hóa Đơn
                SqlCommand cmdMaKH = new SqlCommand(sqlLayMaKH, DAO.conn);
                object resultMaKH = cmdMaKH.ExecuteScalar();
                if (resultMaKH == null)
                {
                    MessageBox.Show("Không tìm thấy khách hàng cho hóa đơn này.");
                    return;
                }

                // Tính tổng tiền
                SqlCommand cmdTongTien = new SqlCommand(sqlTongTien, DAO.conn);
                object resultTongTien = cmdTongTien.ExecuteScalar();
                decimal tongTien = resultTongTien != DBNull.Value ? (decimal)resultTongTien : 0;

                // Lấy Điểm Tích Lũy của khách hàng
                string sqlDiem = "SELECT DiemTichLuy FROM KhachHang WHERE MaKhachHang = N'" + maKH + "'";
                SqlCommand cmdDiem = new SqlCommand(sqlDiem, DAO.conn);
                int diemTichLuy = Convert.ToInt32(cmdDiem.ExecuteScalar());

                // Nếu điểm tích lũy chia hết cho 10 -> giảm 20%
                if (diemTichLuy % 10 == 0 && diemTichLuy != 0)
                {
                    tongTien = tongTien * 0.8m; // Giảm 20%
                }

                txtTongTien.Text = tongTien.ToString("N0"); // Định dạng tiền VNĐ
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tính tổng tiền: " + ex.Message);
            }
            finally
            {
                DAO.Close(); // Đóng kết nối
            }
        }




        private void dgvChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoLuong.Focus();
            btnThemSP.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            if (dgvChiTietHD.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để sửa");
            }
            else
            {

                txtSoLuong.Text = dgvChiTietHD.CurrentRow.Cells[1].Value.ToString();
                txtMoTa.Text = dgvChiTietHD.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text.Trim();
            string maSP = txtMaSP.Text.Trim();
            string soLuong = txtSoLuong.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn và sản phẩm để sửa!");
                return;
            }

            if (string.IsNullOrEmpty(soLuong) || !int.TryParse(soLuong, out int parsedSoLuong))
            {
                MessageBox.Show("Số lượng không hợp lệ. Vui lòng nhập số nguyên!");
                return;
            }

            // Câu lệnh SQL để cập nhật SoLuong
            string sqlUpdate = "UPDATE ChiTietHoaDon " +
                               "SET SoLuong = @SoLuong, ThanhTien = @ThanhTien " +
                               "WHERE MaHoaDon = @MaHD AND MaSanPham = @MaSP";

            try
            {
                DAO.Connect();
                SqlCommand command = new SqlCommand(sqlUpdate, DAO.conn);
                command.Parameters.AddWithValue("@SoLuong", parsedSoLuong);
                command.Parameters.AddWithValue("@ThanhTien", parsedSoLuong * decimal.Parse(txtDonGia.Text.Trim())); // Tính lại ThanhTien
                command.Parameters.AddWithValue("@MaHD", maHD);
                command.Parameters.AddWithValue("@MaSP", maSP);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật số lượng thành công!");
                    LoadDataToChiTietHD(); // Cập nhật lại danh sách chi tiết hóa đơn
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chi tiết hóa đơn để sửa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi cập nhật số lượng: " + ex.Message);
            }
            finally
            {
                tinhTongTien();
                DAO.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maHD = txtMaHD.Text.Trim();
            string maSP = txtMaSP.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maHD) || string.IsNullOrEmpty(maSP))
            {
                MessageBox.Show("Vui lòng chọn hóa đơn và sản phẩm để xóa!");
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa chi tiết hóa đơn này không?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.No)
            {
                return;
            }

            // Câu lệnh SQL để xóa
            string sqlDelete = "DELETE FROM ChiTietHoaDon WHERE MaHoaDon = @MaHD AND MaSanPham = @MaSP";

            try
            {
                DAO.Connect();
                SqlCommand command = new SqlCommand(sqlDelete, DAO.conn);
                command.Parameters.AddWithValue("@MaHD", maHD);
                command.Parameters.AddWithValue("@MaSP", maSP);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Xóa chi tiết hóa đơn thành công!");
                    LoadDataToChiTietHD(); // Cập nhật lại danh sách chi tiết hóa đơn
                }
                else
                {
                    MessageBox.Show("Không tìm thấy chi tiết hóa đơn để xóa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xóa chi tiết hóa đơn: " + ex.Message);
            }
            finally
            {
                // Tính lại tổng tiền
                tinhTongTien();
                DAO.Close();
            }
        }
    }
}
