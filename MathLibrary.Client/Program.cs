using System;
using MathLibrary2;

namespace MathLibrary.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Демонстрация работы MathLibrary ===\n");

            // Арифметика
            double a = 10, b = 5;
            Console.WriteLine($"Сложение: {a} + {b} = {Calculator.Add(a, b)}");
            Console.WriteLine($"Вычитание: {a} - {b} = {Calculator.Subtract(a, b)}");
            Console.WriteLine($"Умножение: {a} * {b} = {Calculator.Multiply(a, b)}");
            try
            {
                Console.WriteLine($"Деление: {a} / {b} = {Calculator.Divide(a, b)}");
                Console.WriteLine($"Деление на ноль: {Calculator.Divide(a, 0)}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            // Проверка простоты
            Console.WriteLine($"\nЧисло 17 простое? {Calculator.IsPrime(17)}");
            Console.WriteLine($"Число 20 простое? {Calculator.IsPrime(20)}");

            // Возведение в степень
            Console.WriteLine($"\n2^10 = {Calculator.Power(2, 10)}");

            // Факториал
            try
            {
                Console.WriteLine($"5! = {Calculator.Factorial(5)}");
                Console.WriteLine($"Факториал отрицательного: {Calculator.Factorial(-3)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            // Квадратное уравнение
            Console.WriteLine("\nРешение квадратных уравнений:");
            SolveAndPrint(1, -3, 2);
            SolveAndPrint(1, 2, 1);
            SolveAndPrint(1, 0, 1);
        }

        static void SolveAndPrint(double a, double b, double c)
        {
            bool hasRoots = Calculator.SolveQuadratic(a, b, c, out double? x1, out double? x2);
            Console.Write($"Уравнение {a}x² + {b}x + {c} = 0: ");
            if (!hasRoots)
                Console.WriteLine("нет действительных корней");
            else if (x1.HasValue && x2.HasValue)
                Console.WriteLine($"два корня: x1 = {x1}, x2 = {x2}");
            else if (x1.HasValue)
                Console.WriteLine($"один корень: x = {x1}");
            else
                Console.WriteLine("бесконечно много корней");
        }
    }
}