using Advent2023;
using FluentAssertions;

namespace Day04;

public class Day04Test
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, 0)]
    [InlineData(new int[] { 1, 2, 3 }, new int[] { 3, 4, 5 }, 1)]
    [InlineData(new int[] { 1, 2, 3 }, new int[] { 2, 3, 4 }, 2)]
    [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }, 4)]
    [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 1, 2, 3 }, 8)]
    public void Test_Card_Value(int[] winningNumbers, int[] ownNumbers, int desiredResult)
    {
        Card c = new(1, [.. winningNumbers], [.. ownNumbers]);

        c.Value.Should().Be(desiredResult);
    }

    [Fact]
    public void Test_Card_Value_With_Example_Input()
    {
        string[] lines = File.ReadAllLines(FSUtil.GetResource("input-example.txt"));
        CardGame game = CardParser.ParseDocument(lines);
        int desiredResult = 13;

        game.CalculateCardValues().Should().Be(desiredResult);
    }

    [Fact]
    public void Test_Card_Matches()
    {
        List<Card> cards = [
            new(1, [1, 2, 3], [1, 1, 2, 3]),
            new(2, [1, 2, 3], [1, 2, 3]),
            new(3, [1, 2, 3], [2, 3, 4]),
            new(4, [1, 2, 3], [3, 4, 5]),
            new(5, [1, 2, 3], [4, 5, 6])
        ];
        CardGame game = new(cards);
        int desiredResult = 31;

        game.CalculateCardMatches().Should().Be(desiredResult);
    }

    [Fact]
    public void Test_Card_Matches_With_Example_Input()
    {
        string[] lines = File.ReadAllLines(FSUtil.GetResource("input-example.txt"));
        CardGame game = CardParser.ParseDocument(lines);
        int desiredResult = 30;

        game.CalculateCardMatches().Should().Be(desiredResult);
    }
}