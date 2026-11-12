using PizzaLibrary.Data;
using PizzaLibrary.Interfaces;
using PizzaLibrary.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PizzaLibrary.Exceptions;

namespace PizzaLibrary.Services
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private List<IMenuItem> _menuItemList;

        public MenuItemRepository()
        {
            _menuItemList = MockData.MenuItemData;
        }
        public int Count
        {
            get { return _menuItemList.Count; }
        }

        public void AddMenuItem(IMenuItem menuItem)
        {
            if (ContainsByname(menuItem.Name) == false)
            {
                _menuItemList.Add(menuItem);
            }
            else
            {
                throw new MenuItemExist("Menu genstanden eksisterer allerede");
            }
        }

        public List<IMenuItem> GetAll()
        {
            List<IMenuItem> toBeReturned = new List<IMenuItem>();
            foreach (IMenuItem item in _menuItemList)
            {
                toBeReturned.Add(item);
            }
            return toBeReturned;
        }

        public IMenuItem GetMenuItemByNo(int no)
        {
            foreach (IMenuItem item in _menuItemList)
            {
                if (item.No == no)
                {
                    return item;
                }
            }
            return null;
        }

        public void PrintAllMenuItems()
        {
            foreach (IMenuItem item in _menuItemList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void RemoveMenuItem(int no)
        {
            if (GetMenuItemByNo(no) != null)
            {
                _menuItemList.Remove(GetMenuItemByNo(no));
            }
        }

        public bool ContainsByname(string name)
        {
            foreach (IMenuItem item in _menuItemList)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return true;
                }
                
            }
            return false;
        }

        public List<IMenuItem> GetAllByType(MenuType menuType) //får alle der indeholder med bestemt menutype
        {
            List<IMenuItem> allWithType = new List<IMenuItem>();
            foreach (IMenuItem item in _menuItemList)
            {
                if (item.TheMenuType == menuType)
                {
                    allWithType.Add(item);
                }

            }
            return allWithType;
        }


        public IMenuItem GetPriciest()
        {
            IMenuItem priciest = _menuItemList[0];
            for (int i = 0; i < Count;i++)
            {
                if (_menuItemList[i].Price > priciest.Price)
                {
                    priciest = _menuItemList[i];
                }
            }

            return priciest;

        }


        public IMenuItem GetPriciestPizza()  //får dyreste pizza. 
        {
            IMenuItem priciest = _menuItemList[0];
            for (int i = 0; i < Count; i++)
            {
                if (_menuItemList[i].Price > priciest.Price && (_menuItemList[i].TheMenuType == MenuType.PIZZECLASSSICHE || _menuItemList[i].TheMenuType == MenuType.PIZZASPECIALI))
                {
                    priciest = _menuItemList[i];
                }
            }

            return priciest;

        }









        public void PrintMenu() //printer menu
        {
            Console.WriteLine();
            Console.WriteLine("---------- MENU ----------");
            for (int i = 0; i < Enum.GetValues(typeof(MenuType)).Length; i ++)   //getvalues giver en array med alle enums værdier. (fik hjælp til at bearbejde enum som en array)
            {
                MenuSection((MenuType)i); //laver i til en menu type
            }
        }
       

        private void MenuSection(MenuType menusectiontype) //hjælpe metode til menu
        {
            Console.WriteLine(menusectiontype.ToString());
            ToMenuSectionByType(menusectiontype);
            MenuSectionBreaker();
        }

        private void ToMenuSectionByType(MenuType itemMenyType) //hjælpe metode til menu
        {
            foreach (IMenuItem item in _menuItemList)
            {
                if (item.TheMenuType == itemMenyType)
                {
                    ItemToMenuElement(item);
                }
            }
        }
        private void ItemToMenuElement(IMenuItem item) //hjælpe metode til menu
        {
            Console.WriteLine($"{item.Name}     {item.No}");
            Console.WriteLine($"{item.Description}");
        }

        private void MenuSectionBreaker() //hjælpe metode til menu
        {
            Console.WriteLine();
            Console.WriteLine();
        }


    }

    
}
