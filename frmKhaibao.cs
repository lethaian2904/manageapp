using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apptiemchung
{
    
    public partial class frmKhaibao : Form
    {
        List<string> lisgt = new List<string>() { "Nam", "Nữ", "Khác" };
        public frmKhaibao()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        private void Khaibao_Load(object sender, EventArgs e)
        {
            cboGioitinh.DataSource = lisgt;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string cccd = txtCCCD.Text;
            string hovaten = txtHovaten.Text;
            dtpNgaysinh.MinDate = DateTime.Now;
            int dayofmonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            dtpNgaysinh.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dayofmonth);
            string ngaysinh = dtpNgaysinh.MaxDate.ToString();
            string gioitinh = cboGioitinh.Text;
            string quequan = txtQuequan.Text;
            string choohientai = txtChoohientai.Text;
            string sodienthoai = txtSodienthoai.Text;
            string email = txtEmail.Text;
            try
            {
               using(SqlConnection sqlConnection = Ketnoi.GetSqlConnection())
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = CommandType.Text;
                    string sql = "Insert into Thongtincn values('" + cccd + "',N'" + hovaten + "','" + ngaysinh + "','" + gioitinh + "',N'" + quequan + "',N'" + choohientai + "','" + sodienthoai + "','" + email + "')";                  
                    sqlCommand.CommandText = sql;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }    
            }
            catch
            {
                MessageBox.Show("Khai báo không thành công");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGiaodien gd = new frmGiaodien();
            gd.ShowDialog();
            this.Close();
        }
    }
}
