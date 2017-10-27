using System;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Random generator = new Random();

            Console.WriteLine("Welcome to the Grand Circus Casino!\n\nThis is a dice rolling simulator. Each user is allowed up to 10 rolls of the dice.\n");

            bool changeUser = true;
            while (changeUser)
            {
                string name = GetUserName("Please enter your name: ");
                int sides = GetSides($"How many sides would you like your dice to have, {name}?: ");
                bool repeat = RollDice($"Would you like to roll the dice, {name}? (Y or N): ");
                int attempts = 1;

                while (repeat)
                {
                    for (int i = 1; i <= 2; i++)
                    {
                        int num = generator.Next(sides) + 1;
                        Console.WriteLine(num);
                    }
                    Console.Write($"You have {10 - attempts} rolls remaining, {name}. ");
                    if (attempts < 10)
                    {
                        repeat = RollDice("Would you like to roll again? (Y or N): ");
                        attempts++;
                    }
                    else
                    {
                        repeat = false;
                    }
                }
                changeUser = ChangeUser("Would someone else like to roll the dice? (Y or N): ");
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
            if(!int.TryParse(Console.ReadLine(), out int sides) || sides < 6)
            {
                Console.Write("Invalid input. ");
                return GetSides(prompt);
            }
            return sides;
        }

        private static bool RollDice(string prompt)
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
                Console.Write("Invalid Entry. ");
                return RollDice(prompt);
            }
        }

        private static bool ChangeUser(string prompt)
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
                return ChangeUser(prompt);
            }
        }
    }
}
