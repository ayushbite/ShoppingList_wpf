using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Model
{
    public class ProductModel
    {

        [PrimaryKey]
        public int Product_Id { get; set; }
        public string Product_Name { get; set;}
        public int Product_Price { get; set; }  
        public int Product_Qty { get; set; }

    }
}
