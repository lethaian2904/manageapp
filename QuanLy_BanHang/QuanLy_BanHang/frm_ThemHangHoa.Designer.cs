
namespace QuanLy_BanHang
{
    partial class frm_ThemHangHoa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ThemHangHoa));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_MaHang = new System.Windows.Forms.TextBox();
            this.txt_TenHang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_GiaTien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pb = new System.Windows.Forms.PictureBox();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_XacNhan = new System.Windows.Forms.Button();
            this.lbl_trangthai = new System.Windows.Forms.Label();
            this.btn_hinhanh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã Hàng";
            // 
            // txt_MaHang
            // 
            this.txt_MaHang.Location = new System.Drawing.Point(59, 56);
            this.txt_MaHang.Name = "txt_MaHang";
            this.txt_MaHang.Size = new System.Drawing.Size(204, 20);
            this.txt_MaHang.TabIndex = 1;
            // 
            // txt_TenHang
            // 
            this.txt_TenHang.Location = new System.Drawing.Point(59, 95);
            this.txt_TenHang.Name = "txt_TenHang";
            this.txt_TenHang.Size = new System.Drawing.Size(204, 20);
            this.txt_TenHang.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên Hàng";
            // 
            // txt_GiaTien
            // 
            this.txt_GiaTien.Location = new System.Drawing.Point(59, 131);
            this.txt_GiaTien.Name = "txt_GiaTien";
            this.txt_GiaTien.Size = new System.Drawing.Size(170, 20);
            this.txt_GiaTien.TabIndex = 5;
            this.txt_GiaTien.TextChanged += new System.EventHandler(this.txt_GiaTien_TextChanged);
            this.txt_GiaTien.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_GiaTien_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Giá Tiền";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(233, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "VNĐ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Hình Ảnh";
            // 
            // pb
            // 
            this.pb.Image = global::QuanLy_BanHang.Properties.Resources.Coffee;
            this.pb.Location = new System.Drawing.Point(59, 167);
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(170, 146);
            this.pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb.TabIndex = 13;
            this.pb.TabStop = false;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Image = global::QuanLy_BanHang.Properties.Resources.icons8_Delete_32;
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xoa.Location = new System.Drawing.Point(179, 320);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(92, 39);
            this.btn_Xoa.TabIndex = 10;
            this.btn_Xoa.Text = "Xóa   ";
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_XacNhan
            // 
            this.btn_XacNhan.Image = global::QuanLy_BanHang.Properties.Resources.icons8_Check_Circle_32;
            this.btn_XacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_XacNhan.Location = new System.Drawing.Point(7, 320);
            this.btn_XacNhan.Name = "btn_XacNhan";
            this.btn_XacNhan.Size = new System.Drawing.Size(98, 39);
            this.btn_XacNhan.TabIndex = 9;
            this.btn_XacNhan.Text = "Xác Nhận";
            this.btn_XacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_XacNhan.UseVisualStyleBackColor = true;
            this.btn_XacNhan.Click += new System.EventHandler(this.btn_XacNhan_Click);
            // 
            // lbl_trangthai
            // 
            this.lbl_trangthai.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbl_trangthai.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_trangthai.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_trangthai.Image = global::QuanLy_BanHang.Properties.Resources.icons8_list_32;
            this.lbl_trangthai.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_trangthai.Location = new System.Drawing.Point(0, 0);
            this.lbl_trangthai.Name = "lbl_trangthai";
            this.lbl_trangthai.Size = new System.Drawing.Size(278, 44);
            this.lbl_trangthai.TabIndex = 8;
            this.lbl_trangthai.Text = "Thêm Hàng Hóa Mới";
            this.lbl_trangthai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_hinhanh
            // 
            this.btn_hinhanh.Location = new System.Drawing.Point(4, 183);
            this.btn_hinhanh.Name = "btn_hinhanh";
            this.btn_hinhanh.Size = new System.Drawing.Size(50, 40);
            this.btn_hinhanh.TabIndex = 14;
            this.btn_hinhanh.Text = "Chọn hình";
            this.btn_hinhanh.UseVisualStyleBackColor = true;
            this.btn_hinhanh.Click += new System.EventHandler(this.btn_hinhanh_Click);
            // 
            // frm_ThemHangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 364);
            this.Controls.Add(this.btn_hinhanh);
            this.Controls.Add(this.pb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_XacNhan);
            this.Controls.Add(this.lbl_trangthai);
            this.Controls.Add(this.txt_GiaTien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_TenHang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_MaHang);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(294, 403);
            this.MinimizeBox = false;
            this.Name = "frm_ThemHangHoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hàng hóa";
            this.Load += new System.EventHandler(this.frm_ThemHangHoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_MaHang;
        private System.Windows.Forms.TextBox txt_TenHang;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_GiaTien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_trangthai;
        private System.Windows.Forms.Button btn_XacNhan;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pb;
        private System.Windows.Forms.Button btn_hinhanh;
    }
}