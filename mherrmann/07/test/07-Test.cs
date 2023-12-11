using Advent2023;
using FluentAssertions;

namespace Day07;

public class Day07Test
{
    [Fact]
    public void Test_Decode_Hand_Card_String()
    {
        string encoded = "23456789TJQKA";
        Card[] desiredResults = [Card.Two, Card.Three, Card.Four, Card.Five, Card.Six, Card.Seven, Card.Eight, Card.Nine, Card.Ten, Card.Jack, Card.Queen, Card.King, Card.Ace];
        Card[] desiredResultsJoker = [Card.Two, Card.Three, Card.Four, Card.Five, Card.Six, Card.Seven, Card.Eight, Card.Nine, Card.Ten, Card.Joker, Card.Queen, Card.King, Card.Ace];

        CardParser.ParseEncodedHandString(encoded).Should().Equal(desiredResults);
        CardParser.ParseEncodedHandString(encoded, true).Should().Equal(desiredResultsJoker);
    }

    [Theory]
    [InlineData("AAAAA", Category.FiveOfAKind)]
    [InlineData("AA8AA", Category.FourOfAKind)]
    [InlineData("23332", Category.FullHouse)]
    [InlineData("TTT98", Category.ThreeOfAKind)]
    [InlineData("23432", Category.TwoPair)]
    [InlineData("A23A4", Category.OnePair)]
    [InlineData("23456", Category.HighCard)]
    public void Test_Calculate_Category(string encoded, Category desiredResult)
    {
        Hand hand = new(encoded, 0);
        hand.Category.Should().Be(desiredResult);
    }

    [Fact]
    public void Test_GetRank()
    {
        List<Hand> hands = [
            new("32T3K", 0),
            new("T55J5", 0),
            new("KK677", 0),
            new("KTJJT", 0),
            new("QQQJA", 0)
        ];
        Game game = new([.. hands]); //Hacky way to ensure the list isn't sorted by the game class
        int[] ranks = [1, 4, 3, 2, 5];

        hands
            .Select(game.GetRank)
            .Should()
            .Equal(ranks);
    }

    [Fact]
    public void Test_GetWinning()
    {
        List<Hand> hands = [
            new("32T3K", 765),
            new("T55J5", 684),
            new("KK677", 28),
            new("KTJJT", 220),
            new("QQQJA", 483)
        ];
        Game game = new([.. hands]); //Hacky way to ensure the list isn't sorted by the game class
        int[] winnings = [765, 684 * 4, 28 * 3, 220 * 2, 483 * 5];

        hands
            .Select(game.GetWinning)
            .Should()
            .Equal(winnings);
    }

    [Fact]
    public void Test_GetTotalWinnings()
    {
        List<Hand> hands = [
            new("32T3K", 765),
            new("T55J5", 684),
            new("KK677", 28),
            new("KTJJT", 220),
            new("QQQJA", 483)
        ];
        Game game = new(hands);
        int totalWinnings = 6440;

        game.GetTotalWinnings().Should().Be(totalWinnings);
    }

    [Fact]
    public void Test_GetTotalWinnings_With_Example_Input()
    {
        string[] lines = FSUtil.ReadResource("input-example.txt");
        Game game = CardParser.ParseDocument(lines);
        int totalWinnings = 6440;

        Game gameV2 = CardParser.ParseDocument(lines, true);
        int totalWinningsV2 = 5905;

        game.GetTotalWinnings().Should().Be(totalWinnings);
        gameV2.GetTotalWinnings().Should().Be(totalWinningsV2);
    }

    [Fact]
    public void Test_GetRank_With_Joker()
    {
        List<Hand> hands = [
            new("32T3K", 0, true),
            new("T55J5", 0, true),
            new("KK677", 0, true),
            new("KTJJT", 0, true),
            new("QQQJA", 0, true)
        ];
        Game game = new([.. hands]); //Hacky way to ensure the list isn't sorted by the game class
        int[] ranks = [1, 3, 2, 5, 4];

        hands
            .Select(game.GetRank)
            .Should()
            .Equal(ranks);
    }

    [Fact]
    public void Test_GetWinning_With_Joker()
    {
        List<Hand> hands = [
            new("32T3K", 765, true),
            new("T55J5", 684, true),
            new("KK677", 28,  true),
            new("KTJJT", 220, true),
            new("QQQJA", 483, true)
        ];
        Game game = new([.. hands]); //Hacky way to ensure the list isn't sorted by the game class
        int[] winnings = [765, 684 * 3, 28 * 2, 220 * 5, 483 * 4];

        hands
            .Select(game.GetWinning)
            .Should()
            .Equal(winnings);
    }

    [Fact]
    public void Test_GetTotalWinnings_With_Joker()
    {
        List<Hand> hands = [
            new("32T3K", 765, true),
            new("T55J5", 684, true),
            new("KK677", 28,  true),
            new("KTJJT", 220, true),
            new("QQQJA", 483, true)
        ];
        Game game = new(hands);
        int totalWinnings = 5905;

        game.GetTotalWinnings().Should().Be(totalWinnings);
    }
}