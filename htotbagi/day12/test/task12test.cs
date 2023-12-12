using FluentAssertions;
using src.day12_hot_springs;
using Xunit;

namespace Day12_Hot_springs
{
    public class RecordTests
    {
        string filePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day12-hot-springs\\data\\exampleData.txt";
        string realFilePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day12-hot-springs\\data\\realData.txt";

        HotSpring newHotSpring = CreateHotSpring();

        [Fact]
        public void Should_return_symbols_and_numbers_from_input_file()
        {
            // Arrange
            var symbolStrings = new List<string>{ { "???.###" }, { ".??..??...?##." }, { "?#?#?#?#?#?#?#?" },
                                            { "????.#...#..."}, { "????.######..#####." }, { "?###????????" } };

            var sizeLists = new List<List<int>>{ new List<int>{ 1, 1, 3 }, new List<int>{ 1, 1, 3 }, new List<int>{ 1, 3, 1, 6 },
                                                new List<int>{ 4, 1, 1 }, new List<int>{ 1, 6, 5 }, new List<int>{ 3, 2, 1 } };

            // Act
            (List<string> stringResult, List<List<int>> intResult) = newHotSpring.ReadFile(filePath);

            // Assert
            stringResult.Should().BeEquivalentTo(symbolStrings);
            intResult.Should().BeEquivalentTo(sizeLists);
        }

        [Fact]
        public void Should_return_combinations_that_mach_given_symbols()
        {
            // Arrange
            (List<string> resultStrings, List<List<int>> resultIntegers) = newHotSpring.ReadFile(filePath);
            List<string> expectedSymbols = new List<string> { ".##.###", "#.#.###", "##..###" };

            // Act
            List<string> result = newHotSpring.SelectStringsWithMatching(resultStrings[0], resultIntegers[0]);

            // Assert
            result.Should().BeEquivalentTo(expectedSymbols);
        }

        [Theory]
        [InlineData("???.###", new int[] { 1, 1, 3 }, 1)]
        [InlineData(".??..??...?##.", new int[] { 1, 1, 3 }, 4)]
        [InlineData("?#?#?#?#?#?#?#?", new int[] { 1, 3, 1, 6 }, 1)]
        [InlineData("????.#...#...", new int[] { 4, 1, 1 }, 1)]
        [InlineData("????.######..#####.", new int[] { 1, 6, 5 }, 4)]
        [InlineData("?###????????", new int[] { 3, 2, 1 }, 10)]
        public void Should_return_number_of_arrangements(string input, int[] numbers, int expected)
        {
            int result = newHotSpring.CalculateFinalCombinations(input, numbers);

            result.Should().Be(expected);
        }

        [Fact]
        public void Should_return_sum_of_all_arrangements()
        {
            // Act
            int result = newHotSpring.GetFinalArrangementCount(realFilePath);

            // Assert
            result.Should().Be(7017);
        }

        private static HotSpring CreateHotSpring()
        {
            return new HotSpring();
        }
    }
}