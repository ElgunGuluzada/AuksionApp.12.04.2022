using AuksionApp._12._04._2022;
using Business.Interface;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using Utilities;

namespace Business.Services
{
    public class BuyerService : IBuyer
    {
        public static int BuyerId { get; set; }
        private BuyerRepository _buyerRepository { get; set; }
        public BuyerRepository BuyerRepository
        {
            get { return _buyerRepository; }
            set { _buyerRepository = value; }
        }
        public BuyerService()
        {
            _buyerRepository=new BuyerRepository();
        }

        public Buyer Create(Buyer buyer)
        {
            buyer.Id = BuyerId;
            BuyerId++;
            _buyerRepository.Create(buyer);
            return buyer;
        }

        public Buyer Delete(int id)
        {
            Buyer isExist = _buyerRepository.GetOne(p => p.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, "Error!! Mehsul yoxdu.");
            }
            _buyerRepository.Delete(isExist);
            return isExist;
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
            return _buyerRepository.GetOne(b => b.Id == id);
        }

        public Buyer Update(Buyer buyer, int id)
        {
            Buyer isExist = _buyerRepository.GetOne(b=> b.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, "Error");
            }
            isExist.Name = buyer.Name;
            isExist.SurName = buyer.SurName;

            _buyerRepository.Update(buyer);
            return buyer;
        }
        public Buyer AddProduct(Product product, int id)
        {
            Buyer isExist = _buyerRepository.GetOne(b => b.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.Red,ConsoleColor.DarkRed, "Id does not exist");
                return null;
            }
            product.BuyerId = id;
            _buyerRepository.AddProduct(product);

            return isExist;
        }
    }
}
