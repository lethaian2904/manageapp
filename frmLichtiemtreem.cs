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
    public partial class frmLichtiemtreem : Form
    {
        public frmLichtiemtreem()
        {
            InitializeComponent();
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
        }
        Modify modify = new Modify();

        private void frmLichtiemtreem_Load(object sender, EventArgs e)
        {

        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            string Madinhdanh = txtMadinhdanh.Text;
            if (Madinhdanh.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Madinhdanh dể biết thông tin tiêm");
            }
            else
            {
                string sql = "select * from Lichtiemtreem1 where Madinhdanh ='" + Madinhdanh + "'";
                if (modify.lichtiems(sql).Count != 0)
                {
                    label7.Text = modify.lichtiems(sql)[0].Tenvacxin1;
                    label8.Text = modify.lichtiems(sql)[0].Hovaten1;
                    label9.Text = modify.lichtiems(sql)[0].Ngaysinh1.ToString();
                    label10.Text = modify.lichtiems(sql)[0].Ngaytiem1.ToString();
                    label11.Text = modify.lichtiems(sql)[0].Noitiem1;
                }
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
