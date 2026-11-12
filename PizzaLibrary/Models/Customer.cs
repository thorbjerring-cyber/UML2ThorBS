using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Models
{
    public class Customer : ICustomer
    {
        private static int counter = 0;
        public Customer(string name, string mobile, string address)
        {
            Id = ++counter;
            Address = address;
            ClubMember = false;
            Mobile = mobile;
            Name = name;
        }

        public string Address { get; set; }
        public bool ClubMember { get; set; }
        public int Id { get; private set; } //private set er implied hvis der ikke står noget
        public string Mobile { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Name : {Name}, Mobile : {Mobile}, Address : {Address}, Clubmember : {ClubMember}, Id : {Id}";
        }
    }
}
