using AuksionApp._12._04._2022;
using Business.Interface;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;

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
            throw new NotImplementedException();
        }

        public Product GetOne(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Sale(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
