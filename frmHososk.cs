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
    public partial class frmHososk : Form
    {
        public frmHososk()
        {
            InitializeComponent();
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label15.Text = "";
            label16.Text = "";
            label17.Text = "";
            label18.Text = "";
            label19.Text = "";
        }
        Modify modify = new Modify();
        private void Hososk_Load(object sender, EventArgs e)
        {

        }

        private void btnHienthi_Click(object sender, EventArgs e)
        {
            string cccd = txtcccd.Text;
            if(cccd.Trim() == "")
            {
                MessageBox.Show("Vì lý do bảo mật nên vui lòng nhập CCCD của bạn");
            }
            else
            {
                string sql = "select * from Hososk where CCCD = '" + cccd + "'";
                if(modify.Hososks(sql).Count !=0)
                {
                    label7.Text = modify.Hososks(sql)[0].Hovaten1;
                    label8.Text = modify.Hososks(sql)[0].Ngaysinh1.ToString();
                    label9.Text = modify.Hososks(sql)[0].Gioitinh1;
                    label10.Text = modify.Hososks(sql)[0].Nghenghiep1;
                    label15.Text = modify.Hososks(sql)[0].Dantoc1;
                    label16.Text = modify.Hososks(sql)[0].Quocgia1;
                    label17.Text = modify.Hososks(sql)[0].BHYT1;
                    label18.Text = modify.Hososks(sql)[0].Chieucao1;
                    label19.Text = modify.Hososks(sql)[0].Cannang1;
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
