namespace Day06;

public static class RaceParser
{
    public static List<long> ParseDataLine(string line)
    {
        string[] parts = line.Split(' ');
        List<long> res = [];

        for (int i = 1; i < parts.Length; i++)
        {
            if (parts[i].Length != 0) res.Add(long.Parse(parts[i]));
        }

        return res;
    }

    public static long ParseDataLineV2(string line) => long.Parse(
        line
            .ToList()
            .Where(char.IsDigit)
            .Select(c => c.ToString())
            .Aggregate(string.Concat)
        );

    public static RaceManager ParseDocument(string[] lines)
    {
        List<long> time = [];
        List<long> distance = [];
        List<Race> races = [];

        foreach (string line in lines)
        {
            if (line.StartsWith("Time:")) time = ParseDataLine(line);
            else if (line.StartsWith("Distance:")) distance = ParseDataLine(line);
        }

        for (int i = 0; i < time.Count; i++) races.Add(new(time[i], distance[i]));

        return new(races);
    }

    public static RaceManager ParseDocumentV2(string[] lines)
    {
        long time = 0;
        long distance = 0;

        foreach (string line in lines)
        {
            if (line.StartsWith("Time:")) time = ParseDataLineV2(line);
            else if (line.StartsWith("Distance:")) distance = ParseDataLineV2(line);
        }

        return new([new Race(time, distance)]);
    }
}
