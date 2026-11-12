using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Exceptions
{
    public class MenuItemExist : Exception
    {

        public MenuItemExist(string message)
        {
            Message = message;
        }


        public string Message { get; set; }

    }
}
