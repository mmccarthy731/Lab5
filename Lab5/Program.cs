using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();

            Console.WriteLine("Welcome to the Grand Circus Casino!\n\nThis is a dice rolling simulator. Each user is allowed up to 10 rolls of the dice.\n");

            bool newUser = true;
            while (newUser)
            {
                string name = GetUserName("Please enter your name: ");
                int sides = GetSides($"How many sides would you like your dice to have, {name}?: ");
                bool repeat = GetYesOrNo($"Would you like to roll the dice, {name}? (Y or N): ");
                int attempts = 10;

                while (repeat)
                {
                    attempts--;
                    for (int i = 1; i <= 2; i++)
                    {
                        int num = generator.Next(sides) + 1;
                        Console.WriteLine($"Dice {i}: {num}");
                    }
                    if (attempts > 0)
                    {
                        Console.Write($"You have {attempts} rolls remaining, {name}. ");
                        repeat = GetYesOrNo("Would you like to roll again? (Y or N): ");
                    }
                    else
                    {
                        Console.Write($"You are out of rolls, {name}. ");
                        repeat = false;
                    }
                }
                newUser = GetYesOrNo("Would someone else like to roll the dice? (Y or N): ");
            }
            Console.WriteLine("Thank you, and I hope you enjoyed your stay at Grand Circus Casino! Goodbye.");
            Console.ReadLine();
        }

        private static string GetUserName(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private static int GetSides(string prompt)
        {
            Console.Write(prompt);
            if(!int.TryParse(Console.ReadLine(), out int sides) || sides < 2)
            {
                Console.Write("Invalid input. ");
                return GetSides(prompt);
            }
            return sides;
        }

        private static bool GetYesOrNo(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine().ToUpper();
            if(input == "Y")
            {
                return true;
            }
            else if(input == "N")
            {
                return false;
            }
            else
            {
                Console.Write("Invalid input. ");
                return GetYesOrNo(prompt);
            }
        }
    }
}
