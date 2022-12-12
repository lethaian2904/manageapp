using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Apptiemchung
{
    internal class Ketnoi
    {
        public static string stringConnection = @"Data Source=DESKTOP-8OFGL8E\HIEU;Initial Catalog=Hethongtiemchung;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }

}
