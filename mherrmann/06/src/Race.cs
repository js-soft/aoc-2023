namespace Day06;

public record Race(long Time, long Distance)
{
    public double GetTraveledDistance(double timeButtonPressed) => Time * timeButtonPressed - Math.Pow(timeButtonPressed, 2); //f(x) = tx - x^2

    public bool IsRecordBeaten(double timeButtonPressed) => GetTraveledDistance(timeButtonPressed) > Distance;

    public Range RecordRange
    {
        get
        {
            long min;
            long max;
            long half = Time / 2;

            for (min = half; IsRecordBeaten(min); min--) ;
            for (max = half; IsRecordBeaten(max); max++) ;

            return new(min + 1, max - 1);
        }
    }

    public long RecordCount
    {
        get => RecordRange.Count;
    }
}

public record Range(long Min, long Max)
{
    public long Count
    {
        get => Max - Min + 1;
    }
}

public class RaceManager(List<Race> races)
{
    public List<Race> Races = races;

    public long GetRecordCount(Race race) => race.RecordCount;

    public long GetRecordErrorMargin() => Races
        .Select(GetRecordCount)
        .Aggregate((a, b) => a * b);
}