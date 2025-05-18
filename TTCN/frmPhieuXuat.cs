using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTCN
{
    public partial class frmPhieuXuat : Form
    {
        public frmPhieuXuat()
        {
            InitializeComponent();
        }
        private void LoadDataPhieuXuat()
        {
            DAO.Connect();
            string sql = "SELECT * FROM PhieuXuat";
            dgvPhieuXuat.DataSource = DAO.LoadDataToTable(sql);
            DAO.Close();
        }
        private void frmPhieuXuat_Load(object sender, EventArgs e)
        {
            LoadDataPhieuXuat();
            //fill du lieu cho combobox
            string sql = "SELECT * FROM NhanVien";
            DAO.FillDataToCombo(cbMaNV, sql, "MaNhanVien", "TenNhanVien");
        }

        private void dgvPhieuXuat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //hiển thị thông tin bảng phiếu xuất lên các txtbox
            txtMaPX.Text = dgvPhieuXuat.CurrentRow.Cells["MaPhieuXuat"].Value.ToString();
            txtMaNV.Text = dgvPhieuXuat.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            dtpTgDuyet.Value = DateTime.Parse(dgvPhieuXuat.CurrentRow.Cells["ThoiGianHoanThanh"].Value.ToString());
            dtpTgXuat.Value = DateTime.Parse(dgvPhieuXuat.CurrentRow.Cells["ThoiGianLapDon"].Value.ToString());
            txtTrangThaiDon.Text = dgvPhieuXuat.CurrentRow.Cells["TrangThaiDon"].Value.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //lấy thông tin nhân viên từ combobox
            string maNV = cbMaNV.SelectedValue.ToString();
            //tra cứu thông tin nhân viên
            string sql = $"SELECT * FROM NhanVien WHERE MaNhanVien = '{maNV}'";
        }
    }
}
