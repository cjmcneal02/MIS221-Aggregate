//PA3  main start
using System;
class CatCade
{
  static int currentTokens = 10;
    static int slotTokens = 0;
    static int hideAndSeekTokens = 0;
    static int blackjackTokens = 0; 
    static int maxTokensPerGame = 10;
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
            Console.WriteLine("2. Play Hide and Seek");
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
                Console.Clear();
                break;
            }
            if (currentTokens >= 20)
            {
                Console.WriteLine("Congratulations. You have enough tokens to adopt a cat!");
                break; 
                //consider making a prize-picking 8menu where player can choose different cats for certain amounts of tokens
                //display the cat using symbols depending on what they choose
                //print remaining tokens, and offer to return to catcade menu or quit 
            }
        }
    }

    private static void PromptToContinue()
    {
        Console.WriteLine("Press Enter to return to Catcade Menu");
        Console.ReadLine();
        Console.Clear();
    }

    private static void PlayHideAndSeek()
    {
        //hide and seek method
    }

    private static void PlaySlots()
    {if (currentTokens<1)
    {
        Console.WriteLine("You need more tokens to use the Slot Machine....");
        PromptToContinue(); //prompt to continue and return to main menue
        return; 
    }
    Console.WriteLine("Spin the Slot Machine!");
    Console.WriteLine("Each spin costs 1 token. Would You Like to play?(Yes or No): ");
    string slotInput = Console.ReadLine().ToLower().Trim();
    switch(slotInput)
    {
        case "yes":
        SpinMachine();
        break;
        case "no":
        PromptToContinue();
        return; 
    }
   
    }
static void SpinMachine()
{

    Console.Write("How many tokens would you like to wager?: ");

    if (!int.TryParse(Console.ReadLine(), out int wager) || wager <= 0) //defines wager; ensures wager is a positive number
    {
        Console.WriteLine("Invalid wager. Return to menu");
        PromptToContinue ();
        return;

    }
    if (wager>currentTokens) //check if wager is valid
    {
        Console.WriteLine("You don't have enough tokens for that wager. Returning to menu.");
        return;

    }
    currentTokens -= wager;
    string[] slotSymbols = {" =^.^=  ","【ᓚ₍ ^. .^₎】","【ฅ^•⩊•^ฅ】", "【≽ܫ≼】", "【≽^•⩊•^≼】","【/ᐠ – ˕ -マ】"}; //possible outcomes
    string  slotOne = slotSymbols[random.Next(slotSymbols.Length)]; //choose random outcomes given slot possibilities
    string slotTwo = slotSymbols[random.Next(slotSymbols.Length)];
    string slotThree = slotSymbols[random.Next(slotSymbols.Length)];
    
    Console.WriteLine($"|{slotOne}|{slotTwo}|{slotThree}");//results of spin

    int matchCount = 0;
    //need to determine tokens won based on matching slots
    if (slotOne==slotTwo && slotTwo==slotThree)
    {
        matchCount = 3; //three grand prize symbols spun
    }
    else if(slotOne == slotTwo||slotTwo ==slotThree||slotOne==slotThree)
    {
        matchCount =2; //two grand prize symbols spun

    }
    else if(slotOne == "=^.^= "|| slotTwo == "=^.^= " ||slotThree =="=^.^= ")
    {
        matchCount = 1; //one grand prize symbol spun
    }
    int earnedTokens = 0;
    switch (matchCount)
    {
        case 3:
        Console.WriteLine("Jackpot! You've tripled your wager!");
        earnedTokens =  wager*3; //jackpot = triple the wager as reward
        Console.WriteLine("You also won free cat food!"); //catfood prize
        break;
        case 2: 
        Console.WriteLine("You spun two matching symbols! You've doubled your wager!");
        earnedTokens=wager * 2;
        break;
        case 1:
        Console.WriteLine(" You got one Grand Prize Symbol...You're wager has been returned");
        earnedTokens = wager; //return wager by adding back
        break;
        default:
        Console.WriteLine("No matches spun...Better Luck next time!");
        break;
    }
    if(slotTokens + earnedTokens<+ maxTokensPerGame)
    {
        slotTokens+=earnedTokens;
        currentTokens+=earnedTokens;
    }
    else
    {
        Console.WriteLine("max tokens reached for slots");
    }

    PromptToContinue();
    
} //end slots
    static void PlayBlackJack()  //blackjack method begin
{
    Console.WriteLine("Welcome to BlackJack!");

    while (true)
    {
        int playerScore = 0;  // Player's score starts at 0
        int dealerScore = random.Next(16, 23);  // Dealer's score is generated once at the start
        bool playerStand = false;  // Flag to check if player chooses to stand

        // This loop continues as long as the player hasn't chosen to stand and their score is below 21
        while (!playerStand && playerScore < 21)
        {
            int newCard = random.Next(1, 11);  // Draw a card with a random value between 1 and 10
            playerScore += newCard;  // Add the value of the new card to the player's total score
            Console.WriteLine($"You drew a {newCard}. Your total score is {playerScore}");

            // If the player's score is less than 21, ask if they want to hit or stand
            if (playerScore < 21)
            {
                Console.WriteLine("Do you want to hit or stand?");
                string blackJackInput = Console.ReadLine().ToLower().Trim();  // Read and convert input to lowercase for consistency

                if (blackJackInput == "hit")
                {
                    // If the player chooses "hit", the loop continues and a new card is drawn on the next iteration
                    continue;  // Move to the next iteration of the loop to draw another card
                }
                else if (blackJackInput == "stand")
                {
                    // If the player chooses "stand", set playerStand to true to stop the card drawing loop
                    playerStand = true;
                }
                else
                {
                    // If the input is anything other than "hit" or "stand", prompt for valid input again
                    Console.WriteLine("Invalid input. Please type 'hit' or 'stand'.");
                }
            }
        }

        // Once the player stands or busts, reveal the dealer's score and determine the winner
        Console.WriteLine($"Dealer's Score: {dealerScore}");
        int earnedTokens = 0;
        // Check results:
        if (playerScore > 21)
        {
            Console.WriteLine("Bust! You lose.");
        }
        else if (dealerScore > 21 || playerScore > dealerScore)
        {
            // Player wins if the dealer busts or the player's score is higher
            Console.WriteLine("You win!");
            earnedTokens += 5;  // Player earns 5 tokens
        }
        else
        {
            // Dealer wins if their score is higher and neither player nor dealer busts
            Console.WriteLine("Dealer wins!");
            earnedTokens -= 3;  // Player loses 3 tokens
        }
        
        if (earnedTokens > 0 && blackjackTokens + earnedTokens<= maxTokensPerGame)
        {
            blackjackTokens +=earnedTokens;
            currentTokens += earnedTokens;
        }
        else if(earnedTokens<=0)
        {
            currentTokens+=earnedTokens;
        }
        else
        {
             Console.WriteLine("max tokens reached for blackjack");
        }
        PromptToContinue();        

        // End the game after one round
        break;
    }
}
}//main end 

