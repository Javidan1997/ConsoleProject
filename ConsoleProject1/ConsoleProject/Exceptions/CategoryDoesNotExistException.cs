using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Exceptions
{
    class CategoryDoesNotExistException:Exception
    {
       private string _message { get; set; }
       public override string Message => _message;
       public CategoryDoesNotExistException(string message)
       {
          this._message = message;
       }
        
    }
}
