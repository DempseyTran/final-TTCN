namespace TTCN
{
    partial class frmDMNhanVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMNhanVien));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvNhanVien = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.thêmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.lbChucVuFilTer = new System.Windows.Forms.Label();
            this.cbChucVuFilter = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbThongTinChucVu = new System.Windows.Forms.Label();
            this.lbMaNhanVien = new System.Windows.Forms.Label();
            this.lbDiaChi = new System.Windows.Forms.Label();
            this.lbTenNhanVien = new System.Windows.Forms.Label();
            this.lbNgaySinh = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mskNgaysinh = new System.Windows.Forms.MaskedTextBox();
            this.mskDienthoai = new System.Windows.Forms.MaskedTextBox();
            this.txtChucVu = new System.Windows.Forms.TextBox();
            this.lbChucVu = new System.Windows.Forms.Label();
            this.rabtnNu = new System.Windows.Forms.RadioButton();
            this.rabtnNam = new System.Windows.Forms.RadioButton();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtTenNhanVien = new System.Windows.Forms.TextBox();
            this.txtMaNhanVien = new System.Windows.Forms.TextBox();
            this.lbGioiTinh = new System.Windows.Forms.Label();
            this.lbSoDienThoai = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtTraCuuBox = new System.Windows.Forms.TextBox();
            this.lbTraCuu = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.BtnThem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSua = new System.Windows.Forms.ToolStripMenuItem();
            this.btnXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLuu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHuyBo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTraCuu = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvNhanVien);
            this.panel1.Location = new System.Drawing.Point(25, 83);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 328);
            this.panel1.TabIndex = 0;
            // 
            // dgvNhanVien
            // 
            this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhanVien.Location = new System.Drawing.Point(3, 0);
            this.dgvNhanVien.Name = "dgvNhanVien";
            this.dgvNhanVien.RowHeadersWidth = 51;
            this.dgvNhanVien.RowTemplate.Height = 24;
            this.dgvNhanVien.Size = new System.Drawing.Size(463, 328);
            this.dgvNhanVien.TabIndex = 0;
            this.dgvNhanVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNhanVien_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 28);
            // 
            // thêmToolStripMenuItem
            // 
            this.thêmToolStripMenuItem.Name = "thêmToolStripMenuItem";
            this.thêmToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.thêmToolStripMenuItem.Text = "Thêm";
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // lbChucVuFilTer
            // 
            this.lbChucVuFilTer.AutoSize = true;
            this.lbChucVuFilTer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChucVuFilTer.Location = new System.Drawing.Point(24, 44);
            this.lbChucVuFilTer.Name = "lbChucVuFilTer";
            this.lbChucVuFilTer.Size = new System.Drawing.Size(76, 22);
            this.lbChucVuFilTer.TabIndex = 4;
            this.lbChucVuFilTer.Text = "Chức vụ";
            // 
            // cbChucVuFilter
            // 
            this.cbChucVuFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbChucVuFilter.FormattingEnabled = true;
            this.cbChucVuFilter.Location = new System.Drawing.Point(197, 46);
            this.cbChucVuFilter.Name = "cbChucVuFilter";
            this.cbChucVuFilter.Size = new System.Drawing.Size(294, 28);
            this.cbChucVuFilter.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.lbThongTinChucVu);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(276, 32);
            this.panel3.TabIndex = 2;
            // 
            // lbThongTinChucVu
            // 
            this.lbThongTinChucVu.AutoSize = true;
            this.lbThongTinChucVu.BackColor = System.Drawing.SystemColors.Window;
            this.lbThongTinChucVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThongTinChucVu.Location = new System.Drawing.Point(3, 7);
            this.lbThongTinChucVu.Name = "lbThongTinChucVu";
            this.lbThongTinChucVu.Size = new System.Drawing.Size(153, 22);
            this.lbThongTinChucVu.TabIndex = 0;
            this.lbThongTinChucVu.Text = "Thông tin chức vụ";
            // 
            // lbMaNhanVien
            // 
            this.lbMaNhanVien.AutoSize = true;
            this.lbMaNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaNhanVien.Location = new System.Drawing.Point(14, 57);
            this.lbMaNhanVien.Name = "lbMaNhanVien";
            this.lbMaNhanVien.Size = new System.Drawing.Size(95, 18);
            this.lbMaNhanVien.TabIndex = 6;
            this.lbMaNhanVien.Text = "Mã nhân viên";
            // 
            // lbDiaChi
            // 
            this.lbDiaChi.AutoSize = true;
            this.lbDiaChi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDiaChi.Location = new System.Drawing.Point(14, 153);
            this.lbDiaChi.Name = "lbDiaChi";
            this.lbDiaChi.Size = new System.Drawing.Size(53, 18);
            this.lbDiaChi.TabIndex = 8;
            this.lbDiaChi.Text = "Địa chỉ";
            // 
            // lbTenNhanVien
            // 
            this.lbTenNhanVien.AutoSize = true;
            this.lbTenNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTenNhanVien.Location = new System.Drawing.Point(14, 89);
            this.lbTenNhanVien.Name = "lbTenNhanVien";
            this.lbTenNhanVien.Size = new System.Drawing.Size(99, 18);
            this.lbTenNhanVien.TabIndex = 9;
            this.lbTenNhanVien.Text = "Tên nhân viên";
            // 
            // lbNgaySinh
            // 
            this.lbNgaySinh.AutoSize = true;
            this.lbNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgaySinh.Location = new System.Drawing.Point(14, 217);
            this.lbNgaySinh.Name = "lbNgaySinh";
            this.lbNgaySinh.Size = new System.Drawing.Size(73, 18);
            this.lbNgaySinh.TabIndex = 10;
            this.lbNgaySinh.Text = "Ngày sinh";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.mskNgaysinh);
            this.panel2.Controls.Add(this.mskDienthoai);
            this.panel2.Controls.Add(this.txtChucVu);
            this.panel2.Controls.Add(this.lbChucVu);
            this.panel2.Controls.Add(this.rabtnNu);
            this.panel2.Controls.Add(this.rabtnNam);
            this.panel2.Controls.Add(this.txtDiaChi);
            this.panel2.Controls.Add(this.txtTenNhanVien);
            this.panel2.Controls.Add(this.txtMaNhanVien);
            this.panel2.Controls.Add(this.lbGioiTinh);
            this.panel2.Controls.Add(this.lbSoDienThoai);
            this.panel2.Controls.Add(this.lbNgaySinh);
            this.panel2.Controls.Add(this.lbTenNhanVien);
            this.panel2.Controls.Add(this.lbDiaChi);
            this.panel2.Controls.Add(this.lbMaNhanVien);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(497, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 328);
            this.panel2.TabIndex = 1;
            // 
            // mskNgaysinh
            // 
            this.mskNgaysinh.Location = new System.Drawing.Point(118, 216);
            this.mskNgaysinh.Mask = "00/00/0000";
            this.mskNgaysinh.Name = "mskNgaysinh";
            this.mskNgaysinh.Size = new System.Drawing.Size(145, 22);
            this.mskNgaysinh.TabIndex = 23;
            this.mskNgaysinh.ValidatingType = typeof(System.DateTime);
            // 
            // mskDienthoai
            // 
            this.mskDienthoai.Location = new System.Drawing.Point(118, 120);
            this.mskDienthoai.Mask = "(999) 000-0000";
            this.mskDienthoai.Name = "mskDienthoai";
            this.mskDienthoai.Size = new System.Drawing.Size(145, 22);
            this.mskDienthoai.TabIndex = 22;
            // 
            // txtChucVu
            // 
            this.txtChucVu.Location = new System.Drawing.Point(118, 184);
            this.txtChucVu.Name = "txtChucVu";
            this.txtChucVu.Size = new System.Drawing.Size(145, 22);
            this.txtChucVu.TabIndex = 21;
            // 
            // lbChucVu
            // 
            this.lbChucVu.AutoSize = true;
            this.lbChucVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbChucVu.Location = new System.Drawing.Point(14, 185);
            this.lbChucVu.Name = "lbChucVu";
            this.lbChucVu.Size = new System.Drawing.Size(62, 18);
            this.lbChucVu.TabIndex = 20;
            this.lbChucVu.Text = "Chức vụ";
            // 
            // rabtnNu
            // 
            this.rabtnNu.AutoSize = true;
            this.rabtnNu.Location = new System.Drawing.Point(193, 248);
            this.rabtnNu.Name = "rabtnNu";
            this.rabtnNu.Size = new System.Drawing.Size(45, 20);
            this.rabtnNu.TabIndex = 19;
            this.rabtnNu.TabStop = true;
            this.rabtnNu.Text = "Nữ";
            this.rabtnNu.UseVisualStyleBackColor = true;
            // 
            // rabtnNam
            // 
            this.rabtnNam.AutoSize = true;
            this.rabtnNam.Location = new System.Drawing.Point(130, 248);
            this.rabtnNam.Name = "rabtnNam";
            this.rabtnNam.Size = new System.Drawing.Size(57, 20);
            this.rabtnNam.TabIndex = 18;
            this.rabtnNam.TabStop = true;
            this.rabtnNam.Text = "Nam";
            this.rabtnNam.UseVisualStyleBackColor = true;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(118, 152);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(145, 22);
            this.txtDiaChi.TabIndex = 17;
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Location = new System.Drawing.Point(118, 88);
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            this.txtTenNhanVien.Size = new System.Drawing.Size(145, 22);
            this.txtTenNhanVien.TabIndex = 15;
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.Location = new System.Drawing.Point(118, 56);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(145, 22);
            this.txtMaNhanVien.TabIndex = 14;
            // 
            // lbGioiTinh
            // 
            this.lbGioiTinh.AutoSize = true;
            this.lbGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGioiTinh.Location = new System.Drawing.Point(14, 249);
            this.lbGioiTinh.Name = "lbGioiTinh";
            this.lbGioiTinh.Size = new System.Drawing.Size(62, 18);
            this.lbGioiTinh.TabIndex = 12;
            this.lbGioiTinh.Text = "Giới tính";
            // 
            // lbSoDienThoai
            // 
            this.lbSoDienThoai.AutoSize = true;
            this.lbSoDienThoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoDienThoai.Location = new System.Drawing.Point(14, 121);
            this.lbSoDienThoai.Name = "lbSoDienThoai";
            this.lbSoDienThoai.Size = new System.Drawing.Size(94, 18);
            this.lbSoDienThoai.TabIndex = 11;
            this.lbSoDienThoai.Text = "Số điện thoại";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // txtTraCuuBox
            // 
            this.txtTraCuuBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTraCuuBox.Location = new System.Drawing.Point(615, 46);
            this.txtTraCuuBox.Name = "txtTraCuuBox";
            this.txtTraCuuBox.Size = new System.Drawing.Size(111, 27);
            this.txtTraCuuBox.TabIndex = 20;
            // 
            // lbTraCuu
            // 
            this.lbTraCuu.AutoSize = true;
            this.lbTraCuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTraCuu.Location = new System.Drawing.Point(500, 51);
            this.lbTraCuu.Name = "lbTraCuu";
            this.lbTraCuu.Size = new System.Drawing.Size(72, 22);
            this.lbTraCuu.TabIndex = 21;
            this.lbTraCuu.Text = "Tra cứu";
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnThem,
            this.btnSua,
            this.btnXoa,
            this.btnLuu,
            this.btnHuyBo,
            this.btnThoat});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 28);
            this.menuStrip2.TabIndex = 22;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // BtnThem
            // 
            this.BtnThem.Image = global::TTCN.Properties.Resources.Hopstarter_Soft_Scraps_Button_Add_48;
            this.BtnThem.Name = "BtnThem";
            this.BtnThem.Size = new System.Drawing.Size(80, 24);
            this.BtnThem.Text = "Thêm";
            this.BtnThem.Click += new System.EventHandler(this.BtnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(72, 24);
            this.btnSua.Text = "Sửa ";
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::TTCN.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_window_close_48;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(69, 24);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.Image")));
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(67, 24);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(81, 24);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Image = global::TTCN.Properties.Resources.Hopstarter_Sleek_Xp_Basic_Delete_48;
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(91, 24);
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.BackgroundImage = global::TTCN.Properties.Resources.Hopstarter_Soft_Scraps_Zoom_48;
            this.btnTraCuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTraCuu.Location = new System.Drawing.Point(732, 44);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new System.Drawing.Size(41, 33);
            this.btnTraCuu.TabIndex = 6;
            this.btnTraCuu.UseVisualStyleBackColor = true;
            // 
            // frmDMNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.lbTraCuu);
            this.Controls.Add(this.txtTraCuuBox);
            this.Controls.Add(this.btnTraCuu);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cbChucVuFilter);
            this.Controls.Add(this.lbChucVuFilTer);
            this.Controls.Add(this.panel1);
            this.Name = "frmDMNhanVien";
            this.Text = "NhanVien";
            this.Load += new System.EventHandler(this.frmDMNhanVien_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem thêmToolStripMenuItem;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Label lbChucVuFilTer;
        private System.Windows.Forms.ComboBox cbChucVuFilter;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbThongTinChucVu;
        private System.Windows.Forms.Label lbMaNhanVien;
        private System.Windows.Forms.Label lbDiaChi;
        private System.Windows.Forms.Label lbTenNhanVien;
        private System.Windows.Forms.Label lbNgaySinh;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbSoDienThoai;
        private System.Windows.Forms.Label lbGioiTinh;
        private System.Windows.Forms.RadioButton rabtnNam;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtTenNhanVien;
        private System.Windows.Forms.TextBox txtMaNhanVien;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.DataGridView dgvNhanVien;
        private System.Windows.Forms.RadioButton rabtnNu;
        private System.Windows.Forms.Button btnTraCuu;
        private System.Windows.Forms.TextBox txtTraCuuBox;
        private System.Windows.Forms.Label lbTraCuu;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem BtnThem;
        private System.Windows.Forms.ToolStripMenuItem btnSua;
        private System.Windows.Forms.ToolStripMenuItem btnXoa;
        private System.Windows.Forms.ToolStripMenuItem btnLuu;
        private System.Windows.Forms.ToolStripMenuItem btnThoat;
        private System.Windows.Forms.TextBox txtChucVu;
        private System.Windows.Forms.Label lbChucVu;
        private System.Windows.Forms.MaskedTextBox mskNgaysinh;
        private System.Windows.Forms.MaskedTextBox mskDienthoai;
        private System.Windows.Forms.ToolStripMenuItem btnHuyBo;
    }
}