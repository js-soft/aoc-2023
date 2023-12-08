namespace Day04;

public record Card(int ID, List<int> WinningNumbers, List<int> OwnNumbers)
{
    public int MatchCount
    {
        get => OwnNumbers.Where(WinningNumbers.Contains).Count();
    }

    public int Value
    {
        get
        {
            int count = MatchCount;
            if (count == 0) return 0;
            else return Convert.ToInt32(Math.Pow(2, count - 1));
        }
    }
}

public struct CardInfo(Card card, int count)
{
    public Card Card = card;
    public int Count = count;
}

public class CardGame(List<Card> cards)
{

    public List<Card> Cards = cards;

    public int CalculateCardValues() => Cards
        .Select(c => c.Value)
        .Aggregate((a, b) => a + b);

    public int CalculateCardMatches()
    {
        Dictionary<int, CardInfo> infos = [];
        Cards.ForEach(c => infos.Add(c.ID, new(c, 1)));

        for (int id = 1; id <= infos.Keys.Max(); id++)
        {
            CardInfo info = infos[id];
            int matches = info.Card.MatchCount;

            for (int j = 1; j <= matches; j++)
            {
                CardInfo i = infos[id + j];
                i.Count += info.Count;
                infos[id + j] = i;
            }
        }

        return infos.Values
            .Select(i => i.Count)
            .Aggregate((a, b) => a + b);
    }
}