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

namespace Apptiemchung
{
    public partial class frmDangkytiemchung : Form
    {
        List<string> listgt = new List<string>() { "Nam", "Nữ", "Khác" };
        public static SqlConnection con;
        public frmDangkytiemchung()
        {
            InitializeComponent();
        }

        Modify modify = new Modify();
        private void btnDangky_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8OFGL8E\HIEU;Initial Catalog=Hethongtiemchung;Integrated Security=True");

            //conn.Open();

            //string madntreem = txtMadinhdanhtreem.Text;
            string cccd = txtCCCD.Text;
            //string madntreem = txtMadinhdanhtreem.Text;
            string hovaten = txtHovarten.Text;
            dtpNgaysinh.MinDate = DateTime.Now;
            int dayofmonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            dtpNgaysinh.MaxDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, dayofmonth);
            string ngaysinh = dtpNgaysinh.Value.ToShortDateString();
            string gioitinh = cboGioitinh.Text;
            
            try
            {
                    /*string sql = "Insert into  Dangkytiemchungtreem values('" + madntreem + "' , '" + cccd + "' , '" + hovaten + "' , '" + ngaysinh + "' , '" + gioitinh + "')";
                    modify.Command(sql);*/
                    string sql = "Insert into Dangkytiemchung values('" + cccd + "' , N'" + hovaten + "' , '" + ngaysinh + "' , N'" + gioitinh + "')";
                    modify.CommandRe(sql);
            }
            catch
            {
                MessageBox.Show("Đăng ký không thành công");
            }


        }

        private void frmDangkytiemchung_Load(object sender, EventArgs e)
        {
            cboGioitinh.DataSource = listgt;
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
