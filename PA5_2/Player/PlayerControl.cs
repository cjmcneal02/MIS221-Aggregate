using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PA5_2.Player
{
        public class PlayerControl
    {
        private List<Kart> _karts;
        private List<string> _players;
        private readonly List<string> _tracks = new List<string>
        {
            "Figure-8 Circuit", "Yoshi Falls", "Cheep Cheep Beach", "Luigi's Mansion", 
            "Desert Hills", "Delfino Square", "Waluigi Pinball", "Shroom Ridge", 
            "DK Pass", "Tick-Tock Clock", "Mario Circuit", "Airship Fortress", 
            "Wario Stadium", "Peach Gardens", "Bowser Castle", "Rainbow Road"
        };

        public PlayerControl(List<Kart> karts)
        {
            _karts = karts;
            _players = new List<string>();
        }

        // Load players into the system
        public void LoadPlayers(List<string> playerIdentifiers)
        {
            foreach (var identifier in playerIdentifiers)
            {
                if (!string.IsNullOrWhiteSpace(identifier) && !_players.Contains(identifier))
                {
                    _players.Add(identifier.Trim());
                    Console.WriteLine($"Player '{identifier}' added successfully.");
                }
                else
                {
                    Console.WriteLine($"Invalid or duplicate player identifier: {identifier}");
                }
            }
        }

        // Display registered players
        public void ShowPlayers()
        {
            Console.WriteLine("\nRegistered Players:");
            if (_players.Count > 0)
            {
                foreach (var player in _players)
                {
                    Console.WriteLine(player);
                }
            }
            else
            {
                Console.WriteLine("No players registered.");
            }
        }

        // Player menu for interaction
        public void PlayerMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\n--- Player Menu ---");
                Console.WriteLine("1. Show Available Karts");
                Console.WriteLine("2. Show Registered Players");
                Console.WriteLine("3. Race Karts");
                Console.WriteLine("4. Exit Player Menu");
                Console.Write("Enter your choice: ");

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        ShowAvailableKarts();
                        break;
                    case 2:
                        ShowPlayers();
                        break;
                    case 3:
                        RaceKarts();
                        break;
                    case 4:
                        Console.WriteLine("Exiting Player Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            } while (choice != 4);
        }

        // Display available karts
        private void ShowAvailableKarts()
        {
            Console.WriteLine("\nAvailable Karts:");
            foreach (var kart in _karts)
            {
                if (kart.IsAvailable)
                {
                    Console.WriteLine($"ID: {kart.Id}, Name: {kart.Name}, Size: {kart.Size}, Available: {kart.IsAvailable}");
                }
            }
        }

        // Simulate racing karts
        private void RaceKarts()
        {
            if (_players.Count == 0)
            {
                Console.WriteLine("No players registered. Please register players first.");
                return;
            }

            Console.WriteLine("\n--- Race Karts ---");
            foreach (var identifier in _players)
            {
                Console.WriteLine($"\nPlayer: {identifier}");
                ShowAvailableKarts();

                Console.Write("Enter Kart ID to race: ");
                if (!int.TryParse(Console.ReadLine(), out int kartId))
                {
                    Console.WriteLine("Invalid Kart ID. Skipping this player.");
                    continue;
                }

                var kart = _karts.Find(k => k.Id == kartId && k.IsAvailable);
                if (kart == null)
                {
                    Console.WriteLine("Kart not available or invalid Kart ID. Skipping this player.");
                    continue;
                }

                kart.IsAvailable = false;

                Console.WriteLine("\nSelect a track:");
                for (int i = 0; i < _tracks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_tracks[i]}");
                }

                Console.Write("Enter track number: ");
                if (!int.TryParse(Console.ReadLine(), out int trackChoice) || trackChoice < 1 || trackChoice > _tracks.Count)
                {
                    Console.WriteLine("Invalid track choice. Skipping this player.");
                    kart.IsAvailable = true;
                    continue;
                }

                string selectedTrack = _tracks[trackChoice - 1];

                // Simulate race result
                var raceTime = new Random().Next(30, 300); // Simulate time in seconds
                Console.WriteLine($"Player {identifier} raced Kart '{kart.Name}' on track '{selectedTrack}' with a time of {raceTime} seconds.");

                // After the race, make the kart available again
                kart.IsAvailable = true;
            }
        }
    }

    // Kart class definition
    public class Kart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public bool IsAvailable { get; set; }
    }
}