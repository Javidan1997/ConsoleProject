using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Exceptions
{
    public class MenuItemAlreadyExistException: Exception
    {
        private string _message { get; set;}
        public override string Message => _message;
        public MenuItemAlreadyExistException(string message="MenuItem already exists")
        {
            this._message = message;
        }
    }
}
