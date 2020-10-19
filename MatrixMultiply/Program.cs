using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace MatrixMultiply
{
    internal static class Program
    {
        private const int Rows = 10;
        private const int Columns = 10;

        private static void Main()
        {
            Console.WriteLine("Матрицы будут выводиться на экран только для размерности <= 10");
            var dimensions = ReadInt("Введите размерность квадратной матрицы (одно число): ");

            Console.WriteLine();

            var m1 = new Matrix(dimensions, dimensions, true);
            var m2 = new Matrix(dimensions, dimensions, true);

            var multiplyers = new Func<Matrix, Matrix, Matrix>[]
            {
                Matrix.MultiplySequental,
                Matrix.MultiplyParallel
            };

            foreach (var multiplyer in multiplyers)
                TestMul(m1, m2, multiplyer);


            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            _ = Console.ReadKey();
        }

        private static void TestMul(Matrix m1, Matrix m2, Func<Matrix, Matrix, Matrix> multiplyer)
        {
            Console.Write($"{multiplyer.Method.GetCustomAttribute<DescriptionAttribute>().Description,-40}");

            var stopwatch = Stopwatch.StartNew();
            var m = m1 * m2;
            var elapsed = stopwatch.Elapsed;

            Console.WriteLine($"{elapsed.TotalSeconds:F9} с");
        }

        private static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;

                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неверный формат числа. Попробуйте еще раз.");
                Console.ForegroundColor = color;
            }
        }
    }
}
