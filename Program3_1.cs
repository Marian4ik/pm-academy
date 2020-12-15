using System;

namespace Task1_3_1
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                //dialog mode
                Console.WriteLine("Marian Finiak\n");
                Console.WriteLine("Task 3");
                Console.WriteLine("Calculator\n");
                
                Console.WriteLine("Enter math expression.");
                Console.WriteLine("Expression contains binary or unary operators.\n" +
                                  "Expression have one or two operands.");
                Console.WriteLine("Enter close if you want to stop program, or help if you need it in any case.");
                do
                {
                    Console.Write("Enter expression or command: ");
                    var expr = Console.ReadLine().ToLower();
                    expr = String.Concat(expr.Split(' '));
                    if (expr == "close") break;
                    else if (expr == "help") PrHelp();
                    else
                    {
                        try
                        {
                            Calculation(expr);
                        }

                        catch (DivideByZeroException)
                        {
                            Console.WriteLine("Problem: DivideByZeroException");
                        }
                        catch (ArgumentException)
                        {
                            Console.WriteLine("Problem: ArgumentException!");
                        }
                        catch (OverflowException)
                        {
                            Console.WriteLine("Problem: OverflowException!");
                        }
                        catch (ArithmeticException)
                        {
                            Console.WriteLine("Problem: ArithmeticException.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Problem: IndexOutOfRangeException!");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error occurred. Application will stop.");
                            break;
                        }
                    }
                } while (true);
            }
            else
            {
                //command mode
                var expr = String.Concat(args);
                try
                {
                    Calculation(expr);
                }
                catch (Exception)
                {
                    return -1;
                }
            }
            return 0;
        }

        static void Calculation(string expr)
        {
            int i = 0;
            double res = 0;
            int countSign = 0;
            int l = expr.Length;

            while (i < l)
            {

                if (expr[i] == ' ')
                {
                    i++;
                }
                else if (Char.IsDigit(expr[i]))
                {
                    Result(ref res, expr, ref i, '+');

                    countSign++;
                    if (i == l)
                    {
                        Console.WriteLine(res);
                    }
                }
                else if (IsOperator(expr[i]))
                {
                    i++;
                    if (i == l || (countSign == 0 && expr[i - 1] != '-'))
                    {
                        throw new ArithmeticException();
                    }

                    Result(ref res, expr, ref i, expr[i - 1]);

                    countSign++;
                    if (countSign <= 2 && i == l)
                    {
                        Console.WriteLine(res);
                    }
                    else if (countSign >= 2)
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                else if (IsBinaryBitOperator(expr[i]))
                {
                    if (countSign == 1)
                    {
                        i++;
                        if (i == l)
                        {
                            throw new ArithmeticException();
                        }

                        Result(ref res, expr, ref i, expr[i - 1]);

                        if (i == l)
                        {
                            Console.WriteLine((int)res);
                        }
                        else
                        {
                            throw new IndexOutOfRangeException();
                        }
                    }
                    else if (countSign == 0)
                    {
                        throw new ArithmeticException();
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                    countSign++;
                }
                else if (expr[i] == '!')
                {
                    if (countSign == 1)
                    {
                        if (++i != l)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        //factorial
                        if (res < 0)
                        {
                            throw new ArithmeticException();
                        }

                        Console.WriteLine(Factorial((int)res));

                    }
                    else if (countSign == 0)
                    {
                        if (i + 1 == l)
                        {
                            throw new ArithmeticException();
                        }

                        i++;
                        Result(ref res, expr, ref i, '!');
                        if (i != l)
                        {
                            throw new IndexOutOfRangeException();
                        }
                        Console.WriteLine(res);
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                else if (expr.IndexOf("pow") == i)
                {
                    i += 3;
                    if (i == l || countSign == 0)
                    {
                        throw new ArithmeticException();
                    }
                    Result(ref res, expr, ref i, 'p');

                    if (i == l)
                    {
                        Console.WriteLine(res);
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }
                }
                else
                {
                    throw new ArithmeticException();
                }
            }
        }
        static void PrHelp()
        {
            
            Console.WriteLine("\nBinary operators: a+b, a-b, a*b, axb, a/b, a\\b, a%b, a pow b, where a,b - double values.\n" +
                              "Binary bit operators: a&b, a|b, a^b, operand only positive\n" +
                              "Unary bit operator: !a, operand only positive.\n" +
                              "Unary operators: a!(factorial), a(echo mode), -a");
            
        }

        static bool IsOperator(char c)
        {
            if (c == '+' || c == '-' ||
                c == '*' || c == 'x' ||
                c == '/' || c == '\\' ||
                c == '%')
            {
                return true;
            }
            return false;
        }

        static bool IsBinaryBitOperator(char c)
        {
            if (c == '&' || c == '|' || c == '^')
            {
                return true;
            }
            return false;
        }

        static void Result(ref double res, string expr, ref int i, char Operator)
        {
            string num = "";
            double currentOperand;
            do
            {
                if (expr[i] == '+')
                {
                    throw new ArithmeticException();
                }
                num += expr[i];
                ++i;
            } while (i < expr.Length &&
                     (Char.IsDigit(expr[i]) || expr[i] == '.'));

            if (!Double.TryParse(num, out currentOperand))
            {
                throw new ArithmeticException();
            }
            res = DoOperation(res, currentOperand, Operator);
        }

        static double DoOperation(double Operand1, double Operand2, char Operator)
        {
            if (Operator == '+')
            {
                return Operand1 + Operand2;
            }
            else if (Operator == '-')
            {
                return Operand1 - Operand2;
            }
            else if (Operator == '*' || Operator == 'x')
            {
                return Operand1 * Operand2;
            }
            else if (Operator == '\\' || Operator == '/')
            {
                if (Operand2 == 0)
                {
                    throw new DivideByZeroException();
                }
                return Operand1 / Operand2;
            }
            else if (Operator == '%')
            {
                return Operand1 % Operand2;
            }
            else if (Operator == '&')
            {
                if (Operand1 <= 0 || Operand2 <= 0)
                {
                    throw new ArgumentException();
                }
                return (int)Operand1 & (int)Operand2;
            }
            else if (Operator == '|')
            {
                if (Operand1 <= 0 || Operand2 <= 0)
                {
                    throw new ArgumentException();
                }
                return (int)Operand1 | (int)Operand2;
            }
            else if (Operator == '^')
            {
                if (Operand1 <= 0 || Operand2 <= 0)
                {
                    throw new ArgumentException();
                }
                return (int)Operand1 ^ (int)Operand2;
            }
            else if (Operator == '!')
            {
                if (Operand2 <= 0)
                {
                    throw new ArgumentException();
                }
                return ~(int)Operand2;
            }
            else if (Operator == 'p')
            {
                return Math.Pow(Operand1, Operand2);
            }
            else
            {
                throw new Exception();
            }
        }

        static Int64 Factorial(int n)
        {
            checked
            {
                Int64 result = 1;
                for (int i = 2; i <= n; ++i) result *= i;
                return result;
            }

        }
    }
}
