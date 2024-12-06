using System;
using System.Collections.Generic;
using System.IO;
using project_5.Models;

namespace project_5
{
    public class AdminControl
    {
        private List<Kart> _karts = new List<Kart>();
        private readonly string _filePath = "kart-inventory.txt";
        private Random _random = new Random();

        public AdminControl()
        {
            LoadKartsFromFile();
        }
        private void LoadKartsFromFile()
        {
            if (File.Exists(_filePath))
            {
                var lines = File.ReadAllLines(_filePath);
                foreach (var line in lines)
                 {
                    var parts = line.Split('#');
                    _karts.Add(new Kart{ Id = int.Parse(parts[0]),Name = parts[1],Size = parts[2], IsAvailable = bool.Parse(parts[3])});
                }
            }
         }
         public void AddKart()
         {
            Kart newKart = GenerateKart();
            _karts.Add(newKart);
            SaveKartToFile();
            Console.WriteLine($"Kart ' {newKart.Name} ' added successfully");

         }
         private Kart GenerateKart()
         {
            string [] names  = {"Speedster", "Roadster", "Monster", "Drifter", "Racer"};
            string [] sizes = {"small", "medium", "large"};
            return new Kart
            { Id = _karts.Count+1, Name = names[_random.Next(names.Length)], Size = sizes[_random.Next(sizes.Length)], IsAvailable = true };
         }
         private void SaveKartToFile()
         {
            using (StreamWriter writer = new StreamWriter(_filePath)){
                foreach (var kart in _karts){
                    writer.WriteLine($"{kart.Id}#{kart.Name}#{kart.Size}#{kart.IsAvailable}");
                }
            }
         }
         public List<Kart> GetKarts(){
            return _karts;
         }
         public void RemoveKart(int id)
         {
            var kart = _karts.Find(k => k.Id == id); 
            if(kart != null){
                _karts.Remove(kart);
                SaveKartToFile();
                Console.WriteLine("kart removed successfully");
            }else{
                Console.WriteLine("kart not found");
            }
         }
         public void EditKart(int id, string newName, string newSize, bool isAvailable)
         {
            var kart = _karts.Find(k => k.Id == id);
            if (kart != null){
                kart.Name = newName;
                kart.Size = newSize;
                kart.IsAvailable = isAvailable;
                SaveKartToFile();
                Console.WriteLine("kart updated successfully");
            } else{
                Console.WriteLine("kart not found");
            }
         }
        public void ManageKarts()
        {
            Console.WriteLine("Kart Inventory: ");
            foreach(var kart in _karts){
                Console.WriteLine($"ID: {kart.Id}, Name: {kart.Name}, Size: {kart.Size}, Available: {kart.IsAvailable}");
            }
        }
        public void ReportMenu()
        {
            Console.WriteLine("Report Menu: ");
            //report generation logic here
        }
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
                Console.WriteLine("5. Report Menu"); 
                Console.WriteLine("6. Exit"); 
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
                    int editId = int.Parse(Console.ReadLine()); Console.Write("Enter new name: "); 
                    string newName = Console.ReadLine(); Console.Write("Enter new size (Small/Medium/Large): "); 
                    string newSize = Console.ReadLine(); Console.Write("Is available (true/false): "); 
                    bool isAvailable = bool.Parse(Console.ReadLine()); 
                    EditKart(editId, newName, newSize, isAvailable); 
                    break;
                    case 4:
                    ManageKarts(); 
                    break; 
                    case 5: 
                    ReportMenu(); 
                    break; 
                    case 6: 
                    Console.WriteLine("Exiting menu..."); 
                    break; 
                    default: Console.WriteLine("Invalid choice, please try again."); 
                    break;
                }
            } while (choice != 6);
        }
   
   
   
   
    }




}





