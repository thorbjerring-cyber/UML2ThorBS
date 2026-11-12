using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Controllers.Customers
{
    public class AddCustomerController
    {
        ICustomerRepository _customerRepository;
        public Customer Customer { get; set; }

        public AddCustomerController(string name, string mobile, string address, bool clubMember, ICustomerRepository customerRepository, bool vip)
        {
            if (vip == true)
            {
                Customer = new VIPCustomer(name, mobile, address); 
            }
            else
            {
                Customer = new Customer(name, mobile, address);
            }
                Customer.ClubMember = clubMember;
                _customerRepository = customerRepository;
            
        }
        public void AddCustomer()
        {
            _customerRepository.AddCustomer(Customer);
        }


    }

}
