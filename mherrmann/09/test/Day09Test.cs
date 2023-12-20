using Advent2023;
using FluentAssertions;

namespace Day09;

public class Day09Test
{
    [Theory]
    [InlineData(new long[] { 0, 0 }, 0)]
    [InlineData(new long[] { 0, 1 }, 2)]
    [InlineData(new long[] { 1, 2 }, 3)]
    [InlineData(new long[] { 1, 3, 5 }, 7)]
    public void Test_ExtrapolateForward_Simple_Sequence(long[] sequence, long extrapolatedResult)
    {
        Sequence s = new([.. sequence]);

        s.ExtrapolateForward().Should().Be(extrapolatedResult);
    }

    [Theory]
    [InlineData(new long[] { 0, -1 }, -2)]
    [InlineData(new long[] { 1, 3, 6 }, 10)]
    //[InlineData(new long[] { 1, 2, 4, 8, 16 }, 32)] //Those two will fail, because the expected algorithm can't handle those
    //[InlineData(new long[] { 1, 2, 1 }, 2)]
    public void Test_ExtrapolateForward_Complex_Sequence(long[] sequence, long extrapolatedResult)
    {
        Sequence s = new([.. sequence]);

        s.ExtrapolateForward().Should().Be(extrapolatedResult);
    }

    [Theory]
    [InlineData(5, new long[] { 0, 1 }, new long[] { 1, 2 })]
    [InlineData(12, new long[] { 1, 2 }, new long[] { 1, 3, 5 }, new long[] { 0, 1 })]
    public void Test_CalculateForwardExtrapolatedSum_With_Simple_Sequences(long extrapolatedResult, params long[][] sequences)
    {
        List<Sequence> s = sequences
            .Select(seq => new Sequence([.. seq]))
            .ToList();
        SensorData data = new(s);

        data.CalculateForwardExtrapolatedSum().Should().Be(extrapolatedResult);
    }

    [Fact]
    public void Test_CalculateForwardExtrapolatedSum_With_Example_Input()
    {
        string[] lines = FSUtil.ReadResource("input-example.txt");
        SensorData data = SequenceParser.ParseDocument(lines);
        long extrapolatedResult = 114;

        data.CalculateForwardExtrapolatedSum().Should().Be(extrapolatedResult);
    }

    [Theory]
    [InlineData(new long[] { 0, 0 }, 0)]
    [InlineData(new long[] { 0, 1 }, -1)]
    [InlineData(new long[] { 1, 2 }, 0)]
    [InlineData(new long[] { 1, 3, 5 }, -1)]
    public void Test_ExtrapolateBackwards_Simple_Sequence(long[] sequence, long extrapolatedResult)
    {
        Sequence s = new([.. sequence]);

        s.ExtrapolateBackwards().Should().Be(extrapolatedResult);
    }

    [Theory]
    [InlineData(new long[] { 0, -1 }, 1)]
    [InlineData(new long[] { 1, 3, 6 }, 0)]
    //[InlineData(new long[] { 1, 2, 4, 8, 16 }, 32)] //Those two will fail, because the expected algorithm can't handle those
    //[InlineData(new long[] { 1, 2, 1 }, 2)]
    public void Test_ExtrapolateBackwards_Complex_Sequence(long[] sequence, long extrapolatedResult)
    {
        Sequence s = new([.. sequence]);

        s.ExtrapolateBackwards().Should().Be(extrapolatedResult);
    }

    [Theory]
    [InlineData(-1, new long[] { 0, 1 }, new long[] { 1, 2 })]
    [InlineData(-2, new long[] { 1, 2 }, new long[] { 1, 3, 5 }, new long[] { 0, 1 })]
    public void Test_CalculateBackwardExtrapolatedSum_With_Simple_Sequences(long extrapolatedResult, params long[][] sequences)
    {
        List<Sequence> s = sequences
            .Select(seq => new Sequence([.. seq]))
            .ToList();
        SensorData data = new(s);

        data.CalculateBackwardExtrapolatedSum().Should().Be(extrapolatedResult);
    }

    [Fact]
    public void Test_CalculateBackwardExtrapolatedSum_With_Example_Input()
    {
        string[] lines = FSUtil.ReadResource("input-example.txt");
        SensorData data = SequenceParser.ParseDocument(lines);
        long extrapolatedResult = 2;

        data.CalculateBackwardExtrapolatedSum().Should().Be(extrapolatedResult);
    }
}