using FluentAssertions;
using Xunit;

namespace test.day03_gear_ratios
{
    public class task03test
    {
        Schematic newSchematic = CreateSchematic();

        [Theory]
        [InlineData("singleDigit.txt", "singleDigitExtended.txt")]
        [InlineData("doubleDigit.txt", "doubleDigitExtended.txt")]
        [InlineData("trippleDigit.txt", "trippleDigitExtended.txt")]
        public void Should_extend_given_file_with_dots(string firstFileName, string secondFileName)
        {
            // Arrange
            var firstFilePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + firstFileName;
            var secondFilePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + secondFileName;

            var expected = newSchematic.ReadFileToList(secondFilePath);

            // Act
            List<string> result = newSchematic.ExtendSchematicWithDots(firstFilePath);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("trippleDigitExtended.txt", 1, 1)]
        public void Is_the_number_first(string fileName, int rowIndex, int colIndex)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + fileName;
            var extendedSchema = newSchematic.ReadFileToList(filePath);

            // Act
            bool result = newSchematic.IsTheNumberFirst(extendedSchema, rowIndex, colIndex);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("trippleDigitExtended.txt", 1, 2)]
        public void Is_the_number_middle(string fileName, int rowIndex, int colIndex)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + fileName;
            var extendedSchema = newSchematic.ReadFileToList(filePath);

            // Act
            bool result = newSchematic.IsTheNumberMiddle(extendedSchema, rowIndex, colIndex);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("trippleDigitExtended.txt", 1, 3)]
        public void Is_the_number_last(string fileName, int rowIndex, int colIndex)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + fileName;
            var extendedSchema = newSchematic.ReadFileToList(filePath);

            // Act
            bool result = newSchematic.IsTheNumberLast(extendedSchema, rowIndex, colIndex);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("singleDigit.txt", 1, 1)]
        public void single_digit_all_points_around(string fileName, int rowIndex, int columnIndex)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + fileName;

            // Act
            bool result = newSchematic.Dimension1(filePath, rowIndex, columnIndex);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("doubleDigit.txt", 1, 2)]
        public void double_digit_all_points_around(string fileName, int rowIndex, int columnIndex)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + fileName;

            // Act
            bool result = newSchematic.Dimension2(filePath, rowIndex, columnIndex);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("trippleDigit.txt", 1, 3)]
        public void tripple_digit_all_points_around(string fileName, int rowIndex, int columnIndex)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + fileName;

            // Act
            bool result = newSchematic.Dimension3(filePath, rowIndex, columnIndex);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData("engineSchematic.txt", 4361)]
        [InlineData("realSchematics.txt", 544433)]
        public void Should_return_correct_sum(string fileName, int expected)
        {
            // Arrange
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "../../../../aoc/day03-gear-ratios/data/" + fileName;

            // Act
            int result = newSchematic.GetFinalResult(filePath);

            // Assert
            result.Should().Be(expected);
        }

        private static Schematic CreateSchematic()
        {
            return new Schematic();
        }
    }
}