using ConsoleProject.Classes;
using ConsoleProject.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Interfaces
{
     interface IRestaurantManager
    {
        public List<MenuItem> MenuItems { get; set; }
        public List <Order> Orders { get; set; }
        void AddOrder(MenuItem menuitem, int count);

        void RemoveOrder(int no);

        List<Order> GetOrderByDateInterval(DateTime dateTime, DateTime dateTime1);

        List<Order> GetOrderByDate(DateTime date);

        List<OrderItem> GetOrdersByPriceInterval(double price, double price1);

        Order GetOrderByNo(int No);

        void AddMenuItem(string name, double price, Category category);

        void RemoveMenuItem(string no);

        void EditMenuItem(string no, string name, double price);

        List<MenuItem> MenuItemsSortByCategory(Category category);

        List<MenuItem> MenuItemsSortByPrice(double price, double price1);

        List<MenuItem> MenuItemsSearch(string info);
       


    }
}
