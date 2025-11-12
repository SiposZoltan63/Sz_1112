using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sz_1112Dolgozat
{
    internal class DatabaseStatements
    {
        Connection conn = new Connection();

        public object AddNewUser(object user)
        {
            try
            {
                conn._connection.Open();
                var newUser = user.GetType().GetProperties();

                string salt = GenerateSalt();
                string hashedPassword = ComputeHmacSha256(newUser[2].GetValue(user).ToString(), salt);

                string sql = "INSERT INTO `users`(`UserName`, `Version`, `Password`, `Salt`,) VALUES (@username,@version,@password,@salt,@email)";

                MySqlCommand cmd = new MySqlCommand(sql, conn._connection);

                cmd.Parameters.AddWithValue("@username", newUser[0].GetValue(user));
                cmd.Parameters.AddWithValue("@fullname", newUser[1].GetValue(user));
                cmd.Parameters.AddWithValue("@password", hashedPassword);
                cmd.Parameters.AddWithValue("@salt", salt);

                cmd.ExecuteNonQuery();

                conn._connection.Close();

                return new { message = "Sikeres hozzáadás." };
            }
            catch (System.Exception ex)
            {
                return new { message = ex.Message };
            }

        }
        public DataView UserList()
        {
            try
            {
                conn._connection.Open();
                string sql = "SELECT `UserName`,`Version`,`Email`,`RegTime`,`ModTime` FROM `users` ";

                MySqlCommand cmd = new MySqlCommand(sql, conn._connection);

                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn._connection);

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                conn._connection.Close();

                return dt.DefaultView;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public string ComputeHmacSha256(string password, string salt)
        {
            using (var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(salt)))
            {
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hash);
            }
        }
        public string GenerateSalt()
        {
            byte[] salt = new byte[16];

            using (var rnd = RandomNumberGenerator.Create())
            {
                rnd.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        internal object DeleteUser(object userId)
        {
            throw new NotImplementedException();
        }
    }
}
