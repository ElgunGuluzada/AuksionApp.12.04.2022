using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Utilities
{
    public  class Notifications
    {
        /// <summary>
        /// Istediyim yerde console cagirmaq evezine bu metodu cagiraraq daha rahat ve rengli formada yazmaq ucun yazilmis metod
        /// </summary>
        /// <returns></returns>

        public static void Display(ConsoleColor frgColor,ConsoleColor bckColor,string message)
        {
            Console.ForegroundColor = frgColor;
            Console.BackgroundColor = bckColor;
            Console.Write(message);
            Console.ResetColor();
        }
    }
}
