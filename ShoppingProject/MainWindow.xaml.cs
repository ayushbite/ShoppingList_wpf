using Newtonsoft.Json;
using ShoppingProject.Model;
using SQLite;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;

namespace ShoppingProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<CustomerModel> customerlist;
        List<ProductModel> productlist;
        List<CustomerModel> customerlistjson;
        List<ProductModel> productlistjson;
        public MainWindow()
        {
            InitializeComponent();
           customerlist = new List<CustomerModel>();
            productlist = new List<ProductModel>();
            readdb();
        }

        private void add_customer(object sender, RoutedEventArgs e)
        {
            AddCustomerWindow addcustomerobj = new AddCustomerWindow();
            addcustomerobj.ShowDialog();
            readdb();
        }

        private void add_product(object sender, RoutedEventArgs e)
        {
            AddProductWindow addproductobj = new AddProductWindow();
            addproductobj.ShowDialog();
            readdb();
        }
        public void readdb()
        {
            //for customer
            using (SQLiteConnection connobj = new SQLiteConnection(App.customerdbpath))
            {
                connobj.CreateTable<CustomerModel>();
                customerlist = connobj.Table<CustomerModel>().ToList();
            }
            if (customerlist != null)
            {

                customer_listview.ItemsSource = customerlist;
            }

            //for products
            using (SQLiteConnection connobj = new SQLiteConnection(App.productdbpath))
            {
                connobj.CreateTable<ProductModel>();
                productlist = (connobj.Table<ProductModel>().ToList()).ToList();
            }
            if (productlist != null)
            {

                product_listview.ItemsSource = productlist;
            }
        }

        private void customer_selected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            CustomerModel selectedcustomer = customer_listview.SelectedItem as CustomerModel;
            //it means it is selected
            if (selectedcustomer != null)
            {
                CustomerDetailWindow contactdetailwindowobj = new CustomerDetailWindow(selectedcustomer);
                contactdetailwindowobj.ShowDialog();
                readdb();
            }
        }

        private void product_selected(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ProductModel selectedproduct = product_listview.SelectedItem as ProductModel;
            //it means it is selected
            if (selectedproduct != null)
            {
                ProductDetailWindow productdetailwindowobj = new ProductDetailWindow(selectedproduct);
                productdetailwindowobj.ShowDialog();
                readdb();
            }

        }

        private void save_customer_json(object sender, RoutedEventArgs e)
        {
            //for customer
            using (SQLiteConnection connobj = new SQLiteConnection(App.customerdbpath))
            {
                connobj.CreateTable<CustomerModel>();
                customerlistjson = connobj.Table<CustomerModel>().ToList();
            }
            string customerjson = JsonConvert.SerializeObject(customerlistjson, Formatting.Indented);
            FileStream fs = new FileStream(App.folderpath+"\\customer.json", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(customerjson);
            sw.Close();
            fs.Close();
            MessageBox.Show("written sucessfully");
        }

        private void save_product_json(object sender, RoutedEventArgs e)
        {
            //for PRODUCT
            using (SQLiteConnection connobj = new SQLiteConnection(App.productdbpath))
            {
                connobj.CreateTable<ProductModel>();
                productlistjson = connobj.Table<ProductModel>().ToList();
            }
            string productjson = JsonConvert.SerializeObject(productlistjson, Formatting.Indented);
            FileStream fs = new FileStream(App.folderpath + "\\product.json", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(productjson);
            sw.Close();
            fs.Close();
            MessageBox.Show("written sucessfully");
           
        }

        private void sale(object sender, RoutedEventArgs e)
        {
            SaleWindow swobj = new SaleWindow();
            swobj.ShowDialog();
            readdb();
        }

        private void user_can_buy_check(object sender, RoutedEventArgs e)
        {
            Product_User_Can_Buy_Window obj = new Product_User_Can_Buy_Window();
            obj.ShowDialog();
            readdb();
        }
    }
  
}
