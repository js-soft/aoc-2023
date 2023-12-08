namespace Day02;

using Advent2023;
using FluentAssertions;

public class Day0201Test
{

    [Theory]
    [InlineData("Game 1: 1 red, 5 green, 3 blue", 1, "1: (1,5,3)")]         //RGB Draws
    [InlineData("Game 2: 69 red, 420 green, 35 blue", 2, "2: (69,420,35)")]
    [InlineData("Game 1: 3 blue, 1 red, 5 green", 1, "1: (1,5,3)")]         //BRG Draws
    [InlineData("Game 2: 35 blue, 69 red, 420 green", 2, "2: (69,420,35)")]
    [InlineData("Game 1: 3 blue", 1, "1: (0,0,3)")]                         //B Draws
    [InlineData("Game 2: 35 blue", 2, "2: (0,0,35)")]
    public void Test_ParseLine_With_Different_Inputs(string input, int expectedId, string expectedToString)
    {
        Game game = GameParser.ParseLine(input);

        game.Id.Should().Be(expectedId, $"Game ID is {game.Id}, instead of {expectedId}");
        game.ToString().Should().Be(expectedToString);
    }

    [Theory]
    [InlineData("Game 1: ")]
    [InlineData("Game 2: ")]
    public void Test_ParseLine_With_Empty_Draw_Should_Throw_FormatException(string input)
    {
        Action parse = () => GameParser.ParseLine(input);
        parse.Should().Throw<FormatException>();
    }

    [Fact]
    public void Test_ParseDocument_With_Example_Data()
    {
        string[] lines = File.ReadAllLines(FSUtil.GetResource("input-example.txt"));
        string[] outputs = [
            "1: (4,0,3) (1,2,6) (0,2,0)",
            "2: (0,2,1) (1,3,4) (0,1,1)",
            "3: (20,8,6) (4,13,5) (1,5,0)",
            "4: (3,1,6) (6,3,0) (14,3,15)",
            "5: (6,3,1) (1,2,2)"
        ];

        List<Game> games = GameParser.ParseDocument(lines);

        games
            .Select(game => game.ToString())
            .Should().BeEquivalentTo(outputs);
    }

    [Fact]
    public void Test_GetPossibleGames_With_Example_Data()
    {
        string[] lines = File.ReadAllLines(FSUtil.GetResource("input-example.txt"));

        List<Game> games = GameParser.ParseDocument(lines);

        //Example values from Website
        int red = 12;
        int green = 13;
        int blue = 14;
        int result = 8;

        Game.GetPossibleGames(games, red, green, blue)
            .Should().Be(result);
    }
}