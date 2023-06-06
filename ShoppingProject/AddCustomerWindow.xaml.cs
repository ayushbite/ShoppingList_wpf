using ShoppingProject.Model;
using SQLite;
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

namespace ShoppingProject
{
    /// <summary>
    /// Interaction logic for AddCustomerWindow.xaml
    /// </summary>
    public partial class AddCustomerWindow : Window
    {
        public AddCustomerWindow()
        {
            InitializeComponent();
        }

        private void save_customer(object sender, RoutedEventArgs e)
        {
            CustomerModel customermodelobj = new CustomerModel() {
                Customer_Id = Convert.ToInt32(customeridbox.Text),
                 Customer_Name = Convert.ToString(customernamebox.Text),
                  Customer_Credit = Convert.ToInt32(customercreditbox.Text),
                    Customer_Debit = Convert.ToInt32(customerdebitbox.Text),
            };
            using (SQLiteConnection connobj = new SQLiteConnection(App.customerdbpath))
            {
                connobj.CreateTable<CustomerModel>();
                connobj.Insert(customermodelobj);
            }
            this.Close();
        }
    }
}
