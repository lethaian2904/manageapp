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
    public partial class frmHososktreem : Form
    {
        public frmHososktreem()
        {
            InitializeComponent();
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label15.Text = "";
            label16.Text = "";
        }
        Modify modify = new Modify();
        private void btnHienthi_Click(object sender, EventArgs e)
        {
            string Madinhdanh = txtMadinhdanh.Text;
            string CCCD = txtCCCD.Text;
            if(Madinhdanh.Trim() == "")
            {
                MessageBox.Show("Để kiểm tra nhanh nhất xin vui lòng nhập mã định danh");
            } 
            if(CCCD.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập CCCD để kiểm tra chính xác nhất vè thông tin");
            }  
            else
            {
                string sql = "select * from Hososktreem1 where Madinhdanh = '" + Madinhdanh + "' and CCCD = '" + CCCD + "'";
                if(modify.hososktreems(sql).Count != 0)
                {
                    label8.Text = modify.hososktreems(sql)[0].Hovaten1;
                    label9.Text = modify.hososktreems(sql)[0].Ngaysinh1.ToString();
                    label10.Text = modify.hososktreems(sql)[0].Gioitinh1;
                    label15.Text = modify.hososktreems(sql)[0].Chieucao1;
                    label16.Text = modify.hososktreems(sql)[0].Cannang1;
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
