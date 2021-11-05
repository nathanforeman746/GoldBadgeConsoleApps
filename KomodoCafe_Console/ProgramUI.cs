using Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Console
{
    class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();

        public void Run()
        {
            SeedMenuList();
            Menu();
        }
        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                //Display user options
                Console.WriteLine("\n Select a Menu Option:\n" +
                    "1: Add New Menu Item\n" +
                    "2: View Menu Options\n" +
                    "3: View Menu Item by ID\n" +
                    "4: Update A Menu Item\n" +
                    "5: Delete A Menu Item\n" +
                    "6: Exit Program");

                //User Input
                string menuInput = Console.ReadLine();

                switch (menuInput)
                {
                    case "1":
                        AddNewItem();
                        break;
                    case "2":
                        ViewMenu();
                        break;
                    case "3":
                        ViewItemByID();
                        break;
                    case "4":
                        UpdateMenuItem();
                        break;
                    case "5":
                        DeleteMenuItem();
                        break;
                    case "6":
                        Console.WriteLine("Exiting...");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("\nPlease Press Any Key to Continue...\n");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddNewItem()
        {
            Console.Clear();
            MenuClass item = new MenuClass();

            Console.WriteLine("Please Enter ID Number.");
            item.ID = Int16.Parse(Console.ReadLine());

            Console.WriteLine("Please Enter Item Name.");
            item.Name = Console.ReadLine();

            Console.WriteLine("Please Enter the Description.");
            item.Ingredients = Console.ReadLine();

            Console.WriteLine("Please Enter the Price of the Item.");
            item.Price = Decimal.Parse(Console.ReadLine());

            _menuRepo.AddMenuToList(item);
        }
        private void ViewMenu()
        {
            Console.Clear();
            List<MenuClass> menuList = _menuRepo.GetMenuList();

            foreach (MenuClass item in menuList)
            {
                Console.WriteLine($"\n{item.ID}  \n{item.Name}  \n{item.Price}");
            }
        }
        private void ViewItemByID()
        {
            Console.Clear();

            Console.WriteLine("Please Enter the ID of the Item you want to see.");
            int id = Int16.Parse(Console.ReadLine());

            MenuClass item = _menuRepo.GetItemID(id);

            if (item != null)
            {
                Console.WriteLine($"Item ID: {item.ID}\n" +
                    $"Name: {item.Name}\n" +
                    $"Description: {item.Description}\n" +
                    $"Ingredients: {item.Ingredients}\n" +
                    $"Price: {item.Price}");
            }
            else
            {
                Console.WriteLine("Please Enter a Valid ID.");
            }
        }
        private void UpdateMenuItem()
        {
            ViewMenu();

            Console.WriteLine("Please Enter the ID of the Item You Wish to Update.");
            int oldId = Int16.Parse(Console.ReadLine());

            Console.Clear();
            MenuClass newItem = new MenuClass();



            Console.WriteLine("Please Enter the Name of the Item.");
            newItem.Name = Console.ReadLine();

            Console.WriteLine("Please Enter the Description of the Item.");
            newItem.Description = Console.ReadLine();

            Console.WriteLine("Please Enter the Ingredients for this Item.");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Please Enter the Price for this Item.");
            newItem.Price = decimal.Parse(Console.ReadLine());

            bool wasUpdated = _menuRepo.UpdateMenuItem(oldId, newItem);

            if (wasUpdated)
            {
                Console.WriteLine("Item has been updated.");
            }
            else
            {
                Console.WriteLine("Item was not updated.");
            }
        }
        private void DeleteMenuItem()
        {
            ViewMenu();

            Console.WriteLine("\nPlease Enter the ID of the Item you wish to remove.");
            int id = Int16.Parse(Console.ReadLine());

            bool wasDeleted = _menuRepo.RemoveMenuItem(id);

            if (wasDeleted)
            {
                Console.WriteLine("The Item was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The Item could not be deleted.");
            }
        }
        private void SeedMenuList()
        {
            MenuClass italianbeef = new MenuClass(1, "Cheef", "A Six Inch Toasted Roll with 5 ounces of Italian Beef.\n", "Mozzerella, Hot or Sweet Peppers.", 8.99m);
            MenuClass frenchfries = new MenuClass(2, "Fries", "Crispy French Fries that are cooked and salted to perfection.\n", "Ketchup, Ranch, BBQ Sauce, Extra Salt -- if requested.", 2.75m);
            MenuClass breadsticks = new MenuClass(3, "Breadsticks", "Soft and Buttered Breadsticks covered in Romano served with a side of Pizza or Marinara Sauce.\n", "Romano, Garlic Butter, Dough, Pizza or Marinara Sauce on the side.", 6.75m);

            _menuRepo.AddMenuToList(italianbeef);
            _menuRepo.AddMenuToList(frenchfries);
            _menuRepo.AddMenuToList(breadsticks);
        }
    }
}
