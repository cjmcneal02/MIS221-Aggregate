using System;
using System.Runtime.InteropServices;
class Program
{
    static void Main(string[]args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Encode a File");
            Console.WriteLine("2. Decode a File");
            Console.WriteLine("3. Check Word Count");
            Console.WriteLine("4. Exit the Program");
            Console.WriteLine("Enter 1-4 to Select Your Choice: ");
            string userChoice = Console.ReadLine().ToLower().Trim();
            
            switch (userChoice)
            {
                case "1":
                EncodeFile();
                break;
                case "2":
                DecodeFile();
                break;
                case "3":
                WordCount();
                break;
                case "4":
                Console.WriteLine("Now exiting Program...");
                PromptToContinue();
                return;
                default:
                Console.WriteLine("Invalid option entered. Please enter a value 1-4.");
                PromptToContinue();
                Console.Clear();
                break;
                



            }
        }
    } //end main

 private static void PromptToContinue()
{
     Console.WriteLine("Press Enter to continue");
     Console.ReadLine();
      Console.Clear();
}

static void EncodeFile()
{

}

static void DecodeFile()
{

}

static void WordCount()
{

}

} // end program
