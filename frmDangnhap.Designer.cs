namespace Apptiemchung
{
    partial class frmDangnhap
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTendangnhap = new System.Windows.Forms.TextBox();
            this.txtMatkhau = new System.Windows.Forms.TextBox();
            this.btnDangnhap = new System.Windows.Forms.Button();
            this.btnDangky = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Image = global::Apptiemchung.Properties.Resources.anhnen;
            this.label1.Location = new System.Drawing.Point(306, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "ĐĂNG NHẬP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Image = global::Apptiemchung.Properties.Resources.anhnen;
            this.label2.Location = new System.Drawing.Point(174, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đăng nhập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Image = global::Apptiemchung.Properties.Resources.anhnen;
            this.label3.Location = new System.Drawing.Point(174, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu";
            // 
            // txtTendangnhap
            // 
            this.txtTendangnhap.Location = new System.Drawing.Point(373, 222);
            this.txtTendangnhap.Name = "txtTendangnhap";
            this.txtTendangnhap.Size = new System.Drawing.Size(270, 26);
            this.txtTendangnhap.TabIndex = 3;
            // 
            // txtMatkhau
            // 
            this.txtMatkhau.Location = new System.Drawing.Point(373, 314);
            this.txtMatkhau.Name = "txtMatkhau";
            this.txtMatkhau.PasswordChar = '*';
            this.txtMatkhau.Size = new System.Drawing.Size(270, 26);
            this.txtMatkhau.TabIndex = 4;
            // 
            // btnDangnhap
            // 
            this.btnDangnhap.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDangnhap.Image = global::Apptiemchung.Properties.Resources.anhnen;
            this.btnDangnhap.Location = new System.Drawing.Point(239, 461);
            this.btnDangnhap.Name = "btnDangnhap";
            this.btnDangnhap.Size = new System.Drawing.Size(104, 34);
            this.btnDangnhap.TabIndex = 5;
            this.btnDangnhap.Text = "Đăng nhập";
            this.btnDangnhap.UseVisualStyleBackColor = true;
            this.btnDangnhap.Click += new System.EventHandler(this.btnDangnhap_Click);
            // 
            // btnDangky
            // 
            this.btnDangky.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDangky.Image = global::Apptiemchung.Properties.Resources.anhnen;
            this.btnDangky.Location = new System.Drawing.Point(497, 461);
            this.btnDangky.Name = "btnDangky";
            this.btnDangky.Size = new System.Drawing.Size(104, 34);
            this.btnDangky.TabIndex = 6;
            this.btnDangky.Text = "Đăng ký";
            this.btnDangky.UseVisualStyleBackColor = true;
            this.btnDangky.Click += new System.EventHandler(this.btnDangky_Click);
            // 
            // frmDangnhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Apptiemchung.Properties.Resources.anhnen;
            this.ClientSize = new System.Drawing.Size(800, 573);
            this.Controls.Add(this.btnDangky);
            this.Controls.Add(this.btnDangnhap);
            this.Controls.Add(this.txtMatkhau);
            this.Controls.Add(this.txtTendangnhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.IsMdiContainer = true;
            this.Name = "frmDangnhap";
            this.Text = "Đăng nhập";
            this.Load += new System.EventHandler(this.frmDangnhap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTendangnhap;
        private System.Windows.Forms.TextBox txtMatkhau;
        private System.Windows.Forms.Button btnDangnhap;
        private System.Windows.Forms.Button btnDangky;
    }
}