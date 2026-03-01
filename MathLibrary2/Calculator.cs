using System;

namespace MathLibrary
{
    public interface ICalculator
    {
        double Add(double a, double b);
        double Subtract(double a, double b);
        double Multiply(double a, double b);
        double Divide(double a, double b);
        bool IsPrime(int number);
        double Power(double number, double power);
        double Factorial(int n);
        bool SolveQuadratic(double a, double b, double c, out double? x1, out double? x2);
    }

    public class Calculator : ICalculator
    {
        private const double Epsilon = 1e-12; 

        #region Основные операции
        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;

        public double Divide(double a, double b)
        {
            ValidateDivisor(b);
            return a / b;
        }
        #endregion

        #region Проверка простоты числа
        public bool IsPrime(int number)
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
        #endregion

        #region Возведение в степень и факториал
        public double Power(double number, double power) => Math.Pow(number, power);

        public double Factorial(int n)
        {
            ValidateFactorialInput(n);
            double result = 1;
            for (int i = 2; i <= n; i++)
                result *= i;
            return result;
        }
        #endregion

        #region Решение квадратного уравнения
        public bool SolveQuadratic(double a, double b, double c, out double? x1, out double? x2)
        {
            x1 = x2 = null;

            if (Math.Abs(a) < Epsilon)
                return SolveLinear(b, c, out x1);

            double discriminant = b * b - 4 * a * c;

            if (discriminant < -Epsilon)
                return false;

            if (Math.Abs(discriminant) < Epsilon) 
            {
                x1 = -b / (2 * a);
                return true;
            }

            double sqrtD = Math.Sqrt(discriminant);
            x1 = (-b + sqrtD) / (2 * a);
            x2 = (-b - sqrtD) / (2 * a);
            return true;
        }

        private bool SolveLinear(double b, double c, out double? root)
        {
            root = null;
            if (Math.Abs(b) < Epsilon)
                return Math.Abs(c) < Epsilon; 
            root = -c / b;
            return true;
        }
        #endregion

        #region Валидация
        private void ValidateDivisor(double divisor)
        {
            if (Math.Abs(divisor) < Epsilon)
                throw new DivideByZeroException("Делитель не может быть равен нулю.");
        }

        private void ValidateFactorialInput(int n)
        {
            if (n < 0)
                throw new ArgumentException("Факториал определён только для неотрицательных чисел.");
        }
        #endregion
    }
}