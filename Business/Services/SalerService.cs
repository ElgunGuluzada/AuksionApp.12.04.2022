using AuksionApp._12._04._2022;
using Business.Interface;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;

namespace Business.Services
{
    public class SalerService : ISaler
    {
        public static int SalerId { get; set; }
        public static int Count { get; set; }

        private SalerRepository _salerRepository;
        public SalerRepository SalerRepository {
            get { return _salerRepository; }
            set { _salerRepository = value; } }
        public SalerService()
        {
            _salerRepository= new SalerRepository();
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

        public List<Saler> GetAll()
        {
            return _salerRepository.GetAll();
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
        public Saler AddProduct(Product product, int id)
        {
            Saler isExist = _salerRepository.GetOne(s => s.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, "Id does not exist");
                return null;
            }
            product.SalerId = id;
            _salerRepository.AddProduct(product);
            return isExist;
        }

        public Saler AddBuyer(Buyer buyer, int id)
        {
            Saler isExist = _salerRepository.GetOne(s => s.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, "Id does not exist");
                return null;
            }
            buyer.SalerId = id;
            _salerRepository.AddBuyer(buyer);
            return isExist;
        }
    }
}
