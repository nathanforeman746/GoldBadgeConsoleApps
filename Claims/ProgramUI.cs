using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims
{
    class ProgramUI
    {
        private ClaimsRepo _claimsRepo = new ClaimsRepo();

        public void Run()
        {
            SeedList();
            Menu();
        }

        public void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Please Select a Menu Option:\n" +
                    "1: View Claims\n" +
                    "2: Queue to Next Claim\n" +
                    "3: Enter a New Claim\n" +
                    "4: Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewClaims();
                        break;
                    case "2":
                        QueueNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a Valid Number.");
                        break;
                }
                Console.WriteLine("\nPlease Press Any Key to Continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void ViewClaims()
        {
            Console.Clear();
            Queue<Claim> queueOfClaims = _claimsRepo.ViewClaimList();

            Console.WriteLine($"{"ClaimID",-5} {"Type",-4} {"Description",-10} {"Amount",-20} {"DateOfIncident",-11} {"DateOfClaim",-12} {"IsValid",-13}");

            foreach (Claim claim in queueOfClaims)
            {
                Console.WriteLine($"{claim.ClaimID,-5} {claim.TypeOfClaim,-5}" +
                    $"{claim.Description,-10} {"$" + claim.ClaimAmount,-20} {claim.DateOfIncident.ToShortDateString(),-18}" +
                    $"{claim.DateOfClaim.ToShortDateString(),-19} {claim.IsValid,-13}");
            }
        }
        private void QueueNextClaim()
        {
            Console.Clear();
            Queue<Claim> queueClaims = _claimsRepo.ViewClaimList();
            Claim currentClaim = queueClaims.Peek();

            Console.WriteLine("Here are the details for the next claim to be handled:\n\n");
            Console.WriteLine($"ID:\t\t\t{ currentClaim.ClaimID}\n");
            Console.WriteLine($"Type:\t\t\t{ currentClaim.TypeOfClaim}\n");
            Console.WriteLine($"Description:\t\t{ currentClaim.Description}\n");
            Console.WriteLine($"Amount:\t\t\t{"$" + currentClaim.ClaimAmount}\n");
            Console.WriteLine($"Date Of Incident:\t{ currentClaim.DateOfIncident}\n");
            Console.WriteLine($"Date Of Claim:\t\t{ currentClaim.DateOfClaim}\n");
            Console.WriteLine($"Is Valid:\t\t{ currentClaim.IsValid}\n");
            Console.WriteLine("\n\nWould You Like to Initiate This Claim? (y/n)");

            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                queueClaims.Dequeue();
            }
            else
            {
                Console.Clear();
                Menu();
            }

        }
        private void EnterNewClaim()
        {
            Console.Clear();
            Claim claim = new Claim();

            Console.WriteLine("\nEnter ID of claim.");
            claim.ClaimID = Int16.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter claim type.\n" +
                "1: Car \n" +
                "2: Home \n" +
                "3: Theft \n");
            claim.TypeOfClaim = (ClaimType)Int16.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter description.");
            claim.Description = Console.ReadLine();

            Console.WriteLine("\nEnter claim amount.");
            claim.ClaimAmount = decimal.Parse(Console.ReadLine());


            Console.WriteLine("\nEnter date of incident.");
            claim.DateOfIncident = DateTime.Parse(Console.ReadLine());


            Console.WriteLine("\nEnter date of claim.");
            claim.DateOfClaim = DateTime.Parse(Console.ReadLine());

            TimeSpan timespan = claim.DateOfClaim - claim.DateOfIncident;
            int days = (int)timespan.TotalDays;

            if (days <= 30)
            {
                claim.IsValid = true;

            }
            else
            {
                claim.IsValid = false;
            }

            _claimsRepo.AddClaim(claim);

        }
        private void SeedList()
        {
            DateTime dateOfIncidient = new DateTime(2018, 4, 25);
            DateTime dateOfClaim = new DateTime(2018, 4, 27);

            Claim one = new Claim(1, ClaimType.Car, "Car accident on 465.", 400.00m, dateOfIncidient, dateOfClaim, true);

            dateOfIncidient = new DateTime(2018, 4, 11);
            dateOfClaim = new DateTime(2018, 4, 12);

            Claim two = new Claim(2, ClaimType.Home, "House fire in kitchen.", 4000.00m, dateOfIncidient, dateOfClaim, true);

            dateOfIncidient = new DateTime(2018, 4, 27);
            dateOfClaim = new DateTime(2018, 6, 1);

            Claim three = new Claim(3, ClaimType.Theft, "Stolen Pancakes.", 4.00m, dateOfIncidient, dateOfClaim, false);

            _claimsRepo.AddClaim(one);
            _claimsRepo.AddClaim(two);
            _claimsRepo.AddClaim(three);
        }
    }
}
