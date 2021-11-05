using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class MenuRepo
    {
        private List<MenuClass> _menuRepository = new List<MenuClass>();

        //Create
        public void AddMenuToList(MenuClass item)
        {
            _menuRepository.Add(item);
        }
        //Read
        public List<MenuClass> GetMenuList()
        {
            return _menuRepository;
        }
        //Update
        public bool UpdateMenuItem(int item, MenuClass newItem)
        {
            MenuClass oldItem = GetItemID(item);

            if (oldItem != null)
            {
                oldItem.ID = newItem.ID;
                oldItem.Name = newItem.Name;
                oldItem.Description = newItem.Description;
                oldItem.Ingredients = newItem.Ingredients;
                oldItem.Price = newItem.Price;
                return true;
            }
            else
            {
                return false;
            }
        }
        //Delete
        public bool RemoveMenuItem(int id)
        {
            MenuClass item = GetItemID(id);

            if (item == null)
            {
                return false;
            }

            int initialCount = _menuRepository.Count;
            _menuRepository.Remove(item);

            if (initialCount > _menuRepository.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Get Item by ID
        public MenuClass GetItemID(int menuID)
        {
            foreach(MenuClass item in _menuRepository)
            {
                if(item.ID == menuID)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
