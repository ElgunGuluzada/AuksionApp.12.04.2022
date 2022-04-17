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
            Notifications.Display(ConsoleColor.Cyan, ConsoleColor.DarkCyan, "Enter to Product Price: ");
            int price = TryMethods.TryParseMethod();

            Product product = new Product()
            {
                Name = name,
                Price = price
            };
            Console.Clear();
            _productService.Create(product);
            Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, $" The {product.Name} went on sale for ${product.Price} on {DateTime.Now}\n");
        }
        public void UpdateProduct()
        {
            if (ProductService.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Product not available \n Please Try Again! \n");
                return;
            }
            Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, "All Products \n");
            foreach (var prod in _productService.GetAll())
            {
                int oldPrice = prod.Price;
                string oldName = prod.Name;
                Notifications.Display(ConsoleColor.Black, ConsoleColor.White, $" {prod.Id} {prod.Name} ${prod.Price} \n");
            Choose: Notifications.Display(ConsoleColor.Black, ConsoleColor.White, "Choose Product Id: ");
                int id = TryMethods.TryParseMethod();
                if (prod.Id == id)
                {
                    Notifications.Display(ConsoleColor.DarkGray, ConsoleColor.White, "New Product Name: ");
                    string newName = TryMethods.TryNullOrEmptyMethod();
                    Notifications.Display(ConsoleColor.DarkGray, ConsoleColor.White, "New Product Price: ");
                    int newPrice = TryMethods.TryParseMethod();
                    Product product = new Product()
                    {
                        Name = newName,
                        Price = newPrice
                    };
                    _productService.Update(product, id);
                    if (oldPrice < newPrice)
                    {
                        Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" The {oldName} change to {newName} and Price Up {oldPrice} to {newPrice} \n");
                        break;
                    }
                    else if (oldPrice > newPrice)
                    {
                        Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" The {oldName} change to {newName} and Price Down {oldPrice} to {newPrice} \n");
                        break;
                    }
                    else
                    {
                        Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" The {oldName} change to {newName} and Price Doesn't Change! \n");
                        break;
                    }
                }
                else
                {
                    Notifications.Display(ConsoleColor.DarkRed, ConsoleColor.White, $" The {prod.Id} is not Exist in this List.\n Please Try Again! \n");
                    goto Choose;
                }
            }
        }
        public void DeleteProduct()
        {
            if (ProductService.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Product not available \n Please Try Again! \n");
                return;
            }

            Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, "All Products");
            foreach (var prod in _productService.GetAll())
            {
                Notifications.Display(ConsoleColor.Black, ConsoleColor.White, $" {prod.Id} {prod.Name} ${prod.Price} \n");
            C1: Notifications.Display(ConsoleColor.Black, ConsoleColor.White, "Choose Product Id: ");
                int id = TryMethods.TryParseMethod();
                if (prod.Id == id)
                {
                    Product product = _productService.Delete(id);
                    Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $"{product.Name} was deleted \n");
                    break;
                }
                else
                {
                    Notifications.Display(ConsoleColor.DarkRed, ConsoleColor.White, $" The {prod.Id} is Not Exist in This List.\n Please Try Again! \n");
                    goto C1;
                }
            }
        }

        public void GetProduct()
        {

        }

        public void GetAllProducts()
        {
            Console.Clear();
            foreach (var item in _productService.GetAll())
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Product Id: {item.Id}\n" +
                    $" Product Name: {item.Name}\n" +
                    $" Product Price: {item.Price}\n");
            }
        }
    }
}

