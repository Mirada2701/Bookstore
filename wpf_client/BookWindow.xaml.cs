using data_access;
using data_access.Entities;
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

namespace wpf_client
{
    /// <summary>
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        Book book;
        public BookWindow()
        {
            InitializeComponent();
            book = new Book();
        }
        public BookWindow(BookstoreDbContext context,Book b,bool change)
        {
            InitializeComponent();
            gridAuthors.ItemsSource = context.Authors.ToList();
            gridGenres.ItemsSource = context.Genres.ToList();
            gridPublishers.ItemsSource = context.Publisher.ToList();
            book = b;
            if(change)
            {
                addBtn.IsEnabled = false;
                changeBtn.IsEnabled = true;
            }
            else
            {
                changeBtn.IsEnabled = false;
                addBtn.IsEnabled = true;
            }
        }
        private void SyncWithBook()
        {
            book.Name = nameTb.Text;
            book.AuthorId = int.Parse(authorTb.Text);
            book.PublisherId = int.Parse(publisherTb.Text);
            book.Count_Pages = int.Parse(pageTb.Text);
            book.GenreId = int.Parse(genreTb.Text);
            book.Publication_Year = DateTime.Parse(dateDp.Text);
            book.Price = decimal.Parse(priceTb.Text);
            book.Sale_Price = decimal.Parse(saleTb.Text);
            book.IsContinuation = cb.IsChecked.GetValueOrDefault();
            this.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SyncWithBook();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SyncWithBook();
        }
    }
}
