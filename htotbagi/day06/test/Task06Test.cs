using Day06Src;
using FluentAssertions;
using Xunit;

namespace Day06Tests
{
    public class Task06Test
    {
        Race newRace = CreateRace();

        [Theory]
        [InlineData("exampleRace.txt", new ulong[] { 7, 15, 30 })]
        [InlineData("realRace.txt", new ulong[] { 48, 87, 69, 81 })]
        [InlineData("exampleRacePuzzle2.txt", new ulong[] { 71530 })]
        [InlineData("realRacePuzzle2.txt", new ulong[] { 48876981 })]
        public void Should_get_times(string fileName, ulong[] expected)
        {
            // Arrange
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06Src/data/" + fileName;

            // Act
            List<ulong> result = newRace.GetTimes(filePath);

            // Assert
            result.Should().Equal(expected);
        }

        [Theory]
        [InlineData("exampleRace.txt", new ulong[] { 9, 40, 200 })]
        [InlineData("realRace.txt", new ulong[] { 255, 1288, 1117, 1623 })]
        [InlineData("exampleRacePuzzle2.txt", new ulong[] { 940200 })]
        [InlineData("realRacePuzzle2.txt", new ulong[] { 255128811171623 })]
        public void Should_get_distances(string fileName, ulong[] expected)
        {
            // Arrange
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06Src/data/" + fileName;

            // Act
            List<ulong> result = newRace.GetDistances(filePath);

            // Assert
            result.Should().Equal(expected);
        }

        [Theory]
        [InlineData("exampleRace.txt", 0, 4)]
        [InlineData("exampleRace.txt", 1, 8)]
        [InlineData("exampleRace.txt", 2, 9)]
        [InlineData("exampleRacePuzzle2.txt", 0, 71503)]
        [InlineData("realRacePuzzle2.txt", 0, 36992486)]
        public void Should_return_number_of_different_ways(string fileName, int raceNumber, ulong expected)
        {
            // Arrange
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06Src/data/" + fileName;

            // Act
            ulong result = newRace.CalculateDifferentWaysForSpecificRace(filePath, raceNumber);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("exampleRace.txt", 288)]
        [InlineData("realRace.txt", 252000)]
        public void Should_return_margin_of_error(string fileName, ulong expected)
        {
            // Arrange
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../Day06Src/data/" + fileName;

            // Act
            ulong result = newRace.GetMarginError(filePath);

            // Assert
            result.Should().Be(expected);
        }

        private static Race CreateRace()
        {
            return new Race();
        }
    }
}