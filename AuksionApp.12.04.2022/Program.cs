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
            BuyerController buyerController = new BuyerController();
            SalerController salerController = new SalerController();
            while (true)
            {

            Menu: Menu.ShowMenu();
                int input = TryMethods.TryParseMethod();
                if (input >= 0 && input <= 18)
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
                        case (int)Menu.MenuBar.DeleteProduct:
                            productController.DeleteProduct();
                            break;
                        case (int)Menu.MenuBar.GetAllProduct:
                            productController.GetAllProducts();
                            break;
                        case (int)Menu.MenuBar.CreateBuyer:
                            buyerController.CreateBuyer();
                            break;
                        case (int)Menu.MenuBar.UpdateBuyer:
                            buyerController.UpdateBuyer();
                            break;
                        case (int)Menu.MenuBar.DeleteBuyer:
                            buyerController.DeleteBuyer();
                            break;
                        case (int)Menu.MenuBar.GetAllBuyer:
                            buyerController.GetAllBuyers();
                            break;
                        case (int)Menu.MenuBar.CreateSaler:
                            salerController.CreateSaler();
                            break;
                        case (int)Menu.MenuBar.UpdateSaler:
                            salerController.UpdateSaler();
                            break;
                        case (int)Menu.MenuBar.DeleteSaler:
                            salerController.DeleteSaler();
                            break;
                        case (int)Menu.MenuBar.GetAllSaler:
                            salerController.GetAllSalers();
                            break;

                        default:
                            goto Menu;
                    }
                }
            }

        Quit: Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, "ThanksForWatching");
            Thread.Sleep(2000);
        }
    }
}
