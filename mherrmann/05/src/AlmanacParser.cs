namespace Day05;
enum ParserMode : byte { Empty, SeedToSoil, SoilToFertilizer, FertilizerToWater, WaterToLight, LightToTemperature, TemperatureToHumidity, HumitityToLocation }

public static class AlmanacParser
{
    public static List<long> ParseSeedLine(string line)
    {
        string[] parts = line.Split(' ');
        List<long> ret = [];

        if (parts.Length < 1 || parts[0] != "seeds:") throw new ArgumentException($"The line \"{line}\" doesn't begin with \"seeds:\"");
        else if (parts.Length < 2) throw new ArgumentException($"The line\"{line}\" doesn't contain any seeds");

        for (int i = 1; i < parts.Length; i++) ret.Add(long.Parse(parts[i]));

        ret.Sort();

        return ret;
    }

    public static List<MapRange> ParseSeedLineV2(string line)
    {
        string[] parts = line.Split(' ');
        List<MapRange> ret = [];

        if (parts.Length < 1 || parts[0] != "seeds:") throw new ArgumentException($"The line \"{line}\" doesn't begin with \"seeds:\"");
        else if (parts.Length < 2) throw new ArgumentException($"The line\"{line}\" doesn't contain any seeds");

        for (int i = 1; i < parts.Length; i += 2)
        {
            long start = long.Parse(parts[i]);
            long count = long.Parse(parts[i + 1]);
            ret.Add(new(start, count, -1));
        }

        ret.Sort(MapRange.CompareSrc);

        return ret;
    }

    public static void ParseMapLines(List<string> lines, out List<MapRange> ret)
    {
        ret = [];

        foreach (string line in lines)
        {
            string[] parts = line.Split(' ');
            long dest = long.Parse(parts[0]);
            long src = long.Parse(parts[1]);
            long range = long.Parse(parts[2]);

            ret.Add(new(src, range, dest));
        }

        ret.Sort(MapRange.CompareSrc);
    }

    public static List<MapRange> ParseMapLines(List<string> lines)
    {
        List<MapRange> ret = [];
        ParseMapLines(lines, out ret);
        return ret;
    }

    public static CategoryMappings ParseMappings(List<string> lines)
    {
        ParserMode mode = ParserMode.Empty;
        int startIndex = 0;

        List<MapRange> SeedToSoil = [];
        List<MapRange> SoilToFertilizer = [];
        List<MapRange> FertilizerToWater = [];
        List<MapRange> WaterToLight = [];
        List<MapRange> LightToTemperature = [];
        List<MapRange> TemperatureToHumidity = [];
        List<MapRange> HumitityToLocation = [];

        for (int i = 1; i < lines.Count; i++)
        {
            string line = lines[i];
            if (line.Length == 0)
            {
                if (mode != ParserMode.Empty)
                {
                    switch (mode)
                    {
                        case ParserMode.SeedToSoil:
                            ParseMapLines(lines.GetRange(startIndex, i - startIndex), out SeedToSoil);
                            break;

                        case ParserMode.SoilToFertilizer:
                            ParseMapLines(lines.GetRange(startIndex, i - startIndex), out SoilToFertilizer);
                            break;

                        case ParserMode.FertilizerToWater:
                            ParseMapLines(lines.GetRange(startIndex, i - startIndex), out FertilizerToWater);
                            break;

                        case ParserMode.WaterToLight:
                            ParseMapLines(lines.GetRange(startIndex, i - startIndex), out WaterToLight);
                            break;

                        case ParserMode.LightToTemperature:
                            ParseMapLines(lines.GetRange(startIndex, i - startIndex), out LightToTemperature);
                            break;

                        case ParserMode.TemperatureToHumidity:
                            ParseMapLines(lines.GetRange(startIndex, i - startIndex), out TemperatureToHumidity);
                            break;

                        case ParserMode.HumitityToLocation:
                            ParseMapLines(lines.GetRange(startIndex, i - startIndex), out HumitityToLocation);
                            break;
                    }
                }
                mode = ParserMode.Empty;
                continue;
            }
            else if (line.EndsWith("map:"))
            {
                string[] mapParts = line.Split(' ');
                switch (mapParts[0])
                {
                    case "seed-to-soil":
                        mode = ParserMode.SeedToSoil;
                        break;

                    case "soil-to-fertilizer":
                        mode = ParserMode.SoilToFertilizer;
                        break;

                    case "fertilizer-to-water":
                        mode = ParserMode.FertilizerToWater;
                        break;

                    case "water-to-light":
                        mode = ParserMode.WaterToLight;
                        break;

                    case "light-to-temperature":
                        mode = ParserMode.LightToTemperature;
                        break;

                    case "temperature-to-humidity":
                        mode = ParserMode.TemperatureToHumidity;
                        break;

                    case "humidity-to-location":
                        mode = ParserMode.HumitityToLocation;
                        break;
                }
                startIndex = i + 1;
                continue;
            }
        }

        if (mode != ParserMode.Empty)
        {
            switch (mode)
            {
                case ParserMode.SeedToSoil:
                    ParseMapLines(lines.GetRange(startIndex, lines.Count - startIndex - 1), out SeedToSoil);
                    break;

                case ParserMode.SoilToFertilizer:
                    ParseMapLines(lines.GetRange(startIndex, lines.Count - startIndex - 1), out SoilToFertilizer);
                    break;

                case ParserMode.FertilizerToWater:
                    ParseMapLines(lines.GetRange(startIndex, lines.Count - startIndex - 1), out FertilizerToWater);
                    break;

                case ParserMode.WaterToLight:
                    ParseMapLines(lines.GetRange(startIndex, lines.Count - startIndex - 1), out WaterToLight);
                    break;

                case ParserMode.LightToTemperature:
                    ParseMapLines(lines.GetRange(startIndex, lines.Count - startIndex - 1), out LightToTemperature);
                    break;

                case ParserMode.TemperatureToHumidity:
                    ParseMapLines(lines.GetRange(startIndex, lines.Count - startIndex - 1), out TemperatureToHumidity);
                    break;

                case ParserMode.HumitityToLocation:
                    ParseMapLines(lines.GetRange(startIndex, lines.Count - startIndex - 1), out HumitityToLocation);
                    break;
            }
        }

        return new(SeedToSoil, SoilToFertilizer, FertilizerToWater, WaterToLight, LightToTemperature, TemperatureToHumidity, HumitityToLocation);
    }

    public static AlmanacV1 ParseDocumentV1(List<string> lines)
    {
        List<long> seeds = ParseSeedLine(lines[0]);
        CategoryMappings mappings = ParseMappings(lines.GetRange(1, lines.Count - 1));

        return new(seeds, mappings);
    }

    public static AlmanacV2 ParseDocumentV2(List<string> lines)
    {
        List<MapRange> seeds = ParseSeedLineV2(lines[0]);
        CategoryMappings mappings = ParseMappings(lines.GetRange(1, lines.Count - 1));

        return new(seeds, mappings);
    }
}
