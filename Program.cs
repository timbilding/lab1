using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Выберите задание");
                Console.WriteLine("1 - Вычисление факториала.");
                Console.WriteLine("2 - Вычисление функции.");
                Console.WriteLine("3 - Вывод чисел Фибоначчи.");
                Console.WriteLine("4 - Ряд Тейлора.");
                int gig = int.Parse(Console.ReadLine());

                switch (gig)
                {
                    case 1:
                        CalculateFactorial();
                        break;
                    case 2:
                        CalculateFunction();
                        break;
                    case 3:
                        Fibonacci();
                        break;
                    case 4:
                        Taylor(1, 5);
                        break;
                }
            }
        }

        static void CalculateFactorial()
        {
            Console.WriteLine("Введите число, для которого нужно посчитать факториал:");
            string n = Console.ReadLine();

            if (ulong.TryParse(n, out ulong num))
            {
                if (num >= 0)
                {
                    ulong factorial = 1;

                    for (ulong i = 1; i <= num; i++)
                    {
                        factorial *= i;
                    }

                    Console.WriteLine($"Факториал числа {num} равен {factorial}");
                }
                else
                {
                    Console.WriteLine("Факториал определен только для неотрицательных чисел.");
                    CalculateFactorial();
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Введите целое число.");
                CalculateFactorial();
            }
        }

        static void CalculateFunction()
        {
            Console.Write("\nВведите число x для рассчетов: ");
            double x = double.Parse(Console.ReadLine());

            double a;

            if (x <= 0 || x > 4)
            {
                Console.WriteLine("Ошибка! Не определено!");
                CalculateFunction();
            }

            if (x > 0 || x <= 4)
            {
                a = Math.Sqrt(Math.Log(4 / x)) - (1 / x) - Math.Pow(Math.E, Math.Sin(x));
                Console.WriteLine("Полученный результат: " + a);
            }
        }

        static void Fibonacci()
        {

            Console.WriteLine("\nДо какого числа считать ряд Фибоначчи?");
            int n = int.Parse(Console.ReadLine());

            int first = 0;
            Console.Write("{0} ", first);
            int second = 1;
            int sum = first + second;


            while (sum < n)
            {
                Console.Write($"{sum} ");

                sum = first + second;
                first = second;
                second = sum;
            }

            Console.ReadLine();
        }

        public static void Taylor(double x, int precision)
        {
            double sum = 1;
            double term = 1;
            ulong n = 1;

            Console.WriteLine("\nВычисление ряда Маклорена для экспоненты в степени х\n");
            do
            {
                term *= x / Fact(n);
                sum += term;
                Console.WriteLine("Ряд " + n + "\t\t" + sum);
                n++;
            }
            while (Math.Abs(term) >= Math.Pow(10, -precision));

        }
        public static ulong Fact(ulong number)
        {
            while (true)
            {
                ulong n = 0;
                ulong fact = 1;

                if (number < 0)
                {
                    Console.WriteLine("Число отрицательное");
                }
                else
                {
                    while (n < number)
                    {
                        n += 1;
                        fact *= n;
                    }
                }

                return fact;
            }
        }

    }
}