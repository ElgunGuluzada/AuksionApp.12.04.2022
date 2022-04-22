using AuksionApp._12._04._2022;
using DataAccess.Interface;
using System;
using System.Collections.Generic;
using Utilities;

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
                return filter == null ? null :
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

      

        public bool BuyProductForSaler(int prdctId, int sylrId)
        {
            try
            {
                Saler saler = DataContext.Salers.Find(s => s.Id == sylrId);
                Product product = DataContext.Products.Find(p => p.Id == prdctId);
                saler.Products.Add(product);
                DataContext.Products.Remove(product);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool SaleProductForBuyer(int prdctId, int sylrId, int byrId)
        {
            try
            {
                Saler saler = DataContext.Salers.Find(s => s.Id == sylrId);
                Buyer newBuyer = DataContext.Buyers.Find(s => s.Id == byrId);

                if (saler.Products.Count<=0)
                {
                    Notifications.Display(ConsoleColor.Red, ConsoleColor.White, "Saticida satiliq mehsul yoxdur.");
                    return true;
                }
                else
                {
                    Product product = saler.Products[prdctId];
                    product.Id = newBuyer.Products.Count;
                    double productNewPrice = product.Price*0.1;
                    Product product1 = new Product()
                    {
                        Name = product.Name,
                        Price = productNewPrice
                    };
                    newBuyer.Products.Add(product1);
                    saler.Products.Remove(product);

                    Notifications.Display(ConsoleColor.Yellow, ConsoleColor.Black, $" Satis Ugurla Heyata Kecdi ..");
                    return true;
                }
               
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}
