using AuksionApp._12._04._2022;
using Business.Interface;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using Utilities;

namespace Business.Services
{
    public class ProductService : IProduct
    {
        public static int ProdId { get; set; }
        private ProductRepository _productRepository { get; set; }
        public ProductRepository ProductRepository
        {
            get { return _productRepository; }
            set { _productRepository = value; }
        }

        public ProductService()
        {
            _productRepository = new ProductRepository();
        }
        public Product Create(Product product)
        {

            product.Id = ProdId;
            ProdId++;
            _productRepository.Create(product);
            return product;
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetOne(int id)
        {
            return _productRepository.GetOne(p => p.Id == id);
        }

        public Product Delete(int id)
        {
            Product isExist = _productRepository.GetOne(p => p.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.DarkRed, ConsoleColor.White, $" The {id} is Not Exist in This List.\n Please Try Again! \n");
                return null;
            }
            else
            {
                _productRepository.Delete(isExist);
                return isExist;
            }
        }

        public Product Update(Product product, int id)
        {
            Product isExist = _productRepository.GetOne(p => p.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.DarkRed, ConsoleColor.White, $" The {id} is not Exist in this List.\n Please Try Again! \n");
                return null;
            }
            else
            {
                string oldName = isExist.Name;
                int oldPrice = isExist.Price;

                string newName = product.Name;
                int newPrice = product.Price;

                if (oldPrice < newPrice)
                {
                    Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" The {oldName} change to {newName} and Price Up {oldPrice} to {newPrice} \n");
                }
                else if (oldPrice > newPrice)
                {
                    Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" The {oldName} change to {newName} and Price Down {oldPrice} to {newPrice} \n");
                }
                else
                {
                    Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" The {oldName} change to {newName} and Price Doesn't Change! \n");
                }
                isExist.Name = product.Name;
                isExist.Price = product.Price;
                _productRepository.Update(product);
                return isExist;
            }
            
        }
    }
}
