using System;
using System.Threading;
using System.Threading.Tasks;

namespace dz12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(CountNumbers); // task1
            Thread thread2 = new Thread(CountNumbers);
            Thread thread3 = new Thread(CountNumbers);
            thread1.Start("поток 1");
            thread2.Start("поток 2");
            thread3.Start("поток 3");

            Console.Write("введите число: "); //task2
            int number = int.Parse(Console.ReadLine());
            int squareResult = Square(number);
            Console.WriteLine($"квадрат числа {number}: {squareResult}");
            CalculateFactorialAsync(number);
            Console.WriteLine("основной поток не блокируется и продолжает работу...");
            Thread.Sleep(8000);
            Console.WriteLine("основной поток завершается.");
        }

        static void CountNumbers(object threadName)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{threadName}: {i}");
                Thread.Sleep(100); //это для того, чтобы просматривалось, потому что без этой штуки консоль просто закрывалась
            }
        }
        static int Square(int x)
        {
            return x * x;
        }

        static async Task CalculateFactorialAsync(int n)
        {
            Console.WriteLine($"начало вычисления факториала для числа {n}...");

            // задержка потока на 8 секунд для имитации долгого вычисления
            await Task.Delay(8000);

            long factorialResult = CalculateFactorial(n);
            Console.WriteLine($"факториал числа {n}: {factorialResult}");
        }

        static long CalculateFactorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;
            else
                return n * CalculateFactorial(n - 1);
        }
    }
}
