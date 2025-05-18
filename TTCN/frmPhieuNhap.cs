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
    public partial class frmPhieuNhap : Form
    {
        public frmPhieuNhap()
        {
            InitializeComponent();
        }
        private void LoadDataPhieuNhap()
        {
            DAO.Connect();
            string sql = "SELECT * FROM PhieuNhap";
            dgvPhieuNhap.DataSource = DAO.LoadDataToTable(sql);
            DAO.Close();
        }
        private void frmPhieuNhap_Load(object sender, EventArgs e)
        {
            LoadDataPhieuNhap();
            FillDataToAllComBo();
        }

        private void chiTiếtĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //lấy mã phiếu nhập từ dgvPhieuNhap
            string maPhieuNhap = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            //hiển thị chi tiết nhập ở dgvPhieuNhap luôn
            string sql = "SELECT * FROM ChiTietPhieuNhap WHERE maphieunhap = '" + maPhieuNhap + "'";
            dgvPhieuNhap.DataSource = DAO.LoadDataToTable(sql);
            



        }

        private void dgvPhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Hiển thị thông tin phiếu nhập lên các textbox
            txtMaPN.Text = dgvPhieuNhap.CurrentRow.Cells[0].Value.ToString();
            txtMaNV.Text = dgvPhieuNhap.CurrentRow.Cells[2].Value.ToString();
            txtMaNCC.Text = dgvPhieuNhap.CurrentRow.Cells[1].Value.ToString();
            txtTgXuat.Text = dgvPhieuNhap.CurrentRow.Cells[3].Value.ToString();
            txtTgDuyet.Text = dgvPhieuNhap.CurrentRow.Cells[4].Value.ToString();
            txtTrangThaiDon.Text = dgvPhieuNhap.CurrentRow.Cells[5].Value.ToString();
            txtTongTien.Text = dgvPhieuNhap.CurrentRow.Cells[6].Value.ToString();
            //

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //lấy giá trị từ 2 ô tra cứu cbTraCuuMaNCC và cbTraCuuMaNV
            string maNCC = cbTraCuuMaNCC.Text;
            string maNV = cbTraCuuMaNV.Text;

            //tra cứu phiếu nhập theo mã NCC và mã NV
            string sqlTraCuu = "SELECT * FROM PhieuNhap WHERE manhacungcap = '" + maNCC + "' AND manhanvien = '" + maNV + "'";
            try
            {
                DAO.Connect();
                SqlCommand command = new SqlCommand(sqlTraCuu, DAO.conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvPhieuNhap.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tra cứu dữ liệu: " + ex.Message);
            }
            finally
            {
                DAO.Close();
            }


        }
        private void FillDataToAllComBo()
        {
            //Lấy dữ liệu từ bảng NhaCungCap
            string sqlNCC = "SELECT * FROM NhaCungCap";
            DAO.FillDataToCombo(cbTraCuuMaNCC, sqlNCC, "manhacungcap", "manhacungcap");
            //Lấy dữ liệu từ bảng NhanVien
            string sqlNV = "SELECT * FROM NhanVien";
            DAO.FillDataToCombo(cbTraCuuMaNV, sqlNV, "manhanvien", "manhanvien");

        }
        private void resetvalues() {
            cbTraCuuMaNCC.Text = "";
            cbTraCuuMaNV.Text = "";
            txtMaPN.Text = "";
            txtMaNV.Text = "";
            txtMaNCC.Text = "";
            txtTgXuat.Text = "";
            txtTgDuyet.Text = "";
            txtTrangThaiDon.Text = "";
            txtTongTien.Text = "";
        }
        private void làmMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetvalues();
            LoadDataPhieuNhap();
            
        }
    }
}
