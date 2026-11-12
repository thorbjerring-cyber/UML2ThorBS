using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Models
{
    public class MenuItem : IMenuItem
    {
        private static int counter = 0;
        public MenuItem(string name, double price, string description, MenuType menuType)
        {
            Name = name;
            Price = price;
            Description = description;
            TheMenuType = menuType;
            No = ++counter;
        }

        public string Description { get; set; }
        public string Name { get; set; }

        public int No { get; }

        public double Price { get; set; }
        public MenuType TheMenuType { get; set; }

        public override string ToString()
        {
            return $"Name : {Name}, Price : {Price}, Description : {Description}, Menutype : {TheMenuType} Number : {No}";
        }
    }
}
