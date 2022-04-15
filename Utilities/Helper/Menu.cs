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
                $" 3-Sale Product\n" +
                $" 4-GetAll Product\n" +
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
            SaleProduct = 3,
            GetAllProduct = 4,
        }
    }
}
