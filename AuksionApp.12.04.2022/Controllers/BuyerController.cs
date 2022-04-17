using Business.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Utilities;
using Utilities.Helper;

namespace AuksionApp._12._04._2022.Controllers
{
    internal class BuyerController
    {
        private BuyerService _buyerService;
        public BuyerController()
        {
            _buyerService = new BuyerService();
        }
        public void CreateBuyer()
        {
            Notifications.Display(ConsoleColor.Cyan, ConsoleColor.DarkCyan, "Enter to buyer Name: ");
            string name = TryMethods.TryNullOrEmptyMethod();
            Notifications.Display(ConsoleColor.Cyan, ConsoleColor.DarkCyan, "Enter to buyer Surname: ");
            string surname = TryMethods.TryNullOrEmptyMethod();
            Notifications.Display(ConsoleColor.Cyan, ConsoleColor.DarkCyan, "Enter to buyer Age: ");
            int age = TryMethods.TryParseMethod();

            Buyer buyer = new Buyer()
            {
                Name = name,
                SurName = surname,
                Age = age
            };
            Console.Clear();
            _buyerService.Create(buyer);
            Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, $" The {buyer.Name} {buyer.SurName} ,{buyer.Age} ,  was Created  on {DateTime.Now}\n");
        }
        public void UpdateBuyer()
        {
            if (BuyerService.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Buyer not available \n Please Try Again! \n");
                return;
            }
            Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, "All buyers \n");
            foreach (var byr in _buyerService.GetAll())
            {
                int oldAge = byr.Age;
                string oldName = byr.Name;
                string oldSurname = byr.SurName;
                Notifications.Display(ConsoleColor.Black, ConsoleColor.White, $" {byr.Id} {byr.Name} {byr.SurName} {byr.Age} \n");
            Choose: Notifications.Display(ConsoleColor.Black, ConsoleColor.White, "Choose buyer Id: ");
                int id = TryMethods.TryParseMethod();
                if (byr.Id == id)
                {
                    Notifications.Display(ConsoleColor.DarkGray, ConsoleColor.White, "New Buyer Name: ");
                    string newName = TryMethods.TryNullOrEmptyMethod();
                    Notifications.Display(ConsoleColor.DarkGray, ConsoleColor.White, "New Buyer Surname: ");
                    string newSurname = TryMethods.TryNullOrEmptyMethod();
                    Notifications.Display(ConsoleColor.DarkGray, ConsoleColor.White, "New Buyer Age: ");
                    int newAge = TryMethods.TryParseMethod();
                    Buyer buyer = new Buyer()
                    {
                        Name = newName,
                        SurName = newSurname,
                        Age = newAge
                    };
                    _buyerService.Update(buyer, id);
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
                    Notifications.Display(ConsoleColor.DarkRed, ConsoleColor.White, $" The {byr.Id} is not Exist in this List.\n Please Try Again! \n");
                    goto Choose;
                }
            }
        }
        public void DeleteBuyer()
        {
            if (BuyerService.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Buyer not available \n Please Try Again! \n");
                return;
            }

            Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, "All buyers");
            foreach (var byr in _buyerService.GetAll())
            {
                Notifications.Display(ConsoleColor.Black, ConsoleColor.White, $" {byr.Id} {byr.Name} {byr.SurName} {byr.Age} \n");
            C1: Notifications.Display(ConsoleColor.Black, ConsoleColor.White, "Choose Buyer Id: ");
                int id = TryMethods.TryParseMethod();
                if (byr.Id == id)
                {
                    Buyer buyer = _buyerService.Delete(id);
                    Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $"{buyer.Name} was deleted \n");
                    break;
                }
                else
                {
                    Notifications.Display(ConsoleColor.DarkRed, ConsoleColor.White, $" The {byr.Id} is Not Exist in This List.\n Please Try Again! \n");
                    goto C1;
                }
            }
        }

        public void GetBuyer()
        {

        }

        public void GetAllBuyers()
        {
            Console.Clear();
            foreach (var byr in _buyerService.GetAll())
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Buyer Id: {byr.Id}\n" +
                    $" Buyer Name: {byr.Name}\n" +
                    $" Buyer SurName: {byr.SurName} \n" +
                    $" Buyer Age: {byr.Age}\n");
            }
        }
    }
}
