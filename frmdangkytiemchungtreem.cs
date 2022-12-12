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
    public partial class frmdangkytiemchungtreem : Form
    {

        List<string> listgt = new List<string>() { "Nam", "Nữ", "Khác" };
        public static SqlConnection con;
        public frmdangkytiemchungtreem()
        {
            InitializeComponent();
        }
        Modify modify = new Modify();
        private void btnDangky_Click(object sender, EventArgs e)
        {
            string madntreem = txtMadinhdanhtreem.Text;
            string cccd = txtcccd.Text;
            string hovaten = txtHovarten.Text;
            dtpNgaysinh.MinDate = DateTime.Now;
            int dayofmonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            dtpNgaysinh.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dayofmonth);
            string ngaysinh = dtpNgaysinh.Value.ToShortDateString();
            string gioitinh = cboGioitinh.Text;

            try
            {
                using (SqlConnection sqlConnection = Ketnoi.GetSqlConnection())
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = CommandType.Text;
                    string sql = "Insert into  Dangkytiemchungtreem values ('" + madntreem + "' , '" + cccd + "' , N'" + hovaten + "' , '" + ngaysinh + "' , N'" + gioitinh + "')";
                    sqlCommand.CommandText = sql;
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Đăng ký không thành công");
            }
        }

        private void frmdangkytiemchungtreem_Load(object sender, EventArgs e)
        {
            cboGioitinh.DataSource = listgt;
        }
    }
}
