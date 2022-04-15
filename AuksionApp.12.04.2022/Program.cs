using AuksionApp._12._04._2022.Controllers;
using System;
using System.Threading;
using Utilities;
using Utilities.Helper;

namespace AuksionApp._12._04._2022
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Notifications.Display(ConsoleColor.Red, ConsoleColor.White, "\n      Welcome \n");
            ProductController productController = new ProductController();
            while (true)
            {

            Menu: Menu.ShowMenu();
                int input = TryMethods.TryParseMethod();
                if (input >= 0 && input <= 4)
                {
                    switch (input)
                    {
                        case (int)Menu.MenuBar.Quit:
                            goto Quit;
                        case (int)Menu.MenuBar.CreateProduct:
                            productController.CreateProduct();
                            break;
                        case (int)Menu.MenuBar.UpdateProduct:
                            productController.UpdateProduct();
                            break;
                        case (int)Menu.MenuBar.SaleProduct:
                            productController.SaleProduct();
                            break;
                        case (int)Menu.MenuBar.GetAllProduct:
                            productController.GetAllProducts();
                            break;

                        default:
                            goto Menu;
                    }
                }
            }

        Quit: Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, "ThanksForWatching");
            Thread.Sleep(3000);
        }
    }
}
