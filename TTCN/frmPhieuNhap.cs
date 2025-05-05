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
        }
    }
}
