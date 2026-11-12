using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Models
{
    public class Beverage : MenuItem
    {
        public Beverage(string name, double price, string description, bool isAlcoholic) : base(name, price, description, MenuType.TILBEHØR) //smider automatisk MenuType.Tilbehør videre op. beverage er altid tilbehør
        {
            IsAlcoholic = isAlcoholic;
        }


        public bool IsAlcoholic { get; set; }

        public override string ToString()
        {
            return $"Name : {Name}, Price : {Price}, Description : {Description}, Menu type : {TheMenuType}, Includes alcohol : {IsAlcoholic}, ID : {No}";
        }
    }
}
