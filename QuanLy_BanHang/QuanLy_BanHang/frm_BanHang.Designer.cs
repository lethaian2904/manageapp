
namespace QuanLy_BanHang
{
    partial class frm_BanHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_BanHang));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Them = new System.Windows.Forms.Button();
            this.nmr_SoLuong = new System.Windows.Forms.NumericUpDown();
            this.cbb_SanPham = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fpnl_SanPham = new System.Windows.Forms.FlowLayoutPanel();
            this.lbl_DatHang = new System.Windows.Forms.Label();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_XacNhan = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_SoLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Them);
            this.groupBox2.Controls.Add(this.nmr_SoLuong);
            this.groupBox2.Controls.Add(this.cbb_SanPham);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 97);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chọn Sản Phẩm";
            // 
            // btn_Them
            // 
            this.btn_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Image = global::QuanLy_BanHang.Properties.Resources.icons8_add_48;
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.Location = new System.Drawing.Point(329, 19);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(112, 65);
            this.btn_Them.TabIndex = 5;
            this.btn_Them.Text = "        Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // nmr_SoLuong
            // 
            this.nmr_SoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmr_SoLuong.Location = new System.Drawing.Point(104, 62);
            this.nmr_SoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmr_SoLuong.Name = "nmr_SoLuong";
            this.nmr_SoLuong.Size = new System.Drawing.Size(61, 26);
            this.nmr_SoLuong.TabIndex = 3;
            this.nmr_SoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cbb_SanPham
            // 
            this.cbb_SanPham.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbb_SanPham.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbb_SanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_SanPham.FormattingEnabled = true;
            this.cbb_SanPham.Location = new System.Drawing.Point(104, 23);
            this.cbb_SanPham.Name = "cbb_SanPham";
            this.cbb_SanPham.Size = new System.Drawing.Size(219, 28);
            this.cbb_SanPham.TabIndex = 2;
            this.cbb_SanPham.SelectedIndexChanged += new System.EventHandler(this.cbb_SanPham_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Số Lượng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sản phẩm";
            // 
            // fpnl_SanPham
            // 
            this.fpnl_SanPham.AutoScroll = true;
            this.fpnl_SanPham.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.fpnl_SanPham.Dock = System.Windows.Forms.DockStyle.Top;
            this.fpnl_SanPham.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fpnl_SanPham.Location = new System.Drawing.Point(0, 145);
            this.fpnl_SanPham.Name = "fpnl_SanPham";
            this.fpnl_SanPham.Size = new System.Drawing.Size(448, 366);
            this.fpnl_SanPham.TabIndex = 2;
            // 
            // lbl_DatHang
            // 
            this.lbl_DatHang.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lbl_DatHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbl_DatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_DatHang.Location = new System.Drawing.Point(0, 0);
            this.lbl_DatHang.Name = "lbl_DatHang";
            this.lbl_DatHang.Size = new System.Drawing.Size(448, 48);
            this.lbl_DatHang.TabIndex = 3;
            this.lbl_DatHang.Text = "Đặt Hàng Bàn ";
            this.lbl_DatHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Image = global::QuanLy_BanHang.Properties.Resources.icons8_Delete_48;
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xoa.Location = new System.Drawing.Point(310, 517);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(131, 54);
            this.btn_Xoa.TabIndex = 5;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_XacNhan
            // 
            this.btn_XacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_XacNhan.Image = global::QuanLy_BanHang.Properties.Resources.icons8_Check_Circle_48;
            this.btn_XacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_XacNhan.Location = new System.Drawing.Point(6, 517);
            this.btn_XacNhan.Name = "btn_XacNhan";
            this.btn_XacNhan.Size = new System.Drawing.Size(131, 54);
            this.btn_XacNhan.TabIndex = 4;
            this.btn_XacNhan.Text = "           Xác Nhận";
            this.btn_XacNhan.UseVisualStyleBackColor = true;
            this.btn_XacNhan.Click += new System.EventHandler(this.button1_Click);
            // 
            // frm_BanHang
            // 
            this.AcceptButton = this.btn_Them;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(448, 574);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_XacNhan);
            this.Controls.Add(this.fpnl_SanPham);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lbl_DatHang);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(464, 39);
            this.Name = "frm_BanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bán Hàng";
            this.Load += new System.EventHandler(this.frm_BanHang_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmr_SoLuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbb_SanPham;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel fpnl_SanPham;
        private System.Windows.Forms.Label lbl_DatHang;
        private System.Windows.Forms.Button btn_XacNhan;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.NumericUpDown nmr_SoLuong;
        private System.Windows.Forms.Label label3;
    }
}