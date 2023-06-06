using ShoppingProject.Model;
using SQLite;
using System;
using System.Windows;

namespace ShoppingProject
{
    /// <summary>
    /// Interaction logic for CustomerDetailWindow.xaml
    /// </summary>
    public partial class CustomerDetailWindow : Window
    {
        CustomerModel customermodelobj;
        public CustomerDetailWindow(CustomerModel cm)
        {
            InitializeComponent();
            this.customermodelobj = cm;
            customeridbox.Text = Convert.ToString(customermodelobj.Customer_Id);
            customernamebox.Text = Convert.ToString(customermodelobj.Customer_Name);
            customercreditbox.Text = Convert.ToString(customermodelobj.Customer_Credit);
            customerdebitbox.Text = Convert.ToString(customermodelobj.Customer_Debit);

        }

        private void update_customer(object sender, RoutedEventArgs e)
        {
            customermodelobj.Customer_Id = Convert.ToInt32(customeridbox.Text);
            customermodelobj.Customer_Name = customernamebox.Text;
            customermodelobj.Customer_Credit = Convert.ToInt32(customercreditbox.Text);
            customermodelobj.Customer_Debit = Convert.ToInt32(customerdebitbox.Text);
            using (SQLiteConnection connobj = new SQLiteConnection(App.customerdbpath))
            {
                connobj.CreateTable<CustomerModel>();
                connobj.Update(customermodelobj);

            }
            this.Close();
        }

        private void delete_customer(object sender, RoutedEventArgs e)
        {

            using (SQLiteConnection connobj = new SQLiteConnection(App.customerdbpath))
            {
                connobj.CreateTable<CustomerModel>();
                connobj.Delete(customermodelobj);

            }
            this.Close();
        }
    }
}
