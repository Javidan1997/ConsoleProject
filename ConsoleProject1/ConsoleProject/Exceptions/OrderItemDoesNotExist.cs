using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Exceptions
{
     
    public class OrderItemDoesNotExist : Exception
    {
        private string _message { get; set; }
        public override string Message => _message;
        public OrderItemDoesNotExist(string message)
        {
            this._message = message;
        }
    }
}
}
