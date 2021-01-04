using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Classes
{
    public class OrderItem
    {
        public MenuItem MenuItem { get; set; }
        public int Count { get; set; }
        public OrderItem (MenuItem menuItem, int count)
        {
            this.MenuItem = menuItem;
            this.Count = count;
        }
    }
}
