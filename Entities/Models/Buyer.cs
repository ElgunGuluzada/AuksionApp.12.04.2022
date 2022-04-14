using Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuksionApp._12._04._2022
{
    public class Buyer:IEntity
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

        private int _buyerPrice;

        public int BuyerPrice
        {
            get { return _buyerPrice; }
            set { _buyerPrice = value; }
        }

        List<Product> _products;
        public List<Product> Products { get { return _products; } }

        List<Buyer> _buyers;
        public List<Buyer> buyers { get { return _buyers; } }

        public void AllBuyer(Buyer _buyer)
        {
            buyers.Add(_buyer);
        }

        public Buyer(string name)
        {
            Name = name;
            List<Product> products = new List<Product>();
            _products = products;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

    }
}
