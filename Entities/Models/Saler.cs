using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuksionApp._12._04._2022
{
    public class Saler:IEntity
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

        List<Saler> _salers;
        public List<Saler> Salers { get { return _salers; } }

        List<Product> _products;
        public List<Product> Products { get { return _products; } }


        public Saler(string name)
        {
            Name = name;
            List<Product> products = new List<Product>();
            _products = products;
        }

        public void AllSalers(Saler salers)
        {
            Salers.Add(salers);
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void SaleProduct(Product product)
        {
            Products.Remove(product);
        }
    }
}
