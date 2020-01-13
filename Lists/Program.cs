using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace More_Exs
{
    public class Program
    {
        public static void Main()
        {
            MixedUp();
        }
        //01.Messaging
        public static void Messaging()
        {
            List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var textToArray = Console.ReadLine().ToCharArray();

            var text = new List<char>(textToArray);

            var number = 0;

            int sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                number = numbers[i];

                while (number != 0)
                {
                    int asd = number % 10;
                    sum += asd;
                    number /= 10;
                }

                if (sum > text.Count)
                {
                    sum -= text.Count;
                }

                Console.Write(text[sum]);
                text.RemoveAt(sum);
                sum = 0;
            }
        }

        //02.Car Race
        public static void CarRace()
        {
            var numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var time = numbers.Count / 2;

            var racer1 = new List<int>();
            var racer2 = new List<int>();
            double sumRacer1 = 0;
            double sumRacer2 = 0;

            for (int i = 0; i < time; i++)
            {
                racer1.Add(numbers[i]);
            }

            for (int j = numbers.Count - 1; j >= time + 1; j--)
            {
                racer2.Add(numbers[j]);
            }

            for (int number = 0; number < time; number++)
            {
                sumRacer1 += racer1[number];
                sumRacer2 += racer2[number];

                if (racer1[number] == 0)
                {
                    var percent = sumRacer1 / 10 * 2;
                    sumRacer1 -= percent;
                }

                if (racer2[number] == 0)
                {
                    var percent = sumRacer2 / 10 * 2;
                    sumRacer2 -= percent;
                }
            }

            if (sumRacer1 < sumRacer2)
            {
                Console.WriteLine("The winner is left with total time: {0}", sumRacer1);

            }
            else
            {
                Console.WriteLine("The winner is right with total time: {0}", sumRacer2);
            }

        }

        //03.Take/Skip Rope
        public static void TakeRope()
        {
            string input = Console.ReadLine();
            List<int> numbers = new List<int>();
            List<int> takeList = new List<int>();
            List<int> skipList = new List<int>();
            StringBuilder result = new StringBuilder();
            List<string> nonNumbers = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]))
                {
                    numbers.Add(int.Parse(input[i].ToString()));
                }
                else
                {
                    nonNumbers.Add(input[i].ToString());
                }
            }
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i % 2 == 0)
                {
                    takeList.Add(numbers[i]);
                }
                else
                {
                    skipList.Add(numbers[i]);
                }
            }

            int indexForSkip = 0;

            for (int i = 0; i < takeList.Count; i++)
            {
                List<string> temp = new List<string>(nonNumbers);

                temp = temp.Skip(indexForSkip).Take(takeList[i]).ToList();

                result.Append(string.Join("", temp));

                indexForSkip += takeList[i] + skipList[i];
            }

            Console.WriteLine(result.ToString());
        }

        //04. Mixed up Lists
        public static void MixedUp()
        {
            List<int> firstInput = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondInput = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> rule = new List<int>();
            List<int> biggerList = new List<int>();
            List<int> mixed = new List<int>();

            if (firstInput.Count > secondInput.Count)
            {
                biggerList = firstInput;
            }
            else
            {
                biggerList = secondInput;
                biggerList.Reverse();
            }
            for (int i = biggerList.Count - 2; i < biggerList.Count; i++)
            {
                rule.Add(biggerList[i]);
            }
            rule.Sort();
            if (firstInput.Count > secondInput.Count)
            {
                firstInput.RemoveRange(firstInput.Count - 2, 2);
                secondInput.Reverse();
            }
            else
            {
                secondInput.RemoveRange(secondInput.Count - 2, 2);
                secondInput.Reverse();
            }
            for (int i = 0; i < firstInput.Count; i++)
            {
                mixed.Add(firstInput[i]);
                mixed.Add(secondInput[i]);
            }
            List<int> output = mixed.FindAll(x => x > rule[0] && x < rule[1]);
            output.Sort();
            Console.WriteLine(string.Join(" ", output));
        }
    }
}