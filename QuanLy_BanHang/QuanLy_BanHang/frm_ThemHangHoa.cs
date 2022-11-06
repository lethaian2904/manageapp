using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.Drawing;

namespace QuanLy_BanHang
{
    public partial class frm_ThemHangHoa : Form
    {
        public frm_ThemHangHoa()
        {
            InitializeComponent();
        }
        //Dùng để kiểm tra trạng thái là thêm mới hay cập nhật
        public bool _trangthai;
        //Giá trị của mã hàng sẽ cập nhật
        public string _maHang_Capnhat;
        private void frm_ThemHangHoa_Load(object sender, EventArgs e)
        {
            /* Kiểm tra nếu biến _trangthai được set là True thì label Trạng thái sẽ là Thêm Hàng Hóa
            Ngược lại thì có nghĩa đang tiến hành sửa thông tin hàng hóa */
            lbl_trangthai.Text = _trangthai ? "Thêm Hàng Hóa" : "Sửa Hàng Hóa";
            //Tương tự, đổi chữ cho button Xác nhận là thêm mới (_trangthai = true) hoặc Cập nhật (_trangthai = false)
            btn_XacNhan.Text = _trangthai ? "Thêm   " : "Cập Nhật  ";
            /* Nếu thêm mới, sẽ cho phép người dùng nhập dữ liệu vào Textbox Mã hàng.
             * Còn nếu cập nhật, mã hàng sẽ không được thay đổi nên sẽ không enable Textbox mã hàng lên */
            txt_MaHang.Enabled = _trangthai ? true : false;
            //Nếu thêm mới thì textbox mã hàng để trống. Nếu cập nhật thì sẽ ghi mã hàng đang muốn cập nhật vào Textbox
            txt_MaHang.Text = _trangthai ? "" : _maHang_Capnhat;
            /* Kiểm tra nếu _trangthai = false => đang muốn cập nhật.
            Select thông tin hàng hóa dựa theo mã hàng, hiển thị lên form để người dùng thao tác sửa thông tin */
            if (!_trangthai)
            {
                //Tạo một sqlCommand
                SqlCommand _cmd = new SqlCommand();
                //Gán câu lệnh select
                _cmd.CommandText = "Select * from tbl_HangHoa where MaHang = @mahang";
                //Gán giá trị cho sqlparameter
                _cmd.Parameters.AddWithValue("@mahang", _maHang_Capnhat);
                //Khởi tạo một instance mới của class Kết nối
                cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
                //Nhận một datareader trả về khi thực hiện lệnh SQL
                var _rd = csSQL.getDataReader(_cmd);
                while (_rd.Read())
                {
                    //Gán các giá trị trong datareader vào textbox tương ứng.
                    txt_TenHang.Text = _rd["TenHang"].ToString().Trim();
                    //Do giá tiền có dạng 100000.000 nên sẽ tách dấu . và lấy index 0 từ mảng string vừa tách.
                    txt_GiaTien.Text = _rd["GiaTien"].ToString().Trim().Split('.')[0];
                    /* Gán hình ảnh cho PictureBox bằng cách gọi hàm Chuyển byte qua image từ form 1, truyền vào
                    tham số là giá trị của cột Hình Ảnh trong datareader */
                    pb.Image = Form1._chuyen_Byte_qua_Image((byte[])_rd["HinhAnh"]);
                }
            }
            else
            {
                //Nếu là thêm mới, thì hiển thị hình ảnh mặc định lên picturebox.
                pb.Image = Properties.Resources.Coffee;
            }
        }
        /* Kiểm tra mã hàng nhập vào có bị trùng với mã hàng có sẵn trong Database hay không.
        Bởi vì mã hàng trong Database là Primary Key nên không thể bị trùng */
        private bool _kiemtra_MaHang(string _mahang)
        {
            //Khởi tạo một instance cho class Kết nối
            cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
            //Tạo một câu lệnh SQL select thông tin dựa theo mã hàng và gán giá trị cho parameter.
            SqlCommand _cmd = new SqlCommand();
            _cmd.CommandText = "Select * from tbl_HangHoa where MaHang = @mahang";
            _cmd.Parameters.AddWithValue("@mahang", _mahang);
            //Nhận kết quả trả về là một datareader.
            var _rd = csSQL.getDataReader(_cmd);
            /* Nếu datareader trả về có data (có row) thì có nghĩa mã hàng đó đã tồn tại trên hệ thống.
             * Còn không thì mã hàng đó chưa tồn tại, có thể sử dụng để thêm mới */
            if (_rd.HasRows)
            {
                csSQL._disconnect();
                return true;
            }
            else
            {
                csSQL._disconnect();
                return false;
            }
        }
        private void btn_XacNhan_Click(object sender, EventArgs e)
        {
            //Tạo các biến lưu trữ thông tin của mã hàng, tên hàng, giá tiền, hình ảnh.
            string _mahang = txt_MaHang.Text.Trim();
            string _tenhang = txt_TenHang.Text.Trim();
            //Xóa dấu phẩy giữa các số để nhập vào SQL.
            string _giatien = txt_GiaTien.Text.Trim().Replace(",", "");
            //Chuyển hình ảnh qua mảng Byte để nhập vào SQL
            byte[] _hinhanh = Form1._chuyen_Image_qua_Byte(pb.Image);
            //Kiểm tra nếu thông tin nhập vào chưa đầy đủ sẽ hiện thông báo và dừng lại.
            if ((_mahang == string.Empty) || (_tenhang == string.Empty) || (_giatien == string.Empty))
            {
                MessageBox.Show("Hãy nhập đầy đủ thông tin hàng hóa.");
                return;
            }
            if (_trangthai) // Trạng thái = true là thêm mới hàng hóa
            {
                /* dùng hàm Kiểm tra mã hàng, nếu kết quả trả về = true => mã hàng đã tồn tại.
                Hiển thị thông báo yêu cầu nhập lại */
                if (_kiemtra_MaHang(_mahang))
                {
                    MessageBox.Show("Không thể thêm mới, mã hàng này đã tồn tại");
                    return;
                }
                //Tạo một instance class Kết nối
                cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
                //Tạo câu lệnh SQL insert và gán giá trị cho các parameter 
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandText = "insert into tbl_HangHoa values (@mahang,@tenhang,@giatien,@hinhanh)";
                _cmd.Parameters.AddWithValue("@mahang", _mahang);
                _cmd.Parameters.AddWithValue("@tenhang", _tenhang);
                _cmd.Parameters.AddWithValue("@giatien", _giatien);
                _cmd.Parameters.AddWithValue("@hinhanh", _hinhanh);
                //Nhận kết quả trả về sau khi thực hiện lệnh SQL dưới dạng số.
                int _ketqua = csSQL.ExecuteNonQuery(_cmd);
                /* Nếu kết quả trả về > 0 có nghĩa là lệnh Insert đã thành công.
                Ngược lại thì lệnh insert thất bại. Hiển thị thông báo thành công hoặc thất bại theo các trường hợp */
                if (_ketqua > 0)
                {
                    MessageBox.Show("Thêm mặt hàng:  " + _tenhang + " thành công.");
                }
                else
                {
                    MessageBox.Show("Thêm hàng hóa thất bại");
                }
            }
            //Trường hợp cập nhật thông tin hàng hóa
            else
            {
                //Khởi tạo một instance
                cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
                //Tạo câu lệnh SQL update và gán các giá trị cho parameter.
                SqlCommand _cmd = new SqlCommand();
                _cmd.CommandText = "Update tbl_HangHoa set TenHang = @tenhang, GiaTien = @giatien where MaHang = @mahang";
                _cmd.Parameters.AddWithValue("@mahang", _mahang);
                _cmd.Parameters.AddWithValue("@tenhang", _tenhang);
                _cmd.Parameters.AddWithValue("@giatien", _giatien);
                //Nhận kết quả trả về khi thực hiện câu lệnh sql
                int _ketqua = csSQL.ExecuteNonQuery(_cmd);
                //Kết quả > 0 có nghĩa là thành công, hiển thị thông báo
                if (_ketqua > 0)
                {
                    MessageBox.Show("Cập nhật mã hàng: " + _mahang + " thành công.");
                }
                //Ngược lại, hiển thị thông báo thất bại.
                else
                {
                    MessageBox.Show("Cập nhật thất bại. Xin hãy kiểm tra lại.");
                }
            }
        }

        //Sự kiện textchanged của textbox giá tiền, dùng để định dạng số tiền theo kiểu: 100,000
        private void txt_GiaTien_TextChanged(object sender, EventArgs e)
        {
            //Kiểm tra nếu textbox có kí tự ( không phải empty)
            if (txt_GiaTien.Text.Trim() != string.Empty)
            {
                //Khai báo và định dạng lại giá tiền
                CultureInfo culture = new CultureInfo("en-US");
                decimal value = decimal.Parse(txt_GiaTien.Text.Trim().Replace(",", "."), NumberStyles.AllowThousands);
                txt_GiaTien.Text = String.Format(culture, "{0:N0}", value);
                txt_GiaTien.Select(txt_GiaTien.Text.Trim().Length, 0);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            //Xóa các thông tin hiển thị trên texbox
            txt_TenHang.Clear();
            txt_GiaTien.Clear();
            /* Nếu trạng thái là True =  thêm mặt hàng, thì mã hàng sẽ xóa để thêm mã khác,
            nếu False là đang cập nhạt, giữ nguyên mã hàng. */
            if (_trangthai)
            {
                txt_MaHang.Clear();
            }
            //Gán lại hình ảnh mặc định cho picturebox
            pb.Image = Properties.Resources.Coffee;
        }

        private void txt_GiaTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Kiểm tra nếu giá trị nhập vào không phải là số hoặc không phải là phím BackSpace( phím xóa ) thì không chấp nhận.
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void btn_hinhanh_Click(object sender, EventArgs e)
        {
            //Tìm kiếm hình ảnh và hiển thị lên Picturebox bằng OpenFileDialog
            using (OpenFileDialog of = new OpenFileDialog())
            {
                //Filter loại File là Image.
                of.FileName = "Image | *.jpg; *.png; *.bmp; *.jpeg";
                if (of.ShowDialog() == DialogResult.OK)
                {
                    pb.Image = Image.FromFile(of.FileName);
                }
            }
        }
    }

}
