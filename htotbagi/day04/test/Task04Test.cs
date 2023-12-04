using Day04Src;
using FluentAssertions;
using Xunit;

namespace Day04Tests
{
    public class Task04Test
    {
        Scratchcard card = CreateScratchcard();

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

        [Theory]
        [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 4)]
        [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)]
        [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 2)]
        [InlineData("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 1)]
        [InlineData("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0)]
        [InlineData("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 0)]
        public void Should_return_matching_number(string input, int expected)
        {
            // Act
            int result = card.CalculateMatchingNumber(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(new[] { 1, 1, 1, 1, 1, 1 }, new[] { 1, 2, 2, 2, 2, 1 }, 0)]
        [InlineData(new[] { 1, 2, 2, 2, 2, 1 }, new[] { 1, 2, 4, 4, 2, 1 }, 1)]
        [InlineData(new[] { 1, 2, 4, 4, 2, 1 }, new[] { 1, 2, 4, 8, 6, 1 }, 2)]
        [InlineData(new[] { 1, 2, 4, 8, 6, 1 }, new[] { 1, 2, 4, 8, 14, 1 }, 3)]
        [InlineData(new[] { 1, 2, 4, 8, 14, 1 }, new[] { 1, 2, 4, 8, 14, 1 }, 4)]
        public void Should_add_copies_of_duplicate_scratch_cards(int[] firstInput, int[] secondInput, int iteration)
        {
            // Arrange
            string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day04Src\\data\\smallScratchboard.txt";
            List<string> scratchboards = card.ReadFileToList(filePath);

            List<int> previousCounter = new List<int>(firstInput);
            List<int> expectedResult = new List<int>(secondInput);

            int totalCardNumber = scratchboards.Count;

            // Act
            List<int> result = card.AddCopiesOfScratchCard(scratchboards, previousCounter, iteration);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Theory]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day04Src\\data\\smallScratchboard.txt", 30)]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day04Src\\data\\bigScratchboard.txt", 5132675)]
        public void Should_count_all_duplicate_cards(string filePath, int expectedSum)
        {
            // Arrange
            List<string> scratchboards = card.ReadFileToList(filePath);
            int totalCardNumber = scratchboards.Count;
            List<int> initialCardCounter = Enumerable.Repeat(1, totalCardNumber).ToList();

            // Act
            int sum = card.CountAllScratchBoards(scratchboards, totalCardNumber, ref initialCardCounter);

            // Assert
            sum.Should().Be(expectedSum);
        }

        private static Scratchcard CreateScratchcard()
        {
            return new Scratchcard();
        }
    }
}