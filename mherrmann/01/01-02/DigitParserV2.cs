using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DigitParserV2
{
    private static readonly Dictionary<string, string> digits = new() {
        { "one",   "1" },
        { "two",   "2" },
        { "three", "3" },
        { "four",  "4" },
        { "five",  "5" },
        { "six",   "6" },
        { "seven", "7" },
        { "eight", "8" },
        { "nine",  "9" }
    };

    private static string ReplaceDigits(string input)
    {
        int stringIndex = -1;
        int digitIndex;

        while (true)
        {
            var indices = digits.Keys
                .Select((key, index) => (input.IndexOf(key), index))
                .Where(sd => sd.Item1 != -1)
                .ToList();

            if (indices.Count > 0)
            {
                (stringIndex, digitIndex) = indices.Min();
                int searchLength = digits.Keys.ElementAt(digitIndex).Length;
                string replace = digits.Values.ElementAt(digitIndex);
                input = string.Concat(input.AsSpan(0, stringIndex), replace, input.AsSpan(stringIndex + searchLength));
            }
            else
            {
                break;
            }
        }

        return input;
    }

    public static int parseLine(string line, bool printLine = false)
    {
        if (line.Length == 0) return 0;

        List<int> digits = ReplaceDigits(line)
            .ToList()
            .Where(char.IsDigit)
            .Select(c => Convert.ToInt32(c) - '0')
            .ToList();

        int sum = digits.First() * 10 + digits.Last();

        if (printLine) Console.WriteLine($"{line} -> {sum}");

        return sum;
    }

    public static int parseDocument(ICollection<string> lines, bool printLines = false)
    {
        int sum = 0;
        foreach (string line in lines) sum += parseLine(line, printLines);

        return sum;
    }
}
