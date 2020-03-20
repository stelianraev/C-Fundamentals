using System;
using System.Linq;

namespace ConsoleApp2
{
   public class Program
    {
       public static void Main(string[] args)
        {
            
        }

        // 01. Valid Username
        public static void ValidUsername()
        {
            var input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => IsLegit(x))
                .ToList();

            foreach (var name in input)
            {
                Console.WriteLine(name);
            }

        }
        public static bool IsLegit(string username)
        {
            bool isCheck = true;
            if (username.Length < 3 || username.Length > 16)
            {
                isCheck = false;

            }


            for (int i = 0; i < username.Length; i++)
            {
                char element = username[i];
                if (!(Char.IsLetterOrDigit(element) || element == '-' || element == '_'))
                {
                    isCheck = false;
                }
            }

            return isCheck;
        }

        // 02. Character Multiplier
        static void CharacterMultiplier()
        {
            string[] input = Console.ReadLine().Split(" ");

            var minLenght = Math.Min(input[0].Length, input[1].Length);
            var maxLength = Math.Max(input[0].Length, input[1].Length);
            var total = 0;

            for (int i = 0; i < minLenght; i++)
            {
                total += input[0][i] * input[1][i];
            }

            if (minLenght != maxLength)
            {
                string longer = input[0].Length > input[1].Length ? input[0] : input[1];

                for (int i = minLenght; i < maxLength; i++)
                {
                    total += longer[i];
                }
            }

            Console.WriteLine(total);
        }

        // 03. Extract File
        static void ExtractFile()
        {
            var input = Console.ReadLine().Split("\\", StringSplitOptions.RemoveEmptyEntries)
                .ToArray()
                .Last()
                .Split(".", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var file = input.Take(input.Length - 1);
            var totalFile = String.Join(".", file);
            var ext = input.Last();

            Console.WriteLine($"File name: {totalFile}");
            Console.WriteLine($"File extension: {ext}");
        }

        // 04. Caesar Cipher
        static void CaesarCipher()
        {
            string input = Console.ReadLine();

            string chipher = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];
                letter += (char)3;
                chipher += letter;
            }

            Console.WriteLine(chipher);
        }

        // 05. Multiply Big Number
        public static void MultiplyBigNumber()
        {
            var firstNum = Console.ReadLine().ToCharArray();
            int secondNum = int.Parse(Console.ReadLine());

            if (secondNum == 0)
            {
                Console.WriteLine(0);
                return;
            }

            int remainder = 0;
            int total;

            var result = new List<int>();

            for (int i = firstNum.Length - 1; i >= 0; i--)
            {
                int num = int.Parse(firstNum[i].ToString());
                total = (num * secondNum);
                total += remainder;
                result.Insert(0, total % 10);
                remainder = total / 10;
            }

            if (remainder > 0)
            {
                result.Insert(0, remainder);
            }


            Console.WriteLine(String.Join("", result).TrimStart('0'));
        }

        // 06. Replace Repeating Chars
        public static void ReplaceRepeatingChars()
        {
            var input = Console.ReadLine().ToCharArray().ToList();

            for (int i = 0; i < input.Count - 1; i++)
            {
                char first = input[i];
                char second = input[i + 1];

                if (first == second)
                {
                    input.RemoveAt(i + 1);
                    i = -1;
                }
            }

            Console.WriteLine(String.Join("", input));
        }

        // 07. String Explosion
        static void StringExplosion()
        {
            string field = Console.ReadLine();
            int bomb = 0;
            for (int i = 0; i < field.Length; i++)
            {
                if (bomb > 0 && field[i] != '>')
                {
                    field = field.Remove(i, 1); // Remove char on this index
                    bomb--; // One bomb is used
                    i--; // after remove next char is moved 1 position, so return counter i to this char, decreasing i by 1  
                }
                else if (field[i] == '>')
                {
                    bomb += int.Parse(field[i + 1].ToString()); // takes the digit after '>' - bomb strength and add to bomb
                }
            }
            Console.WriteLine(field);
        }
    }
}

