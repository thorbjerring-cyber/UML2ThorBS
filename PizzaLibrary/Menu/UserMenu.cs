using PizzaLibrary.Services;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaLibrary.Controllers.Customers;
using PizzaLibrary.Controllers.MenuItems;
using PizzaLibrary.Models;
using PizzaLibrary.Exceptions;


public class UserMenu
{
    private static string mainMenuChoices = "\t1.Vis Menu\n\t2.Vis Kunder\n\t3.Add Customer\n\t4.Add menu item\n\tQ.Afslut\n\n\tIndtast valg:";

    private CustomerRepository _customerRepository = new CustomerRepository();
    private MenuItemRepository _menuItemRepository = new MenuItemRepository();
    private static string ReadChoice(string choices)
    {
        Console.Clear();
        Console.Write(choices);
        string choice = Console.ReadLine();
        Console.Clear();
        return choice.ToLower();
    }

    public void ShowMenu()
    {
        string theChoice = ReadChoice(mainMenuChoices);
        while (theChoice != "q")
        {
            switch (theChoice)
            {
                case "1":
                    Console.WriteLine("Valg 1");
                    ShowMenuItemController showMenuItemController = new ShowMenuItemController(_menuItemRepository);
                    showMenuItemController.ShowAllMenuItems();
                    Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Valg 2");
                    _customerRepository.PrintAllCustomers();
                    Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Valg 3");
                    Console.WriteLine("Indlæs navn:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Indlæs mobil nr:");
                    string mobile = Console.ReadLine();
                    Console.WriteLine("Indlæs adresse:");
                    string address = Console.ReadLine();
                    Console.WriteLine("Vil du være clubmember y/n");
                    string clubMemberString = Console.ReadLine().ToLower();
                    bool isClubMember = (clubMemberString[0] == 'y') ? true : false;
                    Console.WriteLine("Er dette en VIP customer?");  // Vip customer
                    string vipCustomerString = Console.ReadLine().ToLower(); 
                    bool isVIPCustomer = (vipCustomerString[0] == 'y') ? true : false; 
                    AddCustomerController CustomerItemController = new AddCustomerController(name, mobile, address, isClubMember, _customerRepository,isVIPCustomer); //nyt parameter tilføjet i controlleren
                    try //prøver at add customer og fanger eventuelle exceptions
                    {
                        CustomerItemController.AddCustomer();
                    }
                    catch (CustomerMobileNumberExist CME)
                    {
                        Console.WriteLine(CME.Message); 
                    }
                    // heldigt at en vip customer ikke bruger andre parametre end customer :)
                    break;
                case "4":
                    // bedre version af add item, som kan tilføje af enhver klasse, også bare en generel item. 
                    Console.WriteLine("vælg klasse af genstand. 1 for generel menu genstand. 2 for beverage. 3 for bærepose");
                    string chosenMenuItemClassString = Console.ReadLine();
                    int chosenMenuItemClass = int.Parse(chosenMenuItemClassString);
                    if(chosenMenuItemClass == 1 || chosenMenuItemClass == 2 || chosenMenuItemClass == 3)
                    {
                        AddMenuItemController2 MenuItemController2 = new AddMenuItemController2(chosenMenuItemClass);
                        _menuItemRepository.AddMenuItem(MenuItemController2.MenuItem);
                    }
     
                    // denne funktionalitet er

                    //Console.WriteLine("Valg 4");
                    //Console.WriteLine("Indlæs navn på menu genstand");
                    //string itemName = Console.ReadLine();
                    //Console.WriteLine("Indlæs pris på genstand");
                    //string itemPrice = Console.ReadLine();
                    //Console.WriteLine("Indlæs beskrivelse af genstand");
                    //string itemDescription = Console.ReadLine();
                    //Console.WriteLine("Vælg type af genstand. 1 for pizza. 2 for special pizza. 3 for sandwich. 4 for bruschetta. 5 for pasta. 6 for salat. 7 for tilbehør");
                    //MenuType itemMenuType = MenuType.PIZZECLASSSICHE;
                    //string itemMenuTypeChooser = Console.ReadLine();
                    //switch (itemMenuTypeChooser)
                    //{
                    //    case "1":
                    //        itemMenuType = MenuType.PIZZECLASSSICHE;
                    //        break;
                    //    case "2":
                    //        itemMenuType = MenuType.PIZZASPECIALI;
                    //        break;
                    //    case "3":
                    //        itemMenuType = MenuType.SANDWICHES;
                    //        break;
                    //    case "4":
                    //        itemMenuType = MenuType.BRUCHETTA_CROSTINO;
                    //        break;
                    //    case "5":
                    //        itemMenuType = MenuType.PASTAALFORNO;
                    //        break;
                    //    case "6":
                    //        itemMenuType = MenuType.SALATER;
                    //        break;
                    //    case "7":
                    //        itemMenuType = MenuType.TILBEHØR;
                    //        break;
                    //}
                    //AddMenuItemController addMenuItemController = new AddMenuItemController(itemName, double.Parse(itemPrice), itemDescription, itemMenuType, _menuItemRepository);
                    //tilføjer kun generelle MenuItems. kan ikke tilføje beverages osv på en smart måde
                    //yderligere kode skal tilføjes hvis man vil lave beverages og bæreposer efter deres skabeloner.
                    //Man kunne lave controllerne speficikke. f.eks. addBeverageController.
                    //addMenuItemController.AddItem();
                    break;
                default:
                    Console.WriteLine("Angiv et tal fra 1..4 eller q for afslut");
                    break;
                   
            }
            theChoice = ReadChoice(mainMenuChoices);
            
        }
        
    }
    

}



