using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace QuanLy_BanHang
{
    public partial class frm_QL_TaiKhoan : Form
    {
        public frm_QL_TaiKhoan()
        {
            InitializeComponent();
        }
        // Kiểm tra thêm hay sửa thông tin tài khoản.
        public bool _isThemTaiKhoan;
        // Lấy mã Nhân Viên hiện tại đang đăng nhập được lưu giữ tại frm_DangNhap
        private int _MaNV_Hientai = frm_DangNhap._MaNV;
        private void btn_HinhAnh_Click(object sender, EventArgs e)
        {
            //Sử dụng OpenFileDialog để mở cửa sổ tìm kiếm File.
            using (OpenFileDialog of = new OpenFileDialog())
            {
                //Filter chỉ tìm kiếm các file hình ảnh.
                of.Filter = "Image File | *.jpg;*.png;*.bmp;*.jpeg";
                //Nếu người dùng click OK
                if (of.ShowDialog() == DialogResult.OK)
                {
                    //Gán hình ảnh cho Picture Box bằng hình ảnh người dùng chọn.
                    picbox.Image = Image.FromFile(of.FileName);
                }
            }
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            //Gọi hàm _quanly_TaiKhoan và truyền vào Mã nhân viên hiện tại.
            _quanly_TaiKhoan(_MaNV_Hientai);
        }
        private void _quanly_TaiKhoan(int _maNV)
        {
            //Biến chứa tài khoản và mật khẩu người dùng nhập vào Text box.
            string _input_taikhoan = txt_TaiKhoan.Text.Trim();
            string _matkhau = txt_MatKhau.Text.Trim();
            //Biến chứa họ tên, số điện thoại ở Textbox
            string _hoten = txt_HoTen.Text.Trim();
            string _sdt = txt_SDT.Text.Trim();
            //Biến chứa địa chỉ ở Richtext Box
            string _diachi = rtb_DiaChi.Text.Trim();
            //Biến chứa giới tính thông qua index của items được chọn trong Combobox GioiTinh
            int _gioitinh = cbb_GioiTinh.SelectedIndex;
            //Biến chứa cấp bậc thông qua index được chọn trong Combobox CapBac
            int _capbac = cbb_CapBac.SelectedIndex;
            //Tạo một mảng Byte rỗng để chứa data sau khi đổi hình ảnh sang byte[]
            byte[] _imgbyte = null;
            //Kiểm tra nếu tài khoản hoặc mật khẩu trống thì hiển thị thông báo và dừng lại.
            if ((_input_taikhoan == string.Empty) || (_matkhau == string.Empty))
            {
                MessageBox.Show("Hãy nhập tài khoản và mật khẩu.");
                return;
            }
            //Nếu họ tên trống, thông báo yêu cầu nhập họ tên và dừng lại.
            else if (_hoten == string.Empty)
            {
                MessageBox.Show("Hãy nhập họ tên nhân viên.");
                return;
            }
            /* Nếu biến giới tính hoặc cấp bậc = -1, có nghĩa là người dùng chưa lựa chọn.
                Hiển thị thông báo yêu cầu người dùng chọn và dừng lại */
            else if ((_gioitinh == -1) || (_capbac == -1))
            {
                MessageBox.Show("Hãy chọn giới tính và cấp bậc.");
                return;
            }
            //Kiểm tra nếu pictureBox có hình ảnh ( khác giá trị Null).
            if (picbox.Image != null)
            {
                //Chuyển hình ảnh của PictureBox thành Byte[] và gán vào biến _imgbyte
                _imgbyte = Form1._chuyen_Image_qua_Byte(picbox.Image);
            }

            //Khởi tạo kết nối
            cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();

            /* Khi gọi form Quản lý tài khoản đã gán giá trị cho biến _isThemTaiKhoan là True hoặc False.
             * Nếu là True = Thêm tài khoản, nếu = False là cập nhật tài khoản.
             * Biến này dùng để phân biệt 2 trường hợp thêm và cập nhật tài khoản vì 2 trường hợp này dùng chung 1 Form
             * Quản lý tài khoản */
            if (_isThemTaiKhoan) //Trường hợp thêm tài khoản mới
            {
                /* Kiểm tra tài khoản có bị trùng với tài khoản có sẵn trong CSDL không.
                 * Khởi tạo một SQLCommand mới */
                SqlCommand _ktra_taikhoan = new SqlCommand();
                //Gán câu lệnh cho SQLCommand
                _ktra_taikhoan.CommandText = @"select * from tbl_NhanVien where TaiKhoan = @taikhoan";
                //Thêm giá trị cho SQLparameters
                _ktra_taikhoan.Parameters.AddWithValue("@taikhoan", _input_taikhoan);
                //Chạy câu lệnh SQLcommand và nhận lại Datareader.
                var _data = csSQL.getDataReader(_ktra_taikhoan);
                /* Kiểm tra nếu Datareader trả về có data, có nghĩa là tài khoản này đã bị trùng.
                 Hiển thị thông báo và yêu cầu chọn tài khoản khác để thêm mới. Đồng thời dừng chương trình */
                if (_data.HasRows)
                {
                    MessageBox.Show("Hãy chọn tài khoản khác, tài khoản: " + _input_taikhoan + " đã trùng với tài khoản cũ.");
                    return;
                }
                /* Ngắt kết nối tới CSDL, vì Datareader cần giữ kết nối tới CSDL liên tục nên phải ngắt kết nối bằng hàm
                 Disconnect ở class Kết nối SQL */
                csSQL._disconnect();

                //Khởi tạo một SQLcommand
                SqlCommand _cmd = new SqlCommand();
                //Gán câu lệnh insert để thêm mới nhân viên.
                _cmd.CommandText = @"insert into tbl_NhanVien values (@tennv,@gioitinh,@diachi,@sdt,@taikhoan,@matkhau,@capbac,@hinhanh)";
                //Gán các giá trị cho các SQL Parameters đã khai báo trong câu lệnh trên.
                _cmd.Parameters.AddWithValue("@tennv", _hoten);
                _cmd.Parameters.AddWithValue("@gioitinh", _gioitinh);
                _cmd.Parameters.AddWithValue("@diachi", _diachi);
                _cmd.Parameters.AddWithValue("@sdt", _sdt);
                _cmd.Parameters.AddWithValue("@taikhoan", _input_taikhoan);
                _cmd.Parameters.AddWithValue("@matkhau", _matkhau);
                _cmd.Parameters.AddWithValue("@capbac", _capbac);
                _cmd.Parameters.AddWithValue("@hinhanh", _imgbyte);
                /* Tạo biến _add_user và nhận kết quả khi class SQL execute command phía trên.
                 nếu giá trị trả về > 0 có nghĩa là thêm mới User thành công */
                int _add_user = csSQL.ExecuteNonQuery(_cmd);
                //Kiểm tra và hiển thị thông báo thành công hoặc thất bại.
                if (_add_user > 0)
                {
                    MessageBox.Show("Thêm tài khoản: " + _input_taikhoan + " thành công.");
                }
                else
                {
                    MessageBox.Show("Thêm tài khoản thất bại. Xin hãy kiểm tra lại thông tin và thử lại.");
                }
            }
            else //Trường hợp cập nhật tài khoản (_isThemTaiKhoan = false)
            {
                //Kiểm tra tài khoản có sẵn trong CSDL không
                SqlCommand _ktra_taikhoan = new SqlCommand();
                //Gán câu lệnh Select cho SQLCommand, lấy thông tin của Mã nhân viên được tryền vào.
                _ktra_taikhoan.CommandText = @"select * from tbl_NhanVien where MaNV = @manv";
                //Gán giá trị cho SQLParameter
                _ktra_taikhoan.Parameters.AddWithValue("@manv", _maNV);
                //Tạo Datareader đọc data từ SQL trả về thông qua câu lệnh SQLCommand.
                var _data = csSQL.getDataReader(_ktra_taikhoan);
                //Kiểm tra nếu datareader không có data, thông báo mã nhân viên không tồn tại và dừng lại.
                if (!_data.HasRows)
                {
                    MessageBox.Show("Mã nhân viên: " + _maNV + " không tồn tại.");
                    return;
                }
                csSQL._disconnect(); // Đóng connection của Datareader

                //Tạo một SQLcommand
                SqlCommand _cmd = new SqlCommand();
                //Tạo câu lệnh Update
                _cmd.CommandText = @"Update tbl_NhanVien Set TenNV = @hoten, GioiTinh = @gioitinh, DiaChi = @diachi, SoDienThoai = @sdt, 
                                                TaiKhoan = @taikhoan, MatKhau = @matkhau, CapBac = @capbac, HinhAnh = @hinhanh
                                                        where MaNV = @manv";
                //Gán giá trị cho các SQLParameters
                _cmd.Parameters.AddWithValue("@manv", _maNV);
                _cmd.Parameters.AddWithValue("@hoten", _hoten);
                _cmd.Parameters.AddWithValue("@gioitinh", _gioitinh);
                _cmd.Parameters.AddWithValue("@diachi", _diachi);
                _cmd.Parameters.AddWithValue("@sdt", _sdt);
                _cmd.Parameters.AddWithValue("@taikhoan", _input_taikhoan);
                _cmd.Parameters.AddWithValue("@matkhau", _matkhau);
                _cmd.Parameters.AddWithValue("@capbac", _capbac);
                _cmd.Parameters.AddWithValue("@hinhanh", _imgbyte);
                //Thực hiện câu lệnh và nhận kết quả trả về.
                int _ketqua = csSQL.ExecuteNonQuery(_cmd);
                /* Nếu kết quả > 0 thì thông báo cập nhật thành công, sau đó gọi hàm _thongtin_Taikhoan để hiển thị giá trị mới cập nhật.
                Còn ngược lại thì thông báo cập nhật không thành công và dừng lại. */
                if (_ketqua > 0)
                {
                    MessageBox.Show("Cập nhật thông tin tài khoản: " + _input_taikhoan + " thành công.");
                    _thongtin_TaiKhoan(_maNV);
                }
                else
                {
                    MessageBox.Show("Cập thật thông tin thất bại. Xin hãy thử lại.");
                }
            }
        }

        //Lấy thông tin tài khoản thông qua mã nhân viên, sau đó điền vào Form để chỉnh sửa
        private void _thongtin_TaiKhoan(int _MaNV)
        {
            //Tạo một SQLcommand mới
            SqlCommand _cmd = new SqlCommand();
            //Tạo câu truy vấn cho sqlcommand
            _cmd.CommandText = @"Select * from tbl_NhanVien where MaNV = @manv";
            //Đặt giá trị cho Parameter
            _cmd.Parameters.AddWithValue("@manv", _MaNV);
            //Khởi tạo một instance mới của class kết nối SQL
            cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
            //Tạo một SQLDatareader để lưu thông tin trả về sau khi gọi hàm getDatareader từ class Kết nối SQL
            var _reader = csSQL.getDataReader(_cmd);
            //Kiểm tra nếu datareader trả về không có data thì sẽ hiện thông báo và dừng lại.
            if (!_reader.HasRows)
            {
                MessageBox.Show("Không có dữ liệu của mã nhân viên: " + _MaNV);
                return;
            }
            //Lặp và đọc data trong Datareader
            while (_reader.Read())
            {
                //Ghi thông tin vào ô tài khoản.
                txt_TaiKhoan.Text = _reader["TaiKhoan"].ToString().Trim();
                //Ghi thông tin vào ô Mật khẩu.
                txt_MatKhau.Text = _reader["MatKhau"].ToString().Trim();
                //Ghi thông tin vào ô Địa chỉ.
                rtb_DiaChi.Text = _reader["DiaChi"].ToString().Trim();
                //Ghi thông tin vào ô Họ tên
                txt_HoTen.Text = _reader["TenNV"].ToString().Trim();
                //Ghi thông tin vào ô Số điện thoại.
                txt_SDT.Text = _reader["SoDienThoai"].ToString().Trim();
                /* Chuyển giá trị được chọn cho combobox Giới tính.
                  ép kiểu cho giá trị Giới tính trong Datareader.
                Nếu là True = 1 thì sẽ là Nam, chọn item có index là 1 trong ComboBox.
                Nếu là False = 0 thì sẽ là Nữ, chọn item có index là 0. */
                cbb_GioiTinh.SelectedIndex = (bool)_reader["GioiTinh"] ? 1 : 0;
                // Tương tự, ép kiểu của cột CapBac trong datareader qua boolean, nếu true = Quản lý, false = Nhân viên
                cbb_CapBac.SelectedIndex = (bool)_reader["CapBac"] ? 1 : 0;
                //Kiểm tra xem HinhAnh có khác giá trị Null ( không có hình ảnh ) hay không.
                if (_reader["HinhAnh"].ToString().Trim() != string.Empty)
                {
                    //Lấy mảng byte[] của cột HinhAnh trong datareader.
                    byte[] _img = (byte[])_reader["HinhAnh"];
                    //Chuyển byte[] qua hình ảnh bằng hàm ở Form1. Sau đó gán cho Picture Box
                    picbox.Image = Form1._chuyen_Byte_qua_Image(_img);
                }
            }
            //Ngắt kết nối tới CSDL
            csSQL._disconnect();
        }
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            //Xóa các thông tin trong các Controls trên Form
            txt_HoTen.Clear();
            txt_MatKhau.Clear();
            txt_SDT.Clear();
            txt_TaiKhoan.Clear();
            rtb_DiaChi.Clear();
            // Set giá trị được chọn của 2 comboBox về -1 = không chọn giá trị nào.
            cbb_CapBac.SelectedIndex = -1;
            cbb_GioiTinh.SelectedIndex = -1;
            //Xóa hình ảnh trong PictureBox
            picbox.Image = null;
        }
        /* Hàm kiểm tra khi nhấn phím nhập vào Textbox số điện thoại.
         Nếu không phải là số thì không cho nhập */
        private void txt_SDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Kiểm tra nếu giá trị nhập vào không phải là số thì không nhận.
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void frm_ThemTaiKhoan_Load(object sender, EventArgs e)
        {
            //Kiểm tra nếu không phải là đang thêm tài khoản ( nghĩa là đang tiến hành cập nhật)
            if (!_isThemTaiKhoan)
            {
                // Kiểm tra người dùng hiện tại có phải là Quản lý hay không.
                if (frm_DangNhap._isQuanLy)
                {
                    // Nếu đúng là quản lý thì hiện button Tìm kiếm tài khoản
                    btn_TimKiem.Visible = true;
                }
                else
                {
                    /* Nếu không phải là Quản lý thì sẽ gọi hàm để lấy thông tin theo Mã nhân viên hiện tại.
                     Có nghĩa nếu là Nhân viên, thì chỉ được cập nhật thông tin của bản thân */
                    _thongtin_TaiKhoan(_MaNV_Hientai);
                }
                //Đổi text của button Thêm thành Cập nhật.
                btn_Them.Text = "Cập Nhật";
            }
        }
        //Sự kiện click của button Tìm kiếm
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            //Khởi tạo 1 instance mới cho frm_Tim_TaiKhoan
            frm_Tim_TaiKhoan frm = new frm_Tim_TaiKhoan();
            //Hiển thị form Tìm tài khoản để người dùng thao tác.
            frm.ShowDialog();
            //Sau khi form Tìm tài khoàn đã đóng lại, kiểm tra mã nhân viên được chọn
            _MaNV_Hientai = frm._maNV_duocchon;
            /* Nếu mã nhân viên > 0 thì có nghĩa là đã chọn được mã nhân viên.
             Nếu = 0 là giá trị mặc định, có nghĩa là người dùng tắt Form và không chọn tài khoản nào */
            if (_MaNV_Hientai > 0)
            {
                //Lấy thông tin tài khoản được chọn và hiển thị lên Form quản lý tài khoản.
                _thongtin_TaiKhoan(_MaNV_Hientai);
            }
        }
    }
}
