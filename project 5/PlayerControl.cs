using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace project_5
{
    public class PlayerControl
    {
        private List<Kart> _karts;
        private readonly string _filePath = "kart-inventory.txt";
        private readonly string _resultsFilePath = "race-results.txt";
        private Random _random = new Random();
        public PlayerControl(){
            _karts = _karts;
        }
        public void ViewAvailableKarts(){
            Console.WriteLine("available karts: ");
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
        Console.Write("enter a track name: ");
        string trackName = Console.ReadLine();
        
        }
    }
}