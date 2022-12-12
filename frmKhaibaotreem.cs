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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Apptiemchung
{
    public partial class frmKhaibaotreem : Form
    {
        List<string> listgt = new List<string>() { "Nam", "Nữ", "Khác" };
        public frmKhaibaotreem()
        {
            InitializeComponent();
        }

        Modify modify = new Modify();
        private void frmKhaibaotreem_Load(object sender, EventArgs e)
        {
            cboGioitinh.DataSource = listgt;
        }

        private void btnKhaibao_Click(object sender, EventArgs e)
        {
            string Madinhdanh = txtMadinhdanh.Text;
            //string CCCD = txtCCCD.Text;
            string Hovaten = txtHovaten.Text;
            dtpNgaysinh.MinDate = DateTime.Now;
            int dayofmonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            dtpNgaysinh.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dayofmonth);
            string Ngaysinh = dtpNgaysinh.Value.ToShortDateString();
            string Gioitinh = cboGioitinh.Text;
            string Quequan = txtQuequan.Text;
            try
            {
                using (SqlConnection sqlConnection = Ketnoi.GetSqlConnection())
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = CommandType.Text;
                    string sql = "Insert into Thongtincntreem values('" + Madinhdanh + "',N'" + Hovaten + "','" + Ngaysinh + "',N'" + Gioitinh + "',N'" + Quequan + "')";
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

        private void btnQuaylai_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGiaodien gd = new frmGiaodien();
            gd.ShowDialog();
            this.Close();
        }
    }
}
