using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLibrary.Models
{
    public class CarryContainer : MenuItem
    {
        public CarryContainer(string name, bool bioDegradable, ContainerSize bagSize) : base(name, GetBagPrice(bagSize), GetDescription(bagSize),MenuType.TILBEHØR)
        {
            Biodegradable = bioDegradable;
            BagSize = bagSize;
        }

        public bool Biodegradable { get; set; }
        public ContainerSize BagSize { get; set; }
        public static double GetBagPrice(ContainerSize bagSize)
        { //if statements ville nok være smartere. men switch case giver mulighed for yderligere udvidelse.
            switch (bagSize)
            {
                case ContainerSize.SMALL:
                    return 3;
                case ContainerSize.LARGE:
                    return 6;
                default:
                    return 3;
            }
        }

        public static string GetDescription(ContainerSize bagSize)
        {
            switch(bagSize)
            {
                case ContainerSize.SMALL:
                    return "Lille bærepose";
                case ContainerSize.LARGE:
                    return "Stor bærepose";
                default:
                    return "Lille bærepose";
            }
        }


        public override string ToString()
        {
            return $"Name {Name}, Description : {Description}, Biodegradable : {Biodegradable}, Bag size : {BagSize}, Price : {Price}, Menu type : {TheMenuType}, ID : {No}";
        }


    }
}
