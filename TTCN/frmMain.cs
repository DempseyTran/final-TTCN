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

        }

        private void ddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            frmMain.ShowDialog();
        }

        private void danhMụcNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMNhanVien frmNhanVien = new frmDMNhanVien();
            frmNhanVien.ShowDialog();
        }

        private void danhMụcNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMNhaCungCap frmDMNCC= new frmDMNhaCungCap();
            frmDMNCC.ShowDialog();
        }

        private void danhMụcNguyênLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDMNguyenLieu frmDMNL = new frmDMNguyenLieu();
            frmDMNL.ShowDialog();
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
    }

}
