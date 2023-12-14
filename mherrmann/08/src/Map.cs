namespace Day08;

public enum Direction : byte { L, R }

public record Node(short Id, short Left, short Right)
{
    public readonly short IdLastDigit = (short) (Id % 26);

    public Node(string id,string left, string right) : this(TextToId(id), TextToId(left), TextToId(right)) {}
    public Node() : this(-1, -1, -1) {}

    public short GetNextId(Direction direction) => direction == Direction.L ? Left : Right;

    public override string ToString() => $"({IdToText(Id)} -> {IdToText(Left)}, {IdToText(Right)})";

    public static short TextToId(string text)
    {
        if (text.Length != 3) throw new ArgumentException($"The text must have length 3 ({text.Length} given)");

        short first =  (short) (text[0] - 'A');
        short second = (short) (text[1] - 'A');
        short third =  (short) (text[2] - 'A');

        return (short) ((first * 26 * 26) + (second * 26) + third);
    }

    public static string IdToText(short id)
    {
        char third = (char) (id % 26 + 'A');
        char second = (char) (id / 26 % 26 + 'A');
        char first = (char) (id / 26 / 26 + 'A');

        return string.Concat(first, second, third);
    }
}

public class Map
{
    private static readonly short firstId = Node.TextToId("AAA");
    private static readonly short lastId = Node.TextToId("ZZZ");
    private static readonly short IdA = 0;
    private static readonly short IdZ = 25;

    private List<Direction> Directions;
    private List<Node> validNodes;
    private Node[] Nodes;

    public Map(List<Direction> directions, List<Node> nodes)
    {
        Directions = directions;
        Nodes = new Node[lastId + 1];
        validNodes = nodes;

        foreach (Node node in nodes) Nodes[node.Id] = node;
    }

    public long CalculateSteps()
    {
        long steps = 0;
        int dirIndex = 0;
        short id = firstId;

        while (id != lastId)
        {
            Node node = Nodes[id];
            id = node.GetNextId(Directions[dirIndex]);

            dirIndex++;
            steps++;
            if (dirIndex ==  Directions.Count) dirIndex = 0;
        }

        return steps;
    }

    /// <summary>
    /// Brute-Force, will take long
    /// </summary>
    /// <returns></returns>
    public long CalculateSimultaneousSteps()
    {
        long steps = 0;
        int dirIndex = 0;
        List<short> ids = validNodes
            .Where(n => n.IdLastDigit == IdA)
            .Select(n => n.Id)
            .ToList();

        while (ids.Any(id => (id % 26) != IdZ))
        {
            for (int i = 0; i < ids.Count; i++) ids[i] = Nodes[ids[i]].GetNextId(Directions[dirIndex]);

            dirIndex++;
            steps++;
            if (dirIndex == Directions.Count) dirIndex = 0;
        }

        return steps;
    }
}
