using Business.Services;
using DataAccess;
using System;
using Utilities;
using Utilities.Helper;

namespace AuksionApp._12._04._2022.Controllers
{
    internal class ProductController
    {
        ProductService productService = new ProductService();
        public void CreateProduct()
        {
            Notifications.Display(ConsoleColor.Cyan, ConsoleColor.DarkCyan, "Enter to Product Name: ");
            string name = TryMethods.TryNullOrEmptyMethod();
            Notifications.Display(ConsoleColor.Cyan, ConsoleColor.DarkCyan, "Enter to Product Price: ");
            double price = TryMethods.TryDoubleMethod();

            Product product = new Product()
            {
                Id = DataContext.Products.Count,
                Name = name,
                Price = price,
                ReleasedTime = DateTime.Now
            };
            Console.Clear();
            productService.Create(product);
            Notifications.Display(ConsoleColor.White, ConsoleColor.DarkGreen, $" The {product.Name} went on sale for ${product.Price} on {product.ReleasedTime}\n");
        }
        public void UpdateProduct()
        {
            if (DataContext.Products.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Product not available \n Please Try Again! \n");
            }
            else
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, " All Products \n");
                GetAllProducts();
                Notifications.Display(ConsoleColor.Black, ConsoleColor.White, " Choose Product Id: ");
                int id = TryMethods.TryParseMethod();
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Enter new Name for Product");
                string newName = TryMethods.TryNullOrEmptyMethod();
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Enter new Price for Product");
                double newPrice = TryMethods.TryDoubleMethod();
                Product product = new Product()
                {
                    Name = newName,
                    Price = newPrice
                };
                productService.Update(product, id);
            }
        }
        public void DeleteProduct()
        {
            if (DataContext.Products.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Product not available \n Please Try Again! \n");
            }
            else
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, " All Products \n");
                GetAllProducts();
                Notifications.Display(ConsoleColor.Black, ConsoleColor.White, " Choose Product Id: ");
                int id = TryMethods.TryParseMethod();
                productService.Delete(id);
            }
        }

        public Product GetProduct()
        {
            if (DataContext.Products.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Product not available \n Please Try Again! \n");
                return null;
            }
            else
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Please Enter ID for searching \n");
                int id = TryMethods.TryParseMethod();
                return productService.GetOne(id);
            }
        }

        public void GetAllProducts()
        {
            foreach (var prdct in productService.GetAll())
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Product Id: {prdct.Id}\n" +
                    $" Product Name: {prdct.Name}\n" +
                    $" Product Price: {prdct.Price}\n" +
                    $" Product Released Time: {prdct.ReleasedTime}\n");
            }
        }
    }
}

