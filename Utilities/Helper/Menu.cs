using System;
using System.Threading;

namespace Utilities
{
    public class Menu
    {
        /// <summary>
        /// Menu
        /// </summary>
        public static void ShowMenu()
        {
            Notifications.Display(ConsoleColor.Black, ConsoleColor.White,
                $" 1-Create Product\n"+ 
                $" 2-Update Product\n" +
                $" 3-Delete Product\n" +
                $" 4-GetAll Products\n" +
                $" 8-Create Buyer\n"+ 
                $" 9-Update Buyer\n" +
                $" 10-Delete Buyer\n" +
                $" 11-GetAll Buyers\n" +
                $" 15-Create Saler\n"+ 
                $" 16-Update Saler\n" +
                $" 17-Delete Saler\n" +
                $" 18-GetAll Salers\n" +
                $" 0-Quit\n");
            Thread.Sleep(500);
        }
        /// <summary>
        /// Reqemleri Secerek Qeyd Edilen Menulari Istifade Ede Bilersiniz.
        /// </summary>
        public enum MenuBar
        {
            Quit = 0,
            CreateProduct = 1,
            UpdateProduct = 2,
            DeleteProduct = 3,
            GetAllProduct = 4,
            CreateBuyer = 8,
            UpdateBuyer = 9,
            DeleteBuyer = 10,
            GetAllBuyer = 11,
            CreateSaler = 15,
            UpdateSaler = 16,
            DeleteSaler = 17,
            GetAllSaler = 18,
        }
    }
}
