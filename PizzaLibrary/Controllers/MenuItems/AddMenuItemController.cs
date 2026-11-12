using PizzaLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaLibrary.Models;

namespace PizzaLibrary.Controllers.MenuItems
{
    public class AddMenuItemController
    {
        IMenuItemRepository _menuItemRepository;
        public MenuItem MenuItem { set; get; }

        public AddMenuItemController(string name, double price, string description, MenuType menuType, IMenuItemRepository menuItemRepository)
        {
            MenuItem = new MenuItem(name, price, description, menuType);
            _menuItemRepository = menuItemRepository;
        }

        public void AddItem()
        {
            _menuItemRepository.AddMenuItem(MenuItem);
        }





    }
}
