namespace Day07;

public static class CardParser
{
    private static readonly Dictionary<char, Card> handDecodingMap = new() {
        {'2', Card.Two},
        {'3', Card.Three},
        {'4', Card.Four},
        {'5', Card.Five},
        {'6', Card.Six},
        {'7', Card.Seven},
        {'8', Card.Eight},
        {'9', Card.Nine},
        {'T', Card.Ten},
        {'J', Card.Jack},
        {'Q', Card.Queen},
        {'K', Card.King},
        {'A', Card.Ace}
    };

    public static Card[] ParseEncodedHandString(string encoded, bool useJoker = false)
    {
        Card[] res = new Card[encoded.Length];

        for (int i = 0; i < encoded.Length; i++)
        {
            if (useJoker && encoded[i] == 'J') res[i] = Card.Joker;
            else res[i] = handDecodingMap[encoded[i]];
        }

        return res;
    }

    public static Category ParseCardCategory(Card[] cards)
    {
        if (cards.Length != 5) throw new ArgumentException($"Exactly 5 cards are needed ({cards.Length} given)");

        var groups = cards
            .GroupBy(c => c)
            .Select(g => (g.Key, g.Count()))
            .ToDictionary();

        //Add Joker to biggest group
        if (groups.TryGetValue(Card.Joker, out int value))
        {
            int num = value;
            groups.Remove(Card.Joker);

            if (num == 5) return Category.FiveOfAKind; //Edge case for JJJJJ: Treat it as five of a kind

            var maxGroup = groups.MaxBy(g => g.Value);
            groups[maxGroup.Key] = maxGroup.Value + num;
        }

        List<int> groupSizes = groups
            .Select(g => g.Value)
            .ToList();
        
        switch (groups.Count)
        {
            case 1:
                return Category.FiveOfAKind;

            case 2:
                if (groupSizes.Max() == 4) return Category.FourOfAKind;  //4,1 or 1,4
                else return Category.FullHouse;                          //3,2 or 2,3

            case 3:
                if (groupSizes.Max() == 3) return Category.ThreeOfAKind; //3,1,1 or 1,3,1 or 1,1,3
                else return Category.TwoPair;                            //1,2,2 or 2,1,2 or 2,2,1
            case 4:
                return Category.OnePair;                                 //2,1,1,1 or 1,2,1,1 or 1,1,2,1 or 1,1,1,2

            default:
                return Category.HighCard;
        }
    }

    public static Hand ParseHandLine(string line, bool useJoker = false)
    {
        string[] parts = line.Split(' ');
        return new(parts[0], int.Parse(parts[1]), useJoker);
    }

    public static Game ParseDocument(ICollection<string> lines, bool useJoker = false) => new(
        lines
            .Select(l => ParseHandLine(l, useJoker))
            .ToList()
        );
}
