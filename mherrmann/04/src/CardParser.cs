namespace Day04;

public static class CardParser
{

    public static Card ParseLine(string line)
    {
        string[] mainParts = line.Split(": ");
        string[] nameParts = mainParts[0].Split(' ');
        int id = int.Parse(nameParts[^1]);

        string[] numberParts = mainParts[1].Split(" | ");
        string[] winningNumberParts = numberParts[0].Split(' ');
        string[] ownNumberParts = numberParts[1].Split(' ');

        List<int> winningNumbers = winningNumberParts
            .Where(s => s.Length > 0)
            .Select(int.Parse)
            .ToList();

        List<int> ownNumbers = ownNumberParts
            .Where(s => s.Length > 0)
            .Select(int.Parse)
            .ToList();

        return new(id, winningNumbers, ownNumbers);
    }

    public static CardGame ParseDocument(ICollection<string> lines) => new(
        lines
            .Where(s => s.Length > 0)
            .Select(ParseLine)
            .ToList()
        );
}
