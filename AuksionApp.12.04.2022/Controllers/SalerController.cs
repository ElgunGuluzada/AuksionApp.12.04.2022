using Business.Services;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;
using Utilities.Helper;

namespace AuksionApp._12._04._2022.Controllers
{
    internal class SalerController
    {
        SalerService salerService = new SalerService();
     
        public void CreateSaler()
        {
            Notifications.Display(ConsoleColor.Cyan, ConsoleColor.DarkCyan, "Enter to Saler Name: ");
            string name = TryMethods.TryNullOrEmptyMethod();
            Notifications.Display(ConsoleColor.Cyan, ConsoleColor.DarkCyan, "Enter to Saler Surname: ");
            string surname = TryMethods.TryNullOrEmptyMethod();
            Notifications.Display(ConsoleColor.Cyan, ConsoleColor.DarkCyan, "Enter to Saler Age: ");
            int age = TryMethods.TryParseMethod();

            Saler saler = new Saler()
            {
                Name = name,
                SurName = surname,
                Age = age
            };
            Console.Clear();
            salerService.Create(saler);
            Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, $" The {saler.Name} {saler.SurName} ,{saler.Age} ,  was Created  on {DateTime.Now}\n");
        }
        public void UpdateSaler()
        {
            if (DataContext.Salers.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Saler not available \n Please Try Again! \n");
            }
            else
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, " All Saler \n");
                GetAllSalers();
                Notifications.Display(ConsoleColor.Black, ConsoleColor.White, " Choose Saler Id: ");
                int id = TryMethods.TryParseMethod();
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Enter new Name for Saler");
                string newName = TryMethods.TryNullOrEmptyMethod();
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Enter new SurName for Saler");
                string newSurName = TryMethods.TryNullOrEmptyMethod();
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Enter new Age for Saler");
                int newAge = TryMethods.TryParseMethod();
                Saler saler = new Saler()
                {
                    Name = newName,
                    SurName = newSurName,
                    Age = newAge
                };
                salerService.Update(saler, id);
            }
        }
        public void DeleteSaler()
        {
            if (DataContext.Buyers.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Saler not available \n Please Try Again! \n");
            }
            else
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, " All Saler \n");
                GetAllSalers();
                Notifications.Display(ConsoleColor.Black, ConsoleColor.White, " Choose Saler Id: ");
                int id = TryMethods.TryParseMethod();
                salerService.Delete(id);
            }
        }

        public void GetSaler()
        {
            if (DataContext.Salers.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Saler not available \n Please Try Again! \n");
            }
            else
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Please Enter ID for searching \n");
                int id = TryMethods.TryParseMethod();
                salerService.GetOne(id);
            }
        }

        public void GetAllSalers()
        {
            foreach (var slr in salerService.GetAll())
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Saler Id: {slr.Id}\n" +
                    $" Saler Name: {slr.Name}\n" +
                    $" Saler SurName: {slr.SurName}\n" +
                    $" Saler Age: {slr.Age}\n");
            }
        }
    }

}
