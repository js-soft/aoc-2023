/**
 * Day 08 - Puzzle 02
 * Haunted Wasteland
 * Mika Herrmann
 */

using Advent2023;
using Day08;

//string[] lines = FSUtil.ReadResource("input.txt");
//string[] lines = FSUtil.ReadResource("input-example-3.txt");
string[] lines = FSUtil.ReadResource("realNetwork.txt");

Map map = MapParser.ParseDocument([.. lines]);

long sum = map.CalculateSimultaneousSteps();

Console.WriteLine($"\nThe result is {sum}");

/*List<short> ids = [];
for (char first  = 'A'; first <= 'Z'; first++)
{
    for (char second = 'A'; second <= 'Z'; second++)
    {
        for (char third = 'A'; third <= 'Z'; third++)
        {
            string s = string.Concat(first, second, third);
            ids.Add(Node.TextToId(s));

            Console.WriteLine($"{s} -> {Node.IdToText(Node.TextToId(s))}");
        }
    }
}

if (ids.Count != ids.Distinct().Count()) Console.WriteLine("Duplicates exist");
else Console.WriteLine("Duplicates don't exist");*/