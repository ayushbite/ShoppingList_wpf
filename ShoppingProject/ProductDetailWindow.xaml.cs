using ShoppingProject.Model;
using SQLite;
using System;
using System.Windows;

namespace ShoppingProject
{
    /// <summary>
    /// Interaction logic for ProductDetailWindow.xaml
    /// </summary>
    public partial class ProductDetailWindow : Window
    {
        ProductModel productmodelobj;
        public ProductDetailWindow(ProductModel pm)
        {
            InitializeComponent();
            this.productmodelobj = pm;
            productidbox.Text = Convert.ToString(productmodelobj.Product_Id);
            productnamebox.Text = Convert.ToString(productmodelobj.Product_Name);
            productpricebox.Text = Convert.ToString(productmodelobj.Product_Price);
            productqtybox.Text = Convert.ToString(productmodelobj.Product_Qty);

        }

        private void update_product(object sender, RoutedEventArgs e)
        {
            productmodelobj.Product_Id = Convert.ToInt32(productidbox.Text);
            productmodelobj.Product_Name = productnamebox.Text;
            productmodelobj.Product_Price = Convert.ToInt32(productpricebox.Text);
            productmodelobj.Product_Qty = Convert.ToInt32(productqtybox.Text);
            using (SQLiteConnection connobj = new SQLiteConnection(App.productdbpath))
            {
                connobj.CreateTable<ProductModel>();
                connobj.Update(productmodelobj);

            }
            this.Close();

        }

        private void delete_product(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connobj = new SQLiteConnection(App.productdbpath))
            {
                connobj.CreateTable<ProductModel>();
                connobj.Delete(productmodelobj);

            }
            this.Close();
        }
    }
}




