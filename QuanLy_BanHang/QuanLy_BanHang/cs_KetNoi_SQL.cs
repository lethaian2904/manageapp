using System.Data.SqlClient;
using System.Data;

namespace QuanLy_BanHang
{
    internal class cs_KetNoi_SQL
    {
        // private static string _connect_string = @"Data Source=LAPTOP-PSQC0VQB\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private static string _data_file = @"D:\Data_Proj\QuanLy_CuaHang_Cafe.mdf";
        private static string _connect_string = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_data_file};Integrated Security=True;Connect Timeout=30";
        public SqlConnection _conn;
        
        // Mở kết nối tới SQL
        public void _connect()
        {
            //Kiểm tra nếu Connection = null
            if (_conn == null)
            {
                //Khởi tạo một kết nối mới
                _conn = new SqlConnection(_connect_string);
            }
            //Nếu trạng thái hiện tại của connection là Close
            if (_conn.State == ConnectionState.Closed)
            {
                //Mở connection
                _conn.Open();
            }
        }

        // đóng kết nối
        public void _disconnect()
        {
            //Kiểm tra nếu biến _conn khác null và trạng thái là đang mở thì sẽ đóng connection lại
            if ((_conn != null) && (_conn.State == ConnectionState.Open))
            {
                _conn.Close();
            }
        }
        //Hàm trả về một datatable
        public DataTable getDataTable(string sql)
        {
            //Gọi hàm mở kết nối
            _connect();
            //Tạo một data adapter để thực hiện lưu dữ liệu từ SQL đổ về.
            SqlDataAdapter da = new SqlDataAdapter(sql, _conn);
            //Sau đó chuyển data từ data adapter qua datatable
            DataTable dt = new DataTable();
            da.Fill(dt);
            //Ngắt kết nối, trả về datatable
            _disconnect();
            return dt;
        }
        // thực thi câu lệnh truy vấn insert,delete,update
        public int ExecuteNonQuery(SqlCommand sql)
        {
            _connect();
            sql.Connection = _conn;
            int _value = sql.ExecuteNonQuery();
            _disconnect();
            return _value;
        }
        // trả về DataReader
        public SqlDataReader getDataReader(SqlCommand sql)
        {
            _connect();
            sql.Connection = _conn;
            SqlDataReader dr = sql.ExecuteReader();
            return dr;
        }
    }
}
