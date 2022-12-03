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
using System.Data.SqlClient;

namespace quanLyTiemChung
{
    public partial class dangky : Form
    {
        public dangky()
        {
            InitializeComponent();
        }
        public bool checkAccount(string ac)//check mat khau va ten tai khoan
        {
            return Regex.IsMatch(ac, "^[a-zA-Z0-9]{6,20}$");
        }
        public bool CheckEmail(String em)//check email
        {
            return Regex.IsMatch(em, @"^[a-zA-Z0-9_.]{3,30}@gmail.com(.vn|)$");
        }

        public bool CheckPhone(string sdt)//check sdt
        {
            return Regex.IsMatch(sdt, "^[0-9]$");
        }
        


        private void btnDangky_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-PSQC0VQB\SQLEXPRESS;Initial Catalog=quanlytiemchung;Integrated Security=True");
            string tentk = txtTendangnhap.Text;
            string matkhau = txtMatkhau.Text;
            string xnmkhau = txtNLMkhau.Text;
            string email = txtEmail.Text;
            string sdt = txtSodienthoai.Text;
            if (!checkAccount(tentk)) { MessageBox.Show("Vui lòng nhập tên tài khoản từ 6-20 ký tự,với các ký tự chữ và số,chữ hoa và chữ thường!"); return;}
            if(!checkAccount(matkhau)) { MessageBox.Show("Vui lòng nhập tên mật khẩu từ 6-20 ký tự,với các ký tự chữ và số,chữ hoa và chữ thường!"); return; }
            if (xnmkhau != matkhau) { MessageBox.Show("Vui lòng xác nhận mật khẩu chính xác!");return; }
            if (!CheckEmail(sdt)){ MessageBox.Show("Vui lòng nhập đúng định dạng email!");return; }
            
        }
    }

    
}
