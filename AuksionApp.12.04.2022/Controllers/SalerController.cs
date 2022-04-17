using Business.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;
using Utilities.Helper;

namespace AuksionApp._12._04._2022.Controllers
{
    internal class SalerController
    {
        private SalerService _salerService;
        public SalerController()
        {
            _salerService = new SalerService();
        }
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
            _salerService.Create(saler);
            Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, $" The {saler.Name} {saler.SurName} ,{saler.Age} ,  was Created  on {DateTime.Now}\n");
        }
        public void UpdateSaler()
        {
            if (SalerService.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Saler not available \n Please Try Again! \n");
                return;
            }
            Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, "All Salers \n");
            foreach (var slr in _salerService.GetAll())
            {
                int oldAge = slr.Age;
                string oldName = slr.Name;
                string oldSurname = slr.SurName;
                Notifications.Display(ConsoleColor.Black, ConsoleColor.White, $" {slr.Id} {slr.Name} {slr.SurName} {slr.Age} \n");
            Choose: Notifications.Display(ConsoleColor.Black, ConsoleColor.White, "Choose Saler Id: ");
                int id = TryMethods.TryParseMethod();
                if (slr.Id == id)
                {
                    Notifications.Display(ConsoleColor.DarkGray, ConsoleColor.White, "New Saler Name: ");
                    string newName = TryMethods.TryNullOrEmptyMethod();
                    Notifications.Display(ConsoleColor.DarkGray, ConsoleColor.White, "New Saler Surname: ");
                    string newSurname = TryMethods.TryNullOrEmptyMethod();
                    Notifications.Display(ConsoleColor.DarkGray, ConsoleColor.White, "New Saler Age: ");
                    int newAge = TryMethods.TryParseMethod();
                    Saler saler = new Saler()
                    {
                        Name = newName,
                        SurName = newSurname,
                        Age = newAge
                    };
                    _salerService.Update(saler, id);
                    if (oldAge < newAge)
                    {
                        Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" The {oldName} change to {newName} {oldSurname} change to {newSurname} and Age Up {oldAge} to {newAge} \n");
                        break;
                    }
                    else if (oldAge > newAge)
                    {
                        Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" The {oldName} change to {newName} {oldSurname} change to {newSurname} and Age Down {oldAge} to {newAge} \n");
                        break;
                    }
                    else
                    {
                        Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" The {oldName} change to {newName} {oldSurname} change to {newSurname} and Age Doesn't Change! \n");
                        break;
                    }
                }
                else
                {
                    Notifications.Display(ConsoleColor.DarkRed, ConsoleColor.White, $" The {slr.Id} is not Exist in this List.\n Please Try Again! \n");
                    goto Choose;
                }
            }
        }
        public void DeleteSaler()
        {
            if (SalerService.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Saler not available \n Please Try Again! \n");
                return;
            }

            Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, "All Salers");
            foreach (var slr in _salerService.GetAll())
            {
                Notifications.Display(ConsoleColor.Black, ConsoleColor.White, $" {slr.Id} {slr.Name} {slr.SurName} {slr.Age} \n");
            C1: Notifications.Display(ConsoleColor.Black, ConsoleColor.White, "Choose Saler Id: ");
                int id = TryMethods.TryParseMethod();
                if (slr.Id == id)
                {
                    Saler Saler = _salerService.Delete(id);
                    Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $"{Saler.Name} was deleted \n");
                    break;
                }
                else
                {
                    Notifications.Display(ConsoleColor.DarkRed, ConsoleColor.White, $" The {slr.Id} is Not Exist in This List.\n Please Try Again! \n");
                    goto C1;
                }
            }
        }

        public void GetSaler()
        {

        }

        public void GetAllSalers()
        {
            Console.Clear();
            foreach (var slr in _salerService.GetAll())
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Saler Id: {slr.Id}\n" +
                    $" Saler Name: {slr.Name}\n" +
                    $" Saler SurName: {slr.SurName}\n" +
                    $" Saler Age: {slr.Age}\n");
            }
        }
    }

}
