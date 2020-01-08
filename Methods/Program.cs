using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Methods
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            ArrayManipulator(numbers);
        }

        //01 Smallest of Tree Numbers
        public static int SmallestNumber(int first, int second, int third)
        {
            var result = 0;

            if (first < second && first < third)
            {
                result = first;
            }
            else if (second < first && second < third)
            {
                result = second;
            }
            else
            {
                result = third;
            }

            return result;
        }

        //02.Vowels Count
        public static int VowelsCount(string input)
        {
            var vowelsLetters = new List<char>() { 'a', 'o', 'u', 'e', 'i', 'A', 'O', 'U', 'E', 'I' };
            var count = 0;

            foreach (var item in input)
            {
                if (vowelsLetters.Contains(item))
                {
                    count++;
                }
            }

            return count;
        }

        //03. Characters in Range
        public static string CharaktersRange(char start, char end)
        {
            var chars = new List<char>();

            if (start > end)
            {
                for (int i = end + 1; i < start; i++)
                {
                    chars.Add((char)(i));
                }
            }
            else
            {
                for (int i = start + 1; i < end; i++)
                {
                    chars.Add((char)(i));
                }
            }


            string final = new string(String.Join(' ', chars));

            return final;
        }

        //04.Password Validator
        public static void PasswordValidator(string password)
        {
            bool isBetween6and10 = CheckLengthOfPassword(password);
            if (isBetween6and10 == false)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            bool containsOnlyDigitsAndLetters = ContainsOnlyDigitsAndLetters(password);
            if (containsOnlyDigitsAndLetters == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            bool containsMinimum2Digits = CheckMinDigit(password);
            if (containsMinimum2Digits == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isBetween6and10 && containsOnlyDigitsAndLetters && containsMinimum2Digits)
            {
                Console.WriteLine("Password is valid");
            }
        }
        private static bool CheckMinDigit(string password)
        {
            int count = 0;

            for (int i = 0; i < password.Length; i++)
            {
                char symbol = password[i];
                if (char.IsDigit(symbol))
                {
                    count++;
                }

            }

            return count >= 2 ? true : false;
        }
        private static bool ContainsOnlyDigitsAndLetters(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                char symbol = password[i];
                if (!char.IsDigit(symbol) && !char.IsLetter(symbol))
                {
                    return false;
                }
            }
            return true;
        }
        private static bool CheckLengthOfPassword(string password)
        {
            return password.Length >= 6 && password.Length <= 10 ? true : false;
        }

        //05.Add and Subtract
        public static int SumAndSubstract(int number1, int number2, int number3)
        {
            int sum = number1 + number2;

            return sum - number3;
        }

        //06.Middle Characters
        public static void MiddleCharacter(string input)
        {
            int place = 0;
            int second = 0;

            List<char> symbols = new List<char>(input);

            if (input.Length % 2 == 0)
            {
                place = input.Length / 2 - 1;
                second = input.Length / 2;

                Console.WriteLine($"{symbols[place]}{symbols[second]}");
            }
            else
            {
                place = input.Length / 2;

                Console.WriteLine($"{symbols[place]}");
            }

        }

        //07.NxN Matrix
        public static void NxNMatrix(int input)
        {
            int[,] matrix = new int[input, input];

            for (int i = 0; i < input; i++)
            {
                for (int j = 0; j < input; j++)
                {
                    matrix[i, j] = (char)input;
                }
            }

            for (int i = 0; i < input; i++)
            {
                for (int j = 0; j < input; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

        }

        //08.Factorial Division
        public static void FactorialDivision(int first, int second)
        {
            long firstSum = 1;
            long secondSum = 1;
            double divide = 0;

            for (int i = first; i > 0; i--)
            {
                firstSum *= i;
            }

            for (int i = second; i > 0; i--)
            {
                secondSum *= i;
            }

            divide = (double)firstSum / (double)secondSum;

            Console.WriteLine($"{divide:F2}");
        }

        //09.Palindrome Integers
        public static void PalindromeIntegfer()
        {
            string input = Console.ReadLine();

            while (input != "END")
            {

                string result = "";
                var inputArray = input.ToCharArray().ToList();

                var inputArrayReverse = input.ToCharArray().ToList();
                inputArrayReverse.Reverse();

                for (int i = 0; i < input.Length; i++)
                {

                    if (inputArray[i] == inputArrayReverse[i])
                    {
                        result = "true";
                    }
                    else
                    {
                        result = "false";
                    }

                }
                Console.WriteLine(result);

                input = Console.ReadLine();
            }
        }

        //10.Top Number
        public static void TopNumber(int range)
        {
            for (int i = 8; i < range; i++)
            {
                int num = i;

                bool isDivisbleby8 = CheckIsDivisableBy8(i);

                bool containsOddNumber = ContainsOddNumber(i);

                if (isDivisbleby8 && containsOddNumber)
                {
                    Console.WriteLine(i);
                }
            }

            for (int i = 8; i < range; i++)
            {
                var digit = i;
                var sum = 0;
            }
        }
        private static bool ContainsOddNumber(int number)
        {

            while (number != 0)
            {
                int digit = number % 10;
                number /= 10;

                if (digit % 2 == 1)
                {
                    return true;
                }

            }
            return false;
        }
        private static bool CheckIsDivisableBy8(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                int digit = number % 10;
                number /= 10;

                sum += digit;
            }

            if (sum % 8 == 0)
            {
                return true;
            }
            return false;
        }

        //11.Array Manipulator
        public static void ArrayManipulator(int[] numbers)
        {
            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] tokens = line.Split();

                string command = tokens[0];

                if (command == "exchange")
                {
                    int index = int.Parse(tokens[1]);

                    if (index > numbers.Length - 1 || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    Exchange(numbers, index);
                }

                else if (command == "max")
                {
                    string typeNumber = tokens[1];
                    int index = -1;
                    if (typeNumber == "odd")
                    {
                        index = GetMaxEvenOrOddIndex(numbers, 1);
                    }
                    else
                    {
                        index = GetMaxEvenOrOddIndex(numbers, 0);
                    }
                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                        continue;
                    }
                    Console.WriteLine(index);
                }
                else if (command == "min")
                {
                    string typeNumber = tokens[1];
                    int index = -1;

                    if (typeNumber == "odd")
                    {
                        index = GetMinEvenOrOddIndex(numbers, 1);
                    }
                    else
                    {
                        index = GetMinEvenOrOddIndex(numbers, 0);
                    }
                    if (index == -1)
                    {
                        Console.WriteLine("No matches");
                        continue;
                    }
                    Console.WriteLine(index);

                }
                else if (command == "first")
                {
                    int count = int.Parse(tokens[1]);
                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    string typeNumber = tokens[2];

                    int[] result = new int[0];

                    if (typeNumber == "odd")
                    {
                        result = GetFirstCountEvenOrOddNumbers(numbers, count, 1);
                    }
                    else
                    {
                        result = GetFirstCountEvenOrOddNumbers(numbers, count, 0);
                    }

                    Console.WriteLine("[" + string.Join(", ", result) + "]");
                }

                else if (command == "last")
                {
                    int count = int.Parse(tokens[1]);
                    if (count > numbers.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    string typeNumber = tokens[2];

                    int[] result = new int[0];

                    if (typeNumber == "odd")
                    {
                        result = GetLastCountEvenOrOddNumbers(numbers, count, 1);
                    }
                    else
                    {
                        result = GetLastCountEvenOrOddNumbers(numbers, count, 0);
                    }

                    Console.WriteLine("[" + string.Join(", ", result) + "]");
                }
            }
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static int[] GetLastCountEvenOrOddNumbers(int[] array, int count, int divisionResul)
        {
            int[] arrResult = new int[count];
            int currentCount = 0;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 == divisionResul && currentCount < count)
                {
                    arrResult[currentCount] = array[i];
                    currentCount++;
                }
            }
            // currentCount > count 
            if (currentCount >= count)
            {
                return arrResult.Reverse().ToArray();
            }
            else
            {
                int[] temp = new int[currentCount];
                Array.Copy(arrResult, temp, currentCount);
                return temp.Reverse().ToArray();
            }
        }

        private static int[] GetFirstCountEvenOrOddNumbers(int[] array, int count, int divisionResul)
        {
            int[] arrResult = new int[count];
            int currentCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == divisionResul && currentCount < count)
                {
                    arrResult[currentCount] = array[i];
                    currentCount++;
                }
            }
            // currentCount > count 
            if (currentCount >= count)
            {
                return arrResult;
            }
            else
            {
                int[] temp = new int[currentCount];
                Array.Copy(arrResult, temp, currentCount);
                return temp;
            }
        }

        private static int GetMinEvenOrOddIndex(int[] array, int divisionResul)
        {
            int minNumber = int.MaxValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] <= minNumber && array[i] % 2 == divisionResul)
                {
                    minNumber = array[i];
                    index = i;
                }
            }

            return index;
        }

        private static int GetMaxEvenOrOddIndex(int[] array, int divisionResul)
        {
            int maxNumber = int.MinValue;
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= maxNumber && array[i] % 2 == divisionResul)
                {
                    maxNumber = array[i];
                    index = i;
                }
            }

            return index;
        }
        private static void Exchange(int[] array, int index)
        {
            for (int i = 0; i < index + 1; i++)
            {
                int firstNumber = array[0];

                for (int j = 0; j < array.Length - 1; j++)
                {
                    array[j] = array[j + 1];
                }

                array[array.Length - 1] = firstNumber;
            }
        }
    }
}
