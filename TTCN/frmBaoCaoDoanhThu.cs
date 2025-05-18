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
    public partial class frmBaoCaoDoanhThu : Form
    {
        public frmBaoCaoDoanhThu()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       
        private void loadDataHoaDonToGridView()
        {
            string HienThiBCDoanhThuQuery = "SELECT * FROM HoaDon ";

            try
            {
                DAO.Connect();
                SqlCommand command = new SqlCommand(HienThiBCDoanhThuQuery, DAO.conn);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgvBCDT.DataSource = dt;
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
        private void frmBaoCaoDoanhThu_Load(object sender, EventArgs e)
        {
            loadDataHoaDonToGridView();
        }

        private void btnXemCTHD_Click(object sender, EventArgs e)
        {
            //hiển thị lên dataGridView chi tiết hóa đơn có mã = txtMaHD
            string maHD = txtMaHD.Text;
            string HienThiCTHDQuery = "SELECT * FROM ChiTietHoaDon WHERE MaHoaDon = @maHD";
            try
            {
                DAO.Connect();
                SqlCommand command = new SqlCommand(HienThiCTHDQuery, DAO.conn);
                command.Parameters.AddWithValue("@maHD", maHD);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvBCDT.DataSource = dt;
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

        private void button5_Click(object sender, EventArgs e)
        {
            dgvBCDT.DataSource = null;
            loadDataHoaDonToGridView();
        }

        private void dgvBCDT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //hiển thị mã hóa đơn ở dòng được chọn lên txtMaHD
            if (dgvBCDT.SelectedCells.Count > 0)
            {
                int rowIndex = dgvBCDT.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvBCDT.Rows[rowIndex];
                string maHD = Convert.ToString(selectedRow.Cells["MaHoaDon"].Value);
                txtMaHD.Text = maHD;
            }
        }
    }
}
