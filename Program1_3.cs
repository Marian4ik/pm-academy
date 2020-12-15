using System;

namespace HW1_1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Author: Marian Finiak\n");
            Console.WriteLine("Task 1_3");
            Console.WriteLine("Calculate sum of math formula.\n");
            
            int i = 1;
            int bYear = 2000;
            double epsilon = 1d / bYear;
            Console.WriteLine($"birth year: {bYear};\nepsilon: {epsilon};\nsum (1/i*(i+1)) i from {i} to Infinity\n");
            double element = 1;
            double sum = 0;
            while (element >= epsilon)
            {
                element = 1d / (i * (i + 1));
                sum += element;
                i++;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}