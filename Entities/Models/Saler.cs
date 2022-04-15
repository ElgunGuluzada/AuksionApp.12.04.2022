﻿using Entities.Interface;
using System.Collections.Generic;

namespace AuksionApp._12._04._2022
{
    public class Saler : IEntity
    {
        private static int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

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

        List<Saler> _salers;
        public List<Saler> Salers
        {
            get { return _salers; }
            set { _salers = value; }
        }

        List<Buyer> _buyers;
        public List<Buyer> Buyer { 
            get { return _buyers; } 
            set { _buyers = value; } 
        }

        List<Product> _products;
        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }
    }
}