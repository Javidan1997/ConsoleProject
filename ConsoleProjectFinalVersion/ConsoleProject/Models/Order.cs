using ConsoleProject.Enums;
using ConsoleProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Classes
{
    public class Order 
    {
        private static int counter { get; set; } = 0;
        private int _no;
        public int No 
        { 
          get { return _no; }
          
        }
        public List<OrderItem> OrderItems { get; set; }
        public List<Order> Orders { get; set; }
        private double _totalAmount { get; set; }
        public double TotalAmount 
        {
          get { return _totalAmount; } 
        
        }
        public DateTime Date { get; set; }
       public Order ()
        {
            OrderItems = new List<OrderItem>();
           
            this._no = counter++ -1;
            this.Date = DateTime.Now;
            
            
        }
        public void Sell(string name, int count)
        {
            if (count <= 0) return;
            OrderItem orderItem = OrderItems.Find(o => o.MenuItem.Name.Equals(name));

            if (orderItem == null) return;
            orderItem.Count = count;
            this._totalAmount += count * orderItem.MenuItem.Price;
        }

    }
}
