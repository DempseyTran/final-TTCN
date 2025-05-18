using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
//using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;


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

            string HienThiCTHDQuery = @"SELECT c.MaSanPham, s.TenSanPham, c.SoLuong, c.DonGia, c.ThanhTien, c.MoTa 
                     FROM ChiTietHoaDon c 
                     INNER JOIN SanPham s ON c.MaSanPham = s.MaSanPham 
                     WHERE c.MaHoaDon = @MaHD";

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

            // Kiểm tra điểm tích lũy của khách hàng
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
                    giamGia = 0.2m; // kiểu decimal, giảm 20%
                    txtGiamGia.Text = (giamGia * 100).ToString("0") + "%";

                    //Update lại giảm giá = 0.2m trong cơ sở dữ liệu
                    try
                    {
                        string sqlUpdateGiamGia = "UPDATE HoaDon SET GiamGia = @GiamGia WHERE MaHoaDon = @MaHD";
                        SqlCommand commandGiamGia = new SqlCommand(sqlUpdateGiamGia, DAO.conn);
                        commandGiamGia.Parameters.AddWithValue("@GiamGia", giamGia);
                        commandGiamGia.Parameters.AddWithValue("@MaHD", maHD);
                        commandGiamGia.ExecuteNonQuery();
                        MessageBox.Show("Cập nhật giảm giá thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi cập nhật giảm giá: " + ex.Message);
                    }
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

                txtSoLuong.Text = dgvChiTietHD.CurrentRow.Cells[2].Value.ToString();
                txtMoTa.Text = dgvChiTietHD.CurrentRow.Cells[5].Value.ToString();
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

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy thông tin
                string maKhach = txtMaKH.Text;
                DateTime ngayBan = dtpNgayBan.Value;
                string soHD = txtMaHD.Text;

                // 2. Đường dẫn lưu
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string pdfPath = Path.Combine(folder, $"HD_{soHD}.pdf");

                // 3. Font hỗ trợ tiếng Việt
                BaseFont bf = BaseFont.CreateFont(@"c:\windows\fonts\times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                iTextSharp.text.Font titleFont = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font boldFont = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.BOLD);

                // 4. Tạo PDF
                Document doc = new Document(PageSize.A4, 36, 36, 36, 36);
                PdfWriter.GetInstance(doc, new FileStream(pdfPath, FileMode.Create));
                doc.Open();

                // 5. Tiêu đề
                Paragraph title = new Paragraph("HÓA ĐƠN BÁN HÀNG", titleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20
                };
                doc.Add(title);

                // 6. Thông tin chung
                PdfPTable infoTable = new PdfPTable(2)
                {
                    WidthPercentage = 80f,
                    SpacingAfter = 20f
                };
                infoTable.SetWidths(new float[] { 1f, 2f });
                infoTable.AddCell(new PdfPCell(new Phrase("Số hóa đơn:", normalFont)) { Border = Rectangle.NO_BORDER });
                infoTable.AddCell(new PdfPCell(new Phrase(soHD, normalFont)) { Border = Rectangle.NO_BORDER });
                infoTable.AddCell(new PdfPCell(new Phrase("Mã khách hàng:", normalFont)) { Border = Rectangle.NO_BORDER });
                infoTable.AddCell(new PdfPCell(new Phrase(maKhach, normalFont)) { Border = Rectangle.NO_BORDER });
                infoTable.AddCell(new PdfPCell(new Phrase("Ngày bán:", normalFont)) { Border = Rectangle.NO_BORDER });
                infoTable.AddCell(new PdfPCell(new Phrase(ngayBan.ToString("dd/MM/yyyy HH:mm"), normalFont)) { Border = Rectangle.NO_BORDER });
                doc.Add(infoTable);

                // 7. Bảng sản phẩm
                PdfPTable tbl = new PdfPTable(6)
                {
                    WidthPercentage = 100f,
                    SpacingBefore = 10f
                };
                tbl.SetWidths(new float[] { 0.7f, 1.5f, 3f, 1f, 1.5f, 2f });

                string[] headers = { "STT", "Mã SP", "Tên SP", "SL", "Đơn giá", "Thành tiền" };
                foreach (var h in headers)
                {
                    var cell = new PdfPCell(new Phrase(h, boldFont))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        BackgroundColor = BaseColor.LIGHT_GRAY,
                        Padding = 5
                    };
                    tbl.AddCell(cell);
                }

                // Duyệt DGV
                //Lấy tổng tiền và giảm giá từ cơ sở dữ liệu
                
                int stt = 1;
                foreach (DataGridViewRow row in dgvChiTietHD.Rows)
                {
                    if (row.IsNewRow) continue;

                    string maSP = row.Cells["MaSanPham"].Value?.ToString();
                    string tenSP = row.Cells["TenSanPham"].Value?.ToString() ?? "";
                    int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value);
                    decimal thanhTien = soLuong * donGia;
                
                    tbl.AddCell(new PdfPCell(new Phrase(stt.ToString(), normalFont)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    tbl.AddCell(new PdfPCell(new Phrase(maSP, normalFont)) { Padding = 5 });
                    tbl.AddCell(new PdfPCell(new Phrase(tenSP, normalFont)));
                    tbl.AddCell(new PdfPCell(new Phrase(soLuong.ToString(), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    tbl.AddCell(new PdfPCell(new Phrase(donGia.ToString("#,##0"), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    tbl.AddCell(new PdfPCell(new Phrase(thanhTien.ToString("#,##0"), normalFont)) { HorizontalAlignment = Element.ALIGN_RIGHT });

                    stt++;
                }

                // Tính giảm giá & tổng tiền sau giảm

                decimal tongTienSauGiam = decimal.Parse(txtTongTien.Text);
                string giamGiaText = txtGiamGia.Text.Replace("%", "").Trim();
                decimal giamGia = decimal.Parse(giamGiaText) / 100;
                

                // Thêm dòng tổng cộng
                PdfPCell emptyCell = new PdfPCell(new Phrase("")) { Border = Rectangle.NO_BORDER };
                for (int i = 0; i < 4; i++) tbl.AddCell(emptyCell);

                tbl.AddCell(new PdfPCell(new Phrase("TỔNG CỘNG", boldFont))
                {
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    Border = Rectangle.NO_BORDER
                });
                tbl.AddCell(new PdfPCell(new Phrase(tongTienSauGiam.ToString("#,##0"), boldFont))
                {
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    BackgroundColor = BaseColor.YELLOW
                });

                // Dòng Giảm giá
                for (int i = 0; i < 4; i++) tbl.AddCell(emptyCell);
                tbl.AddCell(new PdfPCell(new Phrase("GIẢM GIÁ (%)", boldFont))
                {
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    Border = Rectangle.NO_BORDER
                });
                tbl.AddCell(new PdfPCell(new Phrase((giamGia * 100).ToString("0") + "%", boldFont))
                {
                    HorizontalAlignment = Element.ALIGN_RIGHT
                });

                // Dòng Tổng tiền sau giảm
                for (int i = 0; i < 4; i++) tbl.AddCell(emptyCell);
                tbl.AddCell(new PdfPCell(new Phrase("TỔNG TIỀN", boldFont))
                {
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    Border = Rectangle.NO_BORDER
                });
                tbl.AddCell(new PdfPCell(new Phrase(tongTienSauGiam.ToString("#,##0"), boldFont))
                {
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    BackgroundColor = BaseColor.YELLOW
                });

                doc.Add(tbl);

                // Ký tên
                Paragraph footer = new Paragraph("\nNgười lập hóa đơn\n\n\n(Ký tên)", normalFont)
                {
                    Alignment = Element.ALIGN_RIGHT,
                    SpacingBefore = 30
                };
                doc.Add(footer);

                // Kết thúc
                doc.Close();
                Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo PDF:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
