using PizzaLibrary.Interfaces;
using PizzaLibrary.Data;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaLibrary.Exceptions;

namespace PizzaLibrary.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private Dictionary<string, ICustomer> _customers;

        public CustomerRepository()
        {
            _customers = MockData.CustomerData;
        }

        private int myVar;

        public int Count
        {
            get { return _customers.Count(); }
        }

        public void AddCustomer(ICustomer customer)
        {
            if (GetCustomerByMobile(customer.Mobile) == null) //hvis der ikke findes en med samme mobil nummer, så add
            {
                _customers.Add(customer.Mobile, customer);
            }
            else
            {
                throw new CustomerMobileNumberExist("Nummeret findes allerede"); //kaster exception hvis nummer allerde findes
            }

        }

        public List<ICustomer> GetAll() //det skal konverteres fra dictionary til liste per kontrakt. 
        {
            List<ICustomer> toBeReturned = new List<ICustomer>();
            foreach (ICustomer person in _customers.Values)
            {
                toBeReturned.Add(person);
            }
            return toBeReturned;
        }

        public ICustomer GetCustomerByMobile(string mobile)
        {
            foreach (ICustomer person in _customers.Values)
            {
                if (person.Mobile == mobile)
                {
                    return person;
                }
            }
            return null;
        }

        public void PrintAllCustomers()
        {
            foreach (ICustomer person in _customers.Values)
            {
                Console.WriteLine(person.ToString());
            }
        }

        public void RemoveCustomer(string mobile)
        {
            if (GetCustomerByMobile(mobile) != null)
            {
                _customers.Remove(mobile);
            }
        }


        public List<ICustomer> GetMemberList()            //få medlemmer
        {
            List<ICustomer> memberList = new List<ICustomer>();
            foreach (ICustomer person in _customers.Values)
            {
                if (person.ClubMember ==true)
                {
                    memberList.Add(person);
                }
            }
            return memberList;
        }

        public List<ICustomer> GetFromRoskilde()        //få fra roskilde 
        {
            List<ICustomer> roskildeList = new List<ICustomer>();
            foreach (ICustomer person in _customers.Values)
            {
                if (person.Address.Contains("Roskilde"))
                {
                    roskildeList.Add(person);
                }
            }
            return roskildeList;


        }


    }
}
