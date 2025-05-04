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
        private void FillDataNgLieuToCombo()
        {
            string sql = "SELECT MaNguyenLieu FROM NguyenLieu";
            DAO.FillDataToCombo(cbMaNL, sql, "MaNhanVien", "MaNhanVien");
        }
        private void btnThemPN_Click(object sender, EventArgs e)
        {
            
            txtMaPN.Text = GenerateNewInvoiceCode();
            string maPN = txtMaPN.Text.Trim();
            string maNL = cbMaNL.Text.Trim();
            string maNV = cbMaNV.Text.Trim();
            decimal tongTien = 0;


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
                    string lastInvoiceCode = dt.Rows[0]["MaHoaDon"].ToString();
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
        private void LoadDataToNGlieu()
        {
            dgvNguyenLieu.DataSource = null;
            string HienThiSanPhamQuery = "select * from SanPham";
            DataTable dt = DAO.LoadDataToTable(HienThiSanPhamQuery);
            dgvNguyenLieu.DataSource = dt;
        }
        private void LoadDataToChiTietHD()
        {
            dgvChiTietHDNhap.DataSource = null;
            string maPN = txtMaPN.Text.Trim();

            if (string.IsNullOrEmpty(maPN))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn để hiển thị chi tiết!");
                return;
            }

            string HienThiCTHDQuery = "SELECT * FROM ChiTietPhieuNhap " +
                                      "WHERE MaPhieuNhap = @MaPN";

            try
            {
                DAO.Connect();
                SqlCommand command = new SqlCommand(HienThiCTHDQuery, DAO.conn);
                command.Parameters.AddWithValue("@MaHD", maPN);

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
            FillDataNhanVienToCombo();
            FillDataNgLieuToCombo();
            dgvChiTietHDNhap.DataSource = null;
            dgvNguyenLieu.DataSource = null;
            btnThemNL.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuuPN.Enabled = false;
        }
    }
}
