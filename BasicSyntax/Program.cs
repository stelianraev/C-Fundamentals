using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace More_Exercise
{
   public class Program
    {
       public static void Main()
        {
            
        }

        //01.Sort Numbers
        public static void SortNumbers()
        {
            int[] numbers = new int[3];

            for (int i = 0; i < 3; i++)
            {
                int number = int.Parse(Console.ReadLine());

                numbers[i] = number;
            }

            Array.Sort(numbers);

            foreach (var number in numbers.Reverse())
            {
                Console.WriteLine(number);
            }
        }

        //02.English Name of the Last Digit
        public static void EnglishName()
        {
            int input = int.Parse(Console.ReadLine());

            int number = input % 10;

            switch (number)
            {
                case 0:
                    Console.WriteLine("zero");
                    break;
                case 1:
                    Console.WriteLine("one");
                    break;
                case 2:
                    Console.WriteLine("two");
                    break;
                case 3:
                    Console.WriteLine("three");
                    break;
                case 4:
                    Console.WriteLine("four");
                    break;
                case 5:
                    Console.WriteLine("five");
                    break;
                case 6:
                    Console.WriteLine("six");
                    break;
                case 7:
                    Console.WriteLine("seven");
                    break;
                case 8:
                    Console.WriteLine("eight");
                    break;
                case 9:
                    Console.WriteLine("nine");
                    break;
            }

        }

        //03.Gaming Store
        public static void GamingStore()
        {
            decimal currentBalance = decimal.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            decimal price = 0;

            decimal sum = 0;
            
            while (command != "Game Time")
            {
                if(currentBalance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }                

                if (command == "OutFall 4")
                {
                    price = 39.99m;                    
                }
                else if(command == "CS: OG")
                {
                    price = 15.99m;
                }
                else if (command == "Zplinter Zell")
                {
                    price = 19.99m;
                }
                else if (command == "Honored 2")
                {
                    price = 59.99m;
                }
                else if (command == "RoverWatch")
                {
                    price = 29.99m;
                }
                else if (command == "RoverWatch Origins Edition")
                {
                    price = 39.99m;
                }
                else
                {
                    Console.WriteLine("Not Found");
                    command = Console.ReadLine();
                    continue;
                }

                if(price > currentBalance)
                {
                    Console.WriteLine("Too Expensive");
                }
                else
                {
                    sum += price;
                    currentBalance -= price;
                    Console.WriteLine($"Bought {command}");
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${sum:F2}. Remaining: ${currentBalance:F2}");
        }

        //04.Reverse String
        public static void ReverseString()
        {
            string input = Console.ReadLine();

            char[] inputCharArray = input.ToCharArray();

            Array.Reverse(inputCharArray);

            string result = new string(inputCharArray);

            Console.WriteLine(result);

            

        }

        //05.Messages
        public static void Message()
        {
            int clicks = int.Parse(Console.ReadLine());
            string message = string.Empty;

            for (int i = 0; i < clicks; i++)
            {
                string digits = Console.ReadLine();
                int digitLength = digits.Length;
                int digit = digits[0] - '0';    // ASCII hack
                int offset = (digit - 2) * 3;

                if (digit == 0)
                {
                    message += (char)(digit + 32);
                    continue;
                }

                if (digit == 8 || digit == 9)
                {
                    offset++;
                }
                int letterIndex = offset + digitLength - 1;
                message += (char)(letterIndex + 97);
            }

            Console.WriteLine(message);
        }
    }
}
