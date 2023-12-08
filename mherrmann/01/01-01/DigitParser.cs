using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DigitParser
{
    public static int parseLine(string line, bool printLine = false)
    {
        if (line.Length == 0) return 0;

        List<int> digits = line
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
