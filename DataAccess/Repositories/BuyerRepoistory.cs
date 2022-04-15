using AuksionApp._12._04._2022;
using DataAccess.Interface;
using System;
using System.Collections.Generic;

namespace DataAccess.Repositories
{
    public class BuyerRepository : IRepository<Buyer>
    {
        public bool Create(Buyer entity)
        {
            try
            {
                DataContext.Buyers.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Buyer entity)
        {
            try
            {
                DataContext.Buyers.Remove(entity);
                    return true;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public List<Buyer> GetAll(Predicate<Buyer> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Buyers : DataContext.Buyers.FindAll(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Buyer GetOne(Predicate<Buyer> filter = null)
        {
            try
            {
                return filter == null ? DataContext.Buyers[0] :
                     DataContext.Buyers.Find(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(Buyer entity)
        {
            try
            {
                Buyer isExist = GetOne(b => b.Name == entity.Name || b.Id == entity.Id);
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
            try
            {
                return new List<Product> { product };
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
