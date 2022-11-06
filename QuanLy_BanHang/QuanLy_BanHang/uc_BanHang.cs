using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLy_BanHang
{
    public partial class uc_BanHang : UserControl
    {
        public uc_BanHang()
        {
            InitializeComponent();
        }
        //Hàm dùng để trả về một panel chứa picbox và button có tên là Số bàn được nhập vào.
        public Panel _taoban(int _soban)
        {
            //Tạo một panel mới
            Panel _pnl_Ban = new Panel();
            _pnl_Ban.Size = new Size(105, 105);
            _pnl_Ban.BorderStyle = BorderStyle.FixedSingle;
            _pnl_Ban.Name = _soban.ToString();

            //Tạo một pictureBox mới
            PictureBox pb = new PictureBox();
            pb.Dock = DockStyle.Top;
            pb.Height = 70;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Image = Properties.Resources.Table;
            pb.Name = _soban.ToString();

            //Tạo một button mới và đặt Text là Bàn + số bàn được truyền vào
            Button btn = new Button();
            btn.Text = $"Bàn {_soban}";
            btn.AutoSize = false;
            btn.Dock = DockStyle.Bottom;
            btn.Height = 30;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Name = _soban.ToString();
            btn.Click += Btn_Click;

            //Add hai control là PictureBox và Button vào trong Panel.
            _pnl_Ban.Controls.Add(pb);
            _pnl_Ban.Controls.Add(btn);
            //Trả về Panel
            return _pnl_Ban;
        }

        //Sự kiện click Button nằm trong panel Bàn.
        private void Btn_Click(object sender, EventArgs e)
        {
            //Xóa hết các hàng đang hiển thị ở datagridview
            dtgridview.Rows.Clear();
            //Chuyển các  label về giá trị trống
            lbl_TongTien.Text = string.Empty;
            lbl_HoaDon.Text = string.Empty;
            //Ép kiểu object về thành Button
            Button btn = sender as Button;
            //Lấy số bàn = text của button
            lbl_SoBan.Text = btn.Text;
            //Kiểm tra nếu Panel đang màu vàng thì bàn đó đang có khách, sẽ lấy lại danh sách đồ uống khách đã đặt
            Panel panel = btn.Parent as Panel;
            if (panel.BackColor == Color.Yellow)
            {
                cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
                SqlCommand _cmd = new SqlCommand();
                //Lấy mã hóa đơn của bàn đó từ bảng Hóa Đơn, trạng thái chưa thanh toán => đang sử dụng
                int _maHD = 0;
                SqlCommand _cmd_maHoaDon = new SqlCommand($"Select tbl_TinhTien.MaHoaDon from tbl_TinhTien, tbl_HoaDon where tbl_TinhTien.SoBan = {btn.Name}" +
                    $" AND tbl_TinhTien.MaHoaDon = tbl_HoaDon.MaHoaDon AND tbl_HoaDon.ThanhToan = 0");
                //Nhận datareader trả về
                var _rd = csSQL.getDataReader(_cmd_maHoaDon);
                while (_rd.Read())
                {
                    //Set mã hóa đơn là giá trị của cell 0 trong datareader.
                    _maHD = int.Parse(_rd[0].ToString().Trim());
                }
                //Ngắt kết nối.
                csSQL._disconnect();
                //Kiểm tra mã hóa đơn có hợp lệ hay không ( lớn hơn 0)
                if (_maHD > 0)
                {
                    //Ghi mã hóa đơn lên label Hóa đơn.
                    lbl_HoaDon.Text = _maHD.ToString();
                    //Select tất cả mặt hàng của mã hóa đơn đó
                    string _cmd_dt = $"Select tbl_HangHoa.TenHang, tbl_HangHoa.GiaTien, tbl_TinhTien.MaHang, tbl_TinhTien.SoLuong from tbl_HangHoa, tbl_TinhTien " +
                        $"where tbl_TinhTien.MaHoaDon = {_maHD} AND tbl_TinhTien.MaHang = tbl_HangHoa.MaHang";
                    //Nhận datatable trả về.
                    var _dt = csSQL.getDataTable(_cmd_dt);
                    //Tạo biến để tính tổng tiền của hóa đơn đó.
                    int _tongtien = 0;
                    //Duyệt qua tất cả các row trong datatable.
                    foreach (DataRow dr in _dt.Rows)
                    {
                        //Lấy các thông tin của từng row như Mã hàng, tên hàng, số lượng.
                        string _mahang = dr["MaHang"].ToString().Trim();
                        string _tenhang = dr["TenHang"].ToString().Trim();
                        string _soluong = dr["SoLuong"].ToString().Trim();
                        //Lấy giá tiền sẽ bằng giá tiền nhân số lượng hàng.
                        int _giatien = int.Parse(dr["GiaTien"].ToString().Split(',')[0].Trim()) * int.Parse(_soluong);
                        //Tổng tiền sẽ cộng thêm giá tiền của mặt hàng đó.
                        _tongtien += _giatien;
                        //Định dạng lại giá tiền.
                        string _giatien_string = _dinhdang_giatien(_giatien);
                        //Thêm hàng mới vào datagridview
                        dtgridview.Rows.Add(_mahang, _tenhang, _soluong, _giatien_string);
                    }
                    //Hiển thị tổng tiền của hóa đơn lên label Tổng tiền.
                    lbl_TongTien.Text = $"Tổng tiền: {_dinhdang_giatien(_tongtien)} VNĐ";
                }
            }
        }
        private void uc_BanHang_Load(object sender, EventArgs e)
        {
            int _soban = 0;
            cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandText = @"Select count(SoBan) from tbl_Ban";
            var _rd = csSQL.getDataReader(_cmd);
            while (_rd.Read())
            {
                _soban = int.Parse(_rd[0].ToString().Trim());
            }
            for (int i = 1; i <= _soban; i++)
            {
                Panel _pnl_Ban = _taoban(i);
                flpnl_Ban.Controls.Add(_pnl_Ban);
            }
            lbl_NhanVien.Text = frm_DangNhap._TenNhanVien;
            _kiemtra_trangthai_ban();

        }
        //Hàm định dạng giá tiền về kiểu: 100,000
        private string _dinhdang_giatien(int _giatien)
        {
            string _giatien_chuyendoi = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", _giatien);
            return _giatien_chuyendoi;
        }
        private void btn_DatHang_Click(object sender, EventArgs e)
        {
            //Kiểm tra đã chọn bàn hay chưa.
            if (lbl_SoBan.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Hãy chọn bàn để tiến hàng đặt hàng.");
                return;
            }
            //Lấy số bàn hiện tại.
            int _soban = int.Parse(lbl_SoBan.Text.Trim().Split(' ')[1]);
            //Tạo instance mới của form Bán hàng
            frm_BanHang frmBanHang = new frm_BanHang();
            /* Nếu hiện tại datagridview đã có data, có nghĩa là bàn này đã được đặt các món hàng khác.
             * Hiện tại là khách hàng đang gọi thêm, thì sẽ gán số bàn và số hóa đơn cho 2 biến ở Form Bán hàng để
             * khi đặt hàng xong sẽ thêm các hàng hóa mới được đặt vào mã hóa đơn có sẵn */
            frmBanHang._soban = _soban;
            if (dtgridview.Rows.Count > 0)
            {
                frmBanHang._SoHoaDon = int.Parse(lbl_HoaDon.Text);
            }
            //Show form bán hàng để người dùng thao tác
            frmBanHang.ShowDialog();
            //Kiểm tra nếu trạng thái đặt hàng = true, nếu false có nghĩa là người dùng hủy đặt hàng.
            if (frmBanHang._dathang == true)
            {
                //Lấy thông tin hàng hóa: Mã Hàng, Tên Hàng, Giá Tiền
                cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
                SqlCommand _cmd = new SqlCommand();
                //Câu lệnh SQL
                string _cmd_data = "Select MaHang,TenHang,GiaTien from tbl_HangHoa";
                DataTable dt_HangHoa = csSQL.getDataTable(_cmd_data);
                //Duyệt các mã hàng được đặt lưu trong Dictionary của Form Bán hàng
                foreach (var _key in frmBanHang._dict_SanPham_DuocChon.Keys)
                {
                    //Lấy mã hàng là key trong dictionary
                    string _mahang_dathang = _key;
                    //Lấy số lượng đặt hàng của mã hàng này là value của key trong diction
                    int _soluong_dathang = frmBanHang._dict_SanPham_DuocChon[_key];
                    //Lấy tên hàng và giá tiền
                    string _tenHang = string.Empty;
                    int _giatien = 0;
                    //Duyệt qua các hàng của datatable Hàng hóa
                    foreach (DataRow dtr in dt_HangHoa.Rows)
                    {
                        //Kiểm tra nếu mã hàng của row hiện tại trùng với mã hàng đang được đặt.
                        if (dtr[0].ToString().Trim().Equals(_mahang_dathang))
                        {
                            //Lấy giá trị tên hàng và giá tiền.
                            _tenHang = dtr[1].ToString().Trim();
                            _giatien = int.Parse(dtr[2].ToString().Trim().Split(',')[0]);
                        }
                    }

                    //Kiểm tra trong bảng đặt hàng, nếu có sẵn hàng thì cộng vào
                    bool _isCoSan = false;

                    if (dtgridview.Rows.Count > 0)
                    {
                        //Duyệt qua các hàng trong datagridview
                        for (int i = 0; i < dtgridview.Rows.Count; i++)
                        {
                            //Kiểm tra nếu mã hàng trong Datagridview trùng với mã hàng mới được đặt
                            string _mahang_cosan = dtgridview.Rows[i].Cells[0].Value.ToString().Trim();
                            if (_mahang_cosan.Equals(_mahang_dathang))
                            {
                                //Cộng dồn số lượng và tính tại tổng tiền.
                                int _soluong_cosan = int.Parse(dtgridview.Rows[i].Cells[2].Value.ToString().Trim());
                                int _tongsoluong = _soluong_cosan + _soluong_dathang;
                                int _tongtien = _tongsoluong * _giatien;
                                string _dinhdanggiatien = _dinhdang_giatien(_tongtien);
                                //Update giá trị mới vào ROw hiện tại của datagridview
                                dtgridview.Rows[i].SetValues(_mahang_cosan, _tenHang, _tongsoluong, _dinhdanggiatien);
                                _isCoSan = true;
                            }
                        }
                    }
                    //Trường hợp mã hàng chưa tồn tại trong Datagridview
                    if (_isCoSan == false)
                    {
                        //Thêm mới một row vào datagridview với các giá trị mới: mã hàng, tên hàng, số lượng, gái tiền.
                        int _giatien_dathang = _soluong_dathang * _giatien;
                        string _dinhdangGiatien = _dinhdang_giatien(_giatien_dathang);
                        dtgridview.Rows.Add(_mahang_dathang, _tenHang, _soluong_dathang, _dinhdangGiatien);
                    }
                }
                //Tính lại tổng tiền
                int _tongtien_hoadon = 0;
                //Duyệt qua các hàng trong datagridview và cộng lại số tiền trong cell 3 ( column giá tiền)
                for (int i = 0; i < dtgridview.Rows.Count; i++)
                {
                    _tongtien_hoadon += int.Parse(dtgridview.Rows[i].Cells[3].Value.ToString().Replace(".", "").Trim());
                }
                //Hiển thị tổng tiền của hóa đơn lên label Tổng tiền
                string _dinhdang_tonghoadon = _dinhdang_giatien(_tongtien_hoadon);
                lbl_TongTien.Text = $"Tổng tiền: {_dinhdang_tonghoadon} VNĐ";

                //Trường hợp đặt mới, chưa có hóa đơn ( bàn đang trống )
                if (lbl_HoaDon.Text == string.Empty)
                {
                    /* Tạo số hóa đơn bằng cách nhập thông tin mới vào table Hóa đơn, Mã hóa đơn mới sẽ được tự tạo ra
                    do auto-indentity trong SQL, sau đó lấy Max của bảng Mã hóa đơn sẽ là mã hóa đơn mới nhất */
                    int _sohoadon = 0;
                    _cmd.CommandText = $"insert into tbl_HoaDon (MaNV,ThanhToan) values ({frm_DangNhap._MaNV},0)";
                    //Thực hiện câu lệnh insert và kiểm tra giá trị trả về
                    int _kq_insert = csSQL.ExecuteNonQuery(_cmd);
                    if (_kq_insert > 0)
                    {
                        //Lấy Max của cột Mã hóa đơn trong bảng Hóa đơn
                        _cmd.CommandText = $"select Max(MaHoaDon) from tbl_HoaDon";
                        //Trả về một datareader
                        var _rd = csSQL.getDataReader(_cmd);
                        while (_rd.Read())
                        {
                            //Gán giá trị cho biến _sohoadon = cell 0 trong datareader.
                            _sohoadon = (int)_rd[0];
                        }
                        //Ngắt kết nối SQL
                        csSQL._disconnect();
                    }
                    //Hiển thị số hóa đơn lên label Hóa đơn trên form
                    lbl_HoaDon.Text = _sohoadon.ToString();
                }
                //Ghi vào bảng tính tiền để lưu data
                //Duyệt qua tất cả các hàng trong datagridview
                foreach (DataGridViewRow dtr in dtgridview.Rows)
                {
                    //Lấy mã hàng, số lượng của hàng hiện tại
                    string _mahang = dtr.Cells[0].Value.ToString().Trim();
                    int _soluong = int.Parse(dtr.Cells[2].Value.ToString().Trim());
                    //Tạo một SQLcommand select dựa theo mã hóa đơn và mã hàng
                    _cmd.CommandText = $"Select * from tbl_TinhTien where MaHoaDon = {lbl_HoaDon.Text} and MaHang = '{_mahang}' and SoBan = {_soban}";
                    //Trả về một datareader
                    var dr = csSQL.getDataReader(_cmd);
                    if (dr.HasRows) //mã hàng này tồn tại, cần cộng dồn
                    {
                        csSQL._disconnect();
                        //Tạo câu lệnh update
                        _cmd.CommandText = $"update tbl_TinhTien set SoLuong = {_soluong} where MaHoaDon = {lbl_HoaDon.Text} and MaHang = '{_mahang}' and SoBan = {_soban}";
                        //Update và nhận kết quả trả về
                        int _kq_update = csSQL.ExecuteNonQuery(_cmd);
                        //Thông báo nếu update số lượng đặt hàng của mã hàng không thành công.
                        if (_kq_update <= 0)
                        {
                            MessageBox.Show($"Cập nhật mã hàng: {_mahang}, số lượng: {_soluong} không thành công.");
                        }
                    }
                    //Trường hợp mã hàng chưa được đặt trong mã hóa đơn này,
                    else
                    {
                        csSQL._disconnect();
                        //Tạo câu lệnh insert mã hàng vào mã hóa đơn này.
                        _cmd.CommandText = $"insert into tbl_TinhTien (MaHoaDon,MaHang,SoLuong,SoBan) values ({lbl_HoaDon.Text},'{_mahang}',{_soluong},{_soban})";
                        //Kiểm tra kết quả trả về và thông báo nếu không thành công.
                        int kq = csSQL.ExecuteNonQuery(_cmd);
                        if (kq <= 0)
                        {
                            MessageBox.Show($"Thêm mới mã hàng {_mahang} không thành công. Hãy thử lại.");
                        }
                    }
                }
                //Đặt trạng thái bàn sang 1 => có khách.
                //Duyệt qua các control trong flow layout panel
                foreach (var control in flpnl_Ban.Controls)
                {
                    //Ép kiểu control về dạng Panel
                    Panel p = control as Panel;
                    //Kiểm tra nếu panel đó có tên là số bàn đang muốn chuyển trạng thái
                    if (p.Name == _soban.ToString())
                    {
                        //Chuyển màu nền của panel thành màu vàng => có khách
                        p.BackColor = Color.Yellow;
                        //Câu lệnh SQL update giá trị TrangThai trong bảng Bàn trong SQL thành 1
                        _cmd.CommandText = $"update tbl_Ban set TrangThai = 1 where SoBan = {_soban}";
                        //Thực thi câu lệnh SQL và kiểm tra kết quả trả về.
                        int _kq = csSQL.ExecuteNonQuery(_cmd);
                        if (_kq <= 0)
                        {
                            MessageBox.Show("Chuyển trạng thái bàn không thành công.");
                        }
                    }
                }
                //Làm mới lại trạng thái của tất cả các bàn trong flow layout panel bằng cách gọi hàm.
                _kiemtra_trangthai_ban();
            }
        }

        //Kiểm tra nếu bàn đã có khách thì đổi màu vàng.
        private void _kiemtra_trangthai_ban()
        {
            //Tạo một instance của class Kết nối SQL
            cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
            //Tạo một câu lệnh SQL và gán lệnh select
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandText = "select * from tbl_Ban";

            //Nhận về một datareader sau khi select
            var _rd = csSQL.getDataReader(_cmd);
            //Duyệt qua các hàng của Datareader
            while (_rd.Read())
            {
                //lấy số bàn của hàng hiện tại là cell 0 của datareader
                string _soban_sql = _rd[0].ToString().Trim();
                //Lấy trạng thái của hàng hiện tại là cell 1 của datareader
                bool _trangthai = bool.Parse(_rd[1].ToString().Trim());
                //Duyệt qua tất cả các bàn trong flow layout panel Bàn
                foreach (var _control in flpnl_Ban.Controls)
                {
                    //Ép kiểu control là Panel
                    Panel p = _control as Panel;
                    //Lấy tên của Panel chính là số bàn
                    string _soban = p.Name;
                    //Kiểm tra nếu số bàn vừa lấy ra từ Datareader = số bàn đang duyệt trong flow layout panel
                    if (_soban_sql == _soban)
                    {
                        //Nếu trạng thái trong SQL alf true => đang có khách, chuyển thành màu vàng
                        if (_trangthai)
                        {
                            p.BackColor = Color.Yellow;
                        }
                        //Ngược lại thì trả về giá trị Background trong suốt.
                        else
                        {
                            p.BackColor = Color.Transparent;
                        }
                    }
                }
            }
            //Ngắt kết nối SQL
            csSQL._disconnect();
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            //Set trạng thái bàn về 0, thanh toán = 1
            //Lấy số bàn cần thanh toán
            int _soban = int.Parse(lbl_SoBan.Text.Split(' ')[1]);
            //Lấy tổng tiền thanh toán
            int _tongtien = int.Parse(lbl_TongTien.Text.Split(':')[1].Trim().Split(' ')[0].Trim().Replace(".", ""));

            //Tạo instance của class Kết nối
            cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
            //Tạo sqlcommand và gán lệnh update
            SqlCommand _cmd = new SqlCommand();
            //update tổng tiền và trạng thái thanh toán, thời gian thanh toán cho mã hóa đơn hiện tại.
            _cmd.CommandText = $"update tbl_HoaDon set TongTien = {_tongtien},ThanhToan = 1,ThoiGian = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' where MaHoaDon = '{lbl_HoaDon.Text.Trim()}'";
            int _ketqua2 = csSQL.ExecuteNonQuery(_cmd);
            //Update trạng thái bàn từ 1 về 0 ( không có khách )
            _cmd.CommandText = $"update tbl_Ban set TrangThai = 0 where SoBan = '{_soban}'";
            int _ketqua = csSQL.ExecuteNonQuery(_cmd);
            /* Kiểm tra kết quả trả về và thông báo thành công, làm mới lại các bàn bằng hàm _kiemtra_trangthai_ban
                đồng thời xóa dữ liệu cũ ở trên datagridview */
            if ((_ketqua > 0) && (_ketqua2 > 0))
            {
                MessageBox.Show("Thanh toán thành công");
                _kiemtra_trangthai_ban();
                lbl_HoaDon.Text = string.Empty;
                lbl_TongTien.Text = string.Empty;
                dtgridview.Rows.Clear();
            }
        }
    }
}
