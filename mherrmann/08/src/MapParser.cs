namespace Day08;

public static class MapParser
{
    private static Node ParseNode(string line)
    {
        string[] mainParts = line.Split(" = ");
        string id = mainParts[0];
        string values = mainParts[1][1..^1];

        string[] dest = values.Split(", ");

        return new(id, dest[0], dest[1]);
    }

    private static List<Direction> ParseDirectionsLine(string line) => line
        .ToList()
        .Select(c => c == 'L' ? Direction.L : Direction.R)
        .ToList();

    public static Map ParseDocument(List<string> lines)
    {
        if (!(lines[0].StartsWith('L') || lines[0].StartsWith('R'))) throw new ArgumentException("The first line must be filled with directions");

        List<Direction> directions = ParseDirectionsLine(lines.First());
        List<Node> nodes = lines
            .GetRange(1, lines.Count - 1)
            .Where(l => l.Length > 0)
            .Select(ParseNode)
            .ToList();

        return new(directions, nodes);
    }
}
