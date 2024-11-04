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
                exit = true;
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
    Console.Write("Enter the file to encode: ");
    string inputFile = Console.ReadLine();
    Console.Write ("Enter the file name to save the encoded file as: ");
    string outputFile = Console.ReadLine();

    try
    {
        string content = File.ReadAllText(inputFile);
        string encodedContent =  Rot13(content);
        File.WriteAllText(outputFile,encodedContent );
        Console.WriteLine("file encoded successfully.");
        
    }
    catch(Exception ex)
    {
        Console.WriteLine($"error: {ex.Message}");
    }
    PromptToContinue();

}

static void DecodeFile()
{
    Console.Write("Enter a file to decode: ");
    string inputFile = Console.ReadLine();
    Console.Write(" Enter a file name to save the decoded file as: ");
    string outputFile = Console.ReadLine();
    try
    {
        string encodedContent = File.ReadAllText(inputFile);
        string decodedContent = Rot13(encodedContent);
        File.WriteAllText(outputFile,decodedContent);
        Console.WriteLine("File decoded");


    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    PromptToContinue();
}

static void WordCount()
{
    Console.Write("Enter the file you wish to check the count of: ");
    string fileName = Console.ReadLine();

    try
    {
        string content = File.ReadAllText(fileName);
        int wordCount = content.Split(new[]{' ','\t','\n','\r'},StringSplitOptions.RemoveEmptyEntries).Length;
        Console.WriteLine($"The file contains {wordCount} words.");
        
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");

    }
    PromptToContinue();
}
static string Rot13(string input) //rot13 string
{
char[] array = input.ToCharArray();
for (int i = 0; i < array.Length; i++)
{
    int number = (int)array[i];

    if(number>='A' && number <= 'Z') //for uppercase letter inputs
    {
        if (number>'M')
        {
            number -=13;
        }
        else 
        {
            number += 13;
        }
    }
    else if(number >= 'a' && number <= 'z') //for lowercase letter inputs
    {
        if (number >='m')
        {
            number -= 13;
        }
        else
        {
            number += 13;
        }
    }
    array [i] = (char)number;
}
return new string(array);
}
} // end program
