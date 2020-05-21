using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Test
{
    class Data
    {
        public static string ProductName = "Biscuits";
        public static string UnitPriceToInput = "15";
        public static string UnitPriceToRead = "15,0000";
        // UnitPriceToRead - откровенный костыль, но через целочисленный тип+ToString не получилось пока
        public static string QuantityPerUnit = "40";
        public static string UnitsInStock = "36";
        public static string UnitsOnOrder = "9";
        public static string ReorderLevel = "20";
    }
}
