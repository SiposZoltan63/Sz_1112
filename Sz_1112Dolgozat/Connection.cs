using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sz_1112Dolgozat
{
    internal class Connection
    {
        public MySqlConnection _connection;

        private string _host;
        private string _db;
        private string _user;
        private string _password;

        private string _connectionString;
        public Connection() 
        {
            _host = "localhost";
            _db = "application";
            _user = "root";
            _password = "";

            _connectionString = $"SERVER={_host};DATABASE={_db};UID={_user};PASSWORD={_password};SslMode=None";

            _connection = new MySqlConnection(_connectionString);
        }
    }
}
