using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class AdminPage : Window
    {
        private readonly DatabaseStatements _databaseStatements = new DatabaseStatements();
        private readonly MainWindow _mainWindow;
        public AdminPage()
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            FelhasznaloDataGrid.ItemsSource = _databaseStatements.UserList();
        }

        public AdminPage(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        private void Delete_button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var id = DeleteBoxText.Text;
            var userId = new
            {
                Id = id,
            };
            MessageBox.Show(_databaseStatements.DeleteUser(userId).ToString());
            FelhasznaloDataGrid.ItemsSource = _databaseStatements.UserList();
        }
    }
}
