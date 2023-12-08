namespace Day05;

using FluentAssertions;
using Advent2023;

public class Day05Test
{
    [Fact]
    public void Test_RunCompleteSeedToLocation()
    {
        List<long> seeds = [10, 26, 30];
        CategoryMappings mappings = new(
            [new(8, 5, 13)],
            [new(25, 3, 19)],
            [new(29, 3, 44)],
            [new(14, 3, 4)],
            [new(44, 3, 68)],
            [new(68, 3, 419)],
            [new(419, 3, 68), new(19, 3, 69), new(4, 3, 70)]
        );
        AlmanacV1 a = new(seeds, mappings);

        List<long> desiredValues = [71, 70, 69];

        seeds
            .Select(a.RunCompleteSeedToLocation)
            .ToList()
            .Should().Equal(desiredValues);
    }

    [Fact]
    public void Test_FindLowestLocationFromSeeds()
    {
        List<long> seeds = [10, 26, 30];
        CategoryMappings mappings = new(
            [new(8, 5, 13)],
            [new(25, 3, 19)],
            [new(29, 3, 44)],
            [new(14, 3, 4)],
            [new(44, 3, 68)],
            [new(68, 3, 419)],
            [new(419, 3, 68), new(19, 3, 69), new(4, 3, 70)]
        );
        AlmanacV1 a = new(seeds, mappings);

        long desiredResult = 69;

        a.FindLowestLocationFromSeeds().Should().Be(desiredResult);
    }

    [Fact]
    public void Test_FindLowestLocationFromSeeds_With_Example_Input()
    {
        string[] lines = FSUtil.ReadResource("input-example.txt");
        AlmanacV1 a = AlmanacParser.ParseDocumentV1([.. lines]);

        long desiredResult = 35;

        a.FindLowestLocationFromSeeds().Should().Be(desiredResult);
    }

    [Fact]
    public void Test_ParseSeedLineV2()
    {
        string line = "seeds: 79 14 55 13";
        List<MapRange> desiredResult = [new(79, 14, -1), new(55, 13, -1)];
        desiredResult.Sort(MapRange.CompareSrc);

        AlmanacParser.ParseSeedLineV2(line).Should().Equal(desiredResult);
    }

    [Fact]
    public void Test_FindLowestLocationFromSeeds_V2_With_Example_Input()
    {
        string[] lines = FSUtil.ReadResource("input-example.txt");
        AlmanacV2 a = AlmanacParser.ParseDocumentV2([.. lines]);

        long desiredResult = 46;

        a.FindLowestLocationFromSeeds().Should().Be(desiredResult);
    }

    [Fact]
    public void Test_Intersection_Between_MapRanges()
    {
        //AContainsB, AIntersectsBRight, BContainsA, ASmallerB, AEqualsB
        List<(MapRange range, MapRange seed, IntersectionResult desiredResult)> data = [
            (new(10, 10, 1), new(5, 5, -1), IntersectionResult.ABiggerB),
            (new(10, 10, 1), new(5, 7, -1), IntersectionResult.AIntersectsBLeft),
            (new(10, 10, 1), new(11, 2, -1), IntersectionResult.AContainsB),
            (new(10, 10, 1), new(11, 10, -1), IntersectionResult.AIntersectsBRight),
            (new(10, 10, 1), new(9, 20, -1), IntersectionResult.BContainsA),
            (new(10, 10, 1), new(20, 5, -1), IntersectionResult.ASmallerB),
            (new(10, 10, 1), new(10, 10 ,-1), IntersectionResult.AEqualsB)
        ];

        foreach ((MapRange range, MapRange seed, IntersectionResult desiredResult) in data)
        {
            range.Intersects(seed).Should().Be(desiredResult);
        }
    }
}