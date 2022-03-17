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
using Library.ClassHelper;

namespace Library.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddBookWindow.xaml
    /// </summary>
    public partial class AddBookWindow : Window
    {
        EF.Book editBook = new EF.Book();
        bool isEdit = false;
        public AddBookWindow()
        {
            InitializeComponent();
            cmbAuthor.ItemsSource = AppData.Context.Author.ToList();
            cmbAuthor.DisplayMemberPath = "LastName";
            cmbAuthor.SelectedIndex = 0;
            cmbSection.ItemsSource = AppData.Context.Section.ToList();
            cmbSection.DisplayMemberPath = "SectionName";
            cmbSection.SelectedIndex = 0;
            cmbPublisher.ItemsSource = AppData.Context.PublishHouse.ToList();
            cmbPublisher.DisplayMemberPath = "Name";
            cmbPublisher.SelectedIndex = 0;
        }
        public AddBookWindow(EF.Book book)
        {
            InitializeComponent();

            editBook = book;

            cmbAuthor.ItemsSource = AppData.Context.Author.ToList();
            cmbAuthor.DisplayMemberPath = "LastName";
            cmbAuthor.SelectedIndex = editBook.AuthorID - 1;
            cmbSection.ItemsSource = AppData.Context.Section.ToList();
            cmbSection.DisplayMemberPath = "SectionName";
            cmbSection.SelectedIndex = editBook.SectionID - 1;
            cmbPublisher.ItemsSource = AppData.Context.PublishHouse.ToList();
            cmbPublisher.DisplayMemberPath = "Name";
            cmbPublisher.SelectedIndex = editBook.PublishHouseID - 1;

            txtName.Text = editBook.Name;
            txtDateRelease.Text = editBook.DateRelease.Date.ToString();
            txtQtyPages.Text = editBook.PageQty.ToString();
            txtPrice.Text = editBook.Price.ToString();

            isEdit = true;
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            // Валидация

            //// проверка на пустоту
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Поле Название не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Поле Название не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbAuthor.Text))
            {
                MessageBox.Show("Поле Автор не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(cmbPublisher.Text))
            {
                MessageBox.Show("Поле Издатель не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                MessageBox.Show("Поле Цена не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtQtyPages.Text))
            {
                MessageBox.Show("Поле Кол-во траниц не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDateRelease.Text))
            {
                MessageBox.Show("Поле Дата издания не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (string.IsNullOrWhiteSpace(cmbSection.Text))
            {
                MessageBox.Show("Поле Секция не должно быть пустым", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // проверка на количество символов

            if (isEdit)
            {
                try
                {
                    editBook.Name = txtName.Text;
                    editBook.AuthorID = cmbAuthor.SelectedIndex + 1;
                    editBook.PublishHouseID = cmbPublisher.SelectedIndex + 1;
                    editBook.SectionID = cmbSection.SelectedIndex + 1;
                    editBook.DateRelease = DateTime.Parse(txtDateRelease.Text);
                    editBook.PageQty = int.Parse(txtQtyPages.Text);
                    editBook.Price = int.Parse(txtPrice.Text);

                    AppData.Context.SaveChanges();
                    MessageBox.Show("Успех", "Данные книги успешно изменены", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
            else
            {
                try
                {
                    var resultClick = MessageBox.Show("Вы уверены?", "Подтверите добавление", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (resultClick == MessageBoxResult.Yes)
                    {
                        // Добавление нового читателя
                        EF.Book newBook = new EF.Book
                        {
                            Name = txtName.Text,
                            AuthorID = cmbAuthor.SelectedIndex + 1,
                            PublishHouseID = cmbPublisher.SelectedIndex + 1,
                            SectionID = cmbSection.SelectedIndex + 1,
                            DateRelease = DateTime.Parse(txtDateRelease.Text),
                            PageQty = int.Parse(txtQtyPages.Text),
                            Price = int.Parse(txtPrice.Text)
                        };

                        AppData.Context.Book.Add(newBook);

                        AppData.Context.SaveChanges();
                        MessageBox.Show("Успех", "Книга успешно добавлена", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
