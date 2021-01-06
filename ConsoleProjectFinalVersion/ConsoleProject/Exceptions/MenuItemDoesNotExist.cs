using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Exceptions
{
    public class MenuItemDoesNotExist : Exception
    {
        private string _message { get; set; }
        public override string Message => _message;
        public MenuItemDoesNotExist(string message = "MenuItem doesn't exist")
        {
            this._message = message;
        }
    }
}
