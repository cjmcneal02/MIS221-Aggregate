using System;
using System.Collections.Generic;
using project_5.Models;

namespace project_5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Initialize AdminControl to manage karts
            AdminControl admin = new AdminControl();
            List<Kart> karts = admin.GetKarts();  // Assume GetKarts is a method that returns the list of karts

            // Prompt user to choose player or admin
            Console.WriteLine("Are you a Player or an Admin?");
            Console.WriteLine("1. Player");
            Console.WriteLine("2. Admin");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Player menu
                    PlayerControl player = new PlayerControl(karts);
                    player.PlayerMenu();
                    break;
                case 2:
                    // Admin menu
                    admin.AdminMenu();
                    break;
                default:
                    Console.WriteLine("Invalid choice, please restart the program and choose a valid option.");
                    break;
            }
        }
    }
}
