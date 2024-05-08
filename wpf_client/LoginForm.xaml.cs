using data_access;
using data_access.Entities;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        BookstoreDbContext context;
        public Customer customer { get; set; }
         
        public LoginForm()
        {
            InitializeComponent();
            context = new BookstoreDbContext();
            customer = new Customer();
        }
        public LoginForm(BookstoreDbContext context)
        {
            InitializeComponent();
            this.context = context;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordTextBox.Text;
            var res = context.Customers.Include(c => c.Credential).Where(c => c.Credential.Login == login && c.Credential.Password == password);
            List<Customer>? list;// = new List<Customer>();
            list = res.ToList();
            if (list.Count > 0)
            {
                customer = list[0];
                this.Close();
            }
            else
                MessageBox.Show("Wrong entered data!!!");                     
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Customer ct = new Customer();
            SignUpWindow signUp = new SignUpWindow(ct,context);
            signUp.ShowDialog();
            context.Customers.Add(ct);
            context.SaveChanges();
        }
    }
}
