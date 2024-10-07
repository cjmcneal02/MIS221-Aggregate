
using System;

namespace UserMenuApp
{
    class Program
    {
//main menu
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1. Convert Units of Measure");
                Console.WriteLine("2. Rock Classification");
                Console.WriteLine("3. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ConvertUnitsOfMeasure();
                        break;
                    case "2":
                        RockClassification();
                        break;
                    case "3":
                        Console.WriteLine("Exiting the program. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid selection. Please choose a valid option.");
                        break;
                }

                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
            }
        }
//menu if conversion selected
        static void ConvertUnitsOfMeasure()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose the type of conversion:");
                Console.WriteLine("1. Length");
                Console.WriteLine("2. Mass");
                Console.WriteLine("3. Temperature");
                Console.WriteLine("4. Return to Main Menu");

                string typeChoice = Console.ReadLine();

                switch (typeChoice)
                {
                    case "1":
                        ConvertLength();
                        break;
                    case "2":
                        ConvertMass();
                        break;
                    case "3":
                        ConvertTemperature();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid selection. Please choose a valid option.");
                        break;
                }

                Console.WriteLine("Press any key to return to the conversion menu...");
                Console.ReadKey();
            }
        }
//length conversion code
        static void ConvertLength()
        {
            Console.Clear();
            Console.WriteLine("Convert Length");
            Console.WriteLine("Enter the amount:");
            string value = Console.ReadLine();

            if (!double.TryParse(value, out double amount))
            {
                Console.WriteLine("Invalid amount. Please enter a numeric value.");
                return;
            }

            Console.WriteLine("Enter the unit you are converting from (inches, yards, miles, mm, cm, m, km):");
            string unitInput = Console.ReadLine()?.ToLower();

            Console.WriteLine("Enter the unit you are converting to (inches, yards, miles, mm, cm, m, km):");
            string unitOutput = Console.ReadLine()?.ToLower();

            double convertedAmount = 0;

            //conversion rates 

            double mmToCm = 0.1;
            double mmToM = 0.001;
            double mmToKm = 0.000001;
            double cmToMm = 10;
            double cmToM = 0.01;
            double cmToKm = 0.00001;
            double mToMm = 1000;
            double mToCm = 100;
            double mToKm = 0.001;
            double kmToMm = 1000000;
            double kmToCm = 100000;
            double kmToM = 1000;
            double inchToYard = 1.0 / 36;
            double inchToMile = 1.0 / 63360;
            double yardToInch = 36;
            double yardToMile = 1.0 / 1760;
            double mileToInch = 63360;
            double mileToYard = 1760;

            if (unitInput == "mm" && unitOutput == "cm")
                convertedAmount = amount * mmToCm;
            else if (unitInput == "mm" && unitOutput == "m")
                convertedAmount = amount * mmToM;
            else if (unitInput== "mm" && unitOutput == "km")
                convertedAmount = amount * mmToKm;
            else if (unitInput == "cm" && unitOutput == "mm")
                convertedAmount = amount * cmToMm;
            else if (unitInput== "cm" && unitOutput == "m")
                convertedAmount = amount * cmToM;
            else if (unitInput == "cm" && unitOutput == "km")
                convertedAmount = amount * cmToKm;
            else if (unitInput== "m" && unitOutput == "mm")
                convertedAmount = amount * mToMm;
            else if (unitInput == "m" && unitOutput == "cm")
                convertedAmount = amount * mToCm;
            else if (unitInput == "m" && unitOutput == "km")
                convertedAmount = amount * mToKm;
            else if (unitInput == "km" && unitOutput == "mm")
                convertedAmount = amount * kmToMm;
            else if (unitInput == "km" && unitOutput == "cm")
                convertedAmount = amount * kmToCm;
            else if (unitInput == "km" && unitOutput == "m")
                convertedAmount = amount * kmToM;
            else if (unitInput == "inches" && unitOutput == "yards")
                convertedAmount = amount * inchToYard;
            else if (unitInput == "inches" && unitOutput == "miles")
                convertedAmount = amount * inchToMile;
            else if (unitInput == "yards" && unitOutput== "inches")
                convertedAmount = amount * yardToInch;
            else if (unitInput == "yards" && unitOutput == "miles")
                convertedAmount = amount * yardToMile;
            else if (unitInput == "miles" && unitOutput == "inches")
                convertedAmount = amount * mileToInch;
            else if (unitInput == "miles" && unitOutput == "yards")
                convertedAmount = amount * mileToYard;
            else
            {
                Console.WriteLine("Invalid unit conversion.");
                return;
            }

            Console.WriteLine($"{amount} {unitInput} is equal to {convertedAmount} {unitOutput}");
        }

//mass conversion code
        static void ConvertMass()
        {
            Console.Clear();
            Console.WriteLine("Convert Mass");
            
            Console.WriteLine("Enter the unit you are converting from (ounces, pounds, kilograms, grams):");
            string unitInput = Console.ReadLine()?.ToLower();

            Console.WriteLine("Enter the unit you are converting to (ounces, pounds, kilograms, grams):");
            string unitOuput = Console.ReadLine()?.ToLower();

            Console.WriteLine("Enter starting amount: ");
            double amount = double.Parse(Console.ReadLine());


            double convertedAmount = 0;

            //MASS CONVERSION

           
            switch (unitInput)
            { //from grams
                case "grams":
                switch(unitOuput)
                {
                    case "kilograms":
                    convertedAmount = amount/1000 ;
                    break;

                    case"ounces":
                    convertedAmount = amount*0.0353 ; 
                    break;

                    case"pounds":
                    convertedAmount = amount*2.2046;
                    break;

                    case "grams": 
                    convertedAmount = amount;
                    break;
                }
                break;
                 //from kilograms
                case "kilograms":
                switch (unitOuput)
                {
                    case "grams":
                    convertedAmount = amount*1000 ; 
                    break;
                    case "ounces":
                    convertedAmount = amount*35.274 ; 
                    break; 
                    case"pounds":
                    convertedAmount= amount*2.20462 ; 
                    break;
                    case "kilograms":
                    convertedAmount=amount;
                    break;
                }
                break;
                case "pounds":
                switch(unitOuput)
                {//from pounds
                    case"grams": convertedAmount = amount * 453.592 ; 
                    break;
                    case"kilograms": convertedAmount = amount / 2.20462 ; 
                    break;
                    case"ounces" : convertedAmount = amount * 16 ; 
                    break;
                    case"pounds": convertedAmount = amount;
                    break; 
                }
                break;
                case "ounces":
                switch (unitInput)
                {// from ounces
                    case "grams":
                    convertedAmount = amount*28.3495;
                    break;
                    case "kilograms":
                    convertedAmount = amount / 35.274;
                    break;
                    case "pounds":
                    convertedAmount = amount /16;
                    break;
                    case "ounces":
                    convertedAmount = amount;
                    break; 
                }
                break; 
            }
            Console.WriteLine($"{amount} {unitInput} is equal to {convertedAmount} {unitOuput}");
        }
//temperature conversion code 
        static void ConvertTemperature()
        {
            Console.Clear();
            Console.WriteLine("Convert Temperature");
            Console.WriteLine("Enter the amount:");
            string value = Console.ReadLine();

            if (!double.TryParse(value, out double amount))
            {
                Console.WriteLine("Invalid amount. Please enter a numeric value.");
                return;
            }

            Console.WriteLine("Enter the unit you are converting from (Fahrenheit, Celsius):");
            string unitInput = Console.ReadLine()?.ToLower();

            Console.WriteLine("Enter the unit you are converting to (Fahrenheit, Celsius):");
            string unitOutput = Console.ReadLine()?.ToLower();

            double convertedAmount = 0;

            if (unitInput == "fahrenheit" && unitOutput == "celsius")
                convertedAmount = (amount - 32) * 5 / 9;
            else if (unitInput == "celsius" && unitOutput == "fahrenheit")
                convertedAmount = (amount * 9 / 5) + 32;
            else
            {
                Console.WriteLine("Invalid unit conversion.");
                return;
            }

            Console.WriteLine($"{amount} {unitInput} is equal to {convertedAmount} {unitOutput}");
        }
//rock classification code
        static void RockClassification()
{
        {
            Console.Clear();
            Console.WriteLine("Rock Classification");

            
            double totalPoints = 0;
            double buffedPoints = 0;

            Console.WriteLine("Enter the number of identical rock samples found: ");
            int identicalSamples = int.Parse(Console.ReadLine()); 
            totalPoints += identicalSamples * 4.5;

            Console.WriteLine("Would you like the rock to be transported?: ");
            string transport = Console.ReadLine().ToLower();
            if (transport == "yes")
            {
                totalPoints += 7.3; 
            }
            if (transport == "no")
            {
               totalPoints += 0;
            }
            Console.WriteLine("What is the the surface temperature of the rock (in degrees)?: ");
            double temperature = double.Parse(Console.ReadLine());
            if (temperature <= 0)
            {
                totalPoints += 9.2;
            }
            Console.WriteLine("What is the total weight of the sample(s)(in kilograms)?: ");
            double weightTotal = double.Parse(Console.ReadLine());
            if(weightTotal > 25)
            {
                totalPoints *= 1.17; // adding 17% increase
            }
            Console.WriteLine($"Total Points: {totalPoints}");

            //buff/debuff the score
            while (true)
            {
                Console.WriteLine("Would you like to adjust the resulting total points? (yes/no): ");
                string pointAdjust = Console.ReadLine().ToLower();
                if (pointAdjust == "no")
                {
                break;
                }
                if (pointAdjust == "yes")
                {
                     Console.WriteLine("Increase or Decrease?: ");
                     string adjustment = Console.ReadLine().ToLower();
                     double adjustmentAmount;
                     switch (adjustment)
                     {
                        case "increase":
                        Console.WriteLine("By how much: ");
                        adjustmentAmount = double.Parse(Console.ReadLine());
                        if (adjustmentAmount > totalPoints)
                        {
                            Console.WriteLine("Error: Adjustment amount is greater than the original point value. Please try again.");
                        }
                        else
                         {
                            totalPoints += adjustmentAmount;
                            buffedPoints += adjustmentAmount;
                            Console.WriteLine($"Updated point value: {totalPoints}");
                            Console.WriteLine($"Total amount increased/decreased: {buffedPoints}");
                            }
                        break;
                         case "decrease":
                          Console.WriteLine("By how much: ");
                          adjustmentAmount = double.Parse(Console.ReadLine());
                          if (adjustmentAmount > totalPoints)
                          {
                            Console.WriteLine("Error: Adjustment amount is greater than the original point value. Please try again.");
                            }
                         else
                         {
                            totalPoints -= adjustmentAmount;
                            buffedPoints -= adjustmentAmount;
                            Console.WriteLine($"Updated point value: {totalPoints}");
                            Console.WriteLine($"Total amount increased/decreased: {buffedPoints}");
                            }
                            break;
                            default:
                            Console.WriteLine("Invalid input. Please enter 'increase' or 'decrease'.");
                            break;
                             }
                     }
                }
            }
        }
    }
}