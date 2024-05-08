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
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        Customer customer;
        BookstoreDbContext bookstore;
        public SignUpWindow(Customer ct, BookstoreDbContext bookstore)
        {
            InitializeComponent();
            customer = ct;
            this.bookstore = bookstore;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int id = bookstore.Customers.Count();
            customer.Id = id + 1;
            customer.FullName = fullnameTB.Text;
            customer.Address = addressTb.Text;
            customer.City = cityTb.Text;
            this.Close();
        }
    }
}
