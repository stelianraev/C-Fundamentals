using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArrayMoreExs
{
    public class Program
    {
        public static void Main()
        {

        }

        //01.Encrypt, Sort and Print Array
        public static void EncryptArray()
        {
            int inputCoutn = int.Parse(Console.ReadLine());

            var calcolation = 0;
            var total = 0;
            var result = new List<int>();

            List<char> vowel = new List<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };

            for (int i = 0; i < inputCoutn; i++)
            {
                string text = Console.ReadLine();

                foreach (var letter in text)
                {
                    if (vowel.Contains(letter))
                    {
                        calcolation = letter * text.Length;
                        total += calcolation;
                    }
                    else
                    {
                        calcolation = letter / text.Length;
                        total += calcolation;
                    }
                }
                result.Add(total);
                total = 0;
            }
            result.Sort();

            foreach (var item in result)
            {
                Console.WriteLine($"{item}");
            }
        }

        //02.Pascal Triangle
        public static void PascalTriangle()
        {
            int input = int.Parse(Console.ReadLine());

            Console.WriteLine(1);

            for (int i = 1; i < input; i++)
            {
                int firstNumber = 1;

                for (int j = 0; j <= i; j++)
                {
                    Console.Write(firstNumber + " ");

                    firstNumber = firstNumber * (i - j) / (j + 1);
                }

                Console.WriteLine();
            }

        }

        //03.Recursive Fibonacci
        public static void RecursiveFibonacci()
        {
            int input = int.Parse(Console.ReadLine());

            if (input <= 0)
            {
                Console.WriteLine(0);
                return;
            }

            var numbers = new uint[input];
            uint firstNum = 1;

            numbers[0] = firstNum;
            numbers[1] = firstNum;

            for (int i = 1; i < input - 1; i++)
            {
                numbers[i + 1] = numbers[i - 1] + numbers[i];
            }

            Console.WriteLine(numbers[input - 1]);
        }

        //04.Fold and Sum 
        public static void FoldSum()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var secondNumbers = new List<int>();
            var result = new List<int>();
            var numbersFirstPart = new List<int>();
            var numberSecondPart = new List<int>();
            var count = (numbers.Count / 2) / 2;

            for (int i = 0; i < count * 2; i++)
            {
                secondNumbers.Add(numbers[i + count]);
            }

            foreach (var number in secondNumbers)
            {
                if (numbers.Contains(number))
                {
                    numbers.Remove(number);
                }
            }

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                var localcount = numbers.Count / 2;
                numbersFirstPart.Add(numbers[i]);
                numberSecondPart.Add(numbers[i + localcount]);
            }

            numbersFirstPart.Reverse();
            numberSecondPart.Reverse();

            var finalPart = new List<int>();

            for (int i = 0; i < numbersFirstPart.Count; i++)
            {
                finalPart.Add(numbersFirstPart[i]);
            }
            for (int i = 0; i < numberSecondPart.Count; i++)
            {
                finalPart.Add(numberSecondPart[i]);
            }

            for (int i = 0; i < finalPart.Count; i++)
            {
                result.Add(secondNumbers[i] + finalPart[i]);
            }

            Console.WriteLine(String.Join(' ', result));
        }

        //05.Longest Increasing Subsequence
        public static void LongestSubsequence()
        {

            int[] nums = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();
            int maxLength = 0;
            int lastIndex = -1;
            int[] len = new int[nums.Length];
            int[] prev = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                len[i] = 1;
                prev[i] = -1;

                for (int k = 0; k < i; k++)
                {
                    if (nums[k] < nums[i] && len[k] + 1 > len[i])
                    {
                        len[i] = len[k] + 1;
                        prev[i] = k;
                    }
                }

                if (len[i] > maxLength)
                {
                    maxLength = len[i];
                    lastIndex = i;
                }
            }

            int[] LIS = new int[maxLength];
            int currentIndex = maxLength - 1;

            while (lastIndex != -1)
            {
                LIS[currentIndex] = nums[lastIndex];
                currentIndex--;
                lastIndex = prev[lastIndex];
            }

            Console.WriteLine(string.Join(" ", LIS));
        }
    }
}
