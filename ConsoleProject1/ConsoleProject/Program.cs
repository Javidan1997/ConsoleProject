using System;

namespace ConsoleProject
{
    class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine("3. Exit");
            

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
                            
                        case "2":

                        case "3":

                        case "4":

                        case "5":

                        case "6":

                        case "7":

                        case "0":
                            return;
                        default:
                            oprChecker = false;
                            break;
                    }

                    goto MenuStart2;
                    
                case "2":
                
                case "3":
              
                case "0":
                    return;
                default:
                    oprChecker = false;
                    break;
            }

            goto MenuStart;
        }

    }

}

