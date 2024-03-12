using System;

namespace github_Collab_Csharp
{
    internal class DiceRoller
    {
        public static void RollNewNumber()
        {
            // Prompt the user to enter the dice roll command
            Console.WriteLine("Please enter your roll (e.g., '2d6'):");

            // Read the input from the user
            string input = Console.ReadLine();

            // Attempt to parse the input
            if (TryParseDiceNotation(input, out int numberOfDice, out int numberOfSides))
            {
                // Initialize the Random object and a variable to store the total roll
                Random random = new Random();
                int totalRoll = 0;

                // Roll the dice the specified number of times
                for (int i = 0; i < numberOfDice; i++)
                {
                    totalRoll += random.Next(1, numberOfSides + 1);
                }

                // Display the result of the dice rolls
                Console.WriteLine($"Result of rolling {numberOfDice}d{numberOfSides}: {totalRoll}");
            }
            else
            {
                // The input was not in the correct format
                Console.WriteLine("Invalid input. Please enter a valid dice notation (e.g., '2d6').");
            }
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
    }
}
