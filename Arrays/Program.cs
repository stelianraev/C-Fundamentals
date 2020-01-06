using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arrays
{
    public class Program
    {
        public static void Main()
        {
            LadyBugs();
        }

        //01.Train
        public static void Train()
        {
            int wagonCaunt = int.Parse(Console.ReadLine());

            int[] wagons = new int[wagonCaunt];

            for (int i = 0; i < wagonCaunt; i++)
            {
                var wagonNumber = int.Parse(Console.ReadLine());

                wagons[i] = wagonNumber;
            }

            int sum = wagons.Sum();

            Console.Write(String.Join(' ', wagons));
            Console.WriteLine();
            Console.WriteLine(sum);

        }

        //02.Common Elements
        public static void CommonElements()
        {
            string[] input1 = Console.ReadLine().Split(" ").ToArray();

            string[] input2 = Console.ReadLine().Split(" ").ToArray();

            List<string> result = new List<string>();

            foreach (var item2 in input2)
            {

                foreach (var item1 in input1)
                {
                    if (item1 == item2)
                    {
                        result.Add(item1);
                    }
                }
            }

            Console.WriteLine(String.Join(' ', result));
        }

        //03.Zig-Zag Arrays
        public static void ZigZag()
        {
            int inputCount = int.Parse(Console.ReadLine());

            int[] numbers1 = new int[inputCount];
            int[] numbers2 = new int[inputCount];

            for (int i = 0; i < inputCount; i++)
            {
                var inputNumbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

                if (i % 2 == 0)
                {
                    numbers1[i] = inputNumbers[1];
                    numbers2[i] = inputNumbers[0];
                }
                else
                {
                    numbers1[i] = inputNumbers[0];
                    numbers2[i] = inputNumbers[1]; ;

                }
            }

            Console.WriteLine(String.Join(' ', numbers2));
            Console.WriteLine(String.Join(' ', numbers1));
        }

        //04.Array Rotation
        public static void ArrayRotation()
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            var rotationCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotationCount; i++)
            {
                var number = numbers[0];

                numbers.Remove(number);

                numbers.Add(number);
            }

            Console.WriteLine(String.Join(' ', numbers));
        }

        //05.Top Integers
        public static void TopIntegers()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var topInteger = new List<int>();

            for (int firstNumber = 0; firstNumber < numbers.Count - 1; firstNumber++)
            {
                var number1 = numbers[firstNumber];

                for (int restNumbers = firstNumber + 1; restNumbers < numbers.Count; restNumbers++)
                {
                    var number2 = numbers[restNumbers];

                    if (number1 <= number2)
                    {
                        topInteger.Remove(number1);
                        break;
                    }

                    if (topInteger.Contains(number1))
                    {
                        continue;
                    }
                    else
                    {
                        topInteger.Add(number1);
                    }

                }
            }

            topInteger.Add(numbers.Last());

            Console.WriteLine(String.Join(' ', topInteger));
        }

        //06.Equal Sums
        public static void EqualSum()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int leftSum = 0;
            int rightSum = 0;


            for (int i = 0; i < numbers.Count; i++)
            {
                rightSum += numbers[i];
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                rightSum -= numbers[i];

                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    return;
                }

                leftSum += numbers[i];
            }

            Console.WriteLine("no");
        }

        //07.Max Sequence of Equal Elements
        public static void MaxSequence()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var longestSeq = new List<int>();
            var start = 0;
            var count = 0;
            var max = 0;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    count++;
                    if (count > max)
                    {
                        start = i - count;
                        max = count;
                    }
                }
                else
                {
                    count = 0;
                }
            }

            for (int i = start + 1; i <= start + max + 1; i++)
            {
                longestSeq.Add(numbers[i]);
            }

            Console.WriteLine(String.Join(' ', longestSeq));
        }

        //08.Magic Sum
        public static void MagicSum()
        {
            var numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            int sum = int.Parse(Console.ReadLine());



            for (int i = 0; i < numbers.Count; i++)
            {
                var firstNum = numbers[i];

                for (int j = i + 1; j < numbers.Count; j++)
                {
                    var secondNum = numbers[j];

                    if (firstNum + secondNum == sum)
                    {
                        Console.Write($"{firstNum} {secondNum}\n");
                    }
                }
            }
        }

        //09.*Kamino Factory
        public static void KaminoFactory()
        {
            var dnaCount = Console.ReadLine();
            string[] bestDna = null;
            int bestLen = -1;
            int startIndex = -1;
            int bestDnaSum = 0;
            int bestSampleIndex = 0;

            int currentSampleIndex = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Clone them!")
                {
                    break;
                }

                string[] currentDna = input.Split('!', StringSplitOptions.RemoveEmptyEntries);
                int currentLen = 0;
                int currentBestLen = 0;
                int currentEndIndex = 0;

                for (int a = 0; a < currentDna.Length; a++)
                {
                    if (currentDna[a] == "1")
                    {
                        currentLen++;
                        if (currentLen > currentBestLen)
                        {
                            currentEndIndex = a;
                            currentBestLen = currentLen;
                        }
                    }
                    else
                    {
                        currentLen = 0;
                    }
                }

                int currentStartIndex = currentEndIndex - currentBestLen + 1;

                bool isCurrentDnaBetter = false;
                int currentDnaSum = currentDna.Select(int.Parse).Sum();

                if (currentBestLen > bestLen)
                {
                    isCurrentDnaBetter = true;
                }
                else if (currentBestLen == bestLen)
                {
                    if (currentStartIndex < startIndex)
                    {
                        isCurrentDnaBetter = true;
                    }
                    else if (currentStartIndex == startIndex)
                    {
                        if (currentDnaSum > bestDnaSum)
                        {
                            isCurrentDnaBetter = true;
                        }
                    }
                }

                currentSampleIndex++;

                if (isCurrentDnaBetter)
                {
                    bestDna = currentDna;
                    bestLen = currentBestLen;
                    startIndex = currentStartIndex;
                    bestDnaSum = currentDnaSum;
                    bestSampleIndex = currentSampleIndex;
                }
            }

            Console.WriteLine($"Best DNA sample {bestSampleIndex} with sum: {bestDnaSum}.");
            Console.WriteLine(string.Join(' ', bestDna));
        }

        //10.Lady Bugs
        public static void LadyBugs()
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] indexesWithBugs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] field = new int[fieldSize];
            for (int i = 0; i < fieldSize; i++)
            {
                if (indexesWithBugs.Contains(i))
                {
                    field[i] = 1;
                }
                else
                {
                    field[i] = 0;
                }
            }

            string[] command = Console.ReadLine().Split(' ').ToArray();
            while (command[0] != "end")
            {
                int index = int.Parse(command[0]);
                int moving = int.Parse(command[2]);
                if (index < 0 || index >= field.Length)
                {
                    command = Console.ReadLine().Split();
                    continue;
                }
                else if (field[index] == 0)
                {
                    command = Console.ReadLine().Split();
                    continue;
                }
                else if (field[index] == 1)
                {
                    if (command[1] == "right")
                    {
                        index = int.Parse(command[0]);
                        moving = int.Parse(command[2]);

                        if (moving > 0)
                        {
                            MoveRight(field, index, moving);
                        }
                        else if (moving < 0)
                        {
                            MoveLeft(field, index, Math.Abs(moving));
                        }
                    }
                    else if (command[1] == "left")
                    {
                        if (moving > 0)
                        {
                            MoveLeft(field, index, moving);
                        }
                        else if (moving < 0)
                        {
                            MoveRight(field, index, Math.Abs(moving));
                        }
                    }

                    command = Console.ReadLine().Split(' ').ToArray();
                }
            }

            Console.WriteLine(string.Join(" ", field));
        }
        static void MoveRight(int[] field, int index, int moving)
        {

            if (index + moving >= field.Length)
            {
                field[index] = 0;
            }
            else
            {
                field[index] = 0;
                for (int i = index + moving; i < field.Length; i += moving)
                {
                    if (field[i] == 1)
                    {
                        continue;
                    }

                    else
                    {
                        field[i] = 1;
                        break;
                    }
                }
            }
            return;
        }
        static void MoveLeft(int[] field, int index, int moving)
        {

            if (index - moving < 0)
            {
                field[index] = 0;
            }
            else
            {
                field[index] = 0;

                for (int i = index - moving; i > -1; i -= moving)
                {

                    if (field[i] == 1)
                    {
                        continue;
                    }
                    else
                    {
                        field[i] = 1;
                        break;
                    }
                }
            }
            return;
        }
    }
}