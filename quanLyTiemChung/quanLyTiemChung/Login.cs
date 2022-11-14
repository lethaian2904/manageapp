using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using System.Data;

namespace quanLyTiemChung
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            SqlConnection conn =  new SqlConnection(@"Data Source=LAPTOP-PSQC0VQB\SQLEXPRESS;Initial Catalog=quanlytiemchung;Integrated Security=True");
            try
            {
                conn.Open();
                string tk = txtTaikhoan.Text;
                string mk = txtMatkhau.Text;
                string sql = "select *from dangnhap where Tendangnhap='" + tk + "'and Matkhau='" + mk + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if(dta.Read()==true)
                {
                    MessageBox.Show("Đăng nhập thành công","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đăng nhập thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có muốn thoát hay không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK) ;
            Application.Exit();
        }
    }
}
