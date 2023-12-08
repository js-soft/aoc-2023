namespace Day05;

using System.Text;

public enum IntersectionResult : byte { ABiggerB, AIntersectsBLeft, AContainsB, AIntersectsBRight, BContainsA, ASmallerB, AEqualsB, Error }

public struct MapRange(long Src, long Count, long Dest)
{
    public long Src = Src;
    public long Count = Count;
    public long Dest = Dest;

    public long SrcEnd
    {
        get => Src + Count - 1;
    }

    public bool IsEmpty
    {
        get => Count < 1;
    }

    public bool Contains(long value) => value >= Src && value < Src + Count;

    public IntersectionResult Intersects(MapRange b)
    {
        /*if (b.SrcEnd < Src) return IntersectionResult.ABiggerB;
        else if (b.Src < Src && b.SrcEnd < SrcEnd) return IntersectionResult.AIntersectsBLeft;
        else if (b.Src >= Src && b.SrcEnd < SrcEnd) return IntersectionResult.AContainsB;
        else if (b.Src >= Src && b.Src < SrcEnd && b.SrcEnd >= SrcEnd) return IntersectionResult.AIntersectsBRight;
        else if (b.Src > SrcEnd) return IntersectionResult.ASmallerB;
        else if (b.Src < Src && b.SrcEnd >= SrcEnd) return IntersectionResult.BContainsA;*/

        long bEnd = b.SrcEnd;
        long End = SrcEnd;

        if (b.Src < Src)
        {
            if (bEnd < Src) return IntersectionResult.ABiggerB;
            else if (bEnd < End) return IntersectionResult.AIntersectsBLeft;
            else if (bEnd >= End) return IntersectionResult.BContainsA;
        } else if (b.Src >= Src)
        {
            if (b.Src == Src && bEnd == End) return IntersectionResult.AEqualsB;
            else if (bEnd <= End) return IntersectionResult.AContainsB;
            else if (b.Src > End) return IntersectionResult.ASmallerB;
            else if (bEnd > End) return IntersectionResult.AIntersectsBRight;
        }

        return IntersectionResult.Error;
    }

    public long GetOffset(long id) => id - Src;

    public static int CompareSrc(MapRange a, MapRange b) => a.Src.CompareTo(b.Src);

    public override string ToString() => $"({Src} - {SrcEnd} -> {Dest})";
}

public record CategoryMappings(
    List<MapRange> SeedToSoil,          List<MapRange> SoilToFertilizer,   List<MapRange> FertilizerToWater,
    List<MapRange> WaterToLight,        List<MapRange>LightToTemperature,  List<MapRange> TemperatureToHumidity,
    List<MapRange> HumitityToLocation
);

public abstract class Almanac<T>(List<T> seeds, CategoryMappings mappings)
{
    public List<T> Seeds = seeds;
    public CategoryMappings Mappings = mappings;

    public abstract long RunCompleteSeedToLocation(T seed);

    public long FindLowestLocationFromSeeds() => seeds
        .Select(RunCompleteSeedToLocation)
        .Min();

    public override string ToString()
    {
        StringBuilder builder = new();

        builder.Append("Seeds: ");
        foreach (T s in seeds) builder.Append(s).Append(' ');
        builder.AppendLine("\n");

        builder.AppendLine("Seeds -> Soil");
        foreach (MapRange r in Mappings.SeedToSoil) builder.Append(r).Append(' ');
        builder.AppendLine("\n");

        builder.AppendLine("Soil -> Fertilizer");
        foreach (MapRange r in Mappings.SoilToFertilizer) builder.Append(r).Append(' ');
        builder.AppendLine("\n");

        builder.AppendLine("Fertilizer -> Water");
        foreach (MapRange r in Mappings.FertilizerToWater) builder.Append(r).Append(' ');
        builder.AppendLine("\n");

        builder.AppendLine("Water -> Light");
        foreach (MapRange r in Mappings.WaterToLight) builder.Append(r).Append(' ');
        builder.AppendLine("\n");

        builder.AppendLine("Light -> Temperature");
        foreach (MapRange r in Mappings.LightToTemperature) builder.Append(r).Append(' ');
        builder.AppendLine("\n");

        builder.AppendLine("Temperature -> Humidity");
        foreach (MapRange r in Mappings.TemperatureToHumidity) builder.Append(r).Append(' ');
        builder.AppendLine("\n");

        builder.AppendLine("Humitity -> Location");
        foreach (MapRange r in Mappings.HumitityToLocation) builder.Append(r).Append(' ');

        return builder.ToString();
    }
}

public class AlmanacV1(List<long> seeds, CategoryMappings mappings) : Almanac<long>(seeds, mappings)
{

    public static long GetMapping(List<MapRange> map, long id)
    {
        foreach (MapRange range in map)
        {
            if (range.Contains(id)) return range.Dest + range.GetOffset(id);
        }

        return id;
    }

    public override long RunCompleteSeedToLocation(long seed) =>
        GetMapping(
            Mappings.HumitityToLocation,
            GetMapping(
                Mappings.TemperatureToHumidity,
                GetMapping(
                    Mappings.LightToTemperature,
                    GetMapping(
                        Mappings.WaterToLight,
                        GetMapping(
                            Mappings.FertilizerToWater,
                            GetMapping(
                                Mappings.SoilToFertilizer,
                                GetMapping(
                                    Mappings.SeedToSoil,
                                    seed
                                )
                            )
                        )
                    )
                )
            )
        );
}

public class AlmanacV2(List<MapRange> seeds, CategoryMappings mappings) : Almanac<MapRange>(seeds, mappings)
{

    private static MapRange SmallerRange(MapRange range, MapRange seed) => new(seed.Src, range.Src - seed.Src, -1);
    private static MapRange InsideRange(MapRange range, MapRange seed)
    {
        long start = Math.Max(range.Src, seed.Src);
        long offset = start - range.Src;
        long count = Math.Min(range.SrcEnd - start, seed.Count);

        return new(range.Dest + offset, count, -1);
    }

    public static List<MapRange> GetMappings(List<MapRange> map, MapRange seed)
    {
        if (map.Count == 0) return [seed];

        List<MapRange> res = [];

        foreach (MapRange range in map)
        {
            if (seed.IsEmpty) return res;

            IntersectionResult i = range.Intersects(seed);

            switch (i)
            {
                case IntersectionResult.ABiggerB:
                    res.Add(seed);
                    return res;

                case IntersectionResult.AIntersectsBLeft:
                    res.Add(SmallerRange(range, seed));
                    res.Add(InsideRange(range, seed));
                    return res;

                case IntersectionResult.AContainsB:
                    res.Add(InsideRange(range, seed));
                    return res;

                case IntersectionResult.AIntersectsBRight:
                    MapRange inside = InsideRange(range, seed);
                    seed.Src = range.SrcEnd;
                    seed.Count -= inside.Count;
                    res.Add(inside);
                    break;

                case IntersectionResult.BContainsA:
                    MapRange left = SmallerRange(range, seed);
                    inside = InsideRange(range, seed);
                    seed.Src = range.SrcEnd;
                    seed.Count -= (left.Count + inside.Count);

                    res.Add(left);
                    res.Add(inside);
                    break;

                case IntersectionResult.AEqualsB:
                    res.Add(new(range.Src, range.Count, -1));
                    return res;

                case IntersectionResult.Error:
                    throw new ArgumentException($"The range {range} couldn't be intersected with seed range {seed}");
            }
        }

        if (!seed.IsEmpty) res.Add(seed);


        return res;
    }

    public static List<MapRange> GetMappings(List<MapRange> map, List<MapRange> seeds) => seeds
        .SelectMany(s => GetMappings(map, s))
        .ToList();

    public override long RunCompleteSeedToLocation(MapRange seed) =>
        GetMappings(
            Mappings.HumitityToLocation,
            GetMappings(
                Mappings.TemperatureToHumidity,
                GetMappings(
                    Mappings.LightToTemperature,
                    GetMappings(
                        Mappings.WaterToLight,
                        GetMappings(
                            Mappings.FertilizerToWater,
                            GetMappings(
                                Mappings.SoilToFertilizer,
                                GetMappings(
                                    Mappings.SeedToSoil,
                                    seed
                                )
                            )
                        )
                    )
                )
            )
        )
        .Select(r => r.Src)
        .Min();
}