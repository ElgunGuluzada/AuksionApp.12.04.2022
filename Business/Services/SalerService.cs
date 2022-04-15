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
        private SalerRepository _salerRepository;
        public SalerRepository SalerRepository {
            get { return _salerRepository; }
            set { _salerRepository = value; } }
        public SalerService()
        {
            _salerRepository= new SalerRepository();
        }
        public Saler Create(Saler buyer)
        {
            buyer.Id = SalerId;
            SalerId++;
            _salerRepository.Create(buyer);
            return buyer;
        }

        public Saler Delete(int id)
        {
            Saler isExist = _salerRepository.GetOne(p => p.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, "Error!! Mehsul yoxdu.");
            }
            _salerRepository.Delete(isExist);
            return isExist;
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
            return _salerRepository.GetOne(s => s.Id == id);

        }

        public Saler Update(Saler saler, int id)
        {
            Saler isExist = _salerRepository.GetOne(s => s.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, "Error");
            }
            isExist.Name = saler.Name;
            isExist.SurName = saler.SurName;

            _salerRepository.Update(saler);
            return saler;
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
