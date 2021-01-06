using System;
using ConsoleProject.Classes;
using ConsoleProject.Enums;
using ConsoleProject.Exceptions;
using ConsoleProject.Services;
using System.Collections.Generic;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)

        {
            RestarurantManager restarurantManager = new RestarurantManager();
            restarurantManager.MenuItems = new List<MenuItem>();


            bool oprChecker = true;

        MenuStart:
            Console.WriteLine("\n============================");

            if (!oprChecker)
            {
                Console.WriteLine("Error! Please, choose the right option ");
                oprChecker = true;
            }

            Console.WriteLine("1. Options for Menu");
            Console.WriteLine("2. Options for Orders");
            Console.WriteLine("0. Exit");


            string selectedOpr = Console.ReadLine();

            switch (selectedOpr)
            {
                case "1":
                MenuStart2:
                    Console.WriteLine("\n============================");

                    if (!oprChecker)
                    {
                        Console.WriteLine("Error! Please, choose the right option ");
                        oprChecker = true;
                    }

                    Console.WriteLine("1. Add new item");
                    Console.WriteLine("2. Edit item");
                    Console.WriteLine("3. Delete item");
                    Console.WriteLine("4. Show all items");
                    Console.WriteLine("5. Filter items for Caegory");
                    Console.WriteLine("6. Filter items for Prices");
                    Console.WriteLine("7. Search items by name");
                    Console.WriteLine("0. Return to the previous Menu");


                    string selectedOpr1 = Console.ReadLine();

                    switch (selectedOpr1)
                    {
                        case "1":
                            AddMenuItem(ref restarurantManager);
                            break;

                        case "2":
                            EditMenuItem(ref restarurantManager);
                            break;

                        case "3":
                            RemoveMenuItem(ref restarurantManager);
                            break;

                        case "4":
                            ShowAllItems(ref restarurantManager);
                            break;

                        case "5":
                            FilterByCategory(ref restarurantManager);
                            break;
                        case "6":
                            FilterByPrices(ref restarurantManager);
                            break;
                        case "7":
                            SearchByName(ref restarurantManager);
                            break;
                        case "0":
                            goto MenuStart;
                        default:
                            oprChecker = false;
                            break;
                    }

                    goto MenuStart2;

                case "2":
                MenuStart3:
                    Console.WriteLine("\n============================");

                    if (!oprChecker)
                    {
                        Console.WriteLine("Error! Please, choose the right option ");
                        oprChecker = true;
                    }

                    Console.WriteLine("1. Add new order");
                    Console.WriteLine("2. Cancel the order");
                    Console.WriteLine("3. Show all orders");
                    Console.WriteLine("4. Show orders due to date range");
                    Console.WriteLine("5. Show orders due to price range");
                    Console.WriteLine("6. Show order of given date");
                    Console.WriteLine("7. Search items by no");
                    Console.WriteLine("0. Return to the previous Menu");


                    string selectedOpr2 = Console.ReadLine();

                    switch (selectedOpr2)
                    {
                        case "1":
                            AddOrder(ref restarurantManager);
                            break;
                        case "2":
                            RemoveOrder(ref restarurantManager);
                            break;
                        case "3":
                            ShowAllOrders(ref restarurantManager);
                            break;
                        case "4":
                            ShowOrdersDueToDateRange(ref restarurantManager);
                            break;
                        case "5":
                            ShowOrdersDueToPriceRange(ref restarurantManager);
                            break;
                        case "6":
                            ShowOrdersDueToDate(ref restarurantManager);
                            break;
                        case "7":
                            SearcOrder(ref restarurantManager);
                            break;
                        case "0":
                            goto MenuStart;

                        default:
                            oprChecker = false;
                            break;
                    }

                    goto MenuStart3;

                case "0":
                    return;
                default:
                    oprChecker = false;
                    break;
            }

            goto MenuStart;
        }
        #region MenuItem Methods
        public static void AddMenuItem(ref RestarurantManager restarurantManager)
        {
            Console.WriteLine("Menu item name:");
            string menuItemName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(menuItemName))
            {
                Console.WriteLine("Error! Write the MenuItem name properly:");
                menuItemName = Console.ReadLine();
            }
            while (restarurantManager.IsExistByName(menuItemName))
            {
                Console.WriteLine("Error! Write the MenuItem name properly:");
                menuItemName = Console.ReadLine();
            }

            Console.WriteLine("Price:");
            string priceStr = Console.ReadLine();
            double price;

            while (!double.TryParse(priceStr, out price) || price < 0)
            {
                Console.WriteLine("Error! Write the MenuItem price properly:");
                priceStr = Console.ReadLine();
            }
            Console.WriteLine("Choose the category:");

            string[] categoryNames = Enum.GetNames(typeof(Category));
            for (int i = 0; i < categoryNames.Length; i++)
            {
                Console.WriteLine(" " + i + "-" + categoryNames[i]);
            }

            string selectedEnumStr = Console.ReadLine();

            int selectedEnumInt;

            while (!int.TryParse(selectedEnumStr, out selectedEnumInt) || selectedEnumInt < 0 || selectedEnumInt >= categoryNames.Length)
            {
                Console.WriteLine("Error! Choose the right option:");
                selectedEnumStr = Console.ReadLine();
            }
            Category selectedCategory = (Category)selectedEnumInt;

            try
            {
                restarurantManager.AddMenuItem(menuItemName, price, selectedCategory);
                Console.WriteLine("MenuItem added, successfully");
            }
            catch (MenuItemAlreadyExistException ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }

        }
        public static void EditMenuItem(ref RestarurantManager restarurantManager)
        {
            Console.WriteLine("Menu item no:");
            string menuItemNo = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(menuItemNo))
            {
                Console.WriteLine("Error! Write the MenuItem no properly:");
                menuItemNo = Console.ReadLine();
            }

            Console.WriteLine("Menu item name:");
            string menuItemName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(menuItemName))
            {
                Console.WriteLine("Error! Write the MenuItem name properly:");
                menuItemName = Console.ReadLine();
            }

            Console.WriteLine("Price:");
            string priceStr = Console.ReadLine();
            double price;

            while (!double.TryParse(priceStr, out price) || price < 0)
            {
                Console.WriteLine("Error! Write the MenuItem price properly:");
                priceStr = Console.ReadLine();
            }

            try
            {
                restarurantManager.EditMenuItem(menuItemNo, menuItemName, price);
                Console.WriteLine("MenuItem edited, successfully");
            }
            catch (MenuItemDoesNotExist ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
        public static void RemoveMenuItem(ref RestarurantManager restarurantManager)
        {
            Console.WriteLine("Menu item no:");
            string menuItemNo = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(menuItemNo))
            {
                Console.WriteLine("Error! Write the MenuItem name properly:");
                menuItemNo = Console.ReadLine();
            }
            try
            {
                restarurantManager.RemoveMenuItem(menuItemNo);
                Console.WriteLine("MenuItem deleted, successfully");
            }
            catch (MenuItemDoesNotExist ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }

        }
        public static void ShowAllItems(ref RestarurantManager restarurantManager)
        {
            restarurantManager.ShowAllItems();
        }
        public static void FilterByCategory(ref RestarurantManager restarurantManager)
        {
            Console.WriteLine("Choose the category:");

            string[] categoryNames = Enum.GetNames(typeof(Category));
            for (int i = 0; i < categoryNames.Length; i++)
            {
                Console.WriteLine(" " + i + "-" + categoryNames[i]);
            }

            string selectedEnumStr = Console.ReadLine();

            int selectedEnumInt;

            while (!int.TryParse(selectedEnumStr, out selectedEnumInt) || selectedEnumInt < 0 || selectedEnumInt >= categoryNames.Length)
            {
                Console.WriteLine("Error! Choose the right option:");
                selectedEnumStr = Console.ReadLine();
            }
            Category selectedCategory = (Category)selectedEnumInt;
            try
            {
                restarurantManager.ShowAllItems(restarurantManager.MenuItemsSortByCategory(selectedCategory));

            }
            catch (MenuItemDoesNotExist ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
        public static void FilterByPrices(ref RestarurantManager restarurantManager)
        {
            Console.WriteLine("Price:");
            string priceStr = Console.ReadLine();
            double price;

            while (!double.TryParse(priceStr, out price) || price < 0)
            {
                Console.WriteLine("Error! Write the MenuItem price properly:");
                priceStr = Console.ReadLine();
            }
            Console.WriteLine("Price 2:");
            string priceStr1 = Console.ReadLine();
            double price1;

            while (!double.TryParse(priceStr1, out price1) || price1 < 0)
            {
                Console.WriteLine("Error! Write the MenuItem price properly:");
                priceStr1 = Console.ReadLine();
            }
            try
            {
                restarurantManager.ShowAllItems(restarurantManager.MenuItemsSortByPrice(price, price1));

            }
            catch (MenuItemDoesNotExist ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
        public static void SearchByName(ref RestarurantManager restarurantManager)
        {
            Console.WriteLine("Menu item name:");
            string menuItemName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(menuItemName))
            {
                Console.WriteLine("Error! Write the MenuItem name properly:");
                menuItemName = Console.ReadLine();
            }
            try
            {
                restarurantManager.ShowAllItems(restarurantManager.MenuItemsSearch(menuItemName));

            }
            catch (MenuItemDoesNotExist ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
        #endregion

        #region Order Methods
        public static void AddOrder(ref RestarurantManager restarurantManager)
        {
            Console.WriteLine("Menu item no:");
            string menuItemNo = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(menuItemNo))
            {
                Console.WriteLine("Error! Write the MenuItem no properly:");
                menuItemNo = Console.ReadLine();
            }
            Console.WriteLine("Count:");
            string countStr = Console.ReadLine();
            int count;

            while (!int.TryParse(countStr, out count) || count < 0)
            {
                Console.WriteLine("Error! Write the MenuItem count properly:");
                countStr = Console.ReadLine();
            }
            Order order = new Order();


            try
            {
                foreach (var c in restarurantManager.MenuItems)
                {
                    if (c.No == menuItemNo)
                    {
                        restarurantManager.AddOrder(c, count);
                        Console.WriteLine("Order is added, successfuly");

                    }
                }
            }
            catch (OrderDoesNotExist ex)
            {
                Console.WriteLine($" {ex.Message}");
            }

        }
        public static void RemoveOrder (ref RestarurantManager restarurantManager)
        {
            Console.WriteLine("Order No:");
            string noStr = Console.ReadLine();
            int no;

            while (!int.TryParse(noStr, out no) || no < 0)
            {
                Console.WriteLine("Error! Write the MenuItem no properly:");
                noStr = Console.ReadLine();
            }
            try
            {               
                    
              restarurantManager.RemoveOrder(no); 
              Console.WriteLine("Order is removed, successfuly");

                
            }
            catch(OrderDoesNotExist ex)
            {
                Console.WriteLine($" {ex.Message}");

            }

        }
        public static void ShowAllOrders (ref RestarurantManager restarurantManager)
        {
            restarurantManager.ShowAllOrders();
        }
        public static void ShowOrdersDueToDateRange (ref RestarurantManager restarurantManager)
        {
            Console.WriteLine("Write the start #date month/day/year#:");
            DateTime date1 = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Write the finish #date month/day/year#:");
            DateTime date2 = Convert.ToDateTime(Console.ReadLine());
            try
            {
                restarurantManager.ShowAllOrders(restarurantManager.GetOrderByDateInterval(date1, date2));

            }
            catch (OrderDoesNotExist ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
        public static void ShowOrdersDueToPriceRange (ref RestarurantManager restarurantManager)
        {
            Console.WriteLine("Price:");
            string priceStr = Console.ReadLine();
            double price;

            while (!double.TryParse(priceStr, out price) || price < 0)
            {
                Console.WriteLine("Error! Write the Order price properly:");
                priceStr = Console.ReadLine();
            }
            Console.WriteLine("Price 2:");
            string priceStr1 = Console.ReadLine();
            double price1;

            while (!double.TryParse(priceStr1, out price1) || price1 < 0)
            {
                Console.WriteLine("Error! Write the Order price properly:");
                priceStr1 = Console.ReadLine();
            }
            try
            {
                
                restarurantManager.ShowAllOrders(restarurantManager.GetOrdersByPriceInterval(price, price1));

            }
            catch (OrderItemDoesNotExist ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }

        }
        public static void ShowOrdersDueToDate(ref RestarurantManager restarurantManager)
        {
            Console.WriteLine("Write the date #month/day/year#:");
            DateTime date1 = Convert.ToDateTime(Console.ReadLine());
            try
            {
                restarurantManager.ShowAllOrders(restarurantManager.GetOrderByDate(date1));

            }
            catch (OrderDoesNotExist ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
        public static void SearcOrder(ref RestarurantManager restarurantManager)
        {
            Console.WriteLine("Order No:");
            string noStr = Console.ReadLine();
            int no;

            while (!int.TryParse(noStr, out no) || no < 0)
            {
                Console.WriteLine("Error! Write the MenuItem price properly:");
                noStr = Console.ReadLine();
            }
            try
            {
                Order c = new Order();
                c = restarurantManager.GetOrderByNo(no);
                Console.WriteLine($"No: {c.No}\n Amount: {c.TotalAmount}\n Category: {c.Date}\n Count:{c.OrderItems.Count}");

            }
            catch (OrderDoesNotExist ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }



        #endregion
    }

}

