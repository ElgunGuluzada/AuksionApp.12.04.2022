using AuksionApp._12._04._2022;
using Business.Interface;
using DataAccess;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using Utilities;

namespace Business.Services
{
    public class SalerService : ISaler
    {
        public static int SalerId { get; set; }
        public static int Count { get; set; }

        private SalerRepository _salerRepository;
        public SalerRepository SalerRepository
        {
            get { return _salerRepository; }
            set { _salerRepository = value; }
        }
        public SalerService()
        {
            _salerRepository = new SalerRepository();
        }
        public Saler Create(Saler saler)
        {
            saler.Id = SalerId;
            SalerId++;
            Count++;
            _salerRepository.Create(saler);
            return saler;
        }
        public Saler Delete(int id)
        {
            Saler isExist = _salerRepository.GetOne(p => p.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Product not available \n Please Try Again! \n");
                return null;
            }
            else
            {
                _salerRepository.Delete(isExist);
                return isExist;
            }
        }

        public List<Saler> GetAll(string filter = null)
        {
            List<Saler> isExist = filter == null ? _salerRepository.GetAll() : _salerRepository.GetAll(b => b.Name == filter);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.White, $" Nothing Found!");
            }
            return isExist;
        }

        public List<Buyer> GetAllBuyers()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts(string name)
        {
            throw new NotImplementedException();
        }

        public Saler GetOne(int id)
        {
            Saler isExist = _salerRepository.GetOne(b => b.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, $"The {id} does not exist");
                return null;
            }
            Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" This is {isExist.Name} \n");
            return isExist;
        }

        public Saler Update(Saler saler, int id)
        {
            Saler isExist = _salerRepository.GetOne(b => b.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.DarkRed, ConsoleColor.White, $" The {id} is not Exist in this List.\n Please Try Again! \n");
                return null;
            }
            else
            {
                string oldName = isExist.Name;
                string oldSurname = isExist.SurName;
                int oldAge = isExist.Age;

                string newName = saler.Name;
                string newSurName = saler.SurName;
                int newAge = saler.Age;

                if (oldAge < newAge)
                {
                    Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" The {oldName} change to {newName}, {oldSurname} change to {newSurName} and Age Up {oldAge} to {newAge} \n");
                }
                else if (oldAge > newAge)
                {
                    Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" The {oldName} change to {newName}, {oldSurname} change to {newSurName} and Age Down {oldAge} to {newAge} \n");
                }
                else
                {
                    Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" The {oldName} change to {newName}, {oldSurname} change to {newSurName} and Age Doesn't Change! \n");
                }
                isExist.Name = saler.Name;
                isExist.Age = saler.Age;
                _salerRepository.Update(saler);
                return isExist;
            }
        }

        public void BuyProductForSaler(int productId,int sylrId)
        {
            Saler sylrFind = _salerRepository.GetOne(s => s.Id == sylrId);
            Product product = DataContext.Products.Find(p => p.Id == productId);

            //sylrFind.PurchaseDate = DateTime.Now;
            if (sylrFind == null || product == null)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Id does not exist. \n Please Try Again!\n");
            }
            else
            {
                product.Id = sylrFind.Products.Count;
                _salerRepository.BuyProductForSaler(productId, product.SalerId);
                for (int i = 0; i < sylrFind.Products.Count; i++)
                {
                    sylrFind.Products[i].Id = i;
                }
                for (int i = 0; i < DataContext.Products.Count; i++)
                {
                    DataContext.Products[i].Id = i;
                }
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkGreen, $" The {product.Name} Purchased By {sylrFind.Name} on {sylrFind.PurchaseDate} ");
            }
        }
       
        public void SaleProductForBuyer(int prdctId, int sylrId, int byrId)
        {
            if (byrId < 0 || sylrId < 0)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.White, "This Saled is Failed.");
            }
            Saler saler = _salerRepository.GetOne(s => s.Id == sylrId);
            Buyer buyer =DataContext.Buyers.Find(b => b.Id ==byrId);
           

            if (buyer == null)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.White, "Create Buyer\n Please Write 8");           
            }

            else
            {
                _salerRepository.SaleProductForBuyer(prdctId, sylrId, byrId);

                for (int i = 0; i < saler.Products.Count; i++)
                {
                    saler.Products[i].Id = i;
                }
                for (int i = 0; i < buyer.Products.Count; i++)
                {
                    buyer.Products[i].Id = i;
                }
            }
        }
    }
}