using Advent2023;
using FluentAssertions;

namespace Day08;

public class Day08Test
{
    private static Map CreateMap(List<Direction> directions, List<Node> nodes)
    {
        return new Map(directions, nodes);
    }

    [Fact]
    public void Test_CalculateSteps_With_Simple_L()
    {
        List<Direction> directions = [Direction.L];
        List<Node> nodes = [
            new("AAA", "ZZZ", "AAA"),
            new("ZZZ", "ZZZ", "ZZZ")
        ];
        Map m = CreateMap(directions, nodes);
        long steps = 1;

        m.CalculateSteps().Should().Be(steps);
    }

    [Fact]
    public void Test_CalculateSteps_With_Simple_LR()
    {
        List<Direction> directions = [Direction.L, Direction.R];
        List<Node> nodes = [
            new("AAA", "AAA", "ZZZ"),
            new("ZZZ", "ZZZ", "ZZZ")
        ];
        Map m = CreateMap(directions, nodes);
        long steps = 2;

        m.CalculateSteps().Should().Be(steps);
    }

    [Fact]
    public void Test_CalculateSteps_With_Repeating_L()
    {
        List<Direction> directions = [Direction.L];
        List<Node> nodes = [
            new("AAA", "BBB", "AAA"),
            new("BBB", "ZZZ", "AAA"),
            new("ZZZ", "ZZZ", "ZZZ")
        ];
        Map m = CreateMap(directions, nodes);
        long steps = 2;

        m.CalculateSteps().Should().Be(steps);
    }

    [Fact]
    public void Test_CalculateSteps_With_Repeating_LR()
    {
        List<Direction> directions = [Direction.L, Direction.R];
        List<Node> nodes = [
            new("AAA", "BBB", "ZZZ"),
            new("BBB", "AAA", "BBB"),
            new("ZZZ", "ZZZ", "ZZZ")
        ];
        Map m = CreateMap(directions, nodes);
        long steps = 4;

        m.CalculateSteps().Should().Be(steps);
    }

    [Theory]
    [InlineData("input-example.txt", 2)]
    [InlineData("input-example-2.txt", 6)]
    public void Test_CalculateSteps_With_Example_Input_Data(string inputFile, long desiredSteps)
    {
        string[] lines = FSUtil.ReadResource(inputFile);
        Map m = MapParser.ParseDocument([.. lines]);

        m.CalculateSteps().Should().Be(desiredSteps);
    }

    [Fact]
    public void Test_CalculateSimultaneousSteps_With_One_Node_And_Simple_L()
    {
        List<Direction> directions = [Direction.L];
        List<Node> nodes = [
            new("AAA", "ZZZ", "AAA"),
            new("ZZZ", "ZZZ", "ZZZ")
        ];
        Map m = CreateMap(directions, nodes);
        long steps = 1;

        m.CalculateSimultaneousSteps().Should().Be(steps);
    }

    [Fact]
    public void Test_CalculateSimultaneousSteps_With_Two_Nodes_And_Simple_L()
    {
        List<Direction> directions = [Direction.L];
        List<Node> nodes = [
            new("AAA", "AAZ", "AAA"),
            new("BBA", "BBZ", "BBA"),
            new("AAZ", "AAZ", "AAZ"),
            new("BBZ", "BBZ", "BBZ")
        ];
        Map m = CreateMap(directions, nodes);
        long steps = 1;

        m.CalculateSimultaneousSteps().Should().Be(steps);
    }

    [Fact]
    public void Test_CalculateSimultaneousSteps_With_Two_Nodes_And_Simple_LR()
    {
        List<Direction> directions = [Direction.L, Direction.R];
        List<Node> nodes = [
            new("AAA", "AAA", "AAZ"),
            new("BBA", "BBA", "BBZ"),
            new("AAZ", "AAZ", "AAZ"),
            new("BBZ", "BBZ", "BBZ")
        ];
        Map m = CreateMap(directions, nodes);
        long steps = 2;

        m.CalculateSimultaneousSteps().Should().Be(steps);
    }

    [Fact]
    public void Test_CalculateSimultaneousSteps_With_Two_Nodes_And_Repeating_L()
    {
        List<Direction> directions = [Direction.L];
        List<Node> nodes = [
            new("AAA", "AAB", "AAA"),
            new("AAB", "AAZ", "AAA"),
            new("AAZ", "AAZ", "AAZ"),

            new("BBA", "BBB", "BBA"),
            new("BBB", "BBZ", "BBA"),
            new("BBZ", "BBZ", "BBZ")
        ];
        Map m = CreateMap(directions, nodes);
        long steps = 2;

        m.CalculateSimultaneousSteps().Should().Be(steps);
    }

    [Fact]
    public void Test_CalculateSimultaneousSteps_With_Two_Nodes_And_Repeating_LR()
    {
        List<Direction> directions = [Direction.L, Direction.R];
        List<Node> nodes = [
            new("AAA", "AAB", "AAZ"),
            new("AAB", "AAA", "AAB"),
            new("AAZ", "AAZ", "AAZ"),

            new("BBA", "BBB", "BBZ"),
            new("BBB", "BBA", "BBB"),
            new("BBZ", "BBZ", "BBZ")
        ];
        Map m = CreateMap(directions, nodes);
        long steps = 4;

        m.CalculateSimultaneousSteps().Should().Be(steps);
    }

    [Fact]
    public void Test_CalculateSimultaneousSteps_With_Example_Input_Data()
    {
        string[] lines = FSUtil.ReadResource("input-example-3.txt");
        Map m = MapParser.ParseDocument([.. lines]);
        long steps = 6;

        m.CalculateSimultaneousSteps().Should().Be(steps);
    }
}