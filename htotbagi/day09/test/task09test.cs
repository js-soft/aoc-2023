using FluentAssertions;
using src.day09;
using Xunit;

namespace test.day9
{
    public class task09test
    {
        Sensor newSensor = CreateSensor();

        string filePath1 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day09-mirage-maintenance\\data\\exampleFile.txt";
        string filePath2 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day09-mirage-maintenance\\data\\realFile.txt";

        [Fact]
        public void Should_read_in_file()
        {
            // Arrange
            List<List<int>> expected = new List<List<int>>
            {
                new List<int> { 0, 3, 6, 9, 12, 15 },
                new List<int> { 1, 3, 6, 10, 15, 21 },
                new List<int> { 10, 13, 16, 21, 30, 45 },
            };

            // Act
            List<List<int>> result = newSensor.newExtractor(filePath1);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_get_next_row1()
        {
            // Arrange
            List<int> input = new List<int> { 0, 3, 6, 9, 12, 15 };
            List<int> expected = new List<int> { 3, 3, 3, 3, 3 };

            // Act
            List<int> result = newSensor.GetNextRowCalculation(input);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_get_next_row2()
        {
            // Arrange
            List<int> input = new List<int> { 3, 3, 3, 3, 3 };
            List<int> expected = new List<int> { 0, 0, 0, 0 };

            // Act
            List<int> result = newSensor.GetNextRowCalculation(input);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_get_all_differences_for_specific_row0()
        {
            // Arrange
            var input = newSensor.newExtractor(filePath1)[0];
            List<List<int>> expected = new List<List<int>>
            {
                new List<int>{ 0, 3, 6, 9, 12, 15 },
                new List<int>{ 3, 3, 3, 3, 3 },
                new List<int>{ 0, 0, 0, 0 },
            };

            // Act
            List<List<int>> result = newSensor.GetAllDifferencesForThatRow(input);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_get_all_differences_for_specific_row1()
        {
            // Arrange
            var input = newSensor.newExtractor(filePath1)[1];

            List<List<int>> expected = new List<List<int>>
            {
                new List<int>{ 1, 3, 6, 10, 15, 21 },
                new List<int>{ 2, 3, 4, 5, 6 },
                new List<int>{ 1, 1, 1, 1 },
                new List<int>{ 0, 0, 0 },
            };

            // Act
            List<List<int>> result = newSensor.GetAllDifferencesForThatRow(input);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_get_all_differences_for_specific_row2()
        {
            // Arrange
            var input = newSensor.newExtractor(filePath1)[2];

            List<List<int>> expected = new List<List<int>>
            {
                new List<int>{ 10, 13, 16, 21, 30, 45},
                new List<int>{ 3, 3, 5, 9, 15 },
                new List<int>{ 0, 2, 4, 6 },
                new List<int>{ 2, 2, 2 },
                new List<int>{ 0, 0 },
            };

            // Act
            List<List<int>> result = newSensor.GetAllDifferencesForThatRow(input);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_add_correct_step0()
        {
            // Arrange
            var firstRow = newSensor.newExtractor(filePath1)[0];
            List<List<int>> input = newSensor.GetAllDifferencesForThatRow(firstRow);
            int expected = 18;

            // Act
            int result = newSensor.AddStepsToAsALastElement(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_add_correct_step1()
        {
            // Arrange
            var firstRow = newSensor.newExtractor(filePath1)[1];
            List<List<int>> input = newSensor.GetAllDifferencesForThatRow(firstRow);
            int expected = 28;

            // Act
            int result = newSensor.AddStepsToAsALastElement(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_add_correct_step2()
        {
            // Arrange
            var firstRow = newSensor.newExtractor(filePath1)[2];
            List<List<int>> input = newSensor.GetAllDifferencesForThatRow(firstRow);
            int expected = 68;

            // Act
            int result = newSensor.AddStepsToAsALastElement(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_return_sum_of_extrapolated_values_for_example_data()
        {
            // Arrange
            int expected = 114;

            // Act
            int result = newSensor.CalcFinal(filePath1);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_return_sum_of_extrapolated_values_for_real_data()
        {
            // Arrange
            int expected = 1581679977;

            // Act
            int result = newSensor.CalcFinal(filePath2);

            // Assert
            result.Should().Be(expected);
        }

        private static Sensor CreateSensor()
        {
            return new Sensor();
        }
    }
}