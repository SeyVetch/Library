using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _13._01._22.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        MainWindow MW;
        public MenuPage(MainWindow win)
        {
            InitializeComponent();
            this.MW = win;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Windows.AuthWindow AW = new Windows.AuthWindow();
            AW.Show();
            this.MW.Close();
        }

        private void btnBookList_Click(object sender, RoutedEventArgs e)
        {
            Page P = new Pages.BookListPage();
            this.MW.SetPage(P);
        }

        private void btnLendBook_Click(object sender, RoutedEventArgs e)
        {
            Page P = new Pages.GiveRecieveBookPage();
            this.MW.SetPage(P);
        }

        private void btnUserList_Click(object sender, RoutedEventArgs e)
        {
            Page P = new Pages.UserListPage();
            this.MW.SetPage(P);
        }

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            Page P = new Pages.AddBookPage();
            this.MW.SetPage(P);
        }
    }
}
