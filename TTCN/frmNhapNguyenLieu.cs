﻿using System;
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
    public partial class frmNhapNguyenLieu : Form
    {
        public frmNhapNguyenLieu()
        {
            InitializeComponent();
        }


        private void traCứuKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMNguyenLieu fDMNL = new frmDMNguyenLieu();
            fDMNL.ShowDialog();
        }
        private void FillDataNhanVienToCombo()
        {
            string sql = "SELECT MaNhanVien FROM NhanVien";
            DAO.FillDataToCombo(cbMaNV, sql, "MaNhanVien", "MaNhanVien");
        }
        private void FillDataNCCToCombo()
        {
            string sql = "SELECT MaNhaCungCap FROM NhaCungCap";
            DAO.FillDataToCombo(cbMaNCC, sql, "MaNhaCungCap", "MaNhaCungCap"); 
        }
        private void LoadDataToNGlieu()
        {
            dgvNguyenLieu.DataSource = null;
            string query = "SELECT * FROM NguyenLieu";
            DataTable dt = DAO.LoadDataToTable(query);
            dgvNguyenLieu.DataSource = dt;
        }
        private void btnThemPN_Click(object sender, EventArgs e)
        {
            
            txtMaPN.Text = GenerateNewInvoiceCode();
            string maPN = txtMaPN.Text.Trim();
            string maNL = cbMaNL.Text.Trim();
            string maNV = cbMaNV.Text.Trim();
            string maNCC = cbMaNCC.Text.Trim();

            decimal tongTien = 0;
            LoadDataToNGlieu();
            //Xu li kiem tra
            if (cbMaNV.Text == "")
            {
                MessageBox.Show("Không để trống mã nhân viên");
                return;
            }
            if (cbMaNCC.Text == "")
            {
                MessageBox.Show("Không để trông mã nhà cung cấp");
                return;
            }
            

            //Các nút
            btnThemNL.Enabled = false;
            btnLuuPN.Enabled = true; // Bật nút Lưu Hóa Đơn, insert 1 đơn rỗng, trạng thái đang xử lí để có thể thêm nguyên liệu vào ChiTietPhieuNhap mà không bị conflict khóa ngoại
            string sqlInsertHoaDonNhap = "INSERT INTO PhieuNhap (MaPhieuNhap, MaNhanVien, MaNhaCungCap, ThoiGianHoanThanh, ThoiGianLapDon, TrangThaiDon, TongTien) VALUES (" +
                         "N'" + maPN + "', " +
                         "N'" + maNV + "', " +
                         "N'" + maNCC + "', " +
                         "GETDATE(), " +
                         "GETDATE(), " +
                         "N'Dang xu ly', " +
                         tongTien + ")";

            try
            {
                DAO.Connect();
                SqlCommand command = new SqlCommand(sqlInsertHoaDonNhap, DAO.conn);
                command.ExecuteNonQuery();
                MessageBox.Show("Thêm hóa đơn nhập thành công!");
                txtMaPN.Text = maPN; // Hiển thị mã hóa đơn vừa tạo
                LoadDataToNGlieu();

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
        private string GenerateNewInvoiceCode()
        {
            string newInvoiceCode = "PN0001"; // Mã mặc định nếu không có dữ liệu
            try
            {
                DAO.Connect(); // Đảm bảo kết nối mở
                string query = "SELECT TOP 1 MaPhieuNhap FROM PhieuNhap ORDER BY MaPhieuNhap DESC";
                DataTable dt = DAO.LoadDataToTable(query);

                if (dt.Rows.Count > 0)
                {
                    string lastInvoiceCode = dt.Rows[0]["MaPhieuNhap"].ToString();
                    int numberPart = int.Parse(lastInvoiceCode.Substring(2)); // Lấy phần số
                    newInvoiceCode = "PN" + (numberPart + 1).ToString("D4"); // Tăng số và định dạng
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
        
        private void LoadDataToChiTietHDNhap()
        {
            dgvChiTietHDNhap.DataSource = null;
            string maPN = txtMaPN.Text.Trim();

            if (string.IsNullOrEmpty(maPN))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn để hiển thị chi tiết!");
                return;
            }

            string HienThiCTHDNhapQuery = "SELECT * FROM ChiTietPhieuNhap " +
                                      "WHERE MaPhieuNhap = @MaPN";

            try
            {
                DAO.Connect();
                SqlCommand command = new SqlCommand(HienThiCTHDNhapQuery, DAO.conn);
                command.Parameters.AddWithValue("@MaPN", maPN);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvChiTietHDNhap.DataSource = dt;
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

        private void frmNhapNguyenLieu_Load(object sender, EventArgs e)
        {
            DAO.Connect();
            FillDataNhanVienToCombo();
            FillDataNCCToCombo();
            dgvChiTietHDNhap.DataSource = null;
            dgvNguyenLieu.DataSource = null;
            btnThemNL.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuuPN.Enabled = false;
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtSoLuong.Focus();
                DataGridViewRow row = dgvNguyenLieu.Rows[e.RowIndex];

                cbMaNL.Text = row.Cells["MaNguyenLieu"].Value?.ToString(); // Nếu cbMaNL chứa danh sách Mã NL
                txtTenNL.Text = row.Cells["TenNguyenLieu"].Value?.ToString(); // Gán tên nguyên liệu nếu cần
                txtDonGia.Text = row.Cells["GiaNhap"].Value?.ToString();

                // Tính thành tiền
                if (decimal.TryParse(row.Cells["GiaNhap"].Value?.ToString(), out decimal donGia) &&
                    int.TryParse(row.Cells["SoLuong"].Value?.ToString(), out int soLuong))
                {
                    txtThanhTien.Text = (donGia * soLuong).ToString("N0");
                }
                else
                {
                    txtThanhTien.Text = "";
                }

                btnThemNL.Enabled = true;
            }
        }

        private void btnThemNL_Click(object sender, EventArgs e)
        {
            string maPN = txtMaPN.Text.Trim();
            string maNL = cbMaNL.Text.Trim();
            string soLuong = txtSoLuong.Text.Trim();
            string donGia = txtDonGia.Text.Trim();

            if (string.IsNullOrEmpty(soLuong))
            {
                MessageBox.Show("Không được bỏ trống số lượng");
                return;
            }

            if (string.IsNullOrEmpty(donGia))
            {
                MessageBox.Show("Không được bỏ trống đơn giá");
                return;
            }

            if (!int.TryParse(soLuong, out int parsedSL) || !decimal.TryParse(donGia, out decimal parsedGia))
            {
                MessageBox.Show("Số lượng hoặc đơn giá không hợp lệ.");
                return;
            }

            decimal thanhTien = parsedSL * parsedGia;

            string sql = "INSERT INTO ChiTietPhieuNhap (MaPhieuNhap, MaNguyenLieu, SoLuong, ThanhTien) " +
                         "VALUES (@MaPN, @MaNL, @SoLuong, @ThanhTien)";

            try
            {
                DAO.Connect();
                SqlCommand cmd = new SqlCommand(sql, DAO.conn);
                cmd.Parameters.AddWithValue("@MaPN", maPN);
                cmd.Parameters.AddWithValue("@MaNL", maNL);
                cmd.Parameters.AddWithValue("@SoLuong", parsedSL);
                cmd.Parameters.AddWithValue("@DonGia", parsedGia);
                cmd.Parameters.AddWithValue("@ThanhTien", thanhTien);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Đã thêm nguyên liệu vào phiếu nhập!");
                LoadDataToChiTietHDNhap();
                LoadDataToNGlieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
            finally
            {
                DAO.Close();
            }

            TinhTongTien(); // Cập nhật tổng
        }
        private void TinhTongTien()
        {
            string maPN = txtMaPN.Text.Trim();
            string sql = "SELECT SUM(ThanhTien) FROM ChiTietPhieuNhap WHERE MaPhieuNhap = @MaPN";

            try
            {
                DAO.Connect();
                SqlCommand cmd = new SqlCommand(sql, DAO.conn);
                cmd.Parameters.AddWithValue("@MaPN", maPN);
                object result = cmd.ExecuteScalar();
                decimal tongTien = result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                txtTongTien.Text = tongTien.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính tổng tiền: " + ex.Message);
            }
            finally
            {
                DAO.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maPN = txtMaPN.Text.Trim();
            string maNL = cbMaNL.Text.Trim();
            string soLuong = txtSoLuong.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maPN) || string.IsNullOrEmpty(maNL))
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
            string sqlUpdate = "UPDATE ChiTietPhieuNhap " +
                               "SET SoLuong = @SoLuong, ThanhTien = @ThanhTien " +
                               "WHERE MaPhieuNhap = @MaPN AND MaNguyenLieu = @MaNL";

            try
            {
                DAO.Connect();
                SqlCommand command = new SqlCommand(sqlUpdate, DAO.conn);
                command.Parameters.AddWithValue("@SoLuong", parsedSoLuong);
                command.Parameters.AddWithValue("@ThanhTien", parsedSoLuong * decimal.Parse(txtDonGia.Text.Trim())); // Tính lại ThanhTien
                command.Parameters.AddWithValue("@MaPN", maPN);
                command.Parameters.AddWithValue("@MaNL", maNL);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật số lượng thành công!");
                    LoadDataToChiTietHDNhap(); // Cập nhật lại danh sách chi tiết hóa đơn
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuPN_Click(object sender, EventArgs e)
        {
            string maPN = txtMaPN.Text.Trim();
            string tongTienText = txtTongTien.Text.Trim();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(maPN))
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
            string sqlUpdate = "UPDATE PhieuNhap SET TongTien = @TongTien, TrangThaiDon = @TrangThaiDon WHERE MaPhieuNhap = @MaPN";

            try
            {
                DAO.Connect();
                SqlCommand command = new SqlCommand(sqlUpdate, DAO.conn);
                command.Parameters.AddWithValue("@TongTien", tongTien);
                command.Parameters.AddWithValue("@MaPN", maPN);
                command.Parameters.AddWithValue("@TrangThaiDon", "Hoan thanh"); // Cập nhật trạng thái đơn
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật tổng tiền thành công!");
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nhập với mã: " + maPN);
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

        private void dgvChiTietHDNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSoLuong.Focus();
            btnThemNL.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            if (dgvChiTietHDNhap.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để sửa");
            }
            else
            {

                txtSoLuong.Text = dgvChiTietHDNhap.CurrentRow.Cells[1].Value.ToString();
            }
        }
        private void tinhTongTien()
        {
            string MaPN = txtMaPN.Text.Trim();
            try
            {
                DAO.Connect(); // Đảm bảo kết nối mở
                               // Câu lệnh SQL để tính tổng tiền}
                string sqlTongTien = "SELECT SUM(ThanhTien) FROM ChiTietPhieuNhap WHERE MaPhieuNhap = N'" + MaPN + "'";


                // Tính tổng tiền
                SqlCommand cmdTongTien = new SqlCommand(sqlTongTien, DAO.conn);
                object resultTongTien = cmdTongTien.ExecuteScalar();
                decimal tongTien = resultTongTien != DBNull.Value ? (decimal)resultTongTien : 0;
                txtTongTien.Text = tongTien.ToString("N0"); // Định dạng số tiền

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
    }
}
