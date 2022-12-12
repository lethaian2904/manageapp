using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Apptiemchung
{
    public partial class frmDangky : Form
    {
        public frmDangky()
        {
            InitializeComponent();
        }
        public bool CheckTaikhoan(string tdn)
        {

            return Regex.IsMatch(tdn, "^[a-zA-Z0-9]{6,24}$");
        }
        public bool CheckEmail(string em)
        {

            return Regex.IsMatch(em, "^[a-zA-Z0-9_.]{3,20}@gmail.com(.vn|)$");
        }
        private void frmDangky_Load(object sender, EventArgs e)
        {
        }
        Modify modify = new Modify();
        private void btnDangky_Click(object sender, EventArgs e)
        {
            string Tendangnhap = txtTendangnhap.Text;
            string Matkhau = txtMatkhau.Text;
            string Nhaplaimatkhau = txtNhaplaimatkhau.Text;
            string Sodienthoai = txtSodienthoai.Text;
            string Email = txtEmail.Text;
            if(!CheckTaikhoan(Tendangnhap))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản dài 6-24 ký tự,có các ký tự chữ,số,chữ hoa");
                return;
            }
            if (!CheckTaikhoan(Matkhau))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản dài 6-24 ký tự,có các ký tự chữ,số,chữ hoa");
                return;
            }
            if (Nhaplaimatkhau != Matkhau)
            {
                MessageBox.Show("Vui lòng nhập đúng mật khẩu");
                return;
            }
            if (!CheckEmail(Email))
            {
                MessageBox.Show("Vui lòng nhập đúng tên email");
                return;
            }
            /*if(modify.Dangnhaps("select * from Dangky where Email = '"+Email+"'").Count != 0)
            {
                MessageBox.Show("Email này đã được đăng ký vui lòng nhập một email khác ");
                return;
            }  */  
            try
            {
                string sql = "Insert into Dangky values('"+Tendangnhap+"','"+Matkhau+"','"+Nhaplaimatkhau+"','"+Sodienthoai+"','"+Email+"')";
                modify.CommandRe(sql);
                if(MessageBox.Show("Đăng ký thành công bạn có muốn đăng nhập luôn không","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Tài khoản này đã được đăng ký vui lòng đăng ký bằng tài khoản khác");
            }
        }
    }
}
