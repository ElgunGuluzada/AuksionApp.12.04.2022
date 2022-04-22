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
            Notifications.Display(ConsoleColor.White, ConsoleColor.DarkCyan, "Enter to Buyer Name: ");
            string name = TryMethods.TryNullOrEmptyMethod();
            Notifications.Display(ConsoleColor.White, ConsoleColor.DarkCyan, "Enter to Buyer Surname: ");
            string surname = TryMethods.TryNullOrEmptyMethod();
            Notifications.Display(ConsoleColor.White, ConsoleColor.DarkCyan, "Enter to Buyer Age: ");
            int age = TryMethods.TryParseMethod();

            Buyer buyer = new Buyer()
            {
                Name = name,
                SurName = surname,
                Age = age
            };
            Console.Clear();
            buyerService.Create(buyer);
            Notifications.Display(ConsoleColor.Green, ConsoleColor.White, $" The {buyer.Name} {buyer.SurName} ,{buyer.Age} ,  was Created  on {DateTime.Now}\n");
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
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Buyer not available \n Please Try Again! \n");
            }
            else
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, " All Buyers \n");
                GetAllBuyers();
                Notifications.Display(ConsoleColor.Black, ConsoleColor.White, " Choose Buyer Id: ");
                int id = TryMethods.TryParseMethod();
                buyerService.Delete(id);
            }
        }
        /// <summary>
        /// Bu Method ise dusduyunde id-e gor hemin alicini tapir ve ekrana cap edir.
        /// </summary>
        /// <returns></returns>
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
                buyerService.GetOne(id);
            }
        }

        /// <summary>
        /// Bu Method ise dusduyunde butun alicilari tapir ve ekrana cap edir.
        /// </summary>
        /// <returns></returns>
        public void GetAllBuyers()
        {
            foreach (var byr in buyerService.GetAll())
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $"          Buyer Id: {byr.Id}\n" +
                    $"          Buyer Name: {byr.Name}\n" +
                    $"          Buyer SurName: {byr.SurName} \n" +
                    $"          Buyer Age: {byr.Age}\n");
                foreach (var prdct in byr.Products)
                {
                    Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $"           Product Id: {prdct.Id}\n" +
                  $"           Product Name: {prdct.Name}\n" +
                  $"           Product Price: {prdct.Price}\n\n");
                }
            }
        }
       
        /// <summary>
        /// Bu metod alici ucun mehsul almaq ucun isleyir.
        /// </summary>
        /// <returns></returns>
        public void BuyProductForBuyer()
        {
            if (DataContext.Buyers.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Buyer not available \n Please Write 8! \n");
            }
            else
            {
                GetAllBuyers();

                Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" Entry Product Name for Add to Buyer \n");
                string prdctName = TryMethods.TryNullOrEmptyMethod();
                Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" Entry Product Price \n");
                int prdctPrice = TryMethods.TryParseMethod();
                Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" Entry Id Buyer for Add \n");
                int byrId = TryMethods.TryParseMethod();

                Product product = new Product()
                {
                    Name = prdctName,
                    Price = prdctPrice,
                    BuyerId = byrId
                };
                buyerService.BuyProductForBuyer(product);
            }
        }
    }
}
