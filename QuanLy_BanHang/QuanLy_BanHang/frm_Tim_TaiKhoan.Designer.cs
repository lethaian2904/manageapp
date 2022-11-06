
namespace QuanLy_BanHang
{
    partial class frm_Tim_TaiKhoan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Tim_TaiKhoan));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TaiKhoan = new System.Windows.Forms.TextBox();
            this.dtgrid_TaiKhoan = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_LamMoi = new System.Windows.Forms.Button();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_TaiKhoan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tài Khoản";
            // 
            // txt_TaiKhoan
            // 
            this.txt_TaiKhoan.Location = new System.Drawing.Point(67, 28);
            this.txt_TaiKhoan.Name = "txt_TaiKhoan";
            this.txt_TaiKhoan.Size = new System.Drawing.Size(213, 20);
            this.txt_TaiKhoan.TabIndex = 1;
            // 
            // dtgrid_TaiKhoan
            // 
            this.dtgrid_TaiKhoan.AllowUserToAddRows = false;
            this.dtgrid_TaiKhoan.AllowUserToDeleteRows = false;
            this.dtgrid_TaiKhoan.AllowUserToOrderColumns = true;
            this.dtgrid_TaiKhoan.AllowUserToResizeRows = false;
            this.dtgrid_TaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgrid_TaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgrid_TaiKhoan.Location = new System.Drawing.Point(0, 104);
            this.dtgrid_TaiKhoan.MultiSelect = false;
            this.dtgrid_TaiKhoan.Name = "dtgrid_TaiKhoan";
            this.dtgrid_TaiKhoan.ReadOnly = true;
            this.dtgrid_TaiKhoan.RowHeadersVisible = false;
            this.dtgrid_TaiKhoan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgrid_TaiKhoan.Size = new System.Drawing.Size(375, 361);
            this.dtgrid_TaiKhoan.TabIndex = 3;
            this.dtgrid_TaiKhoan.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgrid_TaiKhoan_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_LamMoi);
            this.groupBox1.Controls.Add(this.txt_TaiKhoan);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_TimKiem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 98);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm theo tài khoản";
            // 
            // btn_LamMoi
            // 
            this.btn_LamMoi.Image = global::QuanLy_BanHang.Properties.Resources.icons8_refresh_32;
            this.btn_LamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_LamMoi.Location = new System.Drawing.Point(191, 56);
            this.btn_LamMoi.Name = "btn_LamMoi";
            this.btn_LamMoi.Size = new System.Drawing.Size(89, 36);
            this.btn_LamMoi.TabIndex = 3;
            this.btn_LamMoi.Text = "Làm mới  ";
            this.btn_LamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_LamMoi.UseVisualStyleBackColor = true;
            this.btn_LamMoi.Click += new System.EventHandler(this.btn_LamMoi_Click);
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.Image = global::QuanLy_BanHang.Properties.Resources.icons8_search_32;
            this.btn_TimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TimKiem.Location = new System.Drawing.Point(67, 56);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(93, 36);
            this.btn_TimKiem.TabIndex = 2;
            this.btn_TimKiem.Text = "Tìm Kiếm  ";
            this.btn_TimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TimKiem.UseVisualStyleBackColor = true;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // frm_Tim_TaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 465);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtgrid_TaiKhoan);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(391, 504);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(391, 504);
            this.Name = "frm_Tim_TaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tài Khoản";
            this.Load += new System.EventHandler(this.frm_Tim_TaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgrid_TaiKhoan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TaiKhoan;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.DataGridView dtgrid_TaiKhoan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_LamMoi;
    }
}