using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Exceptions
{
    public class CustomerMobileNumberExist : Exception
    {

        public CustomerMobileNumberExist(string message)
        {
            Message = message;
        }

        public string Message { get; set; }



    }
}
