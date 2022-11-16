using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Apptiemchung
{
    internal class Modify
    {
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        public void Modify1()
        {

        }
        public void  Command(string query)
        {
            using (SqlConnection sqlConnection = Ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }    
        }
    }
}
