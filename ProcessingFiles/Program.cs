using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ProcessingFiles
{
    internal static class Program
    {
        private const string ResultFileName = "result.txt";

        private static readonly Random Random = new Random();
        private static readonly Mutex Mutex = new Mutex(false);

        private static void Main()
        {
            var count = ReadInt("Введите количество файлов: ");

            if (File.Exists(ResultFileName))
                File.Delete(ResultFileName);

            for (var i = 0; i < count; i++)
                CreateDataFile(i);

            var tasks = new Task[count];
            for (var i = 0; i < count; i++)
            {
                var i1 = i;
                tasks[i] = Task.Run(() => ProcessDataFile(i1));
            }

            Task.WaitAll(tasks);

            for (var i = 0; i < count; i++)
                File.Delete(GetFileName(i));

            Console.WriteLine();
            Console.WriteLine("Нажмите любую клавишу для выхода...");
            _ = Console.ReadKey();
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

        private static string GetFileName(int index) => $"{index:D6}.txt";

        private static void CreateDataFile(int index) => File.WriteAllText(GetFileName(index),
            $"{Random.Next(1, 3)};{Random.NextDouble() + double.Epsilon};{Random.NextDouble() + double.Epsilon}");

        private static string GetResultString(int operation, double value1, double value2) =>
            operation == 1 ? $"{value1} * {value2} = {value1 * value2}" :
            operation == 2 ? $"{value1} / {value2} = {value1 / value2}" : "Invalid operation";

        private static void ProcessDataFile(int index)
        {
            var text = File.ReadAllText(GetFileName(index));

            var parts = text.Split(';');

            var operation = int.Parse(parts[0]);
            var value1 = double.Parse(parts[1]);
            var value2 = double.Parse(parts[2]);

            var resultString = GetResultString(operation, value1, value2);

            Mutex.WaitOne();

            using (var sw = File.AppendText(ResultFileName))
                sw.WriteLine(resultString);

            Mutex.ReleaseMutex();
        }
    }
}
