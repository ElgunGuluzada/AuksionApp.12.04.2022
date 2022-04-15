using AuksionApp._12._04._2022;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class DataContext
    {
        public static List<Saler> Salers { get; set; }
        public static List<Buyer> Buyers { get; set; }
        public static List<Product> Products { get; set; }

        static DataContext()
        {
            Salers = new List<Saler>();
            Buyers = new List<Buyer>();
            Products = new List<Product>();
        }
    }
}
