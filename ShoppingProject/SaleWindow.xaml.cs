using ShoppingProject.Model;
using SQLite;
using System;
using System.Windows;

namespace ShoppingProject
{
    /// <summary>
    /// Interaction logic for SaleWindow.xaml
    /// </summary>
    public partial class SaleWindow : Window
    {
        CustomerModel custmodelobj;
        ProductModel productmodelobj;
        int user_entered_quantity = 0;
        public SaleWindow()
        {
            InitializeComponent();
        }

        private void sale_completed(object sender, RoutedEventArgs e)
        {
            //get customer from db using cid
            using (SQLiteConnection connobj = new SQLiteConnection(App.customerdbpath))
            {
                connobj.CreateTable<CustomerModel>();
                custmodelobj = connobj.Get<CustomerModel>(Convert.ToInt32(customeridbox.Text));
            }
            //get product from db using pid
            using (SQLiteConnection connobj = new SQLiteConnection(App.productdbpath))
            {
                connobj.CreateTable<ProductModel>();
                productmodelobj = connobj.Get<ProductModel>(Convert.ToInt32(productidbox.Text));
            }
            //getting user enter quanity
            user_entered_quantity = Convert.ToInt32(quantitybox.Text);

            //comparing and removing qnty

            productmodelobj.Product_Qty = productmodelobj.Product_Qty - user_entered_quantity;

            //getting current product price and debit form   user

            custmodelobj.Customer_Debit = custmodelobj.Customer_Debit+ productmodelobj.Product_Price * user_entered_quantity;

            //removing from credit

            custmodelobj.Customer_Credit = custmodelobj.Customer_Credit - custmodelobj.Customer_Debit;


            //updating the db for product and customer
            using (SQLiteConnection connobj = new SQLiteConnection(App.customerdbpath))
            {
                connobj.CreateTable<CustomerModel>();
                connobj.Update(custmodelobj);

            }
            //updating the db for product
            using (SQLiteConnection connobj = new SQLiteConnection(App.productdbpath))
            {
                connobj.CreateTable<ProductModel>();
                connobj.Update(productmodelobj);
            }

            this.Close();



        }
    }
}
