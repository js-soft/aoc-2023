using FluentAssertions;
using src.day10;
using Xunit;

namespace test.day10
{
    public class task10test
    {
        Pipe newPipe = CreatePipe();

        string filePath0 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day10\\data\\exampleData0.txt";
        string filePath1 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day10\\data\\exampleData1.txt";
        string filePath2 = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day10\\data\\exampleData2.txt";
        string realFilePath = "C:\\Users\\htotbagi\\source\\repos\\aoc\\aoc\\day10\\data\\realData.txt";

        [Fact]
        public void Should_read_text_file()
        {
            // Arrange
            List<List<char>> expected = new List<List<char>>
            {
                new List<char> { '.', '.', '.', '.', '.'},
                new List<char> { '.', 'S', '-', '7', '.',},
                new List<char> { '.', '|', '.', '|', '.'},
                new List<char> { '.', 'L', '-', 'J', '.'},
                new List<char> { '.', '.', '.', '.', '.'},
            };

            // Act
            List<List<char>> result = newPipe.ReadTextFile(filePath0);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_create_matrix_of_all_zeros()
        {
            // Arrange
            List<List<int>> expected = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

            // Act
            List<List<int>> result = newPipe.CreateMatrixWithAllZeros(filePath0);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_mark_where_is_the_next_pipe_in_second_iteration()
        {
            // Arrange
            List<List<int>> inputMatrix = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 1, 0, 0},
                new List<int> { 0, 1, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

            List<List<int>> expected = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 1, 2, 0},
                new List<int> { 0, 1, 0, 0, 0},
                new List<int> { 0, 2, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

            int currentIteration = 1;

            // Act
            List<List<int>> result = newPipe.CallEveryPipeCheck(inputMatrix, currentIteration, filePath0);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_mark_where_is_the_next_pipe_in_third_iteration()
        {
            // Arrange
            List<List<int>> inputMatrix = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 1, 2, 0},
                new List<int> { 0, 1, 0, 0, 0},
                new List<int> { 0, 2, 0, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

            List<List<int>> expected = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 1, 2, 0},
                new List<int> { 0, 1, 0, 3, 0},
                new List<int> { 0, 2, 3, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

            int currentIteration = 2;

            // Act
            List<List<int>> result = newPipe.CallEveryPipeCheck(inputMatrix, currentIteration, filePath0);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_mark_where_is_the_next_pipe_in_fourth_iteration()
        {
            // Arrange
            List<List<int>> inputMatrix = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 1, 2, 0},
                new List<int> { 0, 1, 0, 3, 0},
                new List<int> { 0, 2, 3, 0, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

            List<List<int>> expected = new List<List<int>>
            {
                new List<int> { 0, 0, 0, 0, 0},
                new List<int> { 0, 0, 1, 2, 0},
                new List<int> { 0, 1, 0, 3, 0},
                new List<int> { 0, 2, 3, 4, 0},
                new List<int> { 0, 0, 0, 0, 0},
            };

            int currentIteration = 3;

            // Act
            List<List<int>> result = newPipe.CallEveryPipeCheck(inputMatrix, currentIteration, filePath0);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_retur_number_of_steps_realData()
        {
            // Arrange
            int expected = 6831;

            // Act
            int result = newPipe.GetNumberOfSteps(realFilePath);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_retur_number_of_tiles_enclosed_by_loops()
        {
            // Arrange
            int expected = 305;

            // Act
            int result = newPipe.GetNumberOfTilesEnclosed(realFilePath);

            // Assert
            result.Should().Be(expected);
        }

        private static Pipe CreatePipe()
        {
            return new Pipe();
        }
    }
}