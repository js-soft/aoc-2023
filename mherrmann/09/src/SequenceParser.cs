namespace Day09;

public static class SequenceParser
{
    private static Sequence ParseLine(string line) => new(
            line
                .Split(' ')
                .Select(long.Parse)
                .ToList()
        );

    public static SensorData ParseDocument(ICollection<string> lines) => new(
            lines
                .Select(ParseLine)
                .ToList()
        );
}
