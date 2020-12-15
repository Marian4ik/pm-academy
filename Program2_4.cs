using System;

namespace Task1_2_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Marian Finiak\n");
            Console.WriteLine("Task 2_4");
            Console.WriteLine("Game: More or less \n");
            
            Console.WriteLine("Rules:\n" +
                                     "You choose an arbitrary range\n" +
                                     "Computer generet number\n" +
                                     "You are trying to guess this number\n" +
                                     "You will get tips is your number less or more than correct.\n" +
                                     "Game is over when you guess number or type exit.\t");

            Console.WriteLine("Enter the beginning of the range 0 to 1.000.000");
            int beginning;
            while (!Int32.TryParse(Console.ReadLine(), out beginning) || beginning < 0 || beginning > 1000000)
            {
                Console.WriteLine("You have entered an incorrect value!");
            }
            Console.WriteLine($"Enter the finish of the range from {beginning} to 1.000.000");
            int finish;
            while (!Int32.TryParse(Console.ReadLine(), out finish) || finish < beginning || finish > 1000000)
            {
                Console.WriteLine("You have entered an incorrect value!");
            }
            int point = 0;
            int shot = 0;
            var rand = new Random();
            var num = rand.Next(beginning, finish + 1);
            var startTime = DateTime.Now;
            do
            {
                Console.Write("Guess a number: ");
                int playNumber;
                var entr = Console.ReadLine();
                if (entr == "exit") break;
                while (!Int32.TryParse(entr, out playNumber))
                {
                    Console.WriteLine("Enter integer");
                    entr = Console.ReadLine();
                }
                shot++;
                if (playNumber == num)
                {
                    int n = getK(finish - beginning + 1);
                    point = (int)Math.Ceiling(100d * (n - shot + 1) / n);
                    if (point < 1) point = 1;
                    break;
                }
                else if (playNumber < num)
                {
                    Console.WriteLine("More");
                }
                else
                {
                    Console.WriteLine("Less");
                }
            } while (true);



            Console.WriteLine($"Points: {point}");
            Console.WriteLine($"Shots: {shot}");
            Console.WriteLine($"Game duration: {DateTime.Now.Subtract(startTime)}");
        }

        static int getK(int d)
        {
            int min = Math.Abs(d - 1);
            int k = 0;
            for (int i = 1; i <= 20; ++i)
            {
                int p = (int)Math.Pow(2, i);
                if (Math.Abs(d - p) < min)
                {
                    min = Math.Abs(d - p);
                    k = i;
                }
            }

            return k;
        }
    }
}