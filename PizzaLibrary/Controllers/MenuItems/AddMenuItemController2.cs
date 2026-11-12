using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PizzaLibrary.Controllers.MenuItems
{
    public class AddMenuItemController2
    {
        IMenuItemRepository _menuItemRepository;
        public MenuItem MenuItem { set; get; }

        public AddMenuItemController2(int itemClass)
        {
            switch (itemClass)
            {
                case 1:
                    Console.WriteLine("Create general menu item");
                    Console.WriteLine("indtast navn");
                    string name = Console.ReadLine();
                    Console.WriteLine("indtast pris");
                    double price = double.Parse(Console.ReadLine());
                    Console.WriteLine("indtast beskrivelse");
                    string description = Console.ReadLine();

                    Console.WriteLine("indtast type af genstand på menuen. 1 : klassisk pizza, 2 : special pizza, 3 : sandwiches, 4 : bruschetta, 5 : pasta, 6 : salat, 7 : tilbehør");
                    MenuType itemMenuType;
                    string itemMenuTypeChooser = Console.ReadLine();
                    switch (itemMenuTypeChooser)
                    {
                        case "1":
                            itemMenuType = MenuType.PIZZECLASSSICHE;
                            break;
                        case "2":
                            itemMenuType = MenuType.PIZZASPECIALI;
                            break;
                        case "3":
                            itemMenuType = MenuType.SANDWICHES;
                            break;
                        case "4":
                            itemMenuType = MenuType.BRUCHETTA_CROSTINO;
                            break;
                        case "5":
                            itemMenuType = MenuType.PASTAALFORNO;
                            break;
                        case "6":
                            itemMenuType = MenuType.SALATER;
                            break;
                        case "7":
                            itemMenuType = MenuType.TILBEHØR;
                            break;
                        default:
                            itemMenuType = MenuType.PIZZECLASSSICHE;
                            break;
                    }
                    MenuItem = new MenuItem(name, price, description, itemMenuType);
                    break;
                case 2:
                    Console.WriteLine("indtast navn på drikkevare");
                    string bevName = Console.ReadLine();
                    Console.WriteLine("indtast pris på drikkevare");
                    double bevPrice = double.Parse(Console.ReadLine());
                    Console.WriteLine("indtast beskrivelse af drikkevare");
                    string bevDescription = Console.ReadLine();
                    Console.WriteLine("indtast y hvis drikkevare indeholder alkohol, indtast n hvis ikke");
                    string isAlcoholicString = Console.ReadLine().ToLower();
                    bool isAlcoholic;
                    switch (isAlcoholicString)
                    {
                        case "y":
                            isAlcoholic = true;
                            break;
                        case "n":
                            isAlcoholic = false;
                            break;
                        default:
                            isAlcoholic = false;
                            break;
                    }
                    MenuItem = new Beverage(bevName, bevPrice, bevDescription, isAlcoholic);
                    break;
                case 3:
                    Console.WriteLine("Angiv bærepose titel");
                    string bagTitle = Console.ReadLine();

                    Console.WriteLine("angiv om prosen er bionedbrydelig y for ja, n for nej");
                    string isBiodegradableString = Console.ReadLine().ToLower();
                    bool isBiodegradable;
                    switch (isBiodegradableString)
                    {
                        case "y":
                            isBiodegradable = true;
                            break;
                        case "n":
                            isBiodegradable = false;
                            break;
                        default:
                            isBiodegradable = false;
                            break;
                    }
                    Console.WriteLine("angiv navn på bæreobjekt");
                    bagTitle = Console.ReadLine();
                    Console.WriteLine("angiv størrelse på posen. 1 for lille, 2 for stor");
                    string bagSizeString = Console.ReadLine();
                    ContainerSize bagSize;
                    switch (bagSizeString)
                    {
                        case "1":
                            bagSize = ContainerSize.SMALL;
                            break;
                        case "2":
                            bagSize = ContainerSize.LARGE;
                            break;
                        default:
                            bagSize = ContainerSize.SMALL;
                            break;
                    }
                    MenuItem = new CarryContainer(bagTitle, isBiodegradable, bagSize);
                        break;
                    
            }

        }



    }
}
