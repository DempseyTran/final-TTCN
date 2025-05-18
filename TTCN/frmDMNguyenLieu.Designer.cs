namespace TTCN
{
    partial class frmDMNguyenLieu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDMNguyenLieu));
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.thêmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dgvDMNguyenLieu = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaNguyenLieu = new System.Windows.Forms.TextBox();
            this.txtTenNguyenLieu = new System.Windows.Forms.TextBox();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.txtDonGiaNhap = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDMSX = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.txtLoaiNguyenLieu = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboTraCuuLoaiNguyenLieu = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTraCuuTenNL = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.BtnThem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSua = new System.Windows.Forms.ToolStripMenuItem();
            this.btnXoa = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLuu = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHuyBo = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.btnXuatPhieu = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpKhoNguyênLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtKhoNguyênLiệuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDMNguyenLieu)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // thêmToolStripMenuItem
            // 
            this.thêmToolStripMenuItem.Name = "thêmToolStripMenuItem";
            this.thêmToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.thêmToolStripMenuItem.Text = "Thêm";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(116, 28);
            // 
            // dgvDMNguyenLieu
            // 
            this.dgvDMNguyenLieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDMNguyenLieu.Location = new System.Drawing.Point(3, 0);
            this.dgvDMNguyenLieu.Name = "dgvDMNguyenLieu";
            this.dgvDMNguyenLieu.RowHeadersWidth = 51;
            this.dgvDMNguyenLieu.RowTemplate.Height = 24;
            this.dgvDMNguyenLieu.Size = new System.Drawing.Size(731, 297);
            this.dgvDMNguyenLieu.TabIndex = 0;
            this.dgvDMNguyenLieu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDMNguyenLieu_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDMNguyenLieu);
            this.panel1.Location = new System.Drawing.Point(20, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(734, 299);
            this.panel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 32);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Window;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Thông tin nguyên liệu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mã nguyên liệu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "ĐMSX (/ngày)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 18);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tên nguyên liệu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Loại nguyên liệu";
            // 
            // txtMaNguyenLieu
            // 
            this.txtMaNguyenLieu.Location = new System.Drawing.Point(139, 56);
            this.txtMaNguyenLieu.Name = "txtMaNguyenLieu";
            this.txtMaNguyenLieu.Size = new System.Drawing.Size(133, 22);
            this.txtMaNguyenLieu.TabIndex = 14;
            // 
            // txtTenNguyenLieu
            // 
            this.txtTenNguyenLieu.Location = new System.Drawing.Point(139, 86);
            this.txtTenNguyenLieu.Name = "txtTenNguyenLieu";
            this.txtTenNguyenLieu.Size = new System.Drawing.Size(133, 22);
            this.txtTenNguyenLieu.TabIndex = 15;
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(139, 176);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(133, 22);
            this.txtDVT.TabIndex = 16;
            // 
            // txtDonGiaNhap
            // 
            this.txtDonGiaNhap.Location = new System.Drawing.Point(139, 146);
            this.txtDonGiaNhap.Name = "txtDonGiaNhap";
            this.txtDonGiaNhap.Size = new System.Drawing.Size(133, 22);
            this.txtDonGiaNhap.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "Số lượng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 177);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 18);
            this.label10.TabIndex = 21;
            this.label10.Text = "ĐVT";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(14, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 18);
            this.label11.TabIndex = 22;
            this.label11.Text = "Đơn giá nhập";
            // 
            // txtDMSX
            // 
            this.txtDMSX.Location = new System.Drawing.Point(139, 236);
            this.txtDMSX.Name = "txtDMSX";
            this.txtDMSX.Size = new System.Drawing.Size(133, 22);
            this.txtDMSX.TabIndex = 23;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(139, 206);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(133, 22);
            this.txtSoLuong.TabIndex = 24;
            // 
            // txtLoaiNguyenLieu
            // 
            this.txtLoaiNguyenLieu.Location = new System.Drawing.Point(139, 116);
            this.txtLoaiNguyenLieu.Name = "txtLoaiNguyenLieu";
            this.txtLoaiNguyenLieu.Size = new System.Drawing.Size(133, 22);
            this.txtLoaiNguyenLieu.TabIndex = 25;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel2.Controls.Add(this.txtLoaiNguyenLieu);
            this.panel2.Controls.Add(this.txtSoLuong);
            this.panel2.Controls.Add(this.txtDMSX);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtDonGiaNhap);
            this.panel2.Controls.Add(this.txtDVT);
            this.panel2.Controls.Add(this.txtTenNguyenLieu);
            this.panel2.Controls.Add(this.txtMaNguyenLieu);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Location = new System.Drawing.Point(782, 140);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 328);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Loại nguyên liệu";
            // 
            // cboTraCuuLoaiNguyenLieu
            // 
            this.cboTraCuuLoaiNguyenLieu.FormattingEnabled = true;
            this.cboTraCuuLoaiNguyenLieu.Location = new System.Drawing.Point(194, 141);
            this.cboTraCuuLoaiNguyenLieu.Name = "cboTraCuuLoaiNguyenLieu";
            this.cboTraCuuLoaiNguyenLieu.Size = new System.Drawing.Size(303, 24);
            this.cboTraCuuLoaiNguyenLieu.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(503, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 29);
            this.label7.TabIndex = 24;
            this.label7.Text = "Tra cứu";
            // 
            // txtTraCuuTenNL
            // 
            this.txtTraCuuTenNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTraCuuTenNL.Location = new System.Drawing.Point(194, 112);
            this.txtTraCuuTenNL.Name = "txtTraCuuTenNL";
            this.txtTraCuuTenNL.Size = new System.Drawing.Size(303, 27);
            this.txtTraCuuTenNL.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::TTCN.Properties.Resources.Hopstarter_Soft_Scraps_Zoom_48;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(603, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 33);
            this.button1.TabIndex = 22;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(19, 113);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 22);
            this.label12.TabIndex = 25;
            this.label12.Text = "Tên nguyên liệu";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Green;
            this.label13.Location = new System.Drawing.Point(391, 54);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(374, 32);
            this.label13.TabIndex = 26;
            this.label13.Text = "DANH SÁCH NGUYÊN LIỆU";
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
            this.btnThoat,
            this.btnXuatPhieu});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1097, 28);
            this.menuStrip2.TabIndex = 27;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // BtnThem
            // 
            this.BtnThem.Image = global::TTCN.Properties.Resources.Hopstarter_Soft_Scraps_Button_Add_48;
            this.BtnThem.Name = "BtnThem";
            this.BtnThem.Size = new System.Drawing.Size(80, 26);
            this.BtnThem.Text = "Thêm";
            this.BtnThem.Click += new System.EventHandler(this.BtnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(72, 24);
            this.btnSua.Text = "Sửa ";
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
            this.btnLuu.Size = new System.Drawing.Size(67, 26);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Image = global::TTCN.Properties.Resources.Hopstarter_Sleek_Xp_Basic_Delete_48;
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(91, 26);
            this.btnHuyBo.Text = "Hủy bỏ";
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Image = ((System.Drawing.Image)(resources.GetObject("btnThoat.Image")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(81, 26);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXuatPhieu
            // 
            this.btnXuatPhieu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhậpKhoNguyênLiệuToolStripMenuItem,
            this.xuấtKhoNguyênLiệuToolStripMenuItem});
            this.btnXuatPhieu.Image = global::TTCN.Properties.Resources.Gartoon_Team_Gartoon_Misc_Stock_Edit_Bookmarks1;
            this.btnXuatPhieu.Name = "btnXuatPhieu";
            this.btnXuatPhieu.Size = new System.Drawing.Size(114, 26);
            this.btnXuatPhieu.Text = "Xuất phiếu";
            // 
            // nhậpKhoNguyênLiệuToolStripMenuItem
            // 
            this.nhậpKhoNguyênLiệuToolStripMenuItem.Image = global::TTCN.Properties.Resources.Custom_Icon_Design_Flatastic_9_Import_export_48;
            this.nhậpKhoNguyênLiệuToolStripMenuItem.Name = "nhậpKhoNguyênLiệuToolStripMenuItem";
            this.nhậpKhoNguyênLiệuToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.nhậpKhoNguyênLiệuToolStripMenuItem.Text = "Nhập kho nguyên liệu";
            this.nhậpKhoNguyênLiệuToolStripMenuItem.Click += new System.EventHandler(this.nhậpKhoNguyênLiệuToolStripMenuItem_Click);
            // 
            // xuấtKhoNguyênLiệuToolStripMenuItem
            // 
            this.xuấtKhoNguyênLiệuToolStripMenuItem.Image = global::TTCN.Properties.Resources.Custom_Icon_Design_Office_Export_48;
            this.xuấtKhoNguyênLiệuToolStripMenuItem.Name = "xuấtKhoNguyênLiệuToolStripMenuItem";
            this.xuấtKhoNguyênLiệuToolStripMenuItem.Size = new System.Drawing.Size(236, 26);
            this.xuấtKhoNguyênLiệuToolStripMenuItem.Text = "Xuất kho nguyên liệu";
            this.xuấtKhoNguyênLiệuToolStripMenuItem.Click += new System.EventHandler(this.xuấtKhoNguyênLiệuToolStripMenuItem_Click);
            // 
            // frmDMNguyenLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 513);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTraCuuTenNL);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.cboTraCuuLoaiNguyenLieu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmDMNguyenLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nguyên liệu";
            this.Load += new System.EventHandler(this.frmDMNguyenLieu_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDMNguyenLieu)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.ToolStripMenuItem thêmToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DataGridView dgvDMNguyenLieu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaNguyenLieu;
        private System.Windows.Forms.TextBox txtTenNguyenLieu;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.TextBox txtDonGiaNhap;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDMSX;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTraCuuLoaiNguyenLieu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTraCuuTenNL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem BtnThem;
        private System.Windows.Forms.ToolStripMenuItem btnSua;
        private System.Windows.Forms.ToolStripMenuItem btnXoa;
        private System.Windows.Forms.ToolStripMenuItem btnLuu;
        private System.Windows.Forms.ToolStripMenuItem btnHuyBo;
        private System.Windows.Forms.ToolStripMenuItem btnThoat;
        private System.Windows.Forms.ToolStripMenuItem btnXuatPhieu;
        private System.Windows.Forms.ToolStripMenuItem nhậpKhoNguyênLiệuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuấtKhoNguyênLiệuToolStripMenuItem;
        private System.Windows.Forms.TextBox txtLoaiNguyenLieu;
    }
}