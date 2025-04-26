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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DAO.Connect();
        }

        private void ddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();
        }

        private void nhậpKhoNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuNhap frmphieuNhap= new frmPhieuNhap();
            frmphieuNhap.ShowDialog();
        }

        private void xuấtKhoNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuXuat frmphieuXuat = new frmPhieuXuat();
            frmphieuXuat.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void navDMNV_Click(object sender, EventArgs e)
        {
            frmDMNhanVien frmDMNhanVien = new frmDMNhanVien();
            frmDMNhanVien.ShowDialog();
        }

        private void navDMNCC_Click(object sender, EventArgs e)
        {
            frmDMNhaCungCap frmDMNCC = new frmDMNhaCungCap();
            frmDMNCC.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void navDMNL_Click(object sender, EventArgs e)
        {
            frmDMNguyenLieu frmDMNL = new frmDMNguyenLieu();
            frmDMNL.ShowDialog();
        }

        private void navDMSP_Click(object sender, EventArgs e)
        {
            frmDMSanPham frmDMSP = new frmDMSanPham();
            frmDMSP.ShowDialog();
        }
    }

}
