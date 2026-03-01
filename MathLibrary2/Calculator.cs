using System;

namespace MathLibrary2
{
    public class Calculator
    {
        /// <summary>
        /// Вычисляет факториал неотрицательного целого числа.
        /// </summary>
        /// аааааааааааа
        /// привет
        /// коммент для коммита
        public static double Add(double a, double b) => a + b;
        public static double Subtract(double a, double b) => a - b;
        public static double Multiply(double a, double b) => a * b;

        public static double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Делитель не может быть равен нулю.");
            return a / b;
        }

        //помогите
        public static bool IsPrime(int number)
        {
            if (number < 2) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            int boundary = (int)Math.Sqrt(number);
            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;
            return true;
        }

        public static double Power(double number, double power) => Math.Pow(number, power);

        public static double Factorial(int n)
        {
            if (n < 0)
                throw new ArgumentException("Факториал определён только для неотрицательных чисел.");
            double result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }

        public static bool SolveQuadratic(double a, double b, double c, out double? x1, out double? x2)
        {
            x1 = x2 = null;

            // Линейный случай (a == 0)
            if (a == 0)
            {
                if (b == 0)
                {
                    // 0*x + c = 0
                    return c == 0; // бесконечно много корней, если c == 0, иначе нет корней
                }
                // b != 0: один корень x = -c/b
                x1 = -c / b;
                return true;
            }

            double discriminant = b * b - 4 * a * c;

            if (discriminant < 0)
                return false;

            if (Math.Abs(discriminant) < 1e-12) // дискриминант близок к нулю
            {
                x1 = -b / (2 * a);
                return true;
            }

            double sqrtD = Math.Sqrt(discriminant);
            x1 = (-b + sqrtD) / (2 * a);
            x2 = (-b - sqrtD) / (2 * a);
            return true;
        }
    }
}