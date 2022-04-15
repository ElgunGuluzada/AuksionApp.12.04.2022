using AuksionApp._12._04._2022;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    public class SalerRepository : IRepository<Saler>
    {
        public bool Create(Saler entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Saler entity)
        {
            throw new NotImplementedException();
        }

        public List<Saler> GetAll(Predicate<Saler> filter = null)
        {
            throw new NotImplementedException();
        }

        public Saler GetOne(Predicate<Saler> filter = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(Saler entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> AddProduct(Product product)
        {
            return new List<Product>();
        }
        public List<Product> SalerProduct(Product product)
        {
            return new List<Product>();
        }
        public List<Buyer> AddBuyer(Buyer buyer)
        {
            return new List<Buyer> { buyer };
        }
    }
}
