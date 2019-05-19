using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleApp7.Delegates;

namespace ConsoleApp7
{
    class Program
    {

        static void Main(string[] args)
        {

            // Task 3
            var circle = new Circle();

            MyDelegate square = circle.GetCircleSquare;
            MyDelegate length = circle.GetCircleLength;
            MyDelegate volume = circle.GetSphereVolume;

            Console.WriteLine($"Square: {square.Invoke(10)}");
            Console.WriteLine($"Length: {length.Invoke(10)}");
            Console.WriteLine($"Volume: {volume.Invoke(10)}");

            //Task 4

            GetGreeting getGreeting = () =>
            {
                if (DateTime.Now.Hour >= 4 && DateTime.Now.Hour <= 12)
                    GoodMorning();

                if (DateTime.Now.Hour >= 13 && DateTime.Now.Hour <= 17)
                    GoodDay();

                if (DateTime.Now.Hour >= 18 && DateTime.Now.Hour <= 21)
                    GoodEvening();

                if (DateTime.Now.Hour >= 22 && DateTime.Now.Hour <= 3)
                    GoodNight();
            };

            getGreeting.Invoke();



        }

        private static void Task5()
        {
            //Task 5
            Console.WriteLine("Enter command code");
            Console.WriteLine("1.Sum");
            Console.WriteLine("2.Minus");
            Console.WriteLine("3.Mult");
            Console.WriteLine("4.Div");

            Console.WriteLine("Enter X");
            var userX = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Y");
            var userY = int.Parse(Console.ReadLine());

            var input = Console.ReadLine();
            var code = int.Parse(input);

            UseOperation useOperation = (x, y) =>
            {
                switch (code)
                {
                    case 0:
                        return Sum(x, y);
                    case 1:
                        return Minus(x, y);
                    case 2:
                        return Mult(x, y);
                    case 3:
                        return Div(x, y);

                }

                throw new NotSupportedException();
            };

            useOperation.Invoke(userX, userY);
        }

        private static int Sum(int x, int y)
        {
            return x + y;
        }

        private static int Minus(int x, int y)
        {
            return x - y;
        }

        private static int Mult(int x, int y)
        {
            return x * y;

        }

        private static int Div(int x, int y)
        {
            return x / y;

        }

        private static void Task4()
        {
            Operation sum = (x, y) => x + y;
            Operation mult = (x, y) => x * y;
            Operation min = (x, y) => x - y;

            var ops = new Dictionary<string, Operation>();
            ops.Add("sum", sum);
            ops.Add("mult", mult);
            ops.Add("min", min);

            Console.WriteLine(ops["sum"].Invoke(10, 10));
        }



        #region Task1

        private static void ShowMatrix(int[,] array)
        {
            var width = array.GetLength(1);
            var height = array.GetLength(0);

            var h = 0;
            while (h < height)
            {
                var w = 0;
                while (w < width)
                {
                    var item = array[h, w];
                    Console.Write($"{item} ");

                    w++;
                }

                Console.WriteLine();
                h++;
            }
        }

        private static void ShowPositive(int[,] array)
        {
            foreach (var item in array)
                if (item >= 0)
                    Console.Write(item + Environment.NewLine);
        }

        // ReSharper disable once IdentifierTypo
        private static void Mult3(int[,] array)
        {
            for (var x = 0; x < array.GetLength(0); x++)
                for (var y = 0; y < array.GetLength(1); y++)
                    if (array[x, y] >= 0)
                        array[x, y] = 3 * array[x, y];
        }

        #endregion

        #region Task2

        private static void ShowFileContent(string filePath)
        {
            var content = File.ReadAllText(filePath);
            Console.WriteLine(content);
        }

        private static void ReplaceTrashContentInFile(string filePath)
        {
            var content = File.ReadAllText(filePath);
            content = content.Replace(".", "").Replace(".", "")
                .Replace("*", "").Replace("(", "").Replace(")", "");
            File.WriteAllText(filePath, content);
        }

        private static void ShowAllNumbers(string filePath)
        {
            var content = File.ReadAllText(filePath);
            var matches = Regex.Matches(content, @"(\d+)*");
            foreach (Match match in matches)
                foreach (Group matchGroup in match.Groups)
                    Console.WriteLine(matchGroup.Value);

        }

        #endregion

        #region Task4

        private static void GoodMorning()
        {
            Console.WriteLine("Good morning");
        }

        private static void GoodDay()
        {
            Console.WriteLine("Good day");
        }

        private static void GoodEvening()
        {
            Console.WriteLine("Good evening");
        }

        private static void GoodNight()
        {
            Console.WriteLine("Good night");
        }

        #endregion

    }


}
