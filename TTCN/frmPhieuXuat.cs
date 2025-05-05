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
        }
        
    }
}
