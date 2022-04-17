using AuksionApp._12._04._2022;
using Business.Interface;
using DataAccess;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using Utilities;

namespace Business.Services
{
    public class BuyerService : IBuyer
    {
        public static int BuyerId { get; set; }
        public static int Count { get; set; }
        private BuyerRepository _buyerRepository { get; set; }
        public BuyerRepository BuyerRepository
        {
            get { return _buyerRepository; }
            set { _buyerRepository = value; }
        }
        public BuyerService()
        {
            _buyerRepository = new BuyerRepository();
        }

        public Buyer Create(Buyer buyer)
        {
            buyer.Id = BuyerId;
            BuyerId++;
            Count++;
            _buyerRepository.Create(buyer);
            return buyer;
        }

        public Buyer Delete(int id)
        {
            Buyer isExist = _buyerRepository.GetOne(b => b.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.DarkRed, ConsoleColor.White, $" The {id} is Not Exist in This List.\n Please Try Again! \n");
                return null;
            }
            else
            {
                _buyerRepository.Delete(isExist);
                return isExist;
            }
        }

        public List<Buyer> GetAll()
        {
            return _buyerRepository.GetAll();
        }

        public List<Product> GetAllProducts(string name)
        {
            throw new NotImplementedException();
        }

        public Buyer GetOne(int id)
        {
            Buyer isExist = _buyerRepository.GetOne(b => b.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, $"The {id} does not exist");
                return null;
            }
            Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" This is {isExist.Name} \n");
            return isExist;
        }

        public Buyer Update(Buyer buyer, int id)
        {
            Buyer isExist = _buyerRepository.GetOne(b => b.Id == id);
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

                string newName = buyer.Name;
                string newSurName = buyer.SurName;
                int newAge = buyer.Age;

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
                isExist.Name = buyer.Name;
                isExist.Age = buyer.Age;
                _buyerRepository.Update(buyer);
                return isExist;
            }

        }
        public Buyer BuyProduct(Product product,int id)
        {
            Buyer byrFind = _buyerRepository.GetOne(b => b.Id == id);
           
            if (byrFind == null)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Id does not exist. \n Please Try Again!\n");
                return null;
            }
            else
            {
                product.BuyerId = id;
                _buyerRepository.BuyProduct(product);
                //DataContext.Products.Remove(product);
                //Notifications.Display(ConsoleColor.White, ConsoleColor.DarkGreen, $" The {product.Name} Purchased By {byrFind.Name} ");
                return byrFind;
            }

        }

        //public Buyer BuyProduct(Product product, int id)
        //{
        //    Buyer buyer = _buyerRepository.GetOne(b => b.Id == id);

        //    if (buyer==null)
        //    {
        //        Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Id does not exist. \n Please Try Again!\n");
        //        return null;
        //    }
        //    else
        //    {
        //        product.BuyerId = buyer.Id;
        //        _buyerRepository.BuyProduct(product);
        //        return buyer;
        //    }
        //}
    }
}
