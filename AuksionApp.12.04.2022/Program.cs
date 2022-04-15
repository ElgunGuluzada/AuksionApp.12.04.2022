using Business.Services;
using System;
using System.Threading;

namespace AuksionApp._12._04._2022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            Product product = new Product()
            {
                Name = "Alma",
                Price = 5
            };
            productService.Create(product);

            foreach (var item in productService.GetAll())
            {
                Console.WriteLine(item.Name);
            }
           

        }
    }
}
