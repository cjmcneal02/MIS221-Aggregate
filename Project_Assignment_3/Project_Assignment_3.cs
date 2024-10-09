//PA3  main start
using System;
string gameChoice = null;

while (true)
{
    Console.WriteLine(" ================");
    Console.WriteLine("  GAME SELECTION ");
    Console.WriteLine(" ================");
    Console.Clear();
    Console.WriteLine("1. Slot Machine");
    Console.WriteLine("2. Hide & Seek");
    Console.WriteLine("3. BlackJack");
    Console.WriteLine("4. Show Current Tokens");
    Console.WriteLine("5. Exit");

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
             System.Console.WriteLine("You have {tokens} tokens"); //dont forget "$"
            break;
        case "5":
            System.Console.WriteLine("Exiting Catcade!");
            return;
        default:
            Console.WriteLine("You have earned enough tokens to win a Cat");
            break;
    }
}

static void PlayBlackJack()
{
    //throw new NotImplementedException();
}


static void PlaySlots()
{
    //throw new NotImplementedException();
}

static void PlayHideAndSeek()
{
    //throw new NotImplementedException();
}

