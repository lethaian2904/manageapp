using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Apptiemchung
{
    public partial class frmVacxin : Form
    {
        public frmVacxin()
        {
            InitializeComponent();
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";

        }
        Modify modify = new Modify();
        private void frmVacxin_Load(object sender, EventArgs e)
        {
        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            string Tenvacxin = txtTenvacxin.Text;
            if(Tenvacxin.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên vacxin");
            } 
            else
            {
                string sql = "select * from Thongtinvacxin1 where Tenvacxin = '" + Tenvacxin + "'";
                if(modify.Vacxins(sql).Count != 0)
                {
                    label7.Text = modify.Vacxins(sql)[0].Chungloai1;
                    label8.Text = modify.Vacxins(sql)[0].Quocgia1;
                    label9.Text = modify.Vacxins(sql)[0].Giatiennhapkhau1;
                    label10.Text = modify.Vacxins(sql)[0].Thanhtien1;
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
