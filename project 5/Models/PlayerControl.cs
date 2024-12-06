using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using project_5.Models;

namespace project_5
{
    public class PlayerControl
    {
        private List<Kart> _karts;
        private readonly string _filePath = "kart-inventory.txt";
        private readonly string _resultsFilePath = "race-results.txt";
        private Random _random = new Random();
        private List<string> _tracks = new List<string>{
            "Figure-8 Circuit", "Yoshi Falls", "Cheep Cheep Beach", "Luigi's Mansion", "Desert Hills", "Delfino Square", "Waluigi Pinball", "Shroom Ridge", "DK Pass", "Tick-Tock Clock", "Mario Circuit", "Airship Fortress", "Wario Stadium", "Peach Gardens", "Bowser Castle", "Rainbow Road"
        };
        public PlayerControl(List<Kart> karts){
            _karts = _karts;
        }
        public void ViewAvailableKarts(){
            Console.WriteLine("Available karts: ");
            foreach (var kart in _karts){
                if(kart.IsAvailable){
                    Console.WriteLine($"ID: {kart.Id}, Name: {kart.Name}, Size: {kart.Size} is available"); 
                }
            }
        }
        public void RaceKart(string email){
        ViewAvailableKarts();
        Console.Write("enter a kart ID to race: ");
        int kartId = int.Parse(Console.ReadLine());
        Console.Write("Select a track to race on: ");
        for(int i = 0; i < _tracks.Count;i++){
            Console.WriteLine($"{i+1}. {_tracks[i]}");
        }
        Console.Write("Enter a track number: ");
        int trackChoice = int.Parse(Console.ReadLine());
        if (trackChoice <1 || trackChoice > _tracks.Count){
            Console.WriteLine("invalid trackc choice.");\
            return;
        }
        string trackName = _tracks[trackChoice -1];
        var kart = _karts.Find(k => k.Id == kartId && k.IsAvailable);
        if (kart != null){
            kart.IsAvailable = false; 
            Console.WriteLine($"racing a kart '{kart.Name}' on track '{trackName}'..");

            //simulate race result 
            string interactionId = Guid.NewGuid().ToString();
            DateTime raceDate = DateTime.Now;
            int timeElapsed = _random.Next(30,300); //simulate time in seconds
            string result = $"{interactionId}#{email}#{kart.Id}#{raceDate}#{timeElapsed}#{trackName}#No";
            Console.WriteLine($"Race result: {result}");
            //save results to file
            File.AppendAllText(_resultsFilePath, result + Environment.NewLine);
            kart.IsAvailable = true;
            SaveKartsToFile();
            }else{
            Console.WriteLine( "kart not available");
        }
            

        
        }
        }
        public void ViewRacedKarts(string email){
            if(File.Exists(_resultsFilePath)){
                var lines = File.ReadAllLines(_resultsFilePath);
                Console.WriteLine($"Karts raced by {email}:");
                foreach (var line in lines){
                    if(line.StartsWith(email)){
                        Console.WriteLine(line);
                    }else{
                        Console.WriteLine("No race results found");
                    }
                }
            }
        }
        private void SaveKartsToFile(){
            using(StreamWriter writer = new StreamWriter(_filePath)){
                foreach (var kart in _karts){
                    writer.WriteLine($"{kart.Id}#{kart.Name}#{kart.Size}#{kart.IsAvailable}");
                }
            }
        }
        public void PlayerMenu(){
            int choice;
            do{
                Console.WriteLine("\nPlayerMenu");
                Console.WriteLine("1. View Available Karts");
                Console.WriteLine("2.Race a kart");
                Console.WriteLine("3. View Raced Karts by email");
                Console.WriteLine("4. Return a Kart to inventory");
                Console.WriteLine("5. Exit");
                Console.Write("Select your choice");
                choice = int.Parse(Console.ReadLine());

                switch(choice){
                    case 1: 
                    ViewAvailableKarts();
                    break;
                    case 2: 
                    Console.Write("Enter your email address: ");
                    string email = Console.ReadLine();
                    RaceKart(email);
                    break;
                    case 3: 
                    Console.Write("Enter your email address: ");
                    string viewEmail = Console.ReadLine();
                    ViewRacedKarts(viewEmail);
                    break;
                    case 4: 
                    Console.Write("Enter kart ID to return: ");
                    int returnId = int.Parse(Console.ReadLine());
                    var kart = _karts.Find(k => k.Id == returnId);
                    if(kart != null){
                        kart.IsAvailable = true;
                        SaveKartsToFile();
                        Console.WriteLine("Kart returned successfully");
                    }else{
                        Console.WriteLine("Kart not found");
                    }
                    break;
                    case 5: 
                    Console.WriteLine("Exiting Menu...");
                    break;
                    default:
                    Console.WriteLine("invalid choice, try again");
                    break;

                }
            } while (choice != 5);
        }
     }
     public class Kart{
            public int Id {get;set;}
            public string Name {get;set;}
            public string Size {get;set;}
            public bool IsAvailable {get;set;}
        }
 }
