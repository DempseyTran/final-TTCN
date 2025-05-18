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
        public static class Session
        {
            public static string TenDangNhap;
            public static string MaNhanVien;
            public static string ChucVu; // VD: "Quản lý", "Kế toán", "Kho", "Nhân viên"
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            DAO.Connect();
            string chucVu = Session.ChucVu;

            switch (chucVu)
            {
                case "Quản lý":
                    // Không giới hạn quyền
                    break;

                case "Kho":
                    // Chỉ được xem phiếu xuất
                    báoCáoDoanhThuToolStripMenuItem.Visible = false;
                    toolStripMenuItem4.Visible = false;
                    toolStripMenuItem10.Visible = false;
                    //nhậpKhoNguyênLiệuToolStripMenuItem.Visible = true;
                    //xuấtKhoNguyênLiệuToolStripMenuItem.Visible = true;
                    báoCáoTồnKhoToolStripMenuItem.Visible = true;
                    toolStripMenuItem11.Visible = true;
                    // Ẩn các chức năng khác
                    break;

                case "Kế toán":
                    // Chỉ được xem báo cáo
                    báoCáoToolStripMenuItem.Visible = true;
                    //nhậpKhoNguyênLiệuToolStripMenuItem.Visible = true;
                    //xuấtKhoNguyênLiệuToolStripMenuItem.Visible = true;
                    toolStripMenuItem9.Visible = true;
                    navDMNL.Visible = true;
                    navDMNCC.Visible = false;
                    navDMSP.Visible = false;
                    navDMNV.Visible = false;
                    navDMKH.Visible = false;

                    // Cho hiện báo cáo (nếu có)
                    break;

                case "Nhân viên":
                    // Chỉ xem hóa đơn hoặc giao diện đơn giản
                    //nhậpKhoNguyênLiệuToolStripMenuItem.Visible = false;
                    //xuấtKhoNguyênLiệuToolStripMenuItem.Visible = true;

                    báoCáoToolStripMenuItem.Visible = false;
                    toolStripMenuItem4.Visible = false;
                    toolStripMenuItem11.Visible = false;
                    // Ẩn thêm menu hệ thống nếu cần
                    // hệThốngToolStripMenuItem.Visible = false;
                    break;

                default:
                    MessageBox.Show("Không xác định chức vụ, sẽ đóng chương trình.");
                    this.Close();
                    break;
            }
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
            this.Hide();
            frmDangNhap frmDangNhap = new frmDangNhap();
            frmDangNhap.Show();
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

        private void hóaĐơnXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPhieuXuat frmphieuXuat = new frmPhieuXuat();
            frmphieuXuat.ShowDialog();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            frmPhieuNhap frmphieuNhap = new frmPhieuNhap();
            frmphieuNhap.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            frmHoaDonBanHang frmHDBH = new frmHoaDonBanHang();
            frmHDBH.ShowDialog();
        }

        private void báoCáoDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoDoanhThu frmBCDT = new frmBaoCaoDoanhThu();
            frmBCDT.ShowDialog();
        }

        private void danhMụcKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDMKhachHang frmDMKhachHang = new FrmDMKhachHang();
            frmDMKhachHang.ShowDialog();
        }

        private void báoCáoTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoTonKho frmBC = new frmBaoCaoTonKho();
            frmBC.ShowDialog();
        }

       
    }

}
