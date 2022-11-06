using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace QuanLy_BanHang
{
    public partial class uc_QLHangHoa : UserControl
    {
        public uc_QLHangHoa()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void _load_dulieu_hanghoa()
        {
            /* Lấy giá tiền từ datatable ra và gán vào biến _giatien_sql.
            do khi lấy giá tiền sẽ có định dạng là 100000.000 nên sẽ tách dấu chấm ra, và lấy 
            giá trị có index là 0 trong mảng vừa tách. Giá trị đó là số tiền VNĐ dưới dạng 100000 */

            //Xóa hết dữ liệu cũ trong datagridview 
            dtgrid_HangHoa.Rows.Clear();
            //Tạo câu lệnh sqlect SQL
            string _cmd = "Select MaHang[Mã Hàng],TenHang[Tên Hàng],GiaTien[Giá Tiền] from tbl_HangHoa";
            //Khởi tạo một instace của class Kết nối
            cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
            //Lấy kết quả Datatable trả về
            dt = csSQL.getDataTable(_cmd);
            //Duyệt qua các hàng trong datatable 
            foreach (DataRow dr in dt.Rows)
            {
                //Lấy giá tiền từ datatable 
                string _giatien_sql = dr[2].ToString().Trim().Split(',')[0];
                //Chuyển đổi dịnh dạng giá tiền thành 100.000
                string _giatien = _dinhdang_giatien(int.Parse(_giatien_sql));
                // Lấy thông tin Mã Hàng, Tên Hàng trong datatable 
                string _MaHang = dr[0].ToString().Trim();
                string _tenHang = dr[1].ToString().Trim();
                //Tạo hàng mới trong datagrivew, nhập dữ liệu vào.
                dtgrid_HangHoa.Rows.Add(_MaHang, _tenHang, _giatien);
            }
        }

        
        private string _dinhdang_giatien(int _giatien)
        {
            //Khai báo định dạng và chuyển kiểu giá tiền qua 100.000
            string _giatien_chuyendoi = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", _giatien);
            //Trả về giá tiền dưới dạng string
            return _giatien_chuyendoi;
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            //Tạo một instance mới của form Thêm hàng hóa
            frm_ThemHangHoa frm = new frm_ThemHangHoa();
            /* Set giá trị của biến _trangthai của Form hàng hóa = true, có nghĩa là đang muốn
            thêm hàng hóa, giá trị này = false là đang muốn cập nhật hàng hóa */
            frm._trangthai = true;
            //Hiển thị form Thêm hàng hóa để người dùng thao tác.
            frm.ShowDialog();
            _load_dulieu_hanghoa(); //Làm mới dữ liệu sau khi thêm mới
        }
        private void uc_QLHangHoa_Load(object sender, EventArgs e)
        {
            //Gọi hàm load dữ liệu để hiển thị thông tin tất cả hàng hóa lên Datagridview
            _load_dulieu_hanghoa();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            /* Kiểm tra nếu datagridview có dữ liệu ( nghĩa là có hàng hóa trong database)
            đồng thời kiểm tra xem người dùng có chọn mặt hàng nào để cập nhật hay không bằng cách
            kiểm tra hiện Row được chọn hiện tại có index >= 0 */
            if ((dtgrid_HangHoa.Rows.Count > 0) && (dtgrid_HangHoa.CurrentRow.Index >= 0))
            {
                //Khởi tạo một instance mới cho Form Thêm hàng hóa.
                frm_ThemHangHoa frm = new frm_ThemHangHoa();
                //Set biến _trangthai của form thêm hàng hóa  = false => đang muốn cập nhật hàng hóa.
                frm._trangthai = false;
                /* Set biến _mahang_capnhat của form Thêm hàng hóa là giá trị của cell có index = 0 tại hàng đang được chọn
                của datagridview */
                frm._maHang_Capnhat = dtgrid_HangHoa.CurrentRow.Cells[0].Value.ToString().Trim();
                //Hiển thị form Thêm hàng hóa và chỉnh sửa thông tin của mã hàng đã chọn.
                frm.ShowDialog();
                _load_dulieu_hanghoa(); //Làm mới dữ liệu sau khi cập nhật.
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            /* Kiểm tra nếu datagridview có dữ liệu ( nghĩa là có hàng hóa trong database)
            đồng thời kiểm tra xem người dùng có chọn mặt hàng nào để cập nhật hay không bằng cách
            kiểm tra hiện Row được chọn hiện tại có index >= 0 */
            if ((dtgrid_HangHoa.Rows.Count > 0) && (dtgrid_HangHoa.CurrentRow.Index >= 0))
            {
                //Lấy mã hàng muốn xóa từ Cell 0 của row đang được chọn
                string _mahang = dtgrid_HangHoa.CurrentRow.Cells[0].Value.ToString().Trim();
                //Hiển thị thông báo đợi người dùng xác nhận xóa
                DialogResult dr = MessageBox.Show("Bạn muốn xóa mã hàng: " + _mahang + " ra khỏi hệ thống ?.", "Xác nhận xóa.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //Trường hợp người dùng xác nhận xóa.
                if (dr == DialogResult.Yes)
                {
                    //Khởi tạo một instance cho class Kết nối SQL
                    cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
                    //Tạo một sqlcommand
                    SqlCommand _cmd = new SqlCommand();
                    /* Xóa mã hàng trong bảng tính tiền, tránh conflict khi xóa trong bảng Hàng Hóa
                    Bởi vì Mã Hàng trong bảng Tính tiền là khóa ngoại của Mã Hàng */
                    _cmd.CommandText = "Delete from tbl_TinhTien where MaHang = @mahang";
                    _cmd.Parameters.AddWithValue("@mahang", _mahang);
                    csSQL.ExecuteNonQuery(_cmd);
                    //Gán câu lệnh và giá trị cho sqlcommand và sqlparameter
                    _cmd.CommandText = "Delete from tbl_HangHoa where MaHang = @mahang1";
                    _cmd.Parameters.AddWithValue("@mahang1", _mahang);
                    //Thực hiện câu lệnh delete và nhận kết quả trả về.
                    int _ketqua = csSQL.ExecuteNonQuery(_cmd);
                    /* Nếu kết quả trả về > 0 thì thông báo thành công.
                       Ngược lại sẽ thông báo thất bại */
                    if (_ketqua > 0)
                    {
                        MessageBox.Show("Xóa mã hàng: " + _mahang + " thành công.");
                    }
                    else
                    {
                        MessageBox.Show("Xóa mã hàng: " + _mahang + " thất bại.");
                    }
                    //Làm mới lại dữ liệu trên Datagridview bằng cách gọi hàm Load dữ liệu.
                    _load_dulieu_hanghoa();
                }
            }
        }
    }
}
