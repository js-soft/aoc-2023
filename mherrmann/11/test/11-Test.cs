using Advent2023;
using FluentAssertions;

namespace Day11;

public class Day11Test
{
    [Theory]
    [InlineData(new int[] { 0, 0 }, new int[] { 1, 0 }, 1)]
    [InlineData(new int[] { 0, 0 }, new int[] { 0, 1 }, 1)]
    [InlineData(new int[] { 1, 0 }, new int[] { 0, 0 }, 1)]
    [InlineData(new int[] { 0, 1 }, new int[] { 0, 0 }, 1)]
    [InlineData(new int[] { 0, 0 }, new int[] { 1, 1 }, 2)]
    [InlineData(new int[] { 1, 5 }, new int[] { 1, 1 }, 7)]
    [InlineData(new int[] { 1, 6 }, new int[] { 5, 11 }, 16)]
    public void Test_Simple_Paths(int[] p1, int[] p2, int desiredResult)
    {
        List<Galaxy> galaxies = [new(p1[0], p1[1]), new(p2[0], p2[1])];
        Universe u = new(galaxies, 1);

        u.CalculateShortestPaths().Should().Be(desiredResult);
    }

    [Theory]
    [InlineData(new int[] { 0,0, 1,0, 0,1 }, 4)]
    [InlineData(new int[] { 0,0, 1,0, 0,1, 1,1 }, 8)] //1+1+2+2+1+1
    public void Test_Multiple_Paths(int[] data, int desiredResult)
    {
        List<Galaxy> galaxies = [];

        for (int i = 0; i < data.Length; i += 2)
            galaxies.Add(new(data[i], data[i + 1]));

        Universe u = new(galaxies, 1);

        u.CalculateShortestPaths().Should().Be(desiredResult);
    }

    [Fact]
    public void Test_Paths_With_Example_Input()
    {
        string[] lines = FSUtil.ReadResource("input-example.txt");
        Universe u = GalaxyParser.ParseDocument(lines);
        int desiredResult = 374;

        u.CalculateShortestPaths().Should().Be(desiredResult);
    }

    [Theory]
    [InlineData(new int[] { 0, 0 }, new int[] { 1, 0 }, 2, 1)]
    [InlineData(new int[] { 0, 0 }, new int[] { 0, 2 }, 2, 4)]
    [InlineData(new int[] { 0, 0 }, new int[] { 2, 2 }, 2, 8)]
    public void Test_Simple_Paths_With_Other_Expansion(int[] p1, int[] p2, int expansion, int desiredResult)
    {
        List<Galaxy> galaxies = [new(p1[0], p1[1]), new(p2[0], p2[1])];
        Universe u = new(galaxies, expansion);

        u.CalculateShortestPaths().Should().Be(desiredResult);
    }

    [Theory]
    [InlineData(9, 1030)]
    [InlineData(99, 8410)]
    public void Test_Paths_With_Example_Input_And_Other_Expansion(int expansion, int desiredResult)
    {
        string[] lines = FSUtil.ReadResource("input-example.txt");
        Universe u = GalaxyParser.ParseDocument(lines, expansion);

        u.CalculateShortestPaths().Should().Be(desiredResult);
    }
}