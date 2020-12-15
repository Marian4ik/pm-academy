using System;


namespace Task1_2_3
{
    class Program
    {
        static int Main(string[] args)
        {
            int n = args.Length;
            int[] array;
            bool cMode = false;
            if (n == 0)
            {
                Console.WriteLine("Marian Finiak\n");
                Console.WriteLine("Task 2_3");
                Console.WriteLine("statistics of array");
                
                do
                {
                    Console.WriteLine("Enter array size");
                }
                while (!Int32.TryParse(Console.ReadLine(), out n) || n <= 0);
                array = new int[n];
                Console.WriteLine("Enter array elements");
                for (int i = 0; i < n; ++i)
                {
                    while (!Int32.TryParse(Console.ReadLine(), out array[i]))
                    {
                        Console.WriteLine("Enter integer");
                    }
                }
            }
            else
            {
                cMode = true;
                array = new int[n];
                for (int i = 0; i < n; ++i)
                {
                    if (!Int32.TryParse(args[i], out array[i]))
                    {
                        return -1;
                    }
                }
            }
            PrResult(array, cMode);
            return 0;
        }

        static int Min(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; ++i)
            {
                if (array[i] < min) min = array[i];
            }
            return min;
        }
        static int Max(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; ++i)
            {
                if (array[i] > max) max = array[i];
            }
            return max;
        }
        static int Sum(int[] array)
        {
            int sum = 0;
            foreach (var element in array)
            {
                sum += element;
            }

            return sum;
        }

        static double Average(int[] array)
        {
            return (double)Sum(array) / array.Length;
        }

        static double Deviation(int[] array)
        {
            var average = Average(array);
            var S = 0d;
            foreach (var element in array)
            {
                S += (element - average) * (element - average);
            }

            return Math.Sqrt(S / array.Length);
        }

        static int[] Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                for (int j = i + 1; j < array.Length; ++j)
                {
                    if (array[i] > array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        static void PrResult(int[] array, bool commandMode)
        {
            if (!commandMode) Console.Write($"Min element: {Min(array)}\n");
            
            if (!commandMode) Console.Write($"Max element: {Max(array)} \n");
            
            if (!commandMode) Console.Write($"Sum of elements: {Sum(array)}\n");
            
            if (!commandMode) Console.Write($"Average: {Average(array)} \n");
            
            if (!commandMode) Console.Write($"Standard Deviation: {Deviation(array)}\n ");
            
            if (!commandMode) Console.WriteLine("Sorted array:");
            var sortedArray = Sort(array);
            
            foreach (var element in sortedArray) Console.Write($"{element} ");
        }
    }

}