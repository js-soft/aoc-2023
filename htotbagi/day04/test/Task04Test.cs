using Day04Src;
using FluentAssertions;
using Xunit;

namespace Day04Tests
{
    public class Task04Test
    {
        Scratchcard card = new Scratchcard();

        [Theory]
        [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", new int[] { 41, 48, 83, 86, 17 })]
        [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", new int[] { 13, 32, 20, 16, 61 })]
        [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", new int[] { 1, 21, 53, 59, 44 })]
        public void Should_return_winning_numbers(string input, int[] expected)
        {
            // Act
            int[] result = card.GetWinningNumbers(input);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", new int[] { 83, 86, 6, 31, 17, 9, 48, 53 })]
        [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", new int[] { 61, 30, 68, 82, 17, 32, 24, 19 })]
        [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", new int[] { 69, 82, 63, 72, 16, 21, 14, 1 })]
        public void Should_return_current_numbers(string input, int[] expected)
        {
            // Act
            int[] result = card.GetCurrentNumbers(input);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8)]
        [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
        [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2)]
        [InlineData("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1)]
        [InlineData("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0)]
        [InlineData("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0)]
        public void Should_return_number_of_points(string input, int expected)
        {
            // Act
            int result = card.CalculateNumberOfPoints(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day04Src\\data\\smallScratchboard.txt", 13)]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day04Src\\data\\bigScratchboard.txt", 21959)]
        public void Should_calculate_total_number_of_points(string filePath, int expectedTotalPoints)
        {
            // Arrange
            List<string> scratchboards = card.ReadFileToList(filePath);

            // Act
            int result = card.CalculateTotalNumberOfPoints(scratchboards);

            // Assert
            result.Should().Be(expectedTotalPoints);
        }
    }
}