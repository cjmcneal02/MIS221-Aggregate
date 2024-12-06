using System;
using System.Collections.Generic;
using PA5_2.Admin;
using PA5_2.Player;

namespace PA5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load initial data for karts
            AdminControl adminControl = new AdminControl();
            PlayerControl playerControl = new PlayerControl(adminControl.GetKarts());

            while (true)
            {
                Console.WriteLine("\n--- Welcome to Kart Racing Management System ---");
                Console.WriteLine("1. Player Menu");
                Console.WriteLine("2. Admin Menu");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("\n--- Player Menu ---");
                        Console.WriteLine("Enter player emails (separated by commas):");
                        string inputEmails = Console.ReadLine();
                        var playerEmails = new List<string>(inputEmails.Split(','));
                        playerControl.LoadPlayers(playerEmails);
                        playerControl.PlayerMenu();
                        break;

                    case 2:
                        Console.WriteLine("\n--- Admin Menu ---");
                        adminControl.AdminMenu();
                        break;

                    case 3:
                        Console.WriteLine("Exiting the system. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select an option from the menu.");
                        break;
                }
            }
        }
    }
}
