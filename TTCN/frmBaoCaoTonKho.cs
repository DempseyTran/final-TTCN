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
    public partial class frmBaoCaoTonKho : Form
    {
        public frmBaoCaoTonKho()
        {
            InitializeComponent();
        }

        private void frmBaoCaoTonKho_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
            LoadBaoCaoTonKho(dtpFrom.Value, dtpTo.Value);
        }
        private void LoadBaoCaoTonKho(DateTime tuNgay, DateTime denNgay)
        {
            DAO.Connect();

            string query = @"
        SELECT 
            nl.MaNguyenLieu,
            nl.TenNguyenLieu,
            nl.DonViTinh,
            ISNULL((SELECT SUM(SoLuong) FROM ChiTietPhieuNhap ctpn 
                    INNER JOIN PhieuNhap pn ON ctpn.MaPhieuNhap = pn.MaPhieuNhap
                    WHERE ctpn.MaNguyenLieu = nl.MaNguyenLieu 
                      AND pn.ThoiGianHoanThanh BETWEEN @TuNgay AND @DenNgay), 0) AS SoLuongNhap,
            ISNULL((SELECT SUM(SoLuong) FROM ChiTietPhieuXuat ctpx 
                    INNER JOIN PhieuXuat px ON ctpx.MaPhieuXuat = px.MaPhieuXuat
                    WHERE ctpx.MaNguyenLieu = nl.MaNguyenLieu 
                      AND px.ThoiGianHoanThanh BETWEEN @TuNgay AND @DenNgay), 0) AS SoLuongXuat,
            nl.SoLuong AS SoLuongTon
        FROM NguyenLieu nl";

            using (SqlCommand cmd = new SqlCommand(query, DAO.conn))
            {
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvTonKho.DataSource = dt;
            }

            DAO.Close();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            LoadBaoCaoTonKho(dtpFrom.Value, dtpTo.Value);
        }

        private void btnHoanTac_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;
            LoadBaoCaoTonKho(dtpFrom.Value, dtpTo.Value);
        }
    }
}
