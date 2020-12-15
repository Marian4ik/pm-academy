using System;

namespace HW1_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Marian Finiak");
            Console.WriteLine("Сalculation of the probability of the result: ");
            
            Console.WriteLine("Enter the name of the first team: ");
            string name1 = Console.ReadLine();
            
            Console.WriteLine("Enter the name of the second team: ");
            string name2 = Console.ReadLine();
            
            Console.WriteLine("Enter the odds for the first team to win: ");
            var P1 = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter the odds for f draw: ");
            var X = double.Parse(Console.ReadLine());
        
            Console.WriteLine("Enter the odds for the second team to win: ");
            var P2 = double.Parse(Console.ReadLine());

            double oddP1 = 100 / P1;
            double oddX = 100 / X;
            double oddP2 = 100 / P2;
            double margin = (oddP1 + oddX + oddP2) - 100;

            Console.WriteLine($"Winn ''{name1}'': {oddP1}%");
            Console.WriteLine($"Winn ''{name2}'': {oddP2}%");
            Console.WriteLine($"DRAW : {oddX}%");
            Console.WriteLine($"Margin {margin}%");
        }

    }
}
