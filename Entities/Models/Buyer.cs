﻿using Entities.Interface;
using System.Collections.Generic;

namespace AuksionApp._12._04._2022
{
    public class Buyer : IEntity
    {
        public int Id { get; set; }
        public int SalerId { get; set; }

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

        private int _buyerPrice;

        public int BuyerPrice
        {
            get { return _buyerPrice; }
            set { _buyerPrice = value; }
        }

        public List<Product> Products;

        public Buyer()
        {
            Products = new List<Product>();
        }
      
    }
}
