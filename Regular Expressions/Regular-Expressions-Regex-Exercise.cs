using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PostOffice();
        }
        // 01. Furniture
        public static void Furniture()
        {
            List<string> furnitures = new List<string>();

            decimal totalMoneySpent = 0.0m;

            string pattern = @">>([A-Za-z]+)<<([\d]+\.*\d+)\!(\d+)";

            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string name = match.Groups[1].Value;
                    decimal price = decimal.Parse(match.Groups[2].Value);
                    long quantity = long.Parse(match.Groups[3].Value);

                    if (quantity != 0)
                    {
                        furnitures.Add(name);
                        totalMoneySpent += price * quantity;
                    }
                }
            }
            Console.WriteLine("Bought furniture:");
            foreach (var name in furnitures)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine($"Total money spend: {totalMoneySpent:f2}");
        }

        // 02. Race
        public static void Race()
        {
            List<string> participants = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Dictionary<string, int> personKm = new Dictionary<string, int>();

            for (int i = 0; i < participants.Count; i++)
            {
                if (!personKm.ContainsKey(participants[i]))
                {
                    personKm[participants[i]] = 0;
                }
            }

            string pattern = @"(?<name>[A-Za-z]+)|(?<distance>[0-9])";

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                MatchCollection match = Regex.Matches(input, pattern);

                string name = "";
                int sum = 0;

                foreach (Match item in match)
                {
                    foreach (var nameExtract in item.Groups["name"].Value)
                    {
                        name += nameExtract;
                    }

                    foreach (var distanceExtract in item.Groups["distance"].Value)
                    {
                        sum += int.Parse(item.Groups["distance"].Value);
                    }

                }

                if (personKm.ContainsKey(name))
                {
                    personKm[name] += sum;
                }
            }

            var ordered = personKm.OrderByDescending(x => x.Value).Take(3);
            int count = 1;

            foreach (var person in ordered)
            {
                if (count == 1)
                {
                    Console.WriteLine($"{count}st place: {person.Key}");
                }
                else if (count == 2)
                {
                    Console.WriteLine($"{count}nd place: {person.Key}");
                }
                else
                {
                    Console.WriteLine($"{count}rd place: {person.Key}");
                }
                count++;
            }
        }

        // 03. SoftUni Bar Income
        public static void SoftUniBarIncome()
        {
            string pattern = @"%(?<name>[A-Z]{1}[a-z]+)%[^|$\.]*<(?<product>\w+)>[^|$\.]*\|(?<quantity>\d+)\|[^|$\.]*?(?<price>[\d+\.?\d+]+\$)";
            StringBuilder sb = new StringBuilder();

            decimal total = 0;

            string input;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string product = match.Groups["product"].Value;
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    string temp = match.Groups["price"].Value.Remove(match.Groups["price"].Value.Length - 1);
                    decimal price = decimal.Parse(temp);
                    decimal tempPrice = quantity * price;
                    total += tempPrice;

                    sb.AppendLine($"{name}: {product} - {tempPrice:f2}");
                }
            }
            sb.AppendLine($"Total income: {total:f2}");

            Console.WriteLine(sb.ToString());
        }

        // 04. Star Enigma*
        public static void StarEnigma()
        {
            string keyPattern = @"[S,s,T,t,A,a,R,r]";
            string descriptedMsgPattern = @"@([a-zA-Z]+)[^@\-!:>]*:[0-9]+[^@\-!:>]*!([AD])![^@\-!:>]*->[0-9]+";

            List<string> descriptedMsg = new List<string>();
            Dictionary<string, List<string>> planets = new Dictionary<string, List<string>>();
            planets.Add("Attacked", new List<string>());
            planets.Add("Destroyed", new List<string>());

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                MatchCollection keyMatch = Regex.Matches(input, keyPattern);

                int countMatch = keyMatch.Count();
                char[] msg = new char[input.Length];
                for (int j = 0; j < input.Length; j++)
                {
                    var a = input[j] - countMatch;
                    msg[j] = (char)a;
                }
                string descriptingdMsg = new string(msg);
                descriptedMsg.Add(descriptingdMsg);
            }

            for (int i = 0; i < descriptedMsg.Count; i++)
            {
                Match match = Regex.Match(descriptedMsg[i], descriptedMsgPattern);

                if (match.Success)
                {
                    string planetName = match.Groups[1].Value;
                    char typeAttack = char.Parse(match.Groups[2].Value);

                    if (typeAttack == 'A')
                    {
                        planets["Attacked"].Add(planetName);
                    }
                    else if (typeAttack == 'D')
                    {
                        planets["Destroyed"].Add(planetName);
                    }
                }
            }

            foreach (var planet in planets)
            {
                Console.WriteLine($"{planet.Key} planets: {planet.Value.Count}");

                foreach (var plnt in planet.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-> {plnt}");
                }

            }
        }

        // 05 Nether Realms*
        public static void NetherRealms()
        {
            string[] demons = Console.ReadLine().
                 Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .ToArray();

            var demonHealths = new SortedDictionary<string, int>();
            var demonDamages = new SortedDictionary<string, double>();

            var pattern = @"-?\d+\.?\d*";
            var regex = new Regex(pattern);

            foreach (var demon in demons)
            {
                var health = demon
                    .Where(s => !char.IsDigit(s)
                    && s != '+' && s != '-' && s != '*' && s != '/' && s != '.')
                    .Sum(s => (int)s);

                demonHealths[demon] = health;

                var matches = regex.Matches(demon);

                var damage = 0.0;

                foreach (Match match in matches)
                {
                    var value = match.Value;
                    damage += double.Parse(value);
                }

                foreach (var symbol in demon)
                {
                    if (symbol == '*')
                    {
                        damage *= 2;
                    }
                    else if (symbol == '/')
                    {
                        damage /= 2;
                    }
                }
                demonDamages[demon] = damage;
            }

            foreach (var demon in demonDamages)
            {
                var demonName = demon.Key;
                var demonHealth = demonHealths[demonName];
                var demonDamage = demon.Value;

                Console.WriteLine($"{demonName} - {demonHealth} health, {demonDamage:F2} damage");
            }
        }

        // 06. Extract Emails*
        public static void ExtractEmail()
        {
            string input = Console.ReadLine();

            string emailPattern = @"(?<=\s|^)(?<user>[A-Za-z0-9]([-._]?[A-Za-z0-9])*)@(?<host>[A-Za-z](\-?[A-Za-z])*(\.[A-Za-z](\-?[A-Za-z])*)+)";

            MatchCollection matches = Regex.Matches(input, emailPattern);

            foreach (Match item in matches)
            {
                Console.WriteLine($"{item.Value}");
            }
        }

        // 07. Winning Ticket
        public static void WinningTicket()
        {
            var result = new StringBuilder();

            var tickets = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

            var pattern = @"(\@{6,}|\${6,}|\^{6,}|\#{6,})";
            var reg = new Regex(pattern);

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    result.Append($"invalid ticket{Environment.NewLine}");
                    continue;
                }

                var leftMatch = reg.Match(ticket.Substring(0, 10));
                var rightMatch = reg.Match(ticket.Substring(10));
                var minLen = Math.Min(leftMatch.Length, rightMatch.Length);

                if (!leftMatch.Success || !rightMatch.Success)
                {
                    result.Append($"ticket \"{ ticket}\" - no match{Environment.NewLine}");
                    continue;
                }

                var leftPart = leftMatch.Value.Substring(0, minLen);
                var rightPart = rightMatch.Value.Substring(0, minLen);

                if (leftPart.Equals(rightPart))
                {
                    if (leftPart.Length == 10)
                    {
                        result.Append($"ticket \"{ ticket}\" - {minLen}{leftPart.Substring(0, 1)} Jackpot!{Environment.NewLine}");
                    }
                    else
                    {
                        result.Append($"ticket \"{ ticket}\" - {minLen}{leftPart.Substring(0, 1)}{Environment.NewLine}");
                    }
                }
                else
                {
                    result.Append($"ticket \"{ ticket}\" - no match{Environment.NewLine}");
                }
            }

            Console.Write(result.ToString());
        }

        // 08. Rage Quit
        public static void RageQuit()
        {
            string input = Console.ReadLine();
            string pattern = @"(?<symbols>[^\d]+)(?<numbers>\d+)";
            int count = 0;

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            StringBuilder output = new StringBuilder();

            foreach (Match match in matches)
            {
                string message = match.Groups["symbols"].Value;
                int repeats = int.Parse(match.Groups["numbers"].Value);

                for (int i = 0; i < repeats; i++)
                {
                    output.Append(message.ToUpper());
                }
            }

            count = output.ToString().Distinct().Count();

            Console.WriteLine($"Unique symbols used: {count}");
            Console.WriteLine(output);
        }

        // 09. Post Office
        public static void PostOffice()
        {
            var input = Console.ReadLine().Split("|");
            string firstPart = String.Empty;
            string secondPart = String.Empty;
            var thirdPart = input[2].Split(" ");
            HashSet<string> wordCollection = new HashSet<string>();

            string firstPartPattern = @"[#$%*&]{1}(?<firstPart>[A-Z]+)[#$%*&]{1}";
            string secondPartPattern = @"(?<secondPart>\d{2}:{1}\d{2})";

            Match match = Regex.Match(input[0], firstPartPattern);

            if (match.Success)
            {
                firstPart = match.Groups["firstPart"].Value;
            }
            else
            {
                return;
            }

            MatchCollection matches = Regex.Matches(input[1], secondPartPattern);
            Dictionary<char, int> letterLenghts = new Dictionary<char, int>();
            foreach (Match item in matches)
            {
                var splitedMatches = item.Value.Split(":").ToArray();
                int letterNumber = int.Parse(splitedMatches[0]);
                char letter = (char)letterNumber;
                int length = int.Parse(splitedMatches[1]);

                if (letterNumber >= 65 && letterNumber <= 122)
                {
                    if (!letterLenghts.ContainsKey(letter))
                    {
                        letterLenghts[letter] = length + 1;
                    }
                }
            }

            char[] firstPartLetters = firstPart.ToCharArray();

            foreach (var letter in firstPartLetters)
            {
                if (letterLenghts.ContainsKey(letter))
                {
                    if (letterLenghts[letter] >= 1 && letterLenghts[letter] <= 20)
                    {
                        var result = thirdPart.Where(x => x[0] == letter)
                            .Where(x => x.Length == letterLenghts[letter])
                            .FirstOrDefault();
                        if (result != null)
                        {
                            wordCollection.Add(result);
                        }
                    }
                }
            }

            Console.WriteLine(String.Join("\n", wordCollection));
        }
    }
}
