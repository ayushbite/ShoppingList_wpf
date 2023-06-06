using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Model
{
    public class CustomerModel
    {

        [PrimaryKey]
        public int Customer_Id { get; set; }
        public string Customer_Name { get; set; }
        public int Customer_Credit { get; set; }
        public int Customer_Debit { get; set; }

    }
}
