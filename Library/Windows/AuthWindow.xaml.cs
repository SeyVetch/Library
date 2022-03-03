using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Library.ClassHelper;

namespace _13._01._22.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void LogBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = LogBox.Text;
            string password = PasBox.Text;
            var userAuth = AppData.Context.Employee.ToList().FirstOrDefault(i => i.Login == login && i.Password == password);
            if (userAuth != null)
            {
                Window MW = new MainWindow();
                MW.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Пользователь с такими данными не найден!");
            }
        }
    }
}
