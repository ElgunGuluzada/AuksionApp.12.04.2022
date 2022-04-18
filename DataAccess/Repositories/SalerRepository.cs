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

        //public List<Product> GetAllProducts(Predicate<Product> filter = null)
        //{
        //    try
        //    {
        //        return filter == null ? DataContext.Products : DataContext.Products.FindAll(filter);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public Saler AddProduct(Product product)
        //{
        //    try
        //    {
        //        Saler saler = DataContext.Salers.Find(s => s.Id == product.Id);
        //        saler.Products = new List<Product>();
        //        saler.Products.Add(product);
        //        Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, $"{product.Name} {saler.Name} terefinden elde edildi..");
        //        return saler;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public bool BuyProductForSaler(Product product, int sylrId)
        {
            try
            {
                Saler saler = DataContext.Salers.Find(s => s.Id == sylrId);
                saler.Products.Add(product);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool SaleProduct(Product product, int sylrId)
        {
            try
            {
                Saler saler = DataContext.Salers.Find(s => s.Id == sylrId);
                saler.Products.Remove(product);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool SaleProductForBuyer(int prdctId,int sylrId,int byrId)
        {
            try
            {

                Saler saler = DataContext.Salers.Find(s => s.Id == sylrId);
                Buyer newBuyer = DataContext.Buyers.Find(s => s.Id == byrId);

                Product product = newBuyer.Products[prdctId];
                product.Id = newBuyer.Products.Count;
                saler.Products.Remove(product);
                newBuyer.Products.Add(product);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Saler SaleProduct(Product product)
        {
            try
            {
                {
                    Saler saler = DataContext.Salers.Find(s => s.Id == product.Id);
                    saler.Products = new List<Product>();
                    saler.Products.Remove(product);
                    Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, $"{product.Name} {saler.Name} terefinden satildi..");
                    return saler;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Saler AddBuyer(Buyer buyer)
        {
            try
            {
                {
                    Saler saler = DataContext.Salers.Find(s => s.Id == buyer.Id);
                    saler.Buyer = new List<Buyer>();
                    saler.Buyer.Add(buyer);
                    Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, $"{buyer.Name} {saler.Name} in alicilari arasina qeyd olundu..");
                    return saler;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
