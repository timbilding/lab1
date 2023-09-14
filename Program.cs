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
                        Taylor();
                        break;
                }
            }
        }

        static void CalculateFactorial()
        {
            Console.WriteLine("Введите число, для которого нужно посчитать факториал:");
            string n = Console.ReadLine();

            if (int.TryParse(n, out int num))
            {
                if (num >= 0)
                {
                    long factorial = 1;

                    for (long i = 1; i <= num; i++)
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
            int n = Convert.ToInt32(Console.ReadLine());

            int first = 0;
            Console.Write("{0} ", first);
            int second = 1;
            int sum = first + second;
            

            while (sum < n)
            {
                Console.Write("{0} ", sum);
                sum = first + second;
                first = second;
                second = sum;
            }

            Console.ReadLine();
        }

        static void Taylor()
        {
            Console.WriteLine("Подсчитаем точность для cos(x):");

            Console.WriteLine("Введите Х.");
            double x = double.Parse(Console.ReadLine());

            Console.WriteLine("Сколько будет итераций: ");
            int iter = int.Parse(Console.ReadLine());

            // cos(x)=1-x^2/2!+x^4/4!-x^6/6!-...=SUM(-1)^n*(x^2n/(2n)!)

            double TaylorCounting;
            double TaylorSum = 0;

            for (int n = 0; n < iter; n++)
            {
                int factorial = 1; 

                for (int i = 1; i <= n * 2; i++)
                {
                    factorial *= i;
                }

                TaylorCounting = Math.Pow(-1, n) * (Math.Pow(x, 2 * n) / (factorial));
                TaylorSum += TaylorCounting;
                Console.WriteLine($"Член ряда - {TaylorCounting}");
            }

            Console.WriteLine($"Сумма ряда - {TaylorSum}");
        }                
    }
    
}
