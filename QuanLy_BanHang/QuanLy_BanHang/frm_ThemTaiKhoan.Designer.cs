namespace QuanLy_BanHang
{
    partial class frm_QL_TaiKhoan
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TaiKhoan = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbb_GioiTinh = new System.Windows.Forms.ComboBox();
            this.txt_MatKhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_HoTen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_SDT = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbb_CapBac = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rtb_DiaChi = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_HinhAnh = new System.Windows.Forms.Button();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.picbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài Khoản";
            // 
            // txt_TaiKhoan
            // 
            this.txt_TaiKhoan.Location = new System.Drawing.Point(82, 14);
            this.txt_TaiKhoan.Name = "txt_TaiKhoan";
            this.txt_TaiKhoan.Size = new System.Drawing.Size(178, 20);
            this.txt_TaiKhoan.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(314, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Giới Tính";
            // 
            // cbb_GioiTinh
            // 
            this.cbb_GioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_GioiTinh.FormattingEnabled = true;
            this.cbb_GioiTinh.Items.AddRange(new object[] {
            "Nữ",
            "Nam"});
            this.cbb_GioiTinh.Location = new System.Drawing.Point(401, 46);
            this.cbb_GioiTinh.Name = "cbb_GioiTinh";
            this.cbb_GioiTinh.Size = new System.Drawing.Size(84, 21);
            this.cbb_GioiTinh.TabIndex = 3;
            // 
            // txt_MatKhau
            // 
            this.txt_MatKhau.Location = new System.Drawing.Point(82, 46);
            this.txt_MatKhau.Name = "txt_MatKhau";
            this.txt_MatKhau.Size = new System.Drawing.Size(178, 20);
            this.txt_MatKhau.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật Khẩu";
            // 
            // txt_HoTen
            // 
            this.txt_HoTen.Location = new System.Drawing.Point(401, 13);
            this.txt_HoTen.Name = "txt_HoTen";
            this.txt_HoTen.Size = new System.Drawing.Size(223, 20);
            this.txt_HoTen.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên Nhân Viên";
            // 
            // txt_SDT
            // 
            this.txt_SDT.Location = new System.Drawing.Point(401, 112);
            this.txt_SDT.Name = "txt_SDT";
            this.txt_SDT.Size = new System.Drawing.Size(223, 20);
            this.txt_SDT.TabIndex = 9;
            this.txt_SDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SDT_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(314, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Số Điện Thoại";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(314, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Địa Chỉ";
            // 
            // cbb_CapBac
            // 
            this.cbb_CapBac.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_CapBac.FormattingEnabled = true;
            this.cbb_CapBac.Items.AddRange(new object[] {
            "Nhân Viên",
            "Quản Lý"});
            this.cbb_CapBac.Location = new System.Drawing.Point(401, 79);
            this.cbb_CapBac.Name = "cbb_CapBac";
            this.cbb_CapBac.Size = new System.Drawing.Size(84, 21);
            this.cbb_CapBac.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(314, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Cấp Bậc";
            // 
            // rtb_DiaChi
            // 
            this.rtb_DiaChi.Location = new System.Drawing.Point(401, 144);
            this.rtb_DiaChi.Name = "rtb_DiaChi";
            this.rtb_DiaChi.Size = new System.Drawing.Size(223, 132);
            this.rtb_DiaChi.TabIndex = 13;
            this.rtb_DiaChi.Text = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 87);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Hình Ảnh";
            // 
            // btn_HinhAnh
            // 
            this.btn_HinhAnh.Location = new System.Drawing.Point(82, 82);
            this.btn_HinhAnh.Name = "btn_HinhAnh";
            this.btn_HinhAnh.Size = new System.Drawing.Size(84, 23);
            this.btn_HinhAnh.TabIndex = 15;
            this.btn_HinhAnh.Text = "Chọn hình ảnh";
            this.btn_HinhAnh.UseVisualStyleBackColor = true;
            this.btn_HinhAnh.Click += new System.EventHandler(this.btn_HinhAnh_Click);
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.Image = global::QuanLy_BanHang.Properties.Resources._12221_16;
            this.btn_TimKiem.Location = new System.Drawing.Point(266, 12);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(42, 22);
            this.btn_TimKiem.TabIndex = 19;
            this.btn_TimKiem.UseVisualStyleBackColor = true;
            this.btn_TimKiem.Visible = false;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Image = global::QuanLy_BanHang.Properties.Resources.icons8_Delete_32;
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xoa.Location = new System.Drawing.Point(317, 293);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(105, 46);
            this.btn_Xoa.TabIndex = 18;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Image = global::QuanLy_BanHang.Properties.Resources.icons8_add_48;
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.Location = new System.Drawing.Point(141, 293);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(146, 46);
            this.btn_Them.TabIndex = 17;
            this.btn_Them.Text = "Thêm Tài Khoản  ";
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // picbox
            // 
            this.picbox.Image = global::QuanLy_BanHang.Properties.Resources.user_80px;
            this.picbox.Location = new System.Drawing.Point(82, 111);
            this.picbox.Name = "picbox";
            this.picbox.Size = new System.Drawing.Size(178, 165);
            this.picbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picbox.TabIndex = 16;
            this.picbox.TabStop = false;
            // 
            // frm_QL_TaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 345);
            this.Controls.Add(this.btn_TimKiem);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.picbox);
            this.Controls.Add(this.btn_HinhAnh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rtb_DiaChi);
            this.Controls.Add(this.cbb_CapBac);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_SDT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_HoTen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_MatKhau);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbb_GioiTinh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_TaiKhoan);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(649, 384);
            this.Name = "frm_QL_TaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản";
            this.Load += new System.EventHandler(this.frm_ThemTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_GioiTinh;
        private System.Windows.Forms.TextBox txt_MatKhau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_HoTen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_SDT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbb_CapBac;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox rtb_DiaChi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_HinhAnh;
        private System.Windows.Forms.PictureBox picbox;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_TimKiem;
    }
}