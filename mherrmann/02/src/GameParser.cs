namespace Day02;

public static class GameParser
{

    public static Game ParseLine(string line, bool printLine = false)
    {
        string[] parseGame = line.Split(": ");
        string[] parseGameId = parseGame[0].Split(' ');
        int id = int.Parse(parseGameId[1]);

        string[] parseDraws = parseGame[1].Split("; ");
        List<DrawBalls> draws = parseDraws
            .Select(ParseDraw)
            .ToList();

        if (printLine)
        {
            Console.WriteLine($"{line}");
            Console.Write($"\t-> {id}: ");
            foreach (DrawBalls draw in draws) Console.Write($"({draw.Red},{draw.Green},{draw.Blue}) ");
            Console.WriteLine();
        }

        return new(id, draws);
    }

    private static DrawBalls ParseDraw(string draw)
    {
        int red = 0;
        int green = 0;
        int blue = 0;

        string[] items = draw.Split(", ");

        foreach (string item in items)
        {
            string[] parts = item.Split(' ');
            int value = int.Parse(parts[0]);
            string color = parts[1];

            switch(color)
            {
                case "red":
                    red = value;
                    break;

                case "green":
                    green = value;
                    break;

                case "blue":
                    blue = value;
                    break;
            }
        }

        return new(red, green, blue);
    }

    public static List<Game> ParseDocument(ICollection<string> lines, bool printLines = false) => lines
        .Where(line => line.Length > 0) //Just to be safe
        .Select(line => ParseLine(line, printLines))
        .ToList();
}
