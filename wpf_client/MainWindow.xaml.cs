using data_access;
using data_access.Entities;
using Microsoft.EntityFrameworkCore;
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

namespace wpf_client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookstoreDbContext context;
        bool change;
        List<Book> books;
        string name;
        public MainWindow()
        {
            InitializeComponent();
            context = new BookstoreDbContext();
            UpdateWindow();
            comboBox.SelectedItem = "by Name Book";
            comboBox.Items.Add("by Name Book");
            comboBox.Items.Add("by Author Book");
            comboBox.Items.Add("by Genre Book");
            books = new List<Book>();
            LoginForm form = new LoginForm(context);
            form.ShowDialog();
            if (form.customer != null)
            {
                name = form.customer.FullName;
                tb.Text = name;                      
            }
            if(form.customer.Credential.Login != "admin" && form.customer.Credential.Password != "1234")
            {
                addBtn.IsEnabled = false;
                deleteBtn.IsEnabled = false;
                changeBtn.IsEnabled = false;
                writeBtn.IsEnabled = false;
            }
        }
        private void UpdateWindow()
        {            
            lb.ItemsSource = null;
            var res = context.Books.Include(b => b.Author).Include(b => b.Genre).Include(b => b.Publisher);
            lb.ItemsSource = res.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lb.ItemsSource = null;
            var res = context.Books.Include(b => b.Author)
                .Include(b => b.Genre).Include(b => b.Publisher)
                .OrderByDescending(b => b.Id).Take(3);
            lb.ItemsSource = res.ToList();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            change = false;
            Book book = new Book();
            BookWindow window = new BookWindow(context,book,change);
            window.ShowDialog();
            if(window.cb.IsChecked!=null)
            {
                context.Books.Add(book);
                context.SaveChanges();
            }
            UpdateWindow();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            context.Books.Remove((lb.SelectedItem as Book)!);
            context.SaveChanges();
            UpdateWindow();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            change = true;
            Book book = (lb.SelectedItem as Book)!;
            BookWindow window = new BookWindow(context, book,change);
            window.nameTb.Text = book.Name;
            window.authorTb.Text=book.AuthorId.ToString();
            window.publisherTb.Text=book.PublisherId.ToString();
            window.pageTb.Text = book.Count_Pages.ToString();
            window.genreTb.Text = book.GenreId.ToString();
            window.dateDp.Text = book.Publication_Year.ToString();
            window.priceTb.Text = book.Price.ToString();
            window.saleTb.Text = book.Sale_Price.ToString();
            window.cb.IsChecked = book.IsContinuation;
            window.ShowDialog();
            context.SaveChanges();
            UpdateWindow();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            WriteOffBooks write_book = new WriteOffBooks()
            {
                Name = (lb.SelectedItem as Book)!.Name,
                AuthorId = (lb.SelectedItem as Book)!.AuthorId,
                PublisherId = (lb.SelectedItem as Book)!.PublisherId,
                Count_Pages = (lb.SelectedItem as Book)!.Count_Pages,
                GenreId = (lb.SelectedItem as Book)!.GenreId,
                Publication_Year = (lb.SelectedItem as Book)!.Publication_Year,
                Price = (lb.SelectedItem as Book)!.Price,
                Sale_Price = (lb.SelectedItem as Book)!.Sale_Price,
                IsContinuation = (lb.SelectedItem as Book)!.IsContinuation
            };
            context.WriteOffBooks.Add(write_book);
            context.Books.Remove((lb.SelectedItem as Book)!);
            context.SaveChanges();
            UpdateWindow();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            lb.ItemsSource = null;
            var res = context.Books.Include(b => b.Author)
                .Include(b => b.Genre).Include(b => b.Publisher)
                .Where(b => b.Sale_Price >= 300 && b.Sale_Price <= 550).Take(3);
            lb.ItemsSource = res.ToList();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            lb.ItemsSource = null;
            var res = context.Authors.Where(g => g.Books.Count > 3);                
            lb.ItemsSource = res.ToList();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            lb.ItemsSource = null;
            var res = context.Genres.Where(g => g.Books.Count > 2);
            lb.ItemsSource = res.ToList();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {         
            if (comboBox.SelectedItem.ToString() == "by Name Book")
            {
                lb.ItemsSource = null;
                var res = context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.Publisher)
                    .Where(b => b.Name == searchTb.Text);
                lb.ItemsSource = res.ToList();
            }
            else if(comboBox.SelectedItem.ToString() == "by Author Book")
            {
                lb.ItemsSource = null;
                var res = context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.Publisher)
                    .Where(b => b.Author.Name == searchTb.Text);
                lb.ItemsSource = res.ToList();
            }
            else if(comboBox.SelectedItem.ToString() == "by Genre Book")
            {
                lb.ItemsSource = null;
                var res = context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Genre)
                    .Include(b => b.Publisher)
                    .Where(b => b.Genre.Name == searchTb.Text);
                lb.ItemsSource = res.ToList();
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            var book = lb.SelectedItem as Book;
            if (book != null)
                books.Add(book!);
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            BasketWindow basket = new BasketWindow(books,context,name);
            basket.ShowDialog();
        }
    }
}