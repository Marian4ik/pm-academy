using System;

namespace Task2_2
{
    class Program
    {
        static int Main(string[] args)
        {
            int n = args.Length;
            if (n == 0)
            {
                Console.WriteLine("Marian Finiak\n");
                Console.WriteLine("Task 2_2");
                Console.WriteLine("Area calculator of geometric shapes");
                
                Console.WriteLine("You need enter name of the figure and parameters to calculate area.");
                PrCommands();
                while (true)
                {
                    Console.WriteLine("Enter your command in any case");
                    var command = Console.ReadLine().ToLower();
                    if (command == "circle")
                    {
                        Console.Write("Enter radius of the circle: ");
                        double R;
                        if (!Double.TryParse(Console.ReadLine(), out R) || R < 0 || R > 1e150)
                        {
                            Console.WriteLine("You entered an incorrect radius value");
                            continue;
                        }

                        Console.WriteLine($"CIRCLE radius = {R} Area= {R * R * Math.PI}");
                    }
                    else if (command == "square")
                    {
                        Console.Write("Enter length of thе side: ");
                        double side;
                        if (!Double.TryParse(Console.ReadLine(), out side) || side < 0 || side > 1e150)
                        {
                            Console.WriteLine("You entered an incorrect lenght side value.");
                            continue;
                        }

                        Console.WriteLine($" SQUARE  side =  {side} Area = {side * side}");
                    }
                    else if (command == "rectangle")
                    {
                        Console.Write("Enter rectangle's width: ");
                        double width;
                        if (!Double.TryParse(Console.ReadLine(), out width) || width < 0 || width > 1e150)
                        {
                            Console.WriteLine("You entered an incorrect width value.");
                            continue;
                        }
                        Console.Write("Enter rectangle's height: ");
                        double height;
                        if (!Double.TryParse(Console.ReadLine(), out height) || height < 0 || height > 1e150)
                        {
                            Console.WriteLine("You entered an incorrect height value");
                            continue;
                        }

                        Console.WriteLine($"RECTANGLE height = {height} and width {width} area = {width * height}");
                    }
                    else if (command == "triangle")
                    {
                        Console.Write("Enter triangle's side: ");
                        double side;
                        if (!Double.TryParse(Console.ReadLine(), out side) || side < 0 || side > 1e150)
                        {
                            Console.WriteLine("You entered an incorrect side value.");
                            continue;
                        }
                        Console.Write("Enter perpendicular to this side: ");
                        double perpend;
                        if (!Double.TryParse(Console.ReadLine(), out perpend) || perpend < 0 || perpend > 1e150)
                        {
                            Console.WriteLine("You entered an incorrect perpendicular value.");
                            continue;
                        }

                        Console.WriteLine($"TRIANGLE  side = {side} perpendicular = {perpend} area = {side * perpend / 2}");
                    }
                    else if (command == "exit")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Your command is wrong.");
                        PrCommands();
                    }
                }
            }
            else
            {
                var command = args[0].ToLower();
                if (command == "circle")
                {
                    if (n != 2) return -1;
                    double rad;
                    if (!Double.TryParse(args[1], out rad) || rad < 0 || rad > 1e150)
                        return -1;
                    Console.WriteLine(rad * rad * Math.PI);
                }
                else if (command == "square")
                {
                    if (n != 2) return -1;
                    double l;
                    if (!Double.TryParse(args[1], out l) || l < 0 || l > 1e150)
                        return -1;
                    Console.WriteLine(l * l);
                }
                else if (command == "rectangle")
                {
                    if (n != 3) return -1;
                    double l;
                    if (!Double.TryParse(args[1], out l) || l < 0 || l > 1e150)
                        return -1;
                    double k;
                    if (!Double.TryParse(args[2], out k) || k < 0 || k > 1e150)
                        return -1;
                    Console.WriteLine(l * k);
                }
                else if (command == "triangle")
                {
                    if (n != 3) return -1;
                    double l;
                    if (!Double.TryParse(args[1], out l) || l < 0 || l > 1e150)
                        return -1;
                    double h;
                    if (!Double.TryParse(args[2], out h) || h < 0 ||
                        h > 1e150)
                        return -1;

                    Console.WriteLine(l * h / 2);
                }
                else return -1;
                Console.ReadKey();
            }

            return 0;
        }

        static void PrCommands()
        {
            Console.WriteLine("Commands: ");
            Console.WriteLine("-circle;");
            Console.WriteLine("-square;");
            Console.WriteLine("-rectangle;");
            Console.WriteLine("-triangle;");
            Console.WriteLine("-exit.");
        }
    }
}
