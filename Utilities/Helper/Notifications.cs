using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public  class Notifications
    {
        public void Display(ConsoleColor frgColor,ConsoleColor bckColor,string message)
        {
            Console.ForegroundColor = frgColor;
            Console.BackgroundColor = bckColor;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
