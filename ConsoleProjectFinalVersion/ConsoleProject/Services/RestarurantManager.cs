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
    public class RestarurantManager : IRestaurantManager
    {
        public List<MenuItem> MenuItems { get; set; }
        public List<Order> Orders { get; set; }

        
        public RestarurantManager()
        {
            MenuItems = new List<MenuItem>();
            Orders = new List<Order>();

        }
        public bool IsExistByName(string name)
        {
            string nameStr = name.ToLower().Trim();
            return MenuItems.Exists(b => b.Name.ToLower().Trim() == nameStr);
        }
        public void ShowAllItems ()
        {
            foreach(var c in this.MenuItems)
            {
                Console.WriteLine("\n=========================");
                Console.WriteLine($"Name: {c.Name}\nPrice: {c.Price}\nCategory: {c.Categories}\nNo:{c.No}");
            }
        }
        public void ShowAllOrders()
        {
            foreach (var c in this.Orders)
            {
                Console.WriteLine("\n=========================");
                Console.WriteLine($"No: {c.No}\nTotal Amount: {c.TotalAmount}\nDate: {c.Date}\nCount: {c.OrderItems.Count}");
            }
        }
        public void ShowAllItems(List<MenuItem> menuItems)
        {
            foreach (var c in menuItems)
            {
                Console.WriteLine("\n=========================");
                Console.WriteLine($"Name: {c.Name}\nPrice: {c.Price}\nCategory: {c.Categories}\nNo:{c.No}");
            }
        }
        public void ShowAllOrders(List<Order> orders)
        {
            foreach (var c in orders)
            {
                Console.WriteLine("\n=========================");
                Console.WriteLine($"No: {c.No}\nTotal Amount: {c.TotalAmount}\nDate: {c.Date}\nCount: {c.OrderItems.Count}");
            }
        }
        public void ShowAllOrders(List<OrderItem> orderItems)
        {
            foreach (var c in orderItems)
            {
                Console.WriteLine("\n=========================");
                Console.WriteLine($"Count: {c.Count}\nMenuItem Name: {c.MenuItem.Name}\nPrice: {c.MenuItem.Price}\nNo:{c.MenuItem.No}");
            }
        }
        public void AddMenuItem(string name, double price, Category category)
        {
            MenuItem newItem = new MenuItem(name, price,category);
            
           this.MenuItems.Add( newItem);


        }

        public void AddOrder(MenuItem menuitem, int count)
        {
            OrderItem orderItem = new OrderItem(menuitem, count);
            Order order = new Order();
            order.OrderItems.Add(orderItem);
            this.Orders.Add(order);
            order.Sell(menuitem.Name, count);

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
            newList = Orders.FindAll(i => i.Date == date);
            if (newList.Contains(null))
                throw new OrderDoesNotExist("Order doesn't exist");
            else
                return newList;

        }

        public List<Order> GetOrderByDateInterval(DateTime dateTime, DateTime dateTime1)
        {
            List<Order> newList = new List<Order>();

            if (dateTime != null && dateTime1 != null)
            {
                if (dateTime < dateTime1)
                {
                     newList = Orders.FindAll(i => i.Date >= dateTime && i.Date <= dateTime1);
                    return newList;
                }
                else
                {
                    throw new DateIsInvalidException("Date is invalid");
                }
            }
            else
            {
                throw new DateIsInvalidException("Date is invalid");

            }
        }

        public Order GetOrderByNo(int No)
        {
            Order order = new Order();
            order = Orders.Find(i => i.No==No);
            if (order.Equals(null))
                throw new OrderDoesNotExist("Order doesn't exist");
            else
                return order;
        }
        public List<OrderItem> GetOrdersByPriceInterval(double price, double price1)
        {
            List<OrderItem> newList = new List<OrderItem>();
            foreach (var c in this.Orders)
            {
                foreach(var a in c.OrderItems)
                {
                    if (price <= a.MenuItem.Price && a.MenuItem.Price <= price1)
                        newList.Add(a);
                }
                

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
            Order orderRemove = Orders.Find(i => i.No.Equals(no));
            Orders.Remove(orderRemove);
        }
    }
}
