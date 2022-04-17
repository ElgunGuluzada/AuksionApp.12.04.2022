using Business.Services;
using DataAccess;
using System;
using Utilities;
using Utilities.Helper;

namespace AuksionApp._12._04._2022.Controllers
{
    internal class BuyerController
    {
        BuyerService buyerService = new BuyerService();

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
            buyerService.Create(buyer);
            Notifications.Display(ConsoleColor.Green, ConsoleColor.DarkGreen, $" The {buyer.Name} {buyer.SurName} ,{buyer.Age} ,  was Created  on {DateTime.Now}\n");
        }
        public void UpdateBuyer()
        {
            if (DataContext.Buyers.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Buyer not available \n Please Try Again! \n");
            }
            else
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, " All Buyer \n");
                GetAllBuyers();
                Notifications.Display(ConsoleColor.Black, ConsoleColor.White, " Choose Buyer Id: ");
                int id = TryMethods.TryParseMethod();
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Enter new Name for Buyer");
                string newName = TryMethods.TryNullOrEmptyMethod();
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Enter new SurName for Buyer");
                string newSurName = TryMethods.TryNullOrEmptyMethod();
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Enter new Age for Buyer");
                int newAge = TryMethods.TryParseMethod();
                Buyer buyer = new Buyer()
                {
                    Name = newName,
                    SurName = newSurName,
                    Age = newAge
                };

                buyerService.Update(buyer, id);
            }
        }
        public void DeleteBuyer()
        {
            if (DataContext.Buyers.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Product not available \n Please Try Again! \n");
            }
            else
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, " All Products \n");
                GetAllBuyers();
                Notifications.Display(ConsoleColor.Black, ConsoleColor.White, " Choose Product Id: ");
                int id = TryMethods.TryParseMethod();
                buyerService.Delete(id);
            }
        }

        public void GetBuyer()
        {
            if (DataContext.Buyers.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Buyer not available \n Please Try Again! \n");
            }
            else
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Please Enter ID for searching \n");
                int id = TryMethods.TryParseMethod();
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" {buyerService.GetOne(id)} \n");
            }
        }

        public void GetAllBuyers()
        {
            Console.Clear();
            foreach (var byr in buyerService.GetAll())
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Buyer Id: {byr.Id}\n" +
                    $" Buyer Name: {byr.Name}\n" +
                    $" Buyer SurName: {byr.SurName} \n" +
                    $" Buyer Age: {byr.Age}\n");
            }
        }

        public void BuyBuyerForBuyer()
        {
            GetAllBuyers();
            Notifications.Display(ConsoleColor.Gray, ConsoleColor.White, $" Change Id Buyer for Add \n");
            int chngId = TryMethods.TryParseMethod();


            Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Enter Buyer Name: ");
            string prodName = TryMethods.TryNullOrEmptyMethod();

            Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $" Enter Buyer Age: ");
            int prodAge = TryMethods.TryParseMethod();


        }
    }
}
