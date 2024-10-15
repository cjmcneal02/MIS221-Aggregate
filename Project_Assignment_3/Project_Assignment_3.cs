//PA3  main start
using System;
class CatCade
{
    static int currentTokens = 10;
    static int slotTokens = 0;
    static int hideAndSeekTokens = 0;
    static Random random = new Random(); 
    static List<string> hidingSpots = new List<string> { "plant", "couch", "fridge", "balcony", "closet", "bathtub", "sink"};
    
    static void Main(string[] args)
    {
        while(true)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("           CatCade               ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Play Slot Machine");
            Console.WriteLine("2. Play Hide 'n Seek");
            Console.WriteLine("3. Play Blackjack");
            Console.WriteLine("4. See Current Tokens");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");

            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                PlaySlots();
                break;
                case "2":
                PlayHideAndSeek();
                break;
                case "3":
                PlayBlackJack();
                break;
                case "4":
                Console.WriteLine($"You have {currentTokens} tokens.");
                PromptToContinue();
                break;
                case "5":
                Console.WriteLine("Thanks for Playing! Now exiting CatCade.");
                return;
                default: 
                Console.WriteLine("Invalid input. Pleae enter 1, 2, 3, 4, or 5.");
                break;
            }
            if (currentTokens >= 20)
            {
                Console.WriteLine("Congratulations. You have enough tokens to adopt a cat!");
                break; 
            }
        }
    }
    static void PlayBlackJack()
    {
    //PlayBlackJack code
    }
    static void PlaySlots()
    {
    //slot code
    }
    static void PlayHideAndSeek()
    {
    //hide and seek code
    }
static void PromptToContinue()
{
    Console.WriteLine("Press Enter to return to Catcade Menu");
    Console.ReadLine();
}
 }