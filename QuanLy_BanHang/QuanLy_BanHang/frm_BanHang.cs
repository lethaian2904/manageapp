using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLy_BanHang
{
    public partial class frm_BanHang : Form
    {
        public frm_BanHang()
        {
            InitializeComponent();
        }
        public int _SoHoaDon = -1; //Dùng để lưu số hóa đơn cũ nếu bàn này chỉ đặt thêm đồ.
        public int _soban;
        public Dictionary<string, int> _dict_SanPham_DuocChon = new Dictionary<string, int>();
        DataTable dt = new DataTable();
        //Kiểm tra xem có phải bấm nút xác nhận đặt hàng hay không, tránh trường hợp tắt form
        public bool _dathang = false;
        private void frm_BanHang_Load(object sender, EventArgs e)
        {
            lbl_DatHang.Text = $"Đặt hàng bàn số: {_soban}";

            _Load_SanPham();
        }

        private void _Load_SanPham()
        {
            //Load các mặt hàng có trong tbl_HangHoa và gán vào items của comboBox
            AutoCompleteStringCollection _autocpl_Source = new AutoCompleteStringCollection();
            cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
            string _cmd = "Select * from tbl_HangHoa";
            dt = csSQL.getDataTable(_cmd);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string _sanpham = dr[1].ToString().Trim();
                cbb_SanPham.Items.Add(_sanpham);
                _autocpl_Source.Add(_sanpham);
            }
        }
        //Tạo panel chứa các thông tin về mã hàng được chọn
        private Panel _sanpham_duocchon(string _mahang, string _tensp, int _soluong, Image img)
        {
            Panel pnl = new Panel();
            pnl.Name = _mahang;
            //pnl.Dock = DockStyle.Top;
            pnl.Height = 85;
            pnl.Width = 440;
            pnl.BorderStyle = BorderStyle.FixedSingle;
            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Left;
            pb.Image = img;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.FixedSingle;
            Label lbl = new Label();
            lbl.AutoSize = true;
            lbl.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            lbl.Location = new Point(107, 33);
            lbl.Name = "label1";
            lbl.Size = new Size(133, 20);
            lbl.TabIndex = 1;
            lbl.Text = _tensp;

            Label lbl2 = new Label();
            lbl2.AutoSize = true;
            lbl2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            lbl2.Location = new Point(325, 3);
            lbl2.Size = new Size(80, 20);
            lbl2.TabIndex = 2;
            lbl2.Text = "Số lượng";

            NumericUpDown mnr = new NumericUpDown();
            mnr.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            mnr.Location = new Point(330, 33);
            mnr.Name = "numericUpDown1";
            mnr.Size = new Size(61, 29);
            mnr.TabIndex = 4;
            mnr.Value = _soluong;
            mnr.Enabled = false;

            PictureBox pb_xoa = new PictureBox();
            pb_xoa.Image = Properties.Resources.del_48;
            pb_xoa.SizeMode = PictureBoxSizeMode.Zoom;
            pb_xoa.Dock = DockStyle.Right;
            pb_xoa.Width = 30;
            pb_xoa.Cursor = Cursors.Hand;
            pb_xoa.MouseClick += Pb_MouseClick;
            pb_xoa.Name = _mahang;

            pnl.Controls.Add(pb);
            pnl.Controls.Add(lbl);
            pnl.Controls.Add(lbl2);
            pnl.Controls.Add(mnr);
            pnl.Controls.Add(pb_xoa);

            return pnl;
        }

        // Xóa mã hàng và số lượng ra khỏi Dictionary khi nhấn hình ảnh xóa ở danh sách đặt hàng
        private void Pb_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn xóa sản phẩm này khỏi danh sách đặt hàng ?,", "Hủy đặt hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                PictureBox pb = sender as PictureBox;
                Panel pnl = pb.Parent as Panel;
                //Xóa mã hàng ra khỏi Dictionary.
                _dict_SanPham_DuocChon.Remove(pb.Name);
                fpnl_SanPham.Controls.Remove(pnl);
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {

            if (cbb_SanPham.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn sản phẩm.");
                return;
            }
            else if (nmr_SoLuong.Value <= 0)
            {
                MessageBox.Show("Chọn số lượng bán ra.");
                return;
            }

            int _index = cbb_SanPham.SelectedIndex;
            DataRow dr = dt.Rows[_index];
            string _MaHang = dr[0].ToString().Trim();
            int _soluong = int.Parse(nmr_SoLuong.Value.ToString());
            /*Thêm Mã Hàng và số lượng vào Dictionary
              Nếu mã hàng chưa tồn tại trong danh sách đặt hàng */
            if (!_dict_SanPham_DuocChon.Keys.Contains(_MaHang))
            {
                _dict_SanPham_DuocChon.Add(_MaHang, _soluong);
                //Hiển thị sản phẩm được chọn
                Image img = Form1._chuyen_Byte_qua_Image((byte[])dr[3]);
                Panel pnl = _sanpham_duocchon(_MaHang, cbb_SanPham.Text.Trim(), _soluong, img);
                fpnl_SanPham.Controls.Add(pnl);
            }
            /* Nếu mã hàng đã tồn tại trong Dictionary đặt hàng, cộng dồn số lượng đặt vào mã hàng ở bên dưới.
             * Sau đó cập nhật lại số lượng trong Dictionary để chuyển về form tính tiền tính ra tổng số tiền của hóa đơn */
            else
            {
                foreach (var _pnl in fpnl_SanPham.Controls.OfType<Panel>())
                {
                    if (_pnl.Name.Equals(_MaHang))
                    {
                        var _nmr = _pnl.Controls.OfType<NumericUpDown>().FirstOrDefault();
                        _nmr.Value += _soluong;
                        _dict_SanPham_DuocChon[_MaHang] = int.Parse(_nmr.Value.ToString());
                        break;
                    }
                }
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn xóa hết danh sách sản phẩm được chọn ?.", "Xóa danh sách đã đặt.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                fpnl_SanPham.Controls.Clear();
                _dict_SanPham_DuocChon.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_dict_SanPham_DuocChon.Count > 0)
            {
                DialogResult dr = MessageBox.Show("Bạn muốn xác nhận đặt hàng danh sách sản phẩm được chọn ?.", "Xác nhận đặt hàng.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    //Thay đổi trạng thái của bàn sang bận (màu vàng, giá trị 1 là true) trong tbl_Ban
                    cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
                    SqlCommand _cmd = new SqlCommand();
                    _cmd.CommandText = $"Update tbl_Ban set TrangThai = 1 where SoBan = {_soban}";
                    csSQL.ExecuteNonQuery(_cmd);
                    _dathang = true;
                    this.Close();
                }
            }
        }

        private void cbb_SanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            nmr_SoLuong.Value = 1; // Trả lại số lượng về 0 khi chọn sản phẩm khác.
        }
    }
}
