using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PA5_2.Player;

namespace PA5_2.Admin
{
    public class AdminControl
    {
        private readonly List<Kart> _karts = new List<Kart>();
        private readonly List<string> _players = new List<string>();
        private readonly string _kartFilePath = "kart-inventory.txt";
        private readonly string _resultsFilePath = "race-results.txt";
        private readonly string _playersFilePath = "players.txt";

        public AdminControl()
        {
            LoadKartsFromFile();
            LoadPlayersFromFile();
        }

        // Load karts from the file
        private void LoadKartsFromFile()
        {
            if (File.Exists(_kartFilePath))
            {
                var lines = File.ReadAllLines(_kartFilePath);
                foreach (var line in lines)
                {
                    var parts = line.Split('#');
                    _karts.Add(new Kart
                    {
                        Id = int.Parse(parts[0]),
                        Name = parts[1],
                        Size = parts[2],
                        IsAvailable = bool.Parse(parts[3])
                    });
                }
            }
        }
        public List<Kart> GetKarts(){
            return _karts;
        }
        // Save karts to the file
        private void SaveKartsToFile()
        {
            using (StreamWriter writer = new StreamWriter(_kartFilePath))
            {
                foreach (var kart in _karts)
                {
                    writer.WriteLine($"{kart.Id}#{kart.Name}#{kart.Size}#{kart.IsAvailable}");
                }
            }
        }

        // Load players from the file
        private void LoadPlayersFromFile()
        {
            if (File.Exists(_playersFilePath))
            {
                _players.AddRange(File.ReadAllLines(_playersFilePath));
            }
        }

        // Save players to the file
        private void SavePlayersToFile()
        {
            File.WriteAllLines(_playersFilePath, _players);
        }

        // Add a procedural kart
        public void AddKart()
        {
            string[] names = { "Speedster", "Thunder", "Flash", "Racer", "Blitz" };
            string[] sizes = { "Small", "Medium", "Large" };

            Kart newKart = new Kart
            {
                Id = _karts.Count + 1,
                Name = names[new Random().Next(names.Length)],
                Size = sizes[new Random().Next(sizes.Length)],
                IsAvailable = true
            };

            _karts.Add(newKart);
            SaveKartsToFile();
            Console.WriteLine($"Kart '{newKart.Name}' added successfully.");
        }

        // Remove a kart
        public void RemoveKart(int id)
        {
            var kart = _karts.Find(k => k.Id == id);
            if (kart != null)
            {
                _karts.Remove(kart);
                SaveKartsToFile();
                Console.WriteLine("Kart removed successfully.");
            }
            else
            {
                Console.WriteLine("Kart not found.");
            }
        }

        // Edit kart information
        public void EditKart(int id, string newName, string newSize, bool isAvailable)
        {
            var kart = _karts.Find(k => k.Id == id);
            if (kart != null)
            {
                kart.Name = newName;
                kart.Size = newSize;
                kart.IsAvailable = isAvailable;
                SaveKartsToFile();
                Console.WriteLine("Kart updated successfully.");
            }
            else
            {
                Console.WriteLine("Kart not found.");
            }
        }

        // Display the kart inventory
        public void ManageKarts()
        {
            Console.WriteLine("\nKart Inventory:");
            foreach (var kart in _karts)
            {
                Console.WriteLine($"ID: {kart.Id}, Name: {kart.Name}, Size: {kart.Size}, Available: {kart.IsAvailable}");
            }
        }

        // Report menu
        public void ReportMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\nReport Menu:");
                Console.WriteLine("1. Daily Kart Race Report");
                Console.WriteLine("2. Karts Currently Being Used");
                Console.WriteLine("3. Average Race Results by Kart Size");
                Console.WriteLine("4. Top 5 Most Used Karts");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DailyKartRaceReport();
                        break;
                    case 2:
                        KartsCurrentlyInUse();
                        break;
                    case 3:
                        AverageRaceResultsByKartSize();
                        break;
                    case 4:
                        Top5MostUsedKarts();
                        break;
                    case 5:
                        Console.WriteLine("Exiting Report Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            } while (choice != 5);
        }

        // Generate daily kart race report
        public void DailyKartRaceReport()
        {
            Console.WriteLine("\n--- Daily Kart Race Report ---");
            var today = DateTime.Today.ToShortDateString();

            if (File.Exists(_resultsFilePath))
                {
                     var lines = File.ReadAllLines(_resultsFilePath)
                     .Where(line => line.Contains(today))
                     .ToList();
                
                if(lines.Any())
                {
                Console.WriteLine($"Races conducted on {today}:");
                foreach (var line in lines)
                    {
                Console.WriteLine(line);
                     }
                }
                else
                {
                    Console.WriteLine("No races conducted today.");
                }
            }
            else
            {
             Console.WriteLine("No race results available.");
            }
        }
        
        // Show karts currently in use
        public void KartsCurrentlyInUse()
        {
            Console.WriteLine("\nKarts Currently In Use:");
            var inUseKarts = _karts.Where(k => !k.IsAvailable).ToList();
            foreach (var kart in inUseKarts)
            {
                Console.WriteLine($"ID: {kart.Id}, Name: {kart.Name}, Size: {kart.Size}");
            }
        }

        // Show average race results by kart size
        public void AverageRaceResultsByKartSize()
        {
            Console.WriteLine("\nAverage Race Results by Kart Size:");
            if (File.Exists(_resultsFilePath))
            {
                var lines = File.ReadAllLines(_resultsFilePath);
                var resultsBySize = lines
                    .Select(line => line.Split('#'))
                    .GroupBy(parts => parts[2])
                    .Select(group => new
                    {
                        Size = group.Key,
                        AverageTime = group.Average(parts => double.Parse(parts[4]))
                    });

                foreach (var result in resultsBySize)
                {
                    Console.WriteLine($"Size: {result.Size}, Average Time: {result.AverageTime:F2} seconds");
                }
            }
            else
            {
                Console.WriteLine("No race results available.");
            }
        }

        // Show top 5 most used karts
        public void Top5MostUsedKarts()
        {
            Console.WriteLine("\nTop 5 Most Used Karts:");
            if (File.Exists(_resultsFilePath))
            {
                var lines = File.ReadAllLines(_resultsFilePath);
                var usageCounts = lines
                    .Select(line => line.Split('#')[0])
                    .GroupBy(kartId => kartId)
                    .Select(group => new
                    {
                        KartId = group.Key,
                        UsageCount = group.Count()
                    })
                    .OrderByDescending(k => k.UsageCount)
                    .Take(5);

                foreach (var kart in usageCounts)
                {
                    Console.WriteLine($"Kart ID: {kart.KartId}, Usage Count: {kart.UsageCount}");
                }
            }
            else
            {
                Console.WriteLine("No race results available.");
            }
        }

        // Admin menu
        public void AdminMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("\nAdmin Menu:");
                Console.WriteLine("1. Add Kart");
                Console.WriteLine("2. Remove Kart");
                Console.WriteLine("3. Edit Kart");
                Console.WriteLine("4. Manage Karts");
                Console.WriteLine("5. Manage Players"); // NOT COMPLETE, JUST AN IDEA
                Console.WriteLine("6. Report Menu");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddKart();
                        break;
                    case 2:
                        Console.Write("Enter Kart ID to remove: ");
                        int removeId = int.Parse(Console.ReadLine());
                        RemoveKart(removeId);
                        break;
                    case 3:
                        Console.Write("Enter Kart ID to edit: ");
                        int editId = int.Parse(Console.ReadLine());
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter new size (Small/Medium/Large): ");
                        string newSize = Console.ReadLine();
                        Console.Write("Is available (true/false): ");
                        bool isAvailable = bool.Parse(Console.ReadLine());
                        EditKart(editId, newName, newSize, isAvailable);
                        break;
                    case 4:
                        ManageKarts();
                        break;
                    case 5:
                        //ManagePlayers(); IDEA NOT COMPLETED
                        break;
                    case 6:
                        ReportMenu();
                        break;
                    case 7:
                        Console.WriteLine("Exiting Admin Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            } while (choice != 7);
        }

        // Manage players menu
        /*public void ManagePlayers()
        {
            int choice;
            do
            {
                Console.WriteLine("\nManage Players:");
                Console.WriteLine("1. Register Players");
                Console.WriteLine("2. Show Registered Players");
                Console.WriteLine("3. Remove Player");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterPlayers();
                        break;
                    case 2:
                        ShowRegisteredPlayers();
                        break;
                    case 3:
                        RemovePlayer();
                        break;
                    case 4:
                        Console.WriteLine("Returning to Main Menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            } while (choice != 4);
        }*/
    }
}
