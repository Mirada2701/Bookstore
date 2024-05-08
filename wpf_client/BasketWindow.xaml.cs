using data_access;
using data_access.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.Logging;
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
    /// Interaction logic for BasketWindow.xaml
    /// </summary>
    public partial class BasketWindow : Window
    {
        List<Book> books;
        BookstoreDbContext db;
        string name;
        public BasketWindow(List<Book> b, BookstoreDbContext context, string name)
        {
            InitializeComponent();
            books = b;
            listBook.ItemsSource = books;
            decimal sum = 0;
            foreach (Book book in books)
            {
                sum += book.Sale_Price;
            }
            priceBlock.Text = $"You must pay : {sum} grn";
            db = context;
            this.name = name;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Processing your order...");
            var res = db.Customers.Include(c => c.Credential).Where(c => c.FullName == name);
            List<Customer>? list;// = new List<Customer>();
            list = res.ToList();
            Customer customer;
            if (list.Count > 0)
            {
                customer = list[0];
                customer.Books = new List<Book>();
                foreach (Book book in books)
                {
                    customer.Books.Add(book);
                    Thread.Sleep(50);
                }
                db.SaveChanges();
                this.Close();
            }            
        }
    }
}
