using System;
using System.Collections.Generic;
using System.Linq;

namespace Lists
{
    public class Program
    {
        public static void Main()
        {

        }

        //01.Train
        public static void Train(List<int> wagons)
        {
            int wagonCapacity = int.Parse(Console.ReadLine());
            var input = Console.ReadLine();

            while (input != "end")
            {
                var command = input.Split(' ').ToList();

                if (command[0] == "Add")
                {
                    wagons.Add(int.Parse(command[1]));
                }
                else if (command[0] != "Add")
                {
                    var passengers = int.Parse(command[0]);

                    for (int i = 0; i < wagons.Count; i++)
                    {
                        if (wagons[i] + passengers <= wagonCapacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(' ', wagons));
        }

        //02.Change List
        public static void ChangeList(List<int> numbers)
        {
            var input = Console.ReadLine();
            while (input != "end")
            {
                var command = input.Split().ToList();

                if (command[0] == "Delete")
                {

                    numbers.RemoveAll(x => x == int.Parse(command[1]));
                }
                else if (command[0] == "Insert")
                {
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(' ', numbers));
        }

        //03.House Party
        public static void HouseParty()
        {
            int commandsNumber = int.Parse(Console.ReadLine());

            List<string> guests = new List<string>();

            for (int i = 0; i < commandsNumber; i++)
            {
                var command = Console.ReadLine().Split(' ').ToList();

                if (command[2] != "not")
                {
                    if (guests.Contains(command[0]))
                    {
                        Console.WriteLine($"{command[0]} is already in the list!");
                        continue;
                    }
                    else
                    {
                        guests.Add(command[0]);
                    }
                }
                else if (command[2] == "not")
                {

                    if (guests.Contains(command[0]))
                    {
                        guests.Remove(command[0]);
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{command[0]} is not in the list!");
                    }
                }
            }

            foreach (var people in guests)
            {
                Console.WriteLine(people);
            }
        }

        //04. List Operation
        public static void ListOperations(List<int> numbers)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                var command = input.Split(' ').ToList();

                //ADD
                if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                }
                //INSERT
                else if (command[0] == "Insert")
                {
                    if (int.Parse(command[2]) > numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    }
                }
                //REMOVE
                else if (command[0] == "Remove")
                {
                    if (int.Parse(command[1]) > numbers.Count)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(int.Parse(command[1]));

                    }
                }
                //SHIFT
                else if (command[0] == "Shift")
                {
                    if (command[1] == "left")
                    {
                        for (int i = 0; i < int.Parse(command[2]); i++)
                        {
                            var first = numbers[0];
                            numbers.Add(first);
                            numbers.RemoveAt(0);
                        }
                    }
                    else if (command[1] == "right")
                    {
                        for (int i = 0; i < int.Parse(command[2]); i++)
                        {
                            numbers.Reverse();
                            var last = numbers[0];
                            numbers.Add(last);
                            numbers.RemoveAt(0);
                            numbers.Reverse();

                        }
                    }

                }

                input = Console.ReadLine();
            }

            Console.WriteLine(String.Join(' ', numbers));
        }

        //05.Bomb Numbers
        public static void BombNumbers()
        {
            var bombs = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var detonations = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int bombNumber = detonations[0];
            int bombPower = detonations[1];
            int sum = 0;

            for (int i = 0; i < bombs.Count; i++)
            {
                if (bombs.Contains(bombNumber))
                {
                    int bombIndex = 0;
                    for (int j = 0; j < bombs.Count; j++)
                    {
                        if (bombs[j] == bombNumber)
                        {
                            bombIndex = j;

                            for (int p = 0; p < Math.Abs(bombPower); p++)
                            {
                                try
                                {
                                    bombs.RemoveAt(j - 1 - p);
                                    bombIndex--;
                                }
                                catch
                                {
                                    break;
                                }
                            }

                            for (int l = 0; l < Math.Abs(bombPower); l++)
                            {
                                try
                                {
                                    bombs.RemoveAt(bombIndex + 1);
                                }
                                catch
                                {
                                    break;
                                }
                            }

                            bombs.RemoveAt(bombIndex);
                        }
                    }
                }
            }

            for (int i = 0; i < bombs.Count; i++)
            {
                sum += bombs[i];
            }

            Console.WriteLine(sum);
        }

        //06.Card Game
        public static void CardGame()
        {
            List<int> firstCards = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> secondCards = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var range = secondCards.Count;

            for (int i = 0; i < range; i++)
            {
                if (firstCards.Count < secondCards.Count)
                {
                    range = firstCards.Count;
                    i = 0;
                }
                else
                {
                    range = secondCards.Count;
                    i = 0;
                }

                if (firstCards[i] > secondCards[i])
                {
                    firstCards.Add(firstCards[i]);
                    firstCards.Add(secondCards[i]);
                    firstCards.RemoveAt(i);
                    secondCards.RemoveAt(i);
                }
                else if (firstCards[0] < secondCards[i])
                {
                    secondCards.Add(secondCards[i]);
                    secondCards.Add(firstCards[i]);
                    secondCards.RemoveAt(i);
                    firstCards.RemoveAt(i);
                }
                else if (firstCards[i] == secondCards[i])
                {
                    firstCards.RemoveAt(i);
                    secondCards.RemoveAt(i);
                }
            }

            var playerOne = firstCards.Sum();
            var playerTwo = secondCards.Sum();

            if (playerOne > playerTwo)
            {
                Console.WriteLine($"First player wins! Sum: {playerOne}");
            }
            else if (playerOne < playerTwo)
            {
                Console.WriteLine($"Second player wins! Sum: {playerTwo}");
            }
        }

        //07.Append Arrays
        public static void AppendArrays()
        {
            var arraysInput = Console.ReadLine().Split('|').Reverse().ToList();

            var result = new List<int>();

            foreach (var item in arraysInput)
            {
                result.AddRange(item.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList());
            }

            Console.WriteLine(String.Join(' ', result));

        }

        //08.Anonymous Threat
        public static void AnonymousThread()
        {
            List<string> input = Console.ReadLine().Split().ToList();

            while (true)
            {
                string[] commands = Console.ReadLine().Split();
                string command = commands[0];
                if (command == "3:1")
                {
                    break;
                }

                int startIndex = int.Parse(commands[1]);
                int endIndex = int.Parse(commands[2]);
                string concatWord = string.Empty;
                if (endIndex > input.Count - 1 || endIndex < 0)
                {
                    endIndex = input.Count - 1;
                }

                if (startIndex < 0 || startIndex > input.Count)
                {
                    startIndex = 0;
                }

                if (command == "merge")
                {
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        concatWord += input[i];
                    }
                    input.RemoveRange(startIndex, endIndex - startIndex + 1);
                    input.Insert(startIndex, concatWord);
                }
                else if (command == "divide")
                {
                    List<string> divided = new List<string>();
                    int divide = int.Parse(commands[2]);
                    string word = input[startIndex];
                    input.RemoveAt(startIndex);
                    int parts = word.Length / divide;
                    for (int i = 0; i < divide; i++)
                    {
                        if (i == divide - 1)
                        {
                            divided.Add(word.Substring(i * parts));
                        }
                        else
                        {
                            divided.Add(word.Substring(i * parts, parts));
                        }
                    }
                    input.InsertRange(startIndex, divided);
                }
            }

            Console.WriteLine(string.Join(" ", input));
        }

        //09.Pokemon Don't Go
        public static void PokemonGo()
        {
            var distance = Console.ReadLine()
            .Split()
            .Select(long.Parse)
            .ToList();

            long sum = 0;

            while (distance.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                long distanceIndex;
                if (index < 0)
                {
                    distanceIndex = distance[0];
                    distance[0] = distance[distance.Count - 1];
                }
                else if (index >= distance.Count)
                {
                    distanceIndex = distance[distance.Count - 1];
                    distance[distance.Count - 1] = distance[0];
                }
                else
                {
                    distanceIndex = distance[index];
                    distance.RemoveAt(index);
                }

                sum += distanceIndex;

                for (int i = 0; i < distance.Count; i++)
                {
                    if (distance[i] <= distanceIndex)
                    {
                        distance[i] += distanceIndex;
                    }
                    else
                    {
                        distance[i] -= distanceIndex;
                    }
                }
            }

            Console.WriteLine(sum);
        }

        //10.Softuni Course Planning
        public static void SoftuniPlanninig()
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();

            string input = Console.ReadLine();

            while (input != "course start")
            {
                string[] data = input.Split(':');

                string command = data[0];

                if (command == "Add")
                {
                    string title = data[1];

                    if (lessons.Contains(title) == false)
                    {
                        lessons.Add(title);
                    }
                }
                else if (command == "Insert")
                {
                    string title = data[1];
                    int index = int.Parse(data[2]);

                    if (lessons.Contains(title) == false)
                    {
                        if (index >= 0 && index < lessons.Count)
                        {
                            lessons.Insert(index, title);
                        }
                    }
                }
                else if (command == "Remove")
                {
                    string title = data[1];

                    if (lessons.Contains(title))
                    {
                        int index = lessons.IndexOf(title);

                        if (index + 1 < lessons.Count)
                        {
                            if (lessons[index + 1] == $"{title}-Exercise")
                            {
                                lessons.RemoveRange(index, 2);
                            }
                            else
                            {
                                lessons.Remove(title);
                            }
                        }
                        else
                        {
                            lessons.Remove(title);
                        }
                    }
                }
                else if (command == "Swap")
                {
                    string firstTitle = data[1];
                    string secondTitle = data[2];

                    if (lessons.Contains(firstTitle) && lessons.Contains(secondTitle))
                    {
                        int firstTitleIndex = lessons.IndexOf(firstTitle);
                        int secondTitleIndex = lessons.IndexOf(secondTitle);

                        lessons[firstTitleIndex] = secondTitle;
                        lessons[secondTitleIndex] = firstTitle;

                        if (firstTitleIndex + 1 < lessons.Count && secondTitleIndex + 1 < lessons.Count)
                        {
                            if (lessons[firstTitleIndex + 1] == $"{firstTitle}-Exercise" && lessons[secondTitleIndex + 1] == $"{secondTitle}-Exercise")
                            {
                                string temp = lessons[secondTitleIndex + 1];
                                lessons[secondTitleIndex + 1] = lessons[firstTitleIndex + 1];
                                lessons[firstTitleIndex + 1] = temp;
                            }
                            else if (lessons[firstTitleIndex + 1] == $"{firstTitle}-Exercise")
                            {
                                lessons.Insert(secondTitleIndex + 1, lessons[firstTitleIndex + 1]);

                                if (secondTitleIndex > firstTitleIndex)
                                {
                                    lessons.RemoveAt(firstTitleIndex + 1);
                                }
                                else if (secondTitleIndex < firstTitleIndex)
                                {
                                    lessons.RemoveAt(firstTitleIndex + 2);
                                }

                            }
                            else if (lessons[secondTitleIndex + 1] == $"{secondTitle}-Exercise")
                            {
                                lessons.Insert(firstTitleIndex + 1, lessons[secondTitleIndex + 1]);

                                if (firstTitleIndex < secondTitleIndex)
                                {
                                    lessons.RemoveAt(secondTitleIndex + 2);
                                }
                                else if (firstTitleIndex > secondTitleIndex)
                                {
                                    lessons.RemoveAt(secondTitleIndex + 1);
                                }
                            }
                        }
                        else if (firstTitleIndex + 1 < lessons.Count)
                        {
                            if (lessons[firstTitleIndex + 1] == $"{firstTitle}-Exercise")
                            {
                                lessons.Insert(secondTitleIndex + 1, lessons[firstTitleIndex + 1]);

                                if (secondTitleIndex > firstTitleIndex)
                                {
                                    lessons.RemoveAt(firstTitleIndex + 1);
                                }
                                else if (secondTitleIndex < firstTitleIndex)
                                {
                                    lessons.RemoveAt(firstTitleIndex + 2);
                                }
                            }
                        }
                        else if (secondTitleIndex + 1 < lessons.Count)
                        {
                            if (lessons[secondTitleIndex + 1] == $"{secondTitle}-Exercise")
                            {
                                lessons.Insert(firstTitleIndex + 1, lessons[secondTitleIndex + 1]);

                                if (firstTitleIndex < secondTitleIndex)
                                {
                                    lessons.RemoveAt(secondTitleIndex + 2);
                                }
                                else if (firstTitleIndex > secondTitleIndex)
                                {
                                    lessons.RemoveAt(secondTitleIndex + 1);
                                }
                            }
                        }
                    }
                }
                else if (command == "Exercise")
                {
                    string title = data[1];

                    if (lessons.Contains(title))
                    {
                        int index = lessons.IndexOf(title);

                        if (index + 1 < lessons.Count)
                        {
                            if (lessons[index + 1] != $"{title}-Exercise")
                            {
                                lessons.Insert(index + 1, $"{title}-Exercise");
                            }
                        }
                        else
                        {
                            lessons.Add($"{title}-Exercise");
                        }
                    }
                    else
                    {
                        lessons.Add(title);
                        lessons.Add($"{title}-Exercise");
                    }
                }

                input = Console.ReadLine();
            }

            for (int index = 0; index < lessons.Count; index++)
            {
                Console.WriteLine($"{index + 1}.{lessons[index]}");
            }
        }
    }
}