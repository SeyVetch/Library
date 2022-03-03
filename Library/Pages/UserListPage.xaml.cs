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
using Library.EF;
using Library.Windows;
using Library.ClassHelper;
using System.Linq;

namespace _13._01._22.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserListPage.xaml
    /// </summary>
    public partial class UserListPage : Page
    {

        List<Client> clientList = new List<Client>();

        List<string> listSort = new List<string>() { "По умолчанию", "По фамилии", "По имени", "По адресу" };
        public UserListPage()
        {
            InitializeComponent();

            cmbSort.ItemsSource = listSort;
            cmbSort.SelectedIndex = 0;

            Filter();
        }

        private void Filter()
        {
            clientList = AppData.Context.Client.ToList();
            clientList = clientList.
                Where(i => i.LastName.ToLower().Contains(txtSearch.Text.ToLower())
                || i.FirstName.ToLower().Contains(txtSearch.Text.ToLower())).ToList();

            switch (cmbSort.SelectedIndex)
            {
                case 0:
                    clientList.OrderBy(i => i.ID).ToList();
                    break;

                case 1:
                    clientList.OrderBy(i => i.LastName).ToList();
                    break;

                case 2:
                    clientList.OrderBy(i => i.FirstName).ToList();
                    break;

                case 3:
                    clientList.OrderBy(i => i.Address).ToList();
                    break;

                default:
                    clientList.OrderBy(i => i.ID).ToList();
                    break;
            }

            lvReader.ItemsSource = clientList;
        }
        private void btnAddReader_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClientWindow = new AddClientWindow();
            this.Opacity = 0.2;
            addClientWindow.ShowDialog();
            lvReader.ItemsSource = AppData.Context.Client.ToList();
            this.Opacity = 1;

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void lvReader_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Delete || e.Key == System.Windows.Input.Key.Back)
            {
                if (lvReader.SelectedItem is Client && lvReader.SelectedIndex != -1)
                {
                    try
                    {
                        var item = lvReader.SelectedItem as Client;
                        var resultClick = MessageBox.Show("Вы уверены?", "Подтверите Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (resultClick == MessageBoxResult.Yes)
                        {
                            AppData.Context.Client.Remove(item);
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

        private void lvReader_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var editReader = new Client();

            if (lvReader.SelectedItem is Client)
            {
                editReader = lvReader.SelectedItem as Client;
            }

            AddClientWindow addReaderWindow = new AddClientWindow(editReader);
            this.Opacity = 0.2;
            addReaderWindow.ShowDialog();
            lvReader.ItemsSource = AppData.Context.Client.ToList();
            this.Opacity = 1;
        }
    }
}
