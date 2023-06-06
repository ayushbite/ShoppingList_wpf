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
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
        }

       

        private void save_product(object sender, RoutedEventArgs e)
        {
            ProductModel productmodelobj = new ProductModel()
            {
                Product_Id   = Convert.ToInt32(productidbox.Text),
                Product_Name = Convert.ToString(productnamebox.Text),
                Product_Price = Convert.ToInt32(productpricebox.Text),
                Product_Qty = Convert.ToInt32(productqtybox.Text),
            };
            using (SQLiteConnection connobj = new SQLiteConnection(App.productdbpath))
            {
                connobj.CreateTable<ProductModel>();
                connobj.Insert(productmodelobj);
            }
            this.Close();
        }
    }
}
