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
            foreach (var sylr in salerService.GetAll())
            {
                Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $"          Saler Id: {sylr.Id}\n" +
                    $"          Saler Name: {sylr.Name}\n" +
                    $"          Saler SurName: {sylr.SurName}\n" +
                    $"          Saler Age: {sylr.Age}\n");
                foreach (var prdct in sylr.Products)
                {
                    Notifications.Display(ConsoleColor.DarkBlue, ConsoleColor.White, $"           Product Id: {prdct.Id}\n" +
                  $"           Product Name: {prdct.Name}\n" +
                  $"           Product Price: {prdct.Price}\n\n");
                }
            }
        }
        public void BuyProductForSaler()
        {
            if (DataContext.Salers.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Saler not available \n Please Write 15! \n");
            }
            else
            {
                GetAllSalers();

                Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" Entry Product Name for Add to Saler \n");
                string prdctName = TryMethods.TryNullOrEmptyMethod();
                Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" Entry Product Price \n");
                int prdctPrice = TryMethods.TryParseMethod();
                Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" Entry Id Saler for Add \n");
                int sylrId = TryMethods.TryParseMethod();

                Product product = new Product()
                {
                    Name = prdctName,
                    Price = prdctPrice,
                    BuyerId = sylrId
                };
                salerService.BuyProductForSaler(product);
            }
        }
        public void SaleProduct()
        {
            if (DataContext.Salers.Count <= 0)
            {
                Notifications.Display(ConsoleColor.White, ConsoleColor.DarkRed, " Saler not available \n Please Write 15! \n");
            }
            else
            {
                GetAllSalers();

                Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" Entry Product Name for Add to Saler \n");
                string prdctName = TryMethods.TryNullOrEmptyMethod();
                Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" Entry Product Price  \n");
                int prdctPrice = TryMethods.TryParseMethod();
                Notifications.Display(ConsoleColor.DarkGreen, ConsoleColor.White, $" Entry Id Saler for Add \n");
                int sylrId = TryMethods.TryParseMethod();

                Product product = new Product()
                {
                    Name = prdctName,
                    Price = prdctPrice,
                    BuyerId = sylrId
                };
                salerService.SaleProduct(product);
            }
        }


        public void SaleProductForBuyer()
        {
            BuyerController buyerController = new BuyerController();
            GetAllSalers();
            buyerController.GetAllBuyers();
            if (DataContext.Salers.Count <= 0)
            {
                Notifications.Display(ConsoleColor.DarkRed,ConsoleColor.White, " First Create Saler\n Please Try Again \n Write 15! \n");
            }
            else
            {

            Notifications.Display(ConsoleColor.Yellow, ConsoleColor.Black, $" Entry Product Id for Add to Buyer \n");
            int prdctId = TryMethods.TryParseMethod();
            Notifications.Display(ConsoleColor.Yellow, ConsoleColor.Black, $" Entry Saler Id \n");
            int sylrId = TryMethods.TryParseMethod();
            Notifications.Display(ConsoleColor.Yellow, ConsoleColor.Black, $" Entry Id Buyer for Add \n");
            int byrId = TryMethods.TryParseMethod();

           
            salerService.SaleProductForBuyer(prdctId,sylrId,byrId);
            }
        }
    }
}
