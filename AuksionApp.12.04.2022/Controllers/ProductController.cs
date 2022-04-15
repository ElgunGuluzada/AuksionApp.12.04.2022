using Business.Services;
using System;
using Utilities;
using Utilities.Helper;

namespace AuksionApp._12._04._2022.Controllers
{
    internal class ProductController
    {
        private ProductService _productService;
        public ProductController()
        {
            _productService = new ProductService();
        }
        public void CreateProduct()
        {
            Notifications.Display(ConsoleColor.Cyan, ConsoleColor.DarkCyan, "Enter to Product Name: ");
            string name = TryMethods.TryNullOrEmptyMethod();

            Product product = new Product()
            {
                Name = name,
            };
            Console.Clear();
            _productService.Create(product);
            Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, $"{product.Name} created");
        }
        public void UpdateProduct()
        {
            if (ProductService.Count <= 0)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, "Product not available");
                return;
            }
            Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, "All Products");
            _productService.GetAll();
            Notifications.Display(ConsoleColor.Cyan, ConsoleColor.DarkCyan, "Choose Product Id: ");
            int id = TryMethods.TryParseMethod();
            Notifications.Display(ConsoleColor.Cyan, ConsoleColor.DarkCyan, "New Product Name: ");
            string newName = TryMethods.TryNullOrEmptyMethod();
            Product newProduct = new Product()
            {
                Name = newName
            };
            _productService.Update(newProduct, id);
        }

        public void SaleProduct()
        {
            if (ProductService.Count <= 0)
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, "Product not available");
                return;
            }
            Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, "All Products");
            _productService.GetAll();
            Notifications.Display(ConsoleColor.Cyan, ConsoleColor.DarkCyan, "Choose Product Id: ");
            int id = TryMethods.TryParseMethod();
            Product product = _productService.Sale(id);
            Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, $"{product.Name}");
        }

        public void GetProduct()
        {

        }

        public void GetAllProducts()
        {
            Console.Clear();
            foreach (var item in _productService.GetAll())
            {
                Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, $" Product Id: {item.Id}\n" +
                    $" Product Name: {item.Name}\n" +
                    $" Product Price: {item.Price}\n");
            }
        }
    }
}

