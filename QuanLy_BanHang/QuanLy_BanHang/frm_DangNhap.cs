using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLy_BanHang
{
    public partial class frm_DangNhap : Form
    {
        public frm_DangNhap()
        {
            InitializeComponent();
        }

        //Lưu trạng thái đã đăng nhập hay chưa,
        public static bool _isDangNhap = false;
        //Lưu mã nhân viên hiện tại.
        public static int _MaNV;
        //Lưu tên nhân viên hiện tại.
        public static string _TenNhanVien;
        //Lưu chức vụ có phải Quản lý hay không (True / False)
        public static bool _isQuanLy;
        
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            // Khởi tạo kết nối tới CSDL SQL
            cs_KetNoi_SQL _csSQL = new cs_KetNoi_SQL();
            try
            {
                // Kiểm tra tài khoản và mật khẩu, nếu tài khoản hoặc mật khẩu để trống sẽ thông báo và dừng lại.
                string _Taikhoan = txt_TaiKhoan.Text.Trim();
                string _Matkhau = txt_MatKhau.Text.Trim();
                // Nếu tài khoản hoặc mật khẩu trống, hiển thị thông báo và dừng lại.
                if ((_Taikhoan == string.Empty) || (_Matkhau == string.Empty))
                {
                    MessageBox.Show("Hãy nhập tài khoản và mật khẩu để đăng nhập.", "Tài khoản hoặc mật khẩu trống.");
                    return;
                }
                //Tạo SQLcommand để Select từ CSDL thông tin về tài khoản và mật khẩu vừa nhập
                SqlCommand _cmd = new SqlCommand();
                //Gán câu lệnh truy vấn cho SQLCommand
                _cmd.CommandText = @"Select MaNV,TenNV,TaiKhoan,MatKhau,CapBac from tbl_NhanVien where TaiKhoan = @taikhoan AND MatKhau = @matkhau";
                //Gán các parameters tương ứng. Mục đích để tránh lỗi SQL Injection.
                _cmd.Parameters.AddWithValue("@taikhoan", _Taikhoan);
                _cmd.Parameters.AddWithValue("@matkhau", _Matkhau);
                //Gọi hàm getDataReader từ class cs_KetNoi_SQL, truyền vào tham số là SQLCommand vừa tạo.
                var _reader = _csSQL.getDataReader(_cmd);
                //Tạo một biến string trống để gán dữ liệu từ Datareader trả về vào.
                string _line = string.Empty;
                //Kiểm tra nếu Reader không có data, có nghĩa là Tài khoản và mật khẩu vừa nhập vào là sai.
                if(!_reader.HasRows)
                {
                    //Hiển thị thông báo và quay lại.
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác.", "Không tìm thấy thông tin đăng nhập.");
                    return ;
                }
                //Đọc dữ liệu từ Datareader
                while (_reader.Read())
                {
                    //Lưu các thông tin về tài khoản vào biến tạm thời.
                    string _reader_taikhoan = _reader["TaiKhoan"].ToString().Trim();
                    string _reader_matkhau = _reader["MatKhau"].ToString().Trim();
                    string _tenNV = _reader["TenNV"].ToString().Trim();
                    //Ép kiểu dữ liệu từ Bit qua Boolean. 0 = false và 1 = true
                    bool _CapBac = bool.Parse(_reader["CapBac"].ToString().Trim());
                    //Tạo biến lưu Cấp bậc.
                    string _Capbac_hientai = string.Empty;
                    /* Kiểm tra nếu biến Boolean _CapBac là True thì người dùng hiện tại là Quản Lý.
                      False thì là Nhân Viên. */
                    _Capbac_hientai = _CapBac ? "Quản Lý" : "Nhân Viên";
                    //Hiển thị thông báo chào sau khi kiểm tra thành công.
                    MessageBox.Show("Xin chào " + _Capbac_hientai + ": " + _tenNV, "Đăng nhập thành công.");
                    //Đổi trạng thái của biến _isDangNhap. Gán các giá trị mới cho Mã nhân viên, tên nhân viên và _isQuanLy.
                    _isDangNhap = true;
                    _TenNhanVien = _tenNV;
                    _isQuanLy = _CapBac;
                    _MaNV = (int)_reader["MaNV"];
                    break;
                }
                //Nếu đăng nhâp thành công, tắt Form Đăng Nhập và chuyển về lại Form1
                this.Close();
            }
            //Bắt lỗi và hiển thị thông báo lỗi.
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi khi đăng nhập tài khoản.");
            }
            //Đóng kết nối tới CSDL sau khi hoàn thành truy vấn
            finally
            {
                _csSQL._disconnect();
            }
        } 
        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            // Xóa các thông tin vừa nhập vào trên 2 Textbox
            txt_MatKhau.Clear();
            txt_TaiKhoan.Clear();
        }
    }
}
