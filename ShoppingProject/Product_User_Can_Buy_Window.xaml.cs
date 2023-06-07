using ShoppingProject.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace ShoppingProject
{
    /// <summary>
    /// Interaction logic for Product_User_Can_Buy_Window.xaml
    /// </summary>
    public partial class Product_User_Can_Buy_Window : Window
    {
        int customerid;
        CustomerModel custmodelobj;
        List<ProductModel> productmodellistobj;
        List<ProductModel> customproductmodellist;
        //for list view
        ObservableCollection<ProductModel> observableproductlist;

        public Product_User_Can_Buy_Window()
        {
            InitializeComponent();
            customproductmodellist = new List<ProductModel>();
        }

        private void search_product_user_can_buy(object sender, RoutedEventArgs e)
        {
            customproductmodellist.Clear();
            //getting id 
            customerid = Convert.ToInt32(customeridbox.Text);
            //get customer from db using cid
            using (SQLiteConnection connobj = new SQLiteConnection(App.customerdbpath))
            {
                connobj.CreateTable<CustomerModel>();
                custmodelobj = connobj.Get<CustomerModel>(customerid);
            }

            //getting the customer price
            int customer_credit = custmodelobj.Customer_Credit;

            //getting all the products
            using (SQLiteConnection connobj = new SQLiteConnection(App.productdbpath))
            {
                connobj.CreateTable<ProductModel>();
                productmodellistobj = connobj.Table<ProductModel>().ToList();
            }
            //looping through product list and comparing
            foreach (ProductModel model in productmodellistobj)
            {
                if (customer_credit >= model.Product_Price)
                {
                    customproductmodellist.Add(model);
                }
            }
            observableproductlist = new ObservableCollection<ProductModel>(customproductmodellist);
            if (observableproductlist != null)
            {

                usercanbuylist.ItemsSource = observableproductlist;

            }


        }
    }
}
