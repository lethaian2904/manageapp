using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLy_BanHang
{
    public partial class frm_Tim_TaiKhoan : Form
    {
        public frm_Tim_TaiKhoan()
        {
            InitializeComponent();
        }
        //Datatable dùng để lưu dữ liệu sau khi thực hiện lệnh SQL
        DataTable dt = new DataTable();
        /* Mã nhân viên được chọn, lưu mã nhân viên để từ Form Quản lý tài khoản có thể đọc
        và biết được người dùng chọn mã nhân viên nào để thực hiện cập nhật */
        public int _maNV_duocchon;
        /* Kiểm tra có phải là người dùng muốn xóa tài khoản không.
         * Form này dùng chung cho tìm và xóa tài khoản.
         * Biến này dùng để phân biệt và thực hiện chức năng tương ứng.
         * Troe = Xóa tài khoản, False = Tìm tài khoản */
        public bool _isXoaTaiKhoan = false;
        private void _load_dulieu()
        {
            //Khởi tạo một instance của class Kết nối SQL
            cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
            //Tạo câu lệnh select thông tin trong bảng Nhân viên
            string _cmd = "Select MaNV[Mã Nhân Viên],TaiKhoan[Tài Khoản],TenNV[Tên Nhân Viên] from tbl_NhanVien";
            //Thực thi lệnh select và lấy kết quả trả về là một Datatable.
            dt = csSQL.getDataTable(_cmd);
            //Kiểm tra nếu datatable trả về có data ( số hàng > 0)
            if (dt.Rows.Count > 0)
            {
                //Hiển thị datatable lên bằng cách gán Datatable là Datasouce của Datagridview.
                dtgrid_TaiKhoan.DataSource = dt;
            }
        }
        //Sự kiện Form load
        private void frm_Tim_TaiKhoan_Load(object sender, EventArgs e)
        {
            //Gọi hàm Load dữ liệu
            _load_dulieu();
        }
        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            //Kiểm tra nếu Datatable không có dữ liệu thì dừng lại.
            if (dt.Rows.Count <= 0)
            {
                return;
            }
            /* Kiểm tra nếu textbox Tài khoản không có thông tin nhập vào
            Thì sẽ gán datasouce của Datagridview = Datatable */
            if (txt_TaiKhoan.Text.Trim() == string.Empty)
            {
                dtgrid_TaiKhoan.DataSource = dt;
            }
            //Nếu textbox tài khoản có thông tin nhập vào ( không phải để trống )
            else
            {
                //Tạo biến tài khoản là thông tin trong Textbox tài khoản.
                string _taikhoan = txt_TaiKhoan.Text.Trim();
                //Tạo một datatable mới với cấu trúc các cột giống với Datatable global được khai báo từ trước.
                DataTable _data = dt.Clone();
                //Duyệt qua các hàng của Datatable global
                foreach (DataRow dr in dt.Rows)
                {
                    /* Kiểm tra Cell có index = 1 của datarow hiện tại đang được duyệt
                    có chứa thông tin được nhập vào trong Textbox Tài khoản */
                    if (dr[1].ToString().Trim().Contains(_taikhoan))
                    {
                        //Copy datarow này vào datatable mới khởi tạo.
                        _data.Rows.Add(dr.ItemArray);
                    }
                }
                /* Gán datasource của Datagridview là datatable mới khởi tạo.
                Như vậy datagridview sẽ hiển thị thông tin của các tài khoản giống hoặc gần giống với thông tin nhập vào */
                dtgrid_TaiKhoan.DataSource = _data;
            }
        }
        private void dtgrid_TaiKhoan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Kiểm tra nếu row được chọn hiện tại có index > 0 ( tránh trường hợp click vào Header)
            if (dtgrid_TaiKhoan.CurrentRow.Index >= 0)
            {
                /* Kiểm tra biến _isXoaTaiKhoan được gán giá trị khi gọi Form.
                Nếu _isXoaTaiKhoan = false thì sẽ là chọn tài khoản để tiến hành cập nhật.
                Ngược lại thì khi double click sẽ thực hiện xóa tài khoản được chọn */
                if (!_isXoaTaiKhoan) // Trường hợp = false => chọn tài khoản để cập nhật.
                {
                    //Hiển thị thông báo và chờ người dùng xác nhận.
                    DialogResult dr = MessageBox.Show("Bạn muốn chọn tài khoản: " + dtgrid_TaiKhoan.CurrentRow.Cells[1].Value.ToString().Trim() + " để tiến hành cập nhật", "Xác nhận.",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //Nếu người dùng chọn Yes
                    if (dr == DialogResult.Yes)
                    {
                        /* Lưu mã nhân viên được chọn vào biến _maNV_duocchon sau đó tắt form.
                        Bên form quản lý tài khoản sẽ đọc mã nhân viên và tiến hành lấy thông tin để cập nhật
                        thông qua Mã nhân viên này */
                        _maNV_duocchon = int.Parse(dtgrid_TaiKhoan.CurrentRow.Cells[0].Value.ToString().Trim());
                        //Đóng form.
                        this.Close();
                    }
                    //Trường hợp người dùng tắt thông báo hoặc bấm No
                    else
                    {
                        /* Set Mã nhân viên = -1, bên form Quản lý sẽ kiểm tra Mã Nhân viên > 0
                        Nếu khi người dùng tắt form và không chọn tài khoản nào, thì form quản lý cũng sẽ không
                        có thông tin mã nhân viên và sẽ không tiến hành lấy thông tin */
                        _maNV_duocchon = -1;
                        return;
                    }
                }
                //Trường hợp xóa tài khoản.
                else
                {
                    //Tạo biến mã nhân viên lấy từ Cell có index = 0 của datagridview, tại hàng đang được chọn.
                    int _MaNV = int.Parse(dtgrid_TaiKhoan.CurrentRow.Cells[0].Value.ToString().Trim());
                    //Tài khoản nằm ở cell có index = 1
                    string _TaiKhoan = dtgrid_TaiKhoan.CurrentRow.Cells[1].Value.ToString().Trim();
                    //Hiển thị thông báo chờ người dùng xác nhận muốn xóa tài khoản.
                    DialogResult dr = MessageBox.Show("Bạn chắc chắn muốn xóa tài khoản: " + _TaiKhoan + " không ?.", "Xác nhận xóa tài khoản.",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //Nếu người dùng xác nhận bằng cách bấm nút Yes
                    if (dr == DialogResult.Yes)
                    {
                        //Khởi tạo một instance của class Kết nối SQL
                        cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
                        //Tạo một sqlcommand
                        SqlCommand _cmd = new SqlCommand();
                        //Gán câu lệnh delete cho sqlcommand
                        _cmd.CommandText = "Delete from tbl_NhanVien where MaNV = " + _MaNV;
                        //Thực hiện lệnh delete và nhận kết quả trả về là số dòng được thực thi trong SQL
                        int _ketqua = csSQL.ExecuteNonQuery(_cmd);
                        /* Nếu kết quả trả về > 0 có nghĩa lệnh delete đã thực hiện thành công.
                        Hiển thị thông báo xóa thành công, sau đó load lại dữ liệu lên datagridview */
                        if (_ketqua > 0)
                        {
                            MessageBox.Show("Xóa tài khoản: " + _TaiKhoan + " thành công.");
                            _load_dulieu();
                        }
                        //Ngược lại sẽ thông báo xóa tài khoản thất bại.
                        else
                        {
                            MessageBox.Show("Xóa tài khoản: " + _TaiKhoan + " không thành công. Hãy thử lại");
                        }

                    }
                }
            }
        }
        private void btn_LamMoi_Click(object sender, EventArgs e)
        {
            //Gọi hàm Load dữ liệu để làm mới data từ SQL và hiển thị lên Datagridview
            _load_dulieu();
        }
    }
}
