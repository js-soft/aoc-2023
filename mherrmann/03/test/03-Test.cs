using Advent2023;
using FluentAssertions;

namespace Day03;

public class Day03Test
{

    [Fact]
    public void Test_AddElement()
    {
        Element e = new(new Size(new Pos(2, 2), 3), 125);
        Grid grid = new();

        grid.AddElement(e);

        grid.OccupiedPositions
            .Should().Contain(new Pos(2, 2))
            .And.Contain(new Pos(3, 2))
            .And.Contain(new Pos(4, 2));
    }

    [Fact]
    public void Test_AddElement_Twice_Should_Throw_ArgumentException()
    {
        Element e = new(new Size(new Pos(2, 2), 3), 125);
        Grid grid = new();

        Action a = () =>
        {
            grid.AddElement(e);
            grid.AddElement(e);
        };

        a.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Test_GetAdjacentPositions()
    {
        Element e = new(new Size(new Pos(2, 2), 3), 125);
        Grid grid = new();
        List<Pos> expectedPositions = [
            new(1, 1), new(2, 1), new(3, 1), new(4, 1), new(5, 1),
            new(1, 2),                                  new(5, 2),
            new(1, 3), new(2, 3), new(3, 3), new(4, 3), new(5, 3)
        ];

        grid.GetAdjacentPositions(e)
            .Should().BeEquivalentTo(expectedPositions);
    }

    [Fact]
    public void Test_IsAdjacentToSymbol()
    {
        Element e = new(new Size(new Pos(2, 2), 3), 125);
        Element s = new(new Pos(5, 3));
        Grid grid = new();

        grid.AddElement(e);
        grid.AddElement(s);

        grid.IsAdjacentToSymbol(e).Should().BeTrue();
    }

    [Fact]
    public void Test_CalculateEngineParts_With_Example_Data()
    {
        string[] lines = File.ReadAllLines(FSUtil.GetResource("input-example.txt"));
        Grid g = GridParser.ParseDocument(lines);
        int desiredResult = 4361;

        g.CalculateEngineParts().Should().Be(desiredResult);
    }

    [Fact]
    public void Test_IsValidGear()
    {
        Element n1 = new(new Size(new Pos(1, 1), 1), 10);
        Element n2 = new(new Size(new Pos(3, 3), 1), 2);
        Element gear = new(new Pos(2, 2), true);
        Grid g = new();

        g.AddElement(n1);
        g.AddElement(n2);
        g.AddElement(gear);

        g.IsValidGear(gear).Should().BeTrue();
    }

    [Fact]
    public void Test_GetGearValue()
    {
        Element n1 = new(new Size(new Pos(1, 1), 1), 10);
        Element n2 = new(new Size(new Pos(3, 3), 1), 2);
        Element gear = new(new Pos(2, 2), true);
        Grid g = new();
        int desiredResult = 20;

        g.AddElement(n1);
        g.AddElement(n2);
        g.AddElement(gear);

        g.GetGearValue(gear).Should().Be(desiredResult);
    }

    [Fact]
    public void Test_CalculateGearValues_With_Example_Data()
    {
        string[] lines = File.ReadAllLines(FSUtil.GetResource("input-example.txt"));
        Grid g = GridParser.ParseDocument(lines, true);
        int desiredResult = 467835;

        g.CalculateGearValues().Should().Be(desiredResult);
    }
}