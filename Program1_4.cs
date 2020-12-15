using System;

namespace HW1_1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Author: Marian Finiak\n");
            Console.WriteLine("Task 1_4");
            Console.WriteLine("Search for prime numbers.");
            
            Console.Write("enter the lower limit ");
            var lowlim = Int32.Parse(Console.ReadLine());
           
            Console.Write("enter the upper limit");
            var uplim = Int32.Parse(Console.ReadLine());
            
            for (var i = lowlim; i <= uplim; ++i)
            {
                var Prime = true;
                if (i < 2) continue;
                for (var n = 2; n * n <= i; ++n)
                {
                    if (i % n == 0)
                    {
                        Prime = false;
                        break;
                    }
                }
                if (Prime) Console.WriteLine($"{i} is prime");
            }
        }
    }
}