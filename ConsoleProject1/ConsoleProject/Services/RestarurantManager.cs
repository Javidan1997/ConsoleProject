using ConsoleProject.Classes;
using ConsoleProject.Enums;
using ConsoleProject.Exceptions;
using ConsoleProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ConsoleProject.Services
{
    class RestarurantManager : IRestaurantManager
    {
        public List<MenuItem> MenuItems { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        List<MenuItem> IRestaurantManager.MenuItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        List<Order> IRestaurantManager.Orders { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public RestarurantManager()
        {
            List<MenuItem> MenuItems = new List<MenuItem>();
            List<OrderItem> OrderItems = new List<OrderItem>();
            List<Order> Orders = new List<Order>();


        }
        public void AddMenuItem(string name, double price, Category category)
        {
            MenuItem newItem = new MenuItem(category);
            newItem.Name = name;
            newItem.Price = price;
            newItem.Categories = category;
            if (!this.MenuItems.Contains(newItem))
                MenuItems.Add(newItem);
            else throw new MenuItemAlreadyExistException("MenuItem is already added");

        }

        public void AddOrder(MenuItem menuitem, int count)
        {
            MenuItem newMenuItem = new MenuItem(menuitem.Categories);
            newMenuItem = menuitem;
            int countOfOrder = count;
            OrderItem newOrder = new OrderItem(newMenuItem, countOfOrder);

            this.OrderItems.Add(newOrder);

        }

       public void EditMenuItem(string no, string name, double price)
        {
            foreach (var c in MenuItems)
            {
                if (c.No == no)
                { c.Name = name;
                  c.Price = price;
                }
            }

        }

        public List<Order> GetOrderByDate(DateTime date)
        {
            List<Order> newList = new List<Order>();
            foreach (var c in this.Orders)
            {
                if (c.Date == date)
                    newList.Add(c);
            }
            if (newList.Contains(null))
                throw new OrderDoesNotExist("Order doesn't exist");
            else
                return newList;

        }

        public List<Order> GetOrderByDateInterval(DateTime dateTime, DateTime dateTime1)
        {
            int date = Convert.ToInt32(dateTime);
            int date1 = Convert.ToInt32(dateTime1);
            List<Order> newList = new List<Order>();

            foreach (var c in this.Orders)
            {
                int dateOfc = Convert.ToInt32(c.Date);
                if (date <= dateOfc && dateOfc <= date1)
                    newList.Add(c);
              
            }
            if (newList.Contains(null))
                throw new OrderDoesNotExist("Order doesn't exist");
            else
                return newList;
        }

        public Order GetOrderByNo(int No)
        {
            Order order = new Order();
            foreach (var c in this.Orders)
            {
                if (c.No == No)
                    order = c;
            }
            if (order.Equals(null))
                throw new OrderDoesNotExist("Order doesn't exist");
            else
                return order;
        }
        public List<OrderItem> GetOrdersByPriceInterval(double price, double price1)
        {
            List<OrderItem> newList = new List<OrderItem>();
            foreach (var c in this.OrderItems)
            {
                if (price <= c.MenuItem.Price && c.MenuItem.Price <= price1)
                    newList.Add(c);

            }
            if (newList.Contains(null))
                throw new OrderItemDoesNotExist("OrderItem doesn't exist");
            else
                return newList;
        }

        public List<MenuItem> MenuItemsSearch(string info)
        {
            List<MenuItem> newList = new List<MenuItem>();
            foreach (var c in this.MenuItems)
            {
                string name = c.Name.Trim().ToLower();
                if (name.Contains(info.Trim().ToLower()))
                    newList.Add(c);
            }
            if (newList.Contains(null))
                throw new MenuItemDoesNotExist("MenuItem doesn't exist");
            else
                return newList;
        }
        public List<MenuItem> MenuItemsSortByCategory(Category category)
        {
            List<MenuItem> newList = new List<MenuItem>();
            foreach (var c in this.MenuItems)
            {
                if (c.Categories == category)
                {
                    newList.Add(c);
                }
            }
            if(newList.Contains(null))
            throw new MenuItemDoesNotExist("MenuItem doesn't exist");
            else
            return newList;
        }


        public List<MenuItem> MenuItemsSortByPrice(double price, double price1)
        {
            List<MenuItem> newList = new List<MenuItem>();
            foreach (var c in this.MenuItems)
            {
                if (price <= c.Price && c.Price <= price1)
                    newList.Add(c);
            }
            if (newList.Contains(null))
                throw new MenuItemDoesNotExist("MenuItem doesn't exist");
            else
                return newList;
        }

        public void RemoveMenuItem(string no)
        {
            foreach (var c in MenuItems)
            {
                if (c.No == no)
                    this.MenuItems.Remove(c);
                else throw new MenuItemDoesNotExist("MenuItem doesn't exist");
            }
        }

        public void RemoveOrder(int no)
        {
            foreach (var c in this.Orders)
            {
                if (c.No == no)
                    this.Orders.Remove(c);
                else throw new OrderDoesNotExist("Order doesn't exist");
            }
        }
    }
}
