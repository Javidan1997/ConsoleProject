using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Exceptions
{
   
   public class DateIsInvalidException : Exception
    {
        private string _message { get; set; }
        public override string Message => _message;
        public DateIsInvalidException(string message = "Error! Date is invalid")
        {
            this._message = message;
        }

    }
}
