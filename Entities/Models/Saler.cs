using Entities.Interface;
using System;
using System.Collections.Generic;

namespace AuksionApp._12._04._2022
{
    public class Saler : IEntity
    {
        public int Id { get; set; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _surname;

        public string SurName
        {
            get { return _surname; }
            set { _surname = value; }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public DateTime SalesDate { get; set; }
        public DateTime PurchaseDate { get; set; }
        
        List<Buyer> _buyers;
        public List<Buyer> Buyer { 
            get { return _buyers; } 
            set { _buyers = value; } 
        }

        public List<Product> Products;
        public Saler()
        {
            Products = new List<Product>();
        }
       
    }
}
