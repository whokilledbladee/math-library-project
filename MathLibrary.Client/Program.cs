using System;
using MathLibrary; // подключаем пространство имён библиотеки

namespace MathLibrary.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculator calc = new Calculator();

            Console.WriteLine("=== Демонстрация работы MathLibrary.dll (после рефакторинга) ===\n");

            double x = 10, y = 4;
            Console.WriteLine($"Числа: x = {x}, y = {y}");
            Console.WriteLine($"Сложение: {x} + {y} = {calc.Add(x, y)}");
            Console.WriteLine($"Вычитание: {x} - {y} = {calc.Subtract(x, y)}");
            Console.WriteLine($"Умножение: {x} * {y} = {calc.Multiply(x, y)}");

            try
            {
                Console.WriteLine($"Деление: {x} / {y} = {calc.Divide(x, y)}");
                Console.WriteLine($"Попытка деления на ноль: {x} / 0 = {calc.Divide(x, 0)}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Ошибка при делении: {ex.Message}");
            }

            int testNumber = 17;
            Console.WriteLine($"\nЧисло {testNumber} простое? {calc.IsPrime(testNumber)}");
            testNumber = 20;
            Console.WriteLine($"Число {testNumber} простое? {calc.IsPrime(testNumber)}");

            double baseNum = 2, power = 5;
            Console.WriteLine($"\n{baseNum} в степени {power} = {calc.Power(baseNum, power)}");

            int factN = 7;
            try
            {
                Console.WriteLine($"Факториал {factN} = {calc.Factorial(factN)}");
                Console.WriteLine($"Факториал {-3} = {calc.Factorial(-3)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка факториала: {ex.Message}");
            }

            Console.WriteLine("\n--- Решение квадратных уравнений ---");
            SolveAndPrint(calc, 1, -3, 2);
            SolveAndPrint(calc, 1, 2, 1);
            SolveAndPrint(calc, 1, 0, 1);
            SolveAndPrint(calc, 0, 2, -4);
            SolveAndPrint(calc, 0, 0, 5);
            SolveAndPrint(calc, 0, 0, 0);
        }

        static void SolveAndPrint(ICalculator calc, double a, double b, double c)
        {
            bool hasRoots = calc.SolveQuadratic(a, b, c, out double? x1, out double? x2);
            Console.Write($"Уравнение {a}x² + {b}x + {c} = 0: ");
            if (!hasRoots)
                Console.WriteLine("нет действительных корней");
            else if (x1.HasValue && x2.HasValue)
                Console.WriteLine($"два корня: x1 = {x1}, x2 = {x2}");
            else if (x1.HasValue)
                Console.WriteLine($"один корень: x = {x1}");
            else
                Console.WriteLine("бесконечно много корней (тождество)");
        }
    }
}