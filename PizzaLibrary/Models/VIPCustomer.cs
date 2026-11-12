using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Models
{
    public class VIPCustomer : Customer
    {
        public VIPCustomer(string name, string mobile, string address) : base (name, mobile, address)
        {
            
        }

        public double Discount { get; set; }

        public void SetDiscountForVip(double discountRate)
        {
            Discount = discountRate;
        }



        public override string ToString()
        {
            return $"Name : {Name}, Mobile : {Mobile}, Address : {Address}, Discount rate : {Discount}";
        }
    }
}
