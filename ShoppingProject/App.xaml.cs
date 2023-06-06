using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ShoppingProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string customerdatabasename = "Customer.db";
        public static string customerdbpath = System.IO.Path.Combine(folderpath, customerdatabasename);
       
        public static string productdatabasename = "Product.db";
        public static string productdbpath = System.IO.Path.Combine(folderpath, productdatabasename);
    }
}
