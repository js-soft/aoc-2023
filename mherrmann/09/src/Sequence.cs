namespace Day09;

public record Sequence(List<long> Entries)
{
    public long ExtrapolateForward()
    {
        List<List<long>> sequences = CalculateDifferences();

        //Add up values
        sequences.Last().Add(0);
        for (int i = sequences.Count - 2; i >= 0; i--)
            sequences[i].Add(sequences[i].Last() + sequences[i + 1].Last());


        return sequences.First().Last();
    }

    public long ExtrapolateBackwards()
    {
        List<List<long>> sequences = CalculateDifferences();

        sequences.Last().Insert(0, 0);
        for (int i = sequences.Count - 2; i >= 0; i--)
            sequences[i].Insert(0, sequences[i].First() - sequences[i + 1].First());

        return sequences.First().First();
    }

    private List<List<long>> CalculateDifferences()
    {
        List<List<long>> sequences = [Entries];

        //Calculate differences
        while (sequences.Last().Any(l => l != 0))
        {
            List<long> last = sequences.Last();
            List<long> diff = [];

            if (last.Count == 1) diff.Add(0);
            else
                for (int i = 0; i < last.Count - 1; i++)
                    diff.Add(last[i + 1] - last[i]);

            sequences.Add(diff);
        }

        return sequences;
    }
}

public class SensorData(List<Sequence> sequences)
{
    private List<Sequence> Sequences = sequences;

    public long CalculateForwardExtrapolatedSum() => Sequences
        .Select(s => s.ExtrapolateForward())
        .Aggregate((a, b) => a + b);

    public long CalculateBackwardExtrapolatedSum() => Sequences
        .Select(s => s.ExtrapolateBackwards())
        .Aggregate((a, b) => a + b);
}