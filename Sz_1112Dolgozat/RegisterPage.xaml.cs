using MySql.Data.MySqlClient;
using Mysqlx.Cursor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sz_1112Dolgozat
{
    public partial class RegisterPage : Window
    {
        private MainWindow _mainWindow;

        public RegisterPage(MainWindow mainWindow)
        {
            InitializeComponent();

            _mainWindow = mainWindow;

            private void regButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordRegText.Password == PasswordRegText2.Password)
            {
                var user = new
                {
                    UserName = UserNameRegText.Text,
                    Version = VersionRegText.Text,
                    Password = PasswordRegText.Password,
                    Salt = "",

                };

                MessageBox.Show(_databaseStatements.AddNewUser(user).ToString());
                _mainWindow.StartWindow.Navigate(new AdminPage(_mainWindow));
            }
            else
            {
                MessageBox.Show("Eltérő jelszavak.");
            }

        }

    }

    internal class _databaseStatements
    {
        internal static object AddNewUser(object user)
        {
            throw new NotImplementedException();
        }
    }
}
