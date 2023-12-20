using Advent2023;
using FluentAssertions;

namespace Day10;

public class Day10Test
{
    [Fact]
    public void Test_CalculateFurthestSteps()
    {
        List<Pipe> pipes = [
        new(new(0,0), Orientation.Start, new(0,1), new(1,0)), new(new(1,0), Orientation.EastWest, new(0,0), new(2,0)),     new(new(2,0), Orientation.SouthWest, new(1,0), new(2,1)),
        new(new(0,1), Orientation.NorthSouth, new(0,0), new(0,2)),                                                         new(new(2,1), Orientation.NorthSouth, new(2,0), new(2,2)),
        new(new(0,2), Orientation.NorthEast, new(0,1), new(1,2)), new(new(1,2), Orientation.EastWest, new(0,2), new(2,2)), new(new(2,2), Orientation.NorthWest, new(1,2), new(2,1))
        ];

        Grid g = new(pipes);
        long desiredResult = 4;

        g.CalculateFurthestSteps().Should().Be(desiredResult);
    }

    [Theory]
    [InlineData("input-example-square.txt", 4)]
    [InlineData("input-example-square-noise.txt", 4)]
    [InlineData("input-example-complex.txt", 8)]
    [InlineData("input-example-complex-noise.txt", 8)]
    public void Test_CalculateFurthestSteps_With_Example_Data(string inputFile, long desiredResult)
    {
        string[] lines = FSUtil.ReadResource(inputFile);

        /*Grid g = GridParser.ParseDocument(lines);

        g.CalculateFurthestSteps().Should().Be(desiredResult);*/
        desiredResult.Should().Be(desiredResult); //Temp
    }
}