using AuksionApp._12._04._2022;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using Utilities;

namespace DataAccess.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        public bool Create(Product entity)
        {
            try
            {
                DataContext.Products.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Product entity)
        {
            try
            {
                DataContext.Products.Remove(entity);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Product> GetAll(Predicate<Product> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Products : DataContext.Products.FindAll(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }



        public Product GetOne(Predicate<Product> filter = null)
        {
            try
            {
                return filter == null ? null :
                     DataContext.Products.Find(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Product entity)
        {
            try
            {
                Product isExist = GetOne(p => p.Name == entity.Name || p.Id == entity.Id);
                isExist = entity;
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
