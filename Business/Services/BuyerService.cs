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

        public List<Buyer> GetAll(string filter=null)
        {
            List<Buyer> isExist = filter == null ? _buyerRepository.GetAll() : _buyerRepository.GetAll(b => b.Name == filter);
            if (isExist==null)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.White, $" Nothing Found!");
            }
            return isExist;
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
                Notifications.Display(ConsoleColor.Red, ConsoleColor.White, $"The {id} does not exist");
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
        public Product BuyProductForBuyer(Product product)
        {
            Buyer byrFind = _buyerRepository.GetOne(b => b.Id == product.BuyerId);
           
            if (byrFind == null)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Id does not exist. \n Please Try Again!\n");
                return null;
            }
            else
            {
                product.Id = byrFind.Products.Count;
                _buyerRepository.BuyProductForBuyer(product,product.BuyerId);
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkGreen, $" The {product.Name} Purchased By {byrFind.Name} ");
                return product;
            }

        }
    }
}
