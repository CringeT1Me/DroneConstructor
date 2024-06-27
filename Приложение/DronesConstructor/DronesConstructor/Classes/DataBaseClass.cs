using System;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Markup;


namespace ServiceApp
{
    public class DataBaseClass
    {
        private IDbConnection connection;
        private string connectionString;
        public DataBaseClass(string _connectionString)
        {
            connectionString = _connectionString;
            connection = new SqlConnection(connectionString);
            connection.Open();
            connection.Close();
        }

        public DataTable GetTable(string queryString)
        {
            connection.Open();
            IDbCommand command = connection.CreateCommand();
            command.CommandText = queryString;
            DataTable dataTable = new DataTable();
            IDataReader dataReader = command.ExecuteReader();
            dataTable.Load(dataReader);
            connection.Close();
            return dataTable;
        }

        public string GetCell(string queryString)
        {
            return GetTable(queryString).Rows[0][0].ToString();
        }

        public void ExecuteComamnd(string queryString)
        {
            connection.Open();
            IDbCommand command = connection.CreateCommand();
            command.CommandText = queryString;
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
