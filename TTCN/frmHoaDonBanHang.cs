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

        private void frmHoaDonBanHang_Load(object sender, EventArgs e)
        {
            LoadDataToSanPham();
            LoadDataToChiTietHD();
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
            string HienThiCTHDQuery = "select MaSanPham, SoLuong, DonGia, ThanhTien, MoTa from ChiTietHoaDon";
            DataTable dt = DAO.LoadDataToTable(HienThiCTHDQuery);
            dgvChiTietHD.DataSource = dt;
        }
        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //biến hóa đơn
            string MaNV = cbMaNV.Text.Trim();
            string MaKH = txtMaKH.Text.Trim();



            string MaHD = txtMaHD.Text.Trim();
            string MaSP = txtMaSP.Text.Trim();
            string SoLuong = txtSoLuong.Text.Trim();
            string DonGia = txtDonGia.Text.Trim(); 
            string MoTa = richTextBox1.Text.Trim(); 

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


            // Insert vào bảng HD trước 1 mã HD với tổng tiền = 0 để tránh conflict FK khi insert vào bảng ChiTietHoaDon bên dưới

            string sqlInsertHoaDon = "INSERT INTO HoaDon (MaHoaDon, NgayBan, MaNV, MaKH) VALUES (" +
                         "N'" + MaHD + "', " +
                         "GETDATE(), " + // Ngày bán hiện tại
                         "N'" + MaNV + "', " + // Mã nhân viên
                         "N'" + MaKH + "')"; // Mã khách hàng

            try
            {
                DAO.Connect();
                SqlCommand command = new SqlCommand(sqlInsertHoaDon, DAO.conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm hóa đơn: " + ex.Message);
            }
            finally
            {
                DAO.Close();
            }


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
                MessageBox.Show("Lưu thành công!");
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
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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
            txtMaHD.ReadOnly = true; // Đặt txtMaHD thành chỉ đọc
            txtMaHD.Text = GenerateNewInvoiceCode();
        }
    }
}
