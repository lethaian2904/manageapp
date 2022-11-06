using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLy_BanHang
{
    public partial class uc_ThongKe : UserControl
    {
        public uc_ThongKe()
        {
            InitializeComponent();
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            //Xóa hết các data point của Chart.
            chart1.Series["TongTien"].Points.Clear();
            //Xóa tiêu đề của Chart.
            chart1.Titles.Clear();
            //Lấy năm và tháng do người dùng chọn
            int _year = dtpk_Nam.Value.Year;
            //Tháng sẽ bằng với index của items trong combobox. ví dụ: item có index = 1 sẽ là tháng 1.
            int _month = cbb_Thang.SelectedIndex;
            
            //Khởi tạo một instance của class Kết nối.
            cs_KetNoi_SQL csSQL = new cs_KetNoi_SQL();
            //Tạo câu lệnh SQL
            string _cmd_select = string.Empty;
            //Kiểm tra nếu tháng lớn hơn 0 => người dùng chọn tháng từ 1 -> 12.
            if (_month > 0)
            {
                _cmd_select = $"Select SUM(TongTien),DAY(ThoiGian) from tbl_HoaDon where YEAR(ThoiGian) = {_year} and MONTH(ThoiGian) = {_month} GROUP BY DAY(ThoiGian)";
            }
            //Nếu tháng = 0 có nghĩa người dùng chọn xem tất cả các tháng trong năm.
            else
            {
                _cmd_select = $"Select SUM(TongTien),MONTH(THOIGIAN) from tbl_HoaDon where year(ThoiGian) = {_year} GROUP BY MONTH(ThoiGian)";
            }

            //Tạo một datatable lưu dữ liệu trả về sau khi thực hiện câu lệnh SQL
            DataTable _dt_Thongke = csSQL.getDataTable(_cmd_select);
            //Kiểm tra nếu datatable không có dữ liệu, hiển thị thông báo và dừng lại.
            if(_dt_Thongke.Rows.Count <= 0)
            {
                MessageBox.Show("Không có dữ liệu vào khoảng thời gian này.");
                return;
            }

            //lặp theo từng hàng của datatable.
            for (int i = 0; i < _dt_Thongke.Rows.Count; i++)
            {
                /* Thêm datapoint vào Chart để hiển thị lên.
                Data point X = Cell 1 =  Tổng tiền ( lệnh SUM của SQL), Data point Y = Thời gian */
                int _idx = chart1.Series["TongTien"].Points.AddXY( _dt_Thongke.Rows[i][1], _dt_Thongke.Rows[i][0].ToString().Split(',')[0]);
                //Gán nhãn cho mỗi data point
                string _labelX = _dinhdang_giatien(int.Parse(_dt_Thongke.Rows[i][0].ToString().Split(',')[0]));
                chart1.Series["TongTien"].Points[_idx].Label = $"{_labelX} VNĐ";
            }
            //Nếu tháng từ 1 -> 12
            if(_month > 0)
            {
                //Đặt tiêu đề là thống kê của tháng nào trong năm
                chart1.Titles.Add($"Thống kê theo tháng { _month} / { _year}");
                //Trục X sẽ là data của Ngày
                chart1.ChartAreas["TongTien"].AxisX.Title = "Ngày";
            }
            else
            {
                //Ngược lại, sẽ là thống kê theo năm
                chart1.Titles.Add($"Thống kê theo năm {_year}");
                //Trục X sẽ là Tháng
                chart1.ChartAreas["TongTien"].AxisX.Title = "Tháng";
            }
            //Tiêu đề trục Y là Tổng tiền
            chart1.ChartAreas["TongTien"].AxisY.Title = "Tổng Tiền (VNĐ)";
            //Tắt các vạch ô vuông ngang và dọc trong Chart để dễ xem.
            chart1.ChartAreas["TongTien"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["TongTien"].AxisY.MajorGrid.Enabled = false;
        }

        //Định dạng lại giá tiền
        private string _dinhdang_giatien(int _giatien)
        {
            string _giatien_chuyendoi = string.Format(new CultureInfo("vi-VN"), "{0:#,##0}", _giatien);
            return _giatien_chuyendoi;
        }
    }
}
