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
    }

    private static void PlayHideAndSeek()
    {
        throw new NotImplementedException();
    }

    private static void PlaySlots()
    {
        throw new NotImplementedException();
    }

    static void PlayBlackJack()
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

        // Check results:
        if (playerScore > 21)
        {
            Console.WriteLine("Bust! You lose.");
        }
        else if (dealerScore > 21 || playerScore > dealerScore)
        {
            // Player wins if the dealer busts or the player's score is higher
            Console.WriteLine("You win!");
            currentTokens += 5;  // Player earns 5 tokens
        }
        else
        {
            // Dealer wins if their score is higher and neither player nor dealer busts
            Console.WriteLine("Dealer wins!");
            currentTokens -= 3;  // Player loses 3 tokens
        }

        // End the game after one round
        break;
    }
}
}
