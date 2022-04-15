using AuksionApp._12._04._2022;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repositories
{
    internal class ProductRepository : IRepository<Product>
    {
        public bool Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll(Predicate<Product> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product GetOne(Predicate<Product> filter = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(Product entity)
        {
            throw new NotImplementedException();
        }

    }
}
