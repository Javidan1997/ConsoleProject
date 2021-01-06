using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleProject.Exceptions
{
   public class CategoryDoesNotExistException:Exception
    {
       private string _message { get; set; }
       public override string Message => _message;
       public CategoryDoesNotExistException(string message="Category doesn't exist")
       {
          this._message = message;
       }
        
    }
}
