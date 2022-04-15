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

        public Product GetOne(Product product)
        {
            return _productRepository.GetOne(p => p.Id == product.Id);
        }

        public Product Sale(int id)
        {
            Product isExist = _productRepository.GetOne(p => p.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, "Error!! Mehsul yoxdu.");
            }
            _productRepository.Delete(isExist);
            return isExist;
        }

        public Product Update(Product product, int id)
        {
            Product isExist = _productRepository.GetOne(p => p.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, "Error");
            }
            isExist.Name=product.Name;
            isExist.Price=product.Price;

            _productRepository.Update(product);
            return product;
        }
    }
}
