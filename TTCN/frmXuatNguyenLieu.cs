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
    public partial class frmXuatNguyenLieu : Form
    {
        public frmXuatNguyenLieu()
        {
            InitializeComponent();
        }
        private void LoadData()
        {
            string sql = "SELECT * FROM ChiTietPhieuXuat";
            DataTable dt = DAO.LoadDataToTable(sql);
            dgvPhieuXuatKho.DataSource = dt;
        }
        private void FrmPhieuXuatKho_Load(object sender, EventArgs e)
        {
            DAO.Connect();
            LoadData();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
