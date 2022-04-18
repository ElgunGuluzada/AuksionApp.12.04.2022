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
         /// <summary>
        /// Bu Method ise dusduyunde butun productlari tapir ve ekrana cap edir.
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        /// <summary>
        /// Bu Method ise dusduyunde qeyd edilen id -e gore hemin mehsulu tapir ve ekrana cap edir.
        /// Eger hemin id-e mexsus mehsul tapmirsa mehsulun olmadigina dair mesaj gisterir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public Product GetOne(int id)
        {
            Product isExist = _productRepository.GetOne(b => b.Id == id);
            if (isExist == null)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, $" The {id} does not exist\n");
                return null;
            }
            Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" This is {isExist.Name} \n");
            return isExist;
        }
          /// <summary>
        /// Bu Method ise dusduyunde qeyd edilen id -e gore hemin mehsulu tapir ve onu silir.
        /// Eger hemin id-e mexsus mehsul tapmirsa mehsulun olmadigina dair mesaj gisterir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

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
         /// <summary>
        /// Bu Method ise dusduyunde qeyd edilen id -e gore hemin mehsulu tapir ve onun sizden istenilen deyisikliye uygun olaraq deyisir
        /// Deyisikliklerin nece oldugunu nezere alaraq ona uygun mesaj gosterir
        /// Eger hemin id-e mexsus mehsul tapmirsa mehsulun olmadigina dair mesaj gisterir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
