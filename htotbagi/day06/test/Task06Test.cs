using Day06Src;
using FluentAssertions;
using Xunit;

namespace Day06Tests
{
    public class Task06Test
    {
        Race newRace = CreateRace();

        [Theory]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day06Src\\data\\exampleRace.txt", new[] { 7, 15, 30 })]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day06Src\\data\\realRace.txt", new[] { 48, 87, 69, 81 })]
        public void Should_get_times(string filePath, int[] expected)
        {
            // Act
            List<int> result = newRace.GetTimes(filePath);

            // Assert
            result.Should().Equal(expected);
        }

        [Theory]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day06Src\\data\\exampleRace.txt", new[] { 9, 40, 200 })]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day06Src\\data\\realRace.txt", new[] { 255, 1288, 1117, 1623 })]
        public void Should_get_distances(string filePath, int[] expected)
        {
            // Act
            List<int> result = newRace.GetDistances(filePath);

            // Assert
            result.Should().Equal(expected);
        }

        [Theory]
        [InlineData(0, 4)]
        [InlineData(1, 8)]
        [InlineData(2, 9)]
        public void Should_return_number_of_different_ways(int raceNumber, int expected)
        {
            // Arrange
            string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day06Src\\data\\exampleRace.txt";

            // Act
            int result = newRace.CalculateDifferentWaysForSpecificRace(filePath, raceNumber);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day06Src\\data\\exampleRace.txt", 288)]
        [InlineData("C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day06Src\\data\\realRace.txt", 252000)]
        public void Should_return_margin_of_error(string filePath, int expected)
        {
            // Act
            int result = newRace.GetMarginError(filePath);

            // Assert
            result.Should().Be(expected);
        }

        private static Race CreateRace()
        {
            return new Race();
        }
    }
}