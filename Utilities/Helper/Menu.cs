using System;
using System.Threading;

namespace Utilities
{
    public class Menu
    {
        /// <summary>
        /// Verilen Modellere uygun olaraq menyulari size gosterir. Modellerin bir birinden ayri qalmasi ucun bu usuldan istifade etmisem.
        /// </summary>
        public static void ShowMenu()
        {
            Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White,
                $"\n                    Products Menu                     Buyer Menu                          Saler Menu                    \n"+
                $"                  1-Create Product                  8-Create Buyer                     15-Create Saler                  \n" +
                $"                  2-Update Product                  9-Update Buyer                     16-Update Saler                  \n" +
                $"                  3-Delete Product                  10-Delete Buyer                    17-Delete Saler                  \n" +
                $"                  4-GetProductById                  11-GetBuyerById                    18-GetSalerById                  \n" +
                $"                  5-GetAll Products                 12-GetAll Buyers                   19-GetAll Salers                 \n" +
                $"                                                    13-BuyProductForBuyer              20-BuyProductForSaler            \n" +
                $"                                                                                                                                                                            0-Quit                                                              \n" 



              //$" 1-Create Product\n" +
              //$" 2-Update Product\n" +
              //$" 3-Delete Product\n" +
              //$" 4-GetProductById\n" +
              //$" 5-GetAll Products\n" +
              //$" 8-Create Buyer\n" +
              //$" 9-Update Buyer\n" +
              //$" 10-Delete Buyer\n" +
              //$" 11-GetBuyerById\n" +
              //$" 12-GetAll Buyers\n" +
              //$" 15-Create Saler\n" +
              //$" 16-Update Saler\n" +
              //$" 17-Delete Saler\n" +
              //$" 18-GetSalerById\n" +
              //$" 19-GetAll Salers\n" +
              /*$" 0-Quit\n"*/);
            Thread.Sleep(500);
        }
        /// <summary>
        /// Reqemleri Secerek Qeyd Edilen Menulari Istifade Ede Bilersiniz.
        /// Bezi reqemlerin atlamasinin sebebi ise gelecekde menyuya elave punktlarin daxil oldugu zaman bos yerin olmasi ucundur.
        /// </summary>
        public enum MenuBar
        {
            Quit = 0,
            CreateProduct = 1,
            UpdateProduct = 2,
            DeleteProduct = 3,
            GetProduct = 4,
            GetAllProducts = 5,
            CreateBuyer = 8,
            UpdateBuyer = 9,
            DeleteBuyer = 10,
            GetBuyer = 11,
            GetAllBuyers = 12,
            BuyProductForBuyer = 13,
            CreateSaler = 15,
            UpdateSaler = 16,
            DeleteSaler = 17,
            GetSaler = 18,
            GetAllSalers = 19,
            BuyProductForSaler = 20,
        }
    }
}
