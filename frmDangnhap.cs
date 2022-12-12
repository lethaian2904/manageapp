using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apptiemchung
{
    public partial class frmDangnhap : Form
    {
        public frmDangnhap()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string Tendangnhap = txtTendangnhap.Text;
            string Matkhau = txtMatkhau.Text;
            if (Tendangnhap.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản");
            }
            else if (Matkhau.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
            }
            else
            {
                string sql = "select * from Dangky where Tendangnhap = '" + Tendangnhap + "' and Matkhau = '" + Matkhau + "'";
                if (modify.Dangnhaps(sql).Count != 0)
                {
                    MessageBox.Show("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmGiaodien gd =  new frmGiaodien();
                    gd.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên tài khoản hoặc mật khẩu không đúng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void frmDangnhap_Load(object sender, EventArgs e)
        { 
            /*frmGiaodien frmgd = new frmGiaodien();
            frmgd.MdiParent = this;
            this.Show();*/
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {

            frmDangky frmdk = new frmDangky();
            frmdk.MdiParent = this;
            this.Show();
            frmDangky frm = new frmDangky();
            frm.ShowDialog();
        }
        /*public void Hienthi()
        {
            string Tendangnhap = txtTendangnhap.Text;
             //string sql = "select * from Dangky where Tendangnhap = '" + Tendangnhap+ "' ";
        }*/
    }
}
