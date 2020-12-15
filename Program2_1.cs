using System;
using System.Collections.Generic;

namespace Task2_1
{

    class Program
    {
        private static List<string> stata;
        static void Main(string[] args)
        {
            Console.WriteLine("Marian Finiak");
            Console.WriteLine("Task 2_1\n");
            Console.WriteLine("Game Stone-Scissors-Paper.\n");
            
            PlayGame();
        }

        static void PlayGame()
        {
            
            Console.WriteLine("You need to win the largest number of times.");
            Console.WriteLine("Victorious combinations:\n\tstone > scissors\n\tscissors > paper\n\tpaper > stone");
            
            PrintCommands();
            
            stata = new List<string>();
            
            while (true)
            {
                Console.Write("enter command: ");
                var choice = Console.ReadLine().ToLower();

                
                switch (choice)
                {
                    case "stone" :
                        Game(0);
                        break;
                    case "scissors":
                        Game(1);
                        break;
                    case "paper":
                        Game(2);
                        break;
                    case "exit":
                        PrintGameStatistic(stata);
                        return;
                    default:
                        Console.WriteLine("you entered incorrectly");
                        PrintCommands();
                        Console.WriteLine("Try again.");
                        break;
                }

            }
        }

        static void Game(int command)
        {
            var comp = ComputerChoice();
            PrintComputerChoice(comp);
            var res = GetGameResult(command, comp);
            PrintGameResult(res);
            stata.Add(res);
        }
        static void PrintCommands()
        {
            Console.WriteLine("List of commands(enter in any case):");
            Console.WriteLine("\tstone");
            Console.WriteLine("\tscissors");
            Console.WriteLine("\tpaper");
            Console.WriteLine("\texit\n");
        }

        static string GetGameResult(int person, int computer)
        {
            //0 - computer wins, 1 - person wins, 2 - draw
            person = (person + 1) % 3;
            computer = (computer + 1) % 3;
            if (person == computer) return "Draw.";
            else if ((computer + 1) % 3 == person) return "Computer wins.";
            else return "You win!";
        }

        static int ComputerChoice()
        {
            var rand = new Random();
            var variant = rand.Next(3);
            return variant;
        }
        static void PrintComputerChoice(int comp)
        {
            Console.Write($"Computer's choice: ");
            if (comp == 0) Console.WriteLine("stone");
            else if (comp == 1) Console.WriteLine("scissors");
            else Console.WriteLine("paper");
        }
        static string PrintGameResult(string res)
        {
            Console.WriteLine($"Game result: {res}\n");
            return res;
        }

        static void PrintGameStatistic(List<string> stata)
        {
            var size = stata.Count;
            Console.Write($"\nYou have played {size} game");
            if (size != 1) Console.Write(" ");
            Console.WriteLine();
            for (int i = 0; i < size; ++i)
            {
                Console.WriteLine($"Game №{i + 1} result: {stata[i]}");
            }
        }
    }
}