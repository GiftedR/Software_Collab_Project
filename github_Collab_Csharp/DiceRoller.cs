using System;

namespace github_Collab_Csharp
{
    internal class DiceRoller
    {
        private static Random random = new Random();

        public static void RollNewNumber()
        {
            // Prompt the user to enter the dice roll command
            Console.WriteLine("Please enter your roll (e.g., '2d6'):");

            // Read the input from the user
            string input = Console.ReadLine();

            // Roll the dice based on the input
            RollDice(input);
        }

        private static void RollDice(string input)
        {
            string answer = string.Empty;
            // Attempt to parse the input
            if (TryParseDiceNotation(input, out int numberOfDice, out int numberOfSides))
            {
                // Roll the dice and display the results
                int totalRoll = RollDiceSet(numberOfDice, numberOfSides);
                Console.WriteLine($"Result of rolling {numberOfDice}d{numberOfSides}: {totalRoll}");
                do
                {
                    Console.WriteLine("Press 1 to roll again");
                    Console.WriteLine("Press 2 to Exit");
                    answer = Console.ReadLine();
                    if(answer == "1")
                    {
                        Console.Clear();
                        RollNewNumber();
                    }
                    else
                    {
                        break;
                    }
                } while (answer != "2");
            }
            else
            {
                // The input was not in the correct format
                Console.WriteLine("Invalid input. Please enter a valid dice notation (e.g., '2d6').");
            }

        }

        private static int RollDiceSet(int numberOfDice, int numberOfSides)
        {
            int totalRoll = 0;

            // Roll the dice the specified number of times
            for (int i = 0; i < numberOfDice; i++)
            {
                totalRoll += random.Next(1, numberOfSides + 1);
            }
            return totalRoll;
        }

        private static bool TryParseDiceNotation(string input, out int numberOfDice, out int numberOfSides)
        {
            numberOfDice = 0;
            numberOfSides = 0;

            // Split the input based on 'd'
            string[] parts = input.Split('d');

            // Ensure there are exactly two parts and each part is an integer
            if (parts.Length == 2 && int.TryParse(parts[0], out numberOfDice) && int.TryParse(parts[1], out numberOfSides))
            {
                // Check if both numbers are greater than 0
                return numberOfDice > 0 && numberOfSides > 0;
            }

            return false;
        }

        // added a CalculateAverageRoll method  (my new attempt)
        public static double CalculateAverageRoll(int numberOfDice, int numberOfSides, int numRolls)
        {
            double totalSum = 0;
            for (int i = 0; i < numRolls; i++)
            {
                totalSum += RollDiceSet(numberOfDice, numberOfSides);
            }
            return totalSum / numRolls;
        }
    }
}