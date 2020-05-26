using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Test.business_object
{
    public class Product
    {
        public string ProductName { get; set; }
        public string CategoryId { get; set; }
        public string SupplierId { get; set; }
        public string UnitPriceToInput { get; set; }
        public string UnitPriceToRead { get; set; }
        public string QuantityPerUnit { get; set; }
        public string UnitsInStock { get; set; }
        public string UnitsOnOrder { get; set; }
        public string ReorderLevel { get; set; }
        public string Discontinued { get; set; }
    }
}
