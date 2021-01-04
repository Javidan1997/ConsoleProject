using ConsoleProject.Enums;
using ConsoleProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Classes
{
    public class Order 
    {
        private int _no { get; set; }
        public int No 
        { 
          get { return _no; }
          set
          {
                int count = 99;
                _no = count++;
           }
        }
        public List<OrderItem> OrderItems { get; set; }
        public List<Order> Orders { get; set; }
        private double _totalAmount { get; set; }
        public double TotalAmount 
        {
          get { return _totalAmount; } 
          set
            {
                foreach (var c in this.OrderItems)
                {
                    _totalAmount += c.MenuItem.Price * c.Count;
                }
            }
        }
        public DateTime Date { get; set; }
       

    }
}
