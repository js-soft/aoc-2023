namespace Day06;

using Advent2023;
using FluentAssertions;

public class Day06Test
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 6)]
    [InlineData(2, 10)]
    [InlineData(3, 12)]
    [InlineData(4, 12)]
    [InlineData(5, 10)]
    [InlineData(6, 6)]
    [InlineData(7, 0)]
    public void Test_GetTraveledDistance(int timeButtonPressed, int desiredResult)
    {
        Race r = new(7, 9);
        r.GetTraveledDistance(timeButtonPressed).Should().Be(desiredResult);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, true)]
    [InlineData(5, true)]
    [InlineData(6, false)]
    [InlineData(7, false)]
    public void Test_IsRecordBeaten(int timeButtonPressed, bool desiredResult)
    {
        Race r = new(7, 9);
        r.IsRecordBeaten(timeButtonPressed).Should().Be(desiredResult);
    }

    [Theory]
    [InlineData(7, 9, 2, 5)]
    [InlineData(15, 40, 4, 11)]
    [InlineData(30, 200, 11, 19)]
    public void Test_CalculateRecordRange(int time, int distance, int min, int max)
    {
        Race r = new(time, distance);
        Range range = r.RecordRange;

        range.Min.Should().Be(min);
        range.Max.Should().Be(max);
    }

    [Theory]
    [InlineData(7, 9, 4)]
    [InlineData(15, 40, 8)]
    [InlineData(30, 200, 9)]
    public void Test_CalculateRecordCount(int time, int distance, int desiredResult)
    {
        Race r = new(time, distance);
        r.RecordCount.Should().Be(desiredResult);
    }

    [Fact]
    public void Test_GetRecordErrorMargin()
    {
        List<Race> races = [
            new(7, 9),
            new(15, 40),
            new(30, 200)
        ];
        RaceManager manager = new(races);
        int desiredResult = 288;
        
        manager.GetRecordErrorMargin().Should().Be(desiredResult);
    }

    [Fact]
    public void Test_GetRecordErrorMargin_With_Example_Data()
    {
        string[] lines = FSUtil.ReadResource("input-example.txt");
        RaceManager manager = RaceParser.ParseDocument(lines);
        int desiredResult = 288;

        manager.GetRecordErrorMargin().Should().Be(desiredResult);
    }

    [Theory]
    [InlineData("Time:      7  15   30", 71530)]
    [InlineData("Distance:  9  40  200", 940200)]
    public void Test_ParseDataLineV2(string line, long desiredResult)
    {
        RaceParser.ParseDataLineV2(line).Should().Be(desiredResult);
    }

    [Fact]
    public void Test_ParseDocumentV2_With_Example_Data()
    {
        string[] lines = FSUtil.ReadResource("input-example.txt");
        RaceManager manager = RaceParser.ParseDocumentV2(lines);
        long desiredResult = 71503;

        manager.GetRecordErrorMargin().Should().Be(desiredResult);
    }
}