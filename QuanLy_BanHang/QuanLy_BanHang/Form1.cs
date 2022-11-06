using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuanLy_BanHang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static byte[] _chuyen_Image_qua_Byte(Image imageIn)
        {
            //Sử dụng MemoryStream để đọc và trả về một mảng Byte
            using (var ms = new MemoryStream())
            {
                //Lưu dưới dạng RawFormat.
                imageIn.Save(ms, imageIn.RawFormat);
                //Trả về giá trị dưới dạng mảng (Byte[])
                return ms.ToArray();
            }
        }
        public static Image _chuyen_Byte_qua_Image(byte[] buffer)
        {
            //Sử dụng MemoryStream để chuyển.
            using (MemoryStream ms = new MemoryStream())
            {
                //đọc từ đầu mảng tới cuối mảng ( từ vị trí 0 tới hết độ dài của mảng )
                ms.Write(buffer.ToArray(), 0, buffer.Length);
                //Trả về giá trị Image.
                return Image.FromStream(ms);
            }
        }
        private void btn_DangNhap_Click(object sender, EventArgs e)
        {
            /* Kiểm tra trạng thái đăng nhập tại lưu tại form Đăng Nhập.
                Nếu chưa đăng nhập thì sẽ hiện form đăng nhập. */
            if (!frm_DangNhap._isDangNhap)
            {
                //Tạo 1 instance mới của form Đăng nhập
                frm_DangNhap frm = new frm_DangNhap();
                //Hiển thị form 
                frm.ShowDialog();
                // Sau khi form Đăng nhập đã tắt, kiểm tra lại trạng thái đã đăng nhập hay chưa.
                if (frm_DangNhap._isDangNhap)
                {
                    //Nếu đã đăng nhập thành công, hiển thị các phím chức năng để người dùng tương tác
                    btn_QLHangHoa.Visible = true;
                    btn_QLTaiKhoan.Visible = true;
                    /* Kiểm tra nếu người dùng hiện tại là Quản lý, sẽ cho Button Thống kê hiển thị.
                     * Đồng thời hiển thị lời chào là QL: Tên tại button Đăng Nhập */
                    if (frm_DangNhap._isQuanLy)
                    {
                        btn_DangNhap.Text = "QL: " + frm_DangNhap._TenNhanVien;
                        btn_ThongKe.Visible = true;
                    }
                    //Nếu không phải là quản lý thì sẽ chào NV: Tên
                    else
                    {
                        btn_DangNhap.Text = "NV: " + frm_DangNhap._TenNhanVien;
                    }

                    btn_BanHang.Visible = true;
                    //Gọi sự kiện nhấn phím Bán Hàng để mở giao diện bán hàng
                    btn_BanHang_Click(this, null);
                }
            }
            /* Nếu khi người dùng nhấn nút, mà trạng thái đang là Đã Đăng Nhập.
             * Có nghĩa là người dùng đang muốn đăng xuất. */
            else if (frm_DangNhap._isDangNhap)
            {
                //Hiển thị thông báo và nut bấm Yes - No để người dùng xác nhận có muốn đăng xuất hay không.
                DialogResult dr = MessageBox.Show("Bạn muốn đăng xuất ?.", "Xác nhận đăng xuất.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //Trường hợp người dùng xác nhận đăng xuất bằng nhấn Yes.
                if (dr == DialogResult.Yes)
                {
                    //Đổi text của button Đăng Nhập thành Đăng Nhập.
                    btn_DangNhap.Text = "Đăng Nhập";
                    //Đặt lại trạng thái đăng nhập tại form Đăng Nhập là false => chưa đăng nhập.
                    frm_DangNhap._isDangNhap = false;
                    //Đưa pictureBox chứa hình ảnh của cửa hàng để hiển thị ra bên ngoài.
                    pictureBox1.BringToFront();
                    //Ẩn các phím chức năng
                    btn_QLTaiKhoan.Visible = false;
                    btn_QLHangHoa.Visible = false;
                    btn_BanHang.Visible = false;
                    btn_ThongKe.Visible = false;
                }
            }
        }
        private void btn_QLTaiKhoan_Click(object sender, EventArgs e)
        {
            /* Kiểm tra nếu panel menu_TaiKhoan đang bị ẩn thì sẽ hiển thị lên.
             * Đồng thời kiểm tra chức vụ người dùng hiện tại trong form Đăng Nhập.
             * Nếu là Nhân Viên thì chỉ hiển thị Button Cập Nhật tài khoản */
            if (!pnl_menu_TaiKhoan.Visible)
            {
                //Đưa menu tài khoản lên đầu tiên, do đang bị các User Control khác che khuất.
                pnl_menu_TaiKhoan.BringToFront();
                //Hiện menu Tài khoản.
                pnl_menu_TaiKhoan.Visible = true;
                //Kiểm tra nếu thông tin lưu tại form Đăng Nhập không phải là Quản lý...
                if (!frm_DangNhap._isQuanLy)
                {
                    /* Ẩn button Thêm và Xóa tài khoản trong menu tài khoản.
                    Mục đích là để Nhân viên chỉ được cập nhật thông tin của bản thân, không được
                    can thiệp vào các tài khoản khác */
                    btn_ThemTaiKhoan.Visible = false;
                    btn_XoaTaiKhoan.Visible = false;
                    //Do ẩn 2 button Thêm và xóa, nên sẽ set lại chiều cao của menu Bán hàng = chiều cao của button Cập nhật.
                    pnl_menu_TaiKhoan.Height = btn_CapNhatTaiKhoan.Height;
                }
            }
            // Nếu Menu đang hiển thị thì sẽ ẩn đi.
            else
            {
                //Ẩn menu
                pnl_menu_TaiKhoan.Visible = false;
                //Đưa menu ra phía sau các User control khác.
                pnl_menu_TaiKhoan.SendToBack();
            }
        }
        private void btn_ThemTaiKhoan_Click(object sender, EventArgs e)
        {
            //Ẩn menu Tài Khoản sau khi click
            pnl_menu_TaiKhoan.Visible = false;
            //Khởi tạo một instance mới của quản lý tài khoản.
            frm_QL_TaiKhoan frmthem = new frm_QL_TaiKhoan();
            /* Gán giá trị _isThemTaiKhoan ở form Quản lý tài khoản = true.
            Biến này dùng để kiểm tra là hiện tại người dùng đang muốn thêm hay cập nhật tài khoản.
            Do 2 fucntion này sẽ dùng chung 1 form Quản lý tài khoản. */
            frmthem._isThemTaiKhoan = true;
            //Hiển thị form Quản lý tài khoản để tiến hành thêm tài khoản mới.
            frmthem.ShowDialog();
        }
        private void btn_CapNhatTaiKhoan_Click(object sender, EventArgs e)
        {
            //Ẩn menu Tài Khoản sau khi click
            pnl_menu_TaiKhoan.Visible = false;
            //Khởi tạo một instance mới của quản lý tài khoản.
            frm_QL_TaiKhoan frmthem = new frm_QL_TaiKhoan();
            /* Gán giá trị _isThemTaiKhoan ở form Quản lý tài khoản = true.
            Biến này dùng để kiểm tra là hiện tại người dùng đang muốn thêm hay cập nhật tài khoản.
            Do 2 fucntion này sẽ dùng chung 1 form Quản lý tài khoản. */
            frmthem._isThemTaiKhoan = false;
            //Hiển thị form Quản lý tài khoản để tiến hành cập nhật tài khoản.
            frmthem.ShowDialog();
        }
        private void btn_XoaTaiKhoan_Click(object sender, EventArgs e)
        {
            //Ẩn menu Tài Khoản sau khi click
            pnl_menu_TaiKhoan.Visible = false;
            //Khởi tạo instance mới cho form Tìm tài khoản.
            frm_Tim_TaiKhoan frm = new frm_Tim_TaiKhoan();
            /* Gán giá trị cho biến _isXoaTaiKhoan tại form Tìm tài khoản = true.
            Mục đích để khi quản lý muốn tìm tài khoản để cập nhật thì sẽ hiểu là Xóa hay muốn cập nhật thông tin cho
            tài khoản được chọn */
            frm._isXoaTaiKhoan = true;
            //Hiển thị form để tìm và xóa tài khoản.
            frm.ShowDialog();
        }
        //uc_BanHang
        private void btn_QLHangHoa_Click(object sender, EventArgs e)
        {
            //Khởi tạo một instance mới của User Control Quản lý hàng hóa.
            uc_QLHangHoa uc = new uc_QLHangHoa();
            //Gán kiểu Dock của user control QL Hàng hóa là Fill.
            uc.Dock = DockStyle.Fill;
            //Đặt User Control vào làm Control con của pannel Default ở form1.
            pnl_Default.Controls.Add(uc);
            //Đưa user control lên phía trước, hiển thị giao diện để người dùng tương tác.
            uc.BringToFront();
        }

        private void btn_BanHang_Click(object sender, EventArgs e)
        {
            //Khởi tạo một instance mới cho User control Bán Hàng
            uc_BanHang uc_banHang = new uc_BanHang();
            //Gán kiểu Dock của user control QL Hàng hóa là Fill.
            uc_banHang.Dock = DockStyle.Fill;
            //Đặt User Control vào làm Control con của pannel Default ở form1.
            pnl_Default.Controls.Add(uc_banHang);
            /* Đặt giá trị Text của label Nhân viên trong User Control là Tên nhân viên.
            Tên nhân viên này được lưu tại biến _TenNhanVien tại form Đăng Nhập. */
            uc_banHang.lbl_NhanVien.Text = frm_DangNhap._TenNhanVien;
            //Đưa user control lên phía trước, hiển thị giao diện để người dùng tương tác.
            uc_banHang.BringToFront();
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            // Khởi tạo một instance mới
            uc_ThongKe uc = new uc_ThongKe();
            //Gán style Dock cho user control
            uc.Dock = DockStyle.Fill;
            //Add User control vào pannel.
            pnl_Default.Controls.Add(uc);
            //Hiển thị User control.
            uc.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
