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
        public string No 
        { get 
            {
                return _no;
            }
          set 
            {
                int counter = 99;
                string soup = "S";
                string mainMeal = "M";
                string drinks = "D";
                string cookies = "C";
                switch(Categories)
                {
                    case Category.Soup:
                        _no = $"{soup}{counter++}";
                        break;
                    case Category.MainMeal:
                        _no = $"{mainMeal}{counter++}";
                        break;
                    case Category.Drink:
                        _no = $"{drinks}{counter++}";
                        break;
                    case Category.Cookies:
                        _no = $"{cookies}{counter++}";
                        break;
                    default:
                        throw new CategoryDoesNotExistException("Category doesn't exist");
                }

                    
            }
        }
        private string _name { get; set; }
        public string Name
        {
            get 
            {
                return _name;
            }
            set
            {
                RestarurantManager system = new RestarurantManager();
                foreach (var c in system.MenuItems)
                {
                    if (!(value == c.Name))
                        _name = value;
                    else throw new MenuItemAlreadyExistException("This name is already exist");
                }
                if (string.IsNullOrWhiteSpace(value))
                    throw new MenuItemAlreadyExistException("This name is already exist");
            }
        }
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
        public MenuItem (Category category)
        {
            this.Categories = category;
        }
        
   
    }
}
