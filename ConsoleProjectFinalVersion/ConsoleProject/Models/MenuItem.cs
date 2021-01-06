using ConsoleProject.Enums;
using ConsoleProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ConsoleProject.Services;
using ConsoleProject.Exceptions;

namespace ConsoleProject.Classes
{
    public class MenuItem
    {
        private string _no { get; set; }
        public string No { get { return this._no; } }
            
        public string Name { get; set; }
                   
        public double _price { get; set; }
        public double Price 
        { get
            { return _price; }
          set
            { if (value > 0)
                    _price = value;
            }
        }
        public Category Categories { get; set; }

        private static string soup = "SO";
        private static string mainMeal = "MM";
        private static string drinks = "DR";
        private static string cookies = "CK";
        public static int counter { get; set; } = 100;
        private static int counter1 { get; set; } = 100;
        private static int counter2 { get; set; } = 100;
        private static int counter3 { get; set; } = 100;
        

        public MenuItem (string name, double price, Category category)
        {
            this.Categories = category;
            this._price = price;
            this.Name = name;

            switch (Categories)
                {
                    case Category.Soup:
                     counter++;
                        this._no = $"{soup}{counter}";
                        break;
                    case Category.MainMeal:
                      counter1++;
                        this._no = $"{mainMeal}{counter1}";
                        break;
                    case Category.Drink:
                         counter2++;
                        this._no = $"{drinks}{counter2}";
                        break;
                    case Category.Cookies:
                          counter3++;
                        this._no = $"{cookies}{counter3}";
                        break;
                    default:
                        throw new CategoryDoesNotExistException("Category doesn't exist");
                }
            

        }


    }
}
