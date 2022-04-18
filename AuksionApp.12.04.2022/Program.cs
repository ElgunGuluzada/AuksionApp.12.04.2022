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

            Notifications.Display(ConsoleColor.Red, ConsoleColor.White, "\n                                                       Welcome                                                                                                                                                                                  ");
            ProductController productController = new ProductController();
            BuyerController buyerController = new BuyerController();
            SalerController salerController = new SalerController();
            
            while (true)
            {
            Menu: Menu.ShowMenu();
                int input = TryMethods.TryParseMethod();
                if (input >= 0 && input <= 22)
                {
                    switch (input)
                    {   
                        case (int)Menu.MenuBar.Quit:
                            goto Quit;
                        case (int)Menu.MenuBar.CreateProduct:
                            productController.CreateProduct();
                            break;
                        case (int)Menu.MenuBar.UpdateProduct:
                            Console.Clear();
                            productController.UpdateProduct();
                            break;
                        case (int)Menu.MenuBar.DeleteProduct:
                            Console.Clear();
                            productController.DeleteProduct();
                            break;
                        case (int)Menu.MenuBar.GetProduct:
                            Console.Clear();
                            productController.GetProduct();
                            break;
                        case (int)Menu.MenuBar.GetAllProducts:
                            Console.Clear();
                            productController.GetAllProducts();
                            break;
                        case (int)Menu.MenuBar.CreateBuyer:
                            buyerController.CreateBuyer();
                            break;
                        case (int)Menu.MenuBar.UpdateBuyer:
                            Console.Clear();
                            buyerController.UpdateBuyer();
                            break;
                        case (int)Menu.MenuBar.DeleteBuyer:
                            Console.Clear();
                            buyerController.DeleteBuyer();
                            break;
                        case (int)Menu.MenuBar.GetBuyer:
                            Console.Clear();
                            buyerController.GetBuyer();
                            break;
                        case (int)Menu.MenuBar.GetAllBuyers:
                            Console.Clear();
                            buyerController.GetAllBuyers();
                            break;
                        case (int)Menu.MenuBar.BuyProductForBuyer:
                            Console.Clear();
                            buyerController.BuyProductForBuyer();
                            break;
                        case (int)Menu.MenuBar.CreateSaler:
                            salerController.CreateSaler();
                            break;
                        case (int)Menu.MenuBar.UpdateSaler:
                            Console.Clear();
                            salerController.UpdateSaler();
                            break;
                        case (int)Menu.MenuBar.DeleteSaler:
                            Console.Clear();
                            salerController.DeleteSaler();
                            break;
                        case (int)Menu.MenuBar.GetSaler:
                            Console.Clear();
                            salerController.GetSaler();
                            break;
                        case (int)Menu.MenuBar.GetAllSalers:
                            Console.Clear();
                            salerController.GetAllSalers();
                            break;
                        case (int)Menu.MenuBar.BuyProductForSaler:
                            Console.Clear();
                            salerController.BuyProductForSaler();
                            break;
                        case (int)Menu.MenuBar.SalerSaleProductForBuyer:
                            Console.Clear();
                            salerController.SaleProductForBuyer();
                            break;
                        case (int)Menu.MenuBar.SaleProduct:
                            Console.Clear();
                            salerController.SaleProduct();
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
