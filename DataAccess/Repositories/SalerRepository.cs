using AuksionApp._12._04._2022;
using DataAccess.Interface;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class SalerRepository : IRepository<Saler>
    {
        public bool Create(Saler entity)
        {
            try
            {
                DataContext.Salers.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Saler entity)
        {
            try
            {
                DataContext.Salers.Remove(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Saler> GetAll(Predicate<Saler> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Salers : DataContext.Salers.FindAll(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Saler GetOne(Predicate<Saler> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Salers[0] :
                     DataContext.Salers.Find(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Saler entity)
        {
            try
            {
                Saler isExist = GetOne(s => s.Name == entity.Name || s.Id == entity.Id);
                isExist = entity;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
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
