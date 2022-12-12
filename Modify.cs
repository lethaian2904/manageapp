using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing;
using System.Data;

namespace Apptiemchung
{
    internal class Modify
    {
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        SqlDataAdapter sqlDataAdapter;
        public void Modify1()
        {

        }
        public List<Dangnhap> Dangnhaps(string query)
        {
            List<Dangnhap> Dangnhaps = new List<Dangnhap>();
            using (SqlConnection sqlConnection = Ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Dangnhaps.Add(new Dangnhap(sqlDataReader.GetString(0), sqlDataReader.GetString(1)));
                }
                sqlConnection.Close();
            }
            return Dangnhaps;
        }
        public void CommandRe(string query)
        {
            using (SqlConnection sqlConnection = Ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }
        public void RCommand(string query)
        {
            using (SqlConnection sqlConnection = Ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
            }
        }
        public List<Vacxin> Vacxins(string query)
        {
            List<Vacxin> Vacxins = new List<Vacxin>();
            using (SqlConnection sqlConnection = Ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Vacxins.Add(new Vacxin(sqlDataReader.GetString(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2), sqlDataReader.GetString(3), sqlDataReader.GetString(4)));
                }
                sqlConnection.Close();
            }
            return Vacxins;
        }
        public DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = Ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dt);
                sqlDataAdapter.Dispose();
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
            return dt;
        }
        public List<Hososk> Hososks(string query)
        {
            List<Hososk> Hososks = new List<Hososk>();
            using (SqlConnection sqlConnection = Ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Hososks.Add(new Hososk(sqlDataReader.GetString(0), sqlDataReader.GetString(1), sqlDataReader.GetDateTime(2), sqlDataReader.GetString(3),
                        sqlDataReader.GetString(4), sqlDataReader.GetString(5), sqlDataReader.GetString(6), sqlDataReader.GetString(7),
                        sqlDataReader.GetString(8), sqlDataReader.GetString(9)));
                }
                sqlConnection.Close();
            }
            return Hososks;
        }
        public List<Hososktreem> hososktreems(string query)
        {
            List<Hososktreem> hososktreems = new List<Hososktreem>();
            using (SqlConnection sqlConnection = Ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    hososktreems.Add(new Hososktreem(sqlDataReader.GetString(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2),
                        sqlDataReader.GetDateTime(3), sqlDataReader.GetString(4), sqlDataReader.GetString(5), sqlDataReader.GetString(6)));
                }
                sqlConnection.Close();
            }
            return hososktreems;
        }
        public List<Lichtiem> lichtiems(string query)
        {
            List<Lichtiem> lichtiems = new List<Lichtiem>();
            using (SqlConnection sqlConnection = Ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    lichtiems.Add(new Lichtiem(sqlDataReader.GetString(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2),
                        sqlDataReader.GetDateTime(3), sqlDataReader.GetDateTime(4), sqlDataReader.GetString(5)));
                }
                sqlConnection.Close();
            }
            return lichtiems;
        }
        public List<Lichtiemtreem> lichtiemtreems(string query)
        {
            List<Lichtiemtreem> lichtiemtreems = new List<Lichtiemtreem>();
            using (SqlConnection sqlConnection = Ketnoi.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    lichtiemtreems.Add(new Lichtiemtreem(sqlDataReader.GetString(0), sqlDataReader.GetString(1), sqlDataReader.GetString(2),
                        sqlDataReader.GetDateTime(3), sqlDataReader.GetDateTime(4), sqlDataReader.GetString(5)));
                }
                sqlConnection.Close();
            }
            return lichtiemtreems;
        }
    }
}
