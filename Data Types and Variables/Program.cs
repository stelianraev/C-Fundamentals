using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Data_Types_and_Variables
{
    public class Program
    {
        public static void Main()
        {       

        }

        //01.Integer Operations
        public static int OntegerOperations(int number1, int number2, int number3, int number4)
        {
            var result = ((number1 + number2) / number3) * number4;

            return result;

        }

        //02.Sum Digits
        public static int SumDigits(int input)
        {
            int sum = 0;
            while (input != 0)
            {
                var number = input % 10;
                input /= 10;

                sum += number;
            }

            return sum;
        }

        //03.Elevator
        public static int Elevator(int people, int capacity)
        {
            int courses = (int)Math.Ceiling((double)people / capacity);

            return courses;
        }

        //04.Sum of Chars
        public static int SumOfChars(int n)
        {
            int sum = 0;

            var chars = new char[n];

            for (int i = 0; i < n; i++)
            {
                char ch = char.Parse(Console.ReadLine());

                chars[i] = ch;
            }

            for (int i = 0; i < chars.Length; i++)
            {
                sum += chars[i];
            }

            return sum;
        }

        //05.Print Part of the ASCII Table
        public static void PrintPart()
        {
            int start = int.Parse(Console.ReadLine());

            int end = int.Parse(Console.ReadLine());

            List<char> chars = new List<char>();

            for (int i = start; i <= end; i++)
            {
                chars.Add((char)i);
            }

            Console.WriteLine(String.Join(' ', chars));
        }

        //06.Triples of Latin Letters
        public static void TriplesLetters()
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                var first = (char)('a' + i);

                for (int j = 0; j < input; j++)
                {
                    var second = (char)('a' + j);

                    for (int k = 0; k < input; k++)
                    {
                        var third = (char)('a' + k);
                        Console.Write($"{first}{second}{third}");
                        Console.WriteLine();
                    }
                }
            }
        }

        //07. Water Overflow
        public static void WaterOverFlow()
        {
            int inputNumber = int.Parse(Console.ReadLine());

            int tankCapacity = 255;

            int sum = 0;

            for (int i = 0; i < inputNumber; i++)
            {
                int quantitie = int.Parse(Console.ReadLine());

                sum += quantitie;

                if (sum > tankCapacity)
                {
                    sum -= quantitie;
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(sum);
        }

        //08.Beer Kegs
        public static void BeerKegs()
        {
            int kegCount = int.Parse(Console.ReadLine());

            Dictionary<string, double> kegs = new Dictionary<string, double>();

            for (int i = 0; i < kegCount; i++)
            {
                string model = Console.ReadLine();

                double radius = double.Parse(Console.ReadLine());

                int height = int.Parse(Console.ReadLine());

                double calc = 2.14 * (radius * radius) * height;

                kegs.Add(model, calc);
            }

            var resul = kegs.OrderByDescending(x => x.Value).FirstOrDefault().Key;

            Console.WriteLine(resul);
        }

        //09.*Spice Must Flow 
        public static void SpiceFlow()
        {
            int spiceExtracted = int.Parse(Console.ReadLine());

            int days = 0;

            int drops = 10;

            int workersConsuming = 26;

            int sum = 0;

            while (spiceExtracted >= 100)
            {
                sum += spiceExtracted;

                sum -= workersConsuming;

                spiceExtracted -= drops;

                days++;
            }
            if (spiceExtracted >= workersConsuming)
            {
                sum -= workersConsuming;
            }
            if (sum < 0)
            {
                sum = 0;
            }

            Console.WriteLine(days);
            Console.WriteLine(sum);
        }

        //10.*Poke Mon
        public static void PokeMon()
        {
            //N
            int pokePower = int.Parse(Console.ReadLine());

            //M
            int distance = int.Parse(Console.ReadLine());

            //Y
            int exhoustionFactor = int.Parse(Console.ReadLine());

            int pokes = 0;

            double test = (double)pokePower / (double)2;

            if (pokePower <= 0 || distance <= 0)
            {
                pokePower = 0;
                distance = 0;
            }
            else
            {
                while (pokePower >= distance)
                {
                    pokePower -= distance;

                    if (test == distance)
                    {
                        if(exhoustionFactor > 0)
                        {
                        pokePower /= exhoustionFactor;
                        }
                    }

                    pokes++;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(pokes);
        }

        //11.*Snowballs
        public static void Snowballs()
        {
            int snowballCount = int.Parse(Console.ReadLine());

            BigInteger snowBallValue = default;

            int snow = default;
            int time = default;
            int quality = default;

            for (int i = 0; i < snowballCount; i++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());

                BigInteger snowbalValueCurrent = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality);
                
                if(snowbalValueCurrent > snowBallValue)
                {
                    snowBallValue = snowbalValueCurrent;

                    snow = snowballSnow;
                    time = snowballTime;
                    quality = snowballQuality;
                }
            }

            Console.WriteLine($"{snow} : {time} = {snowBallValue} ({quality})");
        }
    }
}
