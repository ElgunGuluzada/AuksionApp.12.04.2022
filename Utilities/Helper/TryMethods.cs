using System;

namespace Utilities.Helper
{
    public class TryMethods
    {

        /// <summary>
        /// Duzgun formada int qeyd olunana qeder dongu bas verir
        /// </summary>
        /// <returns></returns>
        public static int TryParseMethod()
        {
        TRY: string num = Console.ReadLine();
           int input;
            bool isNum = int.TryParse(num, out input);
            if (isNum)
            {
                return input;
            }
            else
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, "Enter the correctly");
                goto TRY;
            }
        }

        /// <summary>
        /// Duzgun formada double qeyd olunana qeder dongu bas verir
        /// </summary>
        /// <returns></returns>
        public static double TryDoubleMethod()
        {
        TRY: string dbl = Console.ReadLine();
            double input;
            bool isNum = double.TryParse(dbl,out input); 
            if (isNum)
            {
                return input;
            }
            else
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, "Enter the correctly");
                goto TRY;
            }
        }

        /// <summary>
        /// ReadLine-dan gelen stringin bos ve ya null olmasinin qarsisini alir.Duz gun formada yazilana qeder dongu davam edir.
        /// </summary>
        /// <returns></returns>
        public static string TryNullOrEmptyMethod()
        {
        T1: string word = Console.ReadLine();

            if (String.IsNullOrEmpty(word))
            {
                Notifications.Display(ConsoleColor.Red, ConsoleColor.DarkRed, "Enter the correctly");
                goto T1;
            }
            return word;
        }

    }
}
