using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SoftUniExamResult();
        }

        // 01. Count Chars in a String
        public static void CountCharsInAString()
        {
            Dictionary<char, int> dic = new Dictionary<char, int>();

            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                char letter = input[i];

                if (letter != ' ')
                {
                    if (!dic.ContainsKey(letter))
                    {
                        dic.Add(letter, 1);
                    }
                    else
                    {
                        dic[letter]++;
                    }
                }
            }

            foreach (var symbol in dic)
            {
                Console.WriteLine($"{symbol.Key} -> {symbol.Value}");
            }
        }

        // 02. A Miner Task
        public static void MinerTask()
        {
            Dictionary<string, int> dic = new Dictionary<string, int>();
            int count = 1;
            string resource = "";
            string input;
            while ((input = Console.ReadLine()) != "stop")
            {
                if (count % 2 != 0)
                {
                    resource = input;
                    if (!dic.ContainsKey(input))
                    {
                        dic[input] = 0;
                    }
                }
                else
                {
                    dic[resource] += int.Parse(input);
                }

                count++;
            }

            foreach (var item in dic)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }

        // 03. Legendary Farming
        public static void LegendaryFarming()
        {
            Dictionary<string, Dictionary<string, int>> dic = new Dictionary<string, Dictionary<string, int>>();

            dic.Add("keyMaterials", new Dictionary<string, int>());
            dic.Add("junks", new Dictionary<string, int>());
            dic["keyMaterials"].Add("shards", 0);
            dic["keyMaterials"].Add("fragments", 0);
            dic["keyMaterials"].Add("motes", 0);

            bool isTrue = true;
            while (isTrue)
            {
                string[] input = Console.ReadLine().Split(" ");

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (!(material == "shards" || material == "motes" || material == "fragments"))
                    {
                        if (!dic["junks"].ContainsKey(material))
                        {
                            dic["junks"].Add(material, quantity);
                        }
                        else
                        {
                            dic["junks"][material] += quantity;
                        }
                    }
                    else
                    {
                        if (!dic["keyMaterials"].ContainsKey(material))
                        {
                            dic["keyMaterials"].Add(material, quantity);
                        }
                        else
                        {
                            dic["keyMaterials"][material] += quantity;
                        }
                    }

                    if (dic["keyMaterials"]["shards"] >= 250)
                    {
                        dic["keyMaterials"]["shards"] -= 250;
                        Console.WriteLine("Shadowmourne obtained!");
                        isTrue = false;
                        break;
                    }
                    else if (dic["keyMaterials"]["fragments"] >= 250)
                    {
                        dic["keyMaterials"]["fragments"] -= 250;
                        Console.WriteLine("Valanyr obtained!");
                        isTrue = false;
                        break;
                    }
                    else if (dic["keyMaterials"]["motes"] >= 250)
                    {
                        dic["keyMaterials"]["motes"] -= 250;
                        Console.WriteLine("Dragonwrath obtained!");
                        isTrue = false;
                        break;
                    }
                }
            }

            var sortedKeys = dic["keyMaterials"]
           .OrderByDescending(x => x.Value)
           .ThenBy(x => x.Key);

            var sortedJunks = dic["junks"]
                .OrderBy(x => x.Key);

            foreach (var item in sortedKeys)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in sortedJunks)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        // 04. Orders
        public static void Orders()
        {
            Dictionary<string, double> productAndPrice = new Dictionary<string, double>();
            Dictionary<string, int> productAndQuantity = new Dictionary<string, int>();

            string input;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] splittedInput = input.Split(" ");
                string product = splittedInput[0];
                double price = double.Parse(splittedInput[1]);
                int quantity = int.Parse(splittedInput[2]);

                if (!(productAndPrice.ContainsKey(product) && productAndQuantity.ContainsKey(product)))
                {
                    productAndPrice[product] = price;
                    productAndQuantity[product] = quantity;
                }
                else
                {
                    productAndPrice[product] = price;
                    productAndQuantity[product] += quantity;
                }
            }

            foreach (var product in productAndPrice)
            {
                var quant = productAndQuantity[product.Key];
                Console.WriteLine($"{product.Key} -> {product.Value * quant:F2}");

            }
        }

        // 05. SoftUni Parking
        public static void SoftUniParking()
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> registered = new Dictionary<string, string>();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");

                string command = input[0];
                string name = input[1];

                if (command == "register")
                {
                    string plate = input[2];
                    if (registered.ContainsKey(name))
                    {
                        sb.AppendLine($"ERROR: already registered with plate number {registered[name]}");
                    }
                    else
                    {
                        registered[name] = plate;
                        sb.AppendLine($"{name} registered {plate} successfully");
                    }
                }
                else if (command == "unregister")
                {
                    if (!registered.ContainsKey(name))
                    {
                        sb.AppendLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        registered.Remove(name);
                        sb.AppendLine($"{name} unregistered successfully");
                    }
                }
            }

            foreach (var item in registered)
            {
                sb.AppendLine($"{item.Key} => {item.Value}");
            }

            Console.WriteLine(sb.ToString());
        }

        // 06. Courses
        public static void Courses()
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] splittedInput = input.Split(" : ");
                string courseName = splittedInput[0];
                string student = splittedInput[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>() { student });
                }
                else
                {
                    if (!courses[courseName].Contains(student))
                    {
                        courses[courseName].Add(student);
                    }
                }
            }

            var sorted = courses.OrderByDescending(x => x.Value.Count);

            foreach (var course in sorted)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count()}");

                var sortedStudents = course.Value.OrderBy(x => x);

                foreach (var student in sortedStudents)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }

        // 07. Student Academy
        public static void StudentAcademy()
        {
            Dictionary<string, List<double>> grades = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!grades.ContainsKey(name))
                {
                    grades[name] = new List<double> { grade };
                }
                else
                {
                    grades[name].Add(grade);
                }
            }

            var filteredGrades = grades.Where(x => x.Value.Sum() / x.Value.Count() >= 4.50);
            var ordered = filteredGrades.OrderByDescending(x => x.Value.Sum() / x.Value.Count());

            foreach (var item in ordered)
            {
                Console.WriteLine($"{item.Key} -> {item.Value.Sum() / item.Value.Count():F2}");
            }
        }

        // 08. Comapny Users
        public static void CompanyUsers()
        {
            Dictionary<string, List<string>> companyCollection = new Dictionary<string, List<string>>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] splittedCommand = command.Split(" -> ");
                string companyName = splittedCommand[0];
                string employeeId = splittedCommand[1];

                if (!companyCollection.ContainsKey(companyName))
                {
                    companyCollection[companyName] = new List<string>();
                }
                if (!companyCollection[companyName].Contains(employeeId))
                {
                    companyCollection[companyName].Add(employeeId);
                }
            }

            var orderedCompanyCollection = companyCollection.OrderBy(x => x.Key);

            foreach (var company in orderedCompanyCollection)
            {
                Console.WriteLine($"{company.Key}");

                foreach (var employee in company.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }

        // 09. ForceBook *
        public static void ForceBook()
        {
            Dictionary<string, List<string>> sideCollection = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains('|'))
                {
                    string[] splittedInput = input.Split(new string[] {" | "}, StringSplitOptions.RemoveEmptyEntries);

                    string side = splittedInput[0];
                    string user = splittedInput[1];

                    if (!sideCollection.ContainsKey(side))
                    {
                        sideCollection.Add(side, new List<string>());
                    }
                    if (!sideCollection[side].Contains(user) &&
                        !sideCollection.Values.Any(x => x.Contains(user)))
                    {
                        sideCollection[side].Add(user);
                    }
                }
                else if (input.Contains("->"))
                {
                    string[] data = input.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                    string user = data[0];
                    string side = data[1];

                    if (!sideCollection.Any(x => x.Value.Contains(user)))
                    {
                        if (!sideCollection.ContainsKey(side))
                        {

                            sideCollection.Add(side, new List<string>());
                        }

                        sideCollection[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                    else
                    {
                        foreach (var member in sideCollection)
                        {
                            if (member.Value.Contains(user))
                            {
                                member.Value.Remove(user);
                            }
                        }

                        if (!sideCollection.ContainsKey(side))
                        {
                            sideCollection.Add(side, new List<string>());
                        }

                        sideCollection[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                }
            }

            foreach (var side in sideCollection.Where(x => x.Value.Count > 0).OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count()}");

                foreach (var user in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

        // 10. SoftUni Exam Result
        public static void SoftUniExamResult()
        {
            Dictionary<string, Dictionary<string, int>> studentCollection = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> lenguageCount = new Dictionary<string, int>();

            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] splittedInput = input.Split("-");
                string user = splittedInput[0];
                string lenguage = splittedInput[1];
                int points = 0;

                if(lenguage == "banned")
                {
                    foreach (var student in studentCollection)
                    {
                        if (student.Value.ContainsKey(user))
                        {
                            student.Value.Remove(user);
                        }
                    }
                }             
                else if (!studentCollection.ContainsKey(lenguage))
                {
                    points = int.Parse(splittedInput[2]);
                    studentCollection[lenguage] = new Dictionary<string, int>();
                    studentCollection[lenguage].Add(user, points);

                    lenguageCount[lenguage] = 1;
                }
                else if (studentCollection.ContainsKey(lenguage) && studentCollection[lenguage].ContainsKey(user))
                {
                    points = int.Parse(splittedInput[2]);
                    if (studentCollection[lenguage][user] < points)
                    {
                        studentCollection[lenguage][user] = points;
                    }

                    lenguageCount[lenguage]++;
                }
                else if (studentCollection.ContainsKey(lenguage) && !studentCollection[lenguage].ContainsKey(user))
                {
                    points = int.Parse(splittedInput[2]);
                    studentCollection[lenguage].Add(user, points);

                    lenguageCount[lenguage]++;
                }

            }
            Dictionary<string, int> users = new Dictionary<string, int>();

            foreach (var lenguage in studentCollection)
            {
                foreach (var student in lenguage.Value.OrderByDescending(x => x.Value))
                {
                    users[student.Key] = student.Value;
                }
            }
            Console.WriteLine("Results:");
            foreach (var user in users.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
              Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var lenguage in lenguageCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{lenguage.Key} - {lenguage.Value}");
            }
        }
    }
}