using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class LettersChangeNumbers
{
    public static void Main()
    {

    }

    // 05. HTML
    public static void HTML()
    {
        string titleArtictle = Console.ReadLine();
        string contentArticle = Console.ReadLine();

        StringBuilder sb = new StringBuilder();

        string space = "    ";

        sb.AppendLine("<h1>");
        sb.AppendLine(space + titleArtictle);
        sb.AppendLine("</h1>");
        sb.AppendLine("<article>");
        sb.AppendLine(space + contentArticle);
        sb.AppendLine("</article>");

        string command;
        while ((command = Console.ReadLine()) != "end of comments")
        {
            sb.AppendLine("<div>");
            sb.AppendLine(space + command);
            sb.AppendLine("</div>");
        }

        Console.WriteLine(sb.ToString());
    }

    // 04. Morse Code Translator
    public static void MorseCodeTranslator()
    {
        List<string> input = Console.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .Select<string, string>(x => x == ".-" ? "A" : x)
            .Select<string, string>(x => x == "-..." ? "B" : x)
            .Select<string, string>(x => x == "-.-." ? "C" : x)
            .Select<string, string>(x => x == "-.." ? "D" : x)
            .Select<string, string>(x => x == "." ? "E" : x)
            .Select<string, string>(x => x == "..-." ? "F" : x)
            .Select<string, string>(x => x == "--." ? "G" : x)
            .Select<string, string>(x => x == "...." ? "H" : x)
            .Select<string, string>(x => x == ".." ? "I" : x)
            .Select<string, string>(x => x == ".---" ? "J" : x)
            .Select<string, string>(x => x == "-.-" ? "K" : x)
            .Select<string, string>(x => x == ".-.." ? "L" : x)
            .Select<string, string>(x => x == "--" ? "M" : x)
            .Select<string, string>(x => x == "-." ? "N" : x)
            .Select<string, string>(x => x == "---" ? "O" : x)
            .Select<string, string>(x => x == ".--." ? "P" : x)
            .Select<string, string>(x => x == "--.-" ? "Q" : x)
            .Select<string, string>(x => x == ".-." ? "R" : x)
            .Select<string, string>(x => x == "..." ? "S" : x)
            .Select<string, string>(x => x == "-" ? "T" : x)
            .Select<string, string>(x => x == "..-" ? "U" : x)
            .Select<string, string>(x => x == "...-" ? "V" : x)
            .Select<string, string>(x => x == ".--" ? "W" : x)
            .Select<string, string>(x => x == "-..-" ? "X" : x)
            .Select<string, string>(x => x == "-.--" ? "Y" : x)
            .Select<string, string>(x => x == "--.." ? "X" : x)
            .Select<string, string>(x => x == "|" ? " " : x)
            .ToList();

        Console.WriteLine(String.Join("", input));
    }

    // 03. Treasure Finder
    public static void TreasureFinder()
    {
        int[] key = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
        string command;
        StringBuilder sb = new StringBuilder();
        while ((command = Console.ReadLine()) != "find")
        {
            var text = "";
            var translatet = command.ToCharArray().ToList();

            for (int i = 0; i < translatet.Count; i++)
            {

                if (i + 1 > key.Length)
                {
                    translatet.RemoveRange(0, key.Length);
                    i = -1;
                    continue;
                }
                var symbol = translatet[i] - key[i];
                text += (char)symbol;
            }

            var nameSymbol = text.IndexOf('&');
            string temp = text.Remove(0, nameSymbol + 1);
            string material = temp.Substring(0, temp.IndexOf('&'));

            var cordinatIndex = text.IndexOf('<');
            string cordTemp = text.Remove(0, cordinatIndex + 1);
            string cordinates = cordTemp.Substring(0, cordTemp.IndexOf('>'));

            sb.AppendLine($"Found {material} at {cordinates}");
        }

        Console.WriteLine(sb.ToString());

    }

    // 02. Ascii Sumator
    public static void AsciiSumator()
    {
        char first = char.Parse(Console.ReadLine());
        char second = char.Parse(Console.ReadLine());
        string text = Console.ReadLine();

        int total = text
            .ToCharArray()
            .Select(x => (int)x)
            .Where(x => x > first && x < second)
            .ToList()
            .Sum();

        Console.WriteLine(total);
    }

    // 01. Extract Person Information
    public static void ExtractPersonInformation()
    {
        int n = int.Parse(Console.ReadLine());

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            int nameStart = input.IndexOf("@") + 1;
            int nameEnd = input.IndexOf("|") - nameStart;
            int ageStart = input.IndexOf("#") + 1;
            int ageEnd = input.IndexOf("*") - ageStart;

            string name = input.Substring(nameStart, nameEnd);
            string age = input.Substring(ageStart, ageEnd);

            sb.AppendLine($"{name} is {age} years old.");
        }

        Console.WriteLine(sb.ToString());
    }
}
