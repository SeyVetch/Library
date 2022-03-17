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
using Library.ClassHelper;
using Library.EF;
using System.Linq;
using Library.Windows;

namespace _13._01._22.Pages
{
    /// <summary>
    /// Логика взаимодействия для BookListPage.xaml
    /// </summary>
    public partial class BookListPage : Page
    {
        List<Book> bookList = new List<Book>();

        List<string> listSort = new List<string>() { "По умолчанию", "По фамилии", "По имени", "По адресу" };
        public BookListPage()
        {
            InitializeComponent();

            Filter();
        }


        private void Filter()
        {
            bookList = AppData.Context.Book.ToList();
            //clientList = clientList.
            //    Where(i => i.LastName.ToLower().Contains(txtSearch.Text.ToLower())
            //    || i.FirstName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();

            //switch (cmbSort.SelectedIndex)
            //{
            //    case 0:
            //        clientList = clientList.OrderBy(i => i.ID).ToList();
            //        break;

            //    case 1:
            //        clientList = clientList.OrderBy(i => i.LastName).ToList();
            //        break;

            //    case 2:
            //        clientList = clientList.OrderBy(i => i.FirstName).ToList();
            //        break;

            //    case 3:
            //        clientList = clientList.OrderBy(i => i.Address).ToList();
            //        break;

            //    default:
            //        clientList = clientList.OrderBy(i => i.ID).ToList();
            //        break;
            //}

            lvBook.ItemsSource = bookList;
        }

        private void lvReader_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete || e.Key == System.Windows.Input.Key.Back)
            {
                if (lvBook.SelectedItem is Book && lvBook.SelectedIndex != -1)
                {
                    try
                    {
                        var item = lvBook.SelectedItem as Book;
                        var resultClick = MessageBox.Show("Вы уверены?", "Подтверите Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resultClick == MessageBoxResult.Yes)
                        {
                            AppData.Context.Book.Remove(item);
                            AppData.Context.SaveChanges();
                            MessageBox.Show("Пользователь успешно удален", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                            Filter();
                        }
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }

            }

        }
        private void lvBook_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var editBook = new Book();

            if (lvBook.SelectedItem is Client)
            {
                editBook = lvBook.SelectedItem as Book;
            }

            AddBookWindow addBookWindow = new AddBookWindow(editBook);
            this.Opacity = 0.2;
            addBookWindow.ShowDialog();
            lvBook.ItemsSource = AppData.Context.Client.ToList();
            this.Opacity = 1;
        }
    }
}
