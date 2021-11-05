using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badges
{
    class ProgramUI
    {
        private BadgesRepo _badgesRepo = new BadgesRepo();

        public void Run()
        {
            SeedList();
            Menu();
        }
        private void Menu()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?\n\n" +
                    "1: Add New Badge.\n" +
                    "2: Edit A Badge.\n" +
                    "3. List All Badges.\n" +
                    "4: Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddBadge();
                        break;
                    case "2":
                        EditBadgeMenu();
                        break;
                    case "3":
                        ViewBadges();
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Number.");
                        break;
                }
                Console.WriteLine("Please Enter Any Key to Continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void AddBadge()
        {
            Badge badge = new Badge();

            Console.Clear();
            Console.WriteLine("Please Enter Badge ID.");
            int id = Int16.Parse(Console.ReadLine());
            badge.BadgeID = id;

            bool keepAddingDoors = true;
            while (keepAddingDoors)
            {
                Console.WriteLine("What Door Does This Badge Require Access to?");
                string door = Console.ReadLine();
                badge.Doors.Add(door);

                Console.WriteLine("Would You Like To Add Another Door? (y/n)");
                string input = Console.ReadLine().ToLower();

                if (input == "n")
                {
                    keepAddingDoors = false;
                    Console.Clear();
                }
            }
            _badgesRepo.AddToAccessList(badge);
            Menu();
        }
        private void EditBadgeMenu()
        {
            Console.Clear();
            Console.WriteLine("What Would You Like to Do?\n\n" +
                "1: Remove A Door\n" +
                "2: Add A Door\n" +
                "3: Main Menu");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    RemoveDoor();
                    break;
                case "2":
                    AddDoor();
                    break;
                case "3":
                    Menu();
                    break;
                default:
                    Console.WriteLine("Please Enter A Valid Number.");
                    break;
            }
            Console.WriteLine("Please Enter Any Key to Continue...");
            Console.ReadKey();
            Console.Clear();
        }
        private void RemoveDoor()
        {
            Console.Clear();
            ViewBadges();
            Console.WriteLine("What is the Badge ID that needs an Update?");
            int id = Int16.Parse(Console.ReadLine());

            var badge = _badgesRepo.GetBadgeID(id);

            string mainList = "";
            foreach (var door in badge.Doors)
            {
                mainList += $"{door,-5}";
            }
            Console.WriteLine("Badge {0} Has Access To Doors {1}\n\n");
            string oldDoor = Console.ReadLine();

            bool wasDeleted = _badgesRepo.DeleteDoor(id, oldDoor);
            if (wasDeleted)
            {
                Console.WriteLine("Door Was Removed.");
            }
            else
            {
                Console.WriteLine("Door Was Not Removed.");
            }
            Console.ReadKey();
            Menu();
        }
        private void AddDoor()
        {
            Console.Clear();
            ViewBadges();
            Console.WriteLine("What is the Badge ID that needs an Update?");
            int id = Int16.Parse(Console.ReadLine());

            var badge = _badgesRepo.GetBadgeID(id);

            string mainList = "";
            foreach ( var door in badge.Doors)
            {
                mainList += $"{door,-5}";
            }
            Console.WriteLine("Badge {0} Has Access to Doors {1}\n\n", id, mainList);
            Console.WriteLine("What Door Would You Like To Add?\n\n");
            string newDoor = Console.ReadLine();

            bool wasAdded = _badgesRepo.AddDoor(id, newDoor);
            if (wasAdded)
            {
                Console.WriteLine("Door Added.");
                Console.ReadKey();
                Menu();
            }
            else
            {
                Console.WriteLine("Door Was Not Added.");
                Console.ReadKey();
                Menu();
            }
        }
        private void ViewBadges()
        {
            Dictionary<int, List<string>> badgeDictionary = _badgesRepo.GetAccessList();

            Console.WriteLine($"{"Badge ID",-10} {"Door Access",-10}\n");
            foreach (KeyValuePair<int, List<string>> badge in badgeDictionary)
            {
                string mainList = "";
                foreach (var door in badge.Value)
                {
                    mainList += $"{door,-5}";
                }
                Console.WriteLine($"{badge.Key,-10} {mainList}\n");
            }
        }
        private void SeedList()
        {
            List<string> doors1 = new List<string>();
            List<string> doors2 = new List<string>();
            List<string> doors3 = new List<string>();
            List<string> doors4 = new List<string>();

            doors1.Add("A1");
            doors1.Add("A2");
            doors1.Add("A3");

            doors2.Add("A4");
            doors2.Add("A5");
            doors2.Add("A6");

            doors3.Add("A1");
            doors3.Add("A3");
            doors3.Add("A5");

            doors4.Add("A2");
            doors4.Add("A4");
            doors4.Add("A6");

            Badge badge1 = new Badge(1001, doors1);
            Badge badge2 = new Badge(2001, doors2);
            Badge badge3 = new Badge(3001, doors3);
            Badge badge4 = new Badge(4001, doors4);

            _badgesRepo.AddToAccessList(badge1);
            _badgesRepo.AddToAccessList(badge2);
            _badgesRepo.AddToAccessList(badge3);
            _badgesRepo.AddToAccessList(badge4);
        }
    }
}
