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
    public partial class frmGiaodien : Form
    {
        public frmGiaodien()
        {
            InitializeComponent();
            string sql = "select * from Thongtinvacxin1";
            dgvChitiet.DataSource = modify.GetDataTable(sql);
        }
        Modify modify = new Modify();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            /*frmDangkytiemchung frm = new frmDangkytiemchung();
            frm.ShowDialog();
            this.Close();*/
        }

        private void pnHienthi_Paint(object sender, PaintEventArgs e)
        {
            string sql = "select * from Dangky";
            if(modify.Dangnhaps(sql).Count !=0)
            {
                lbXinchao.Text = modify.Dangnhaps(sql)[0].ToString();
            }    
        }

        private void pngdChinh_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnChitiet_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmVacxin vc = new frmVacxin();
            vc.ShowDialog();
            this.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn đăng ký tiêm chủng cho bản thân(Yes)-Đăng ký cho người khác(No)", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                frmDangkytiemchung kb = new frmDangkytiemchung();
                kb.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                frmdangkytiemchungtreem frmKhaibaotreem = new frmdangkytiemchungtreem();
                frmKhaibaotreem.ShowDialog();
                this.Close();
            }
        }

        private void dgvChitiet_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           /* string sql = "select * from Thongtinvacxin1";
            dgvChitiet.DataSource = modify.GetDataTable(sql);*/
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmDangnhap dn = new frmDangnhap();
            dn.ShowDialog();
            this.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            /*this.Hide();
            frmKhaibao kb = new frmKhaibao();
            kb.ShowDialog();
            this.Close();*/
            if(MessageBox.Show("Bạn muốn khai báo cho bản thân(Yes)-Khai báo cho người khác(No)","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                frmKhaibao kb = new frmKhaibao();
                kb.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                frmKhaibaotreem frmKhaibaotreem = new frmKhaibaotreem();
                frmKhaibaotreem.ShowDialog();
                this.Close();
            }    
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xem hồ sơ cho bản thân(Yes)-Xem cho người khác(No)", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                frmHososk kb = new frmHososk();
                kb.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                frmHososktreem frmKhaibaotreem = new frmHososktreem();
                frmKhaibaotreem.ShowDialog();
                this.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xem lịch tiêm cho bản thân(Yes)-Xem cho người khác(No)", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                frmLichtiem kb = new frmLichtiem();
                kb.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                frmLichtiemtreem frmKhaibaotreem = new frmLichtiemtreem();
                frmKhaibaotreem.ShowDialog();
                this.Close();
            }
        }
    }
}
