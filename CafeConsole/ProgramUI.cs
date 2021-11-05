using Cafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeConsole
{
    class ProgramUI
    {
        public MenuRepo _menuRepo = new MenuRepo();
        

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

            _menuRepository.AddMenuToList(item);
        }
        private void ViewMenu()
        {
            Console.Clear();
            List<MenuClass> menuList = _menuRepository.GetMenuList();

            foreach (MenuClass item in menuList)
            {
                Console.WriteLine($"\n{item.ID} + \n{item.Name} + \n{item.Price}");
            }
        }
    }
}
    

