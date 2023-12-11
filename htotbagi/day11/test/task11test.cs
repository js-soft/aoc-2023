using FluentAssertions;
using src.day11;
using Xunit;

namespace test.day11
{
    public class task11test
    {
        Universe newUniverse = CreateUniverse();

        [Fact]
        public void Should_get_coordinates()
        {
            // Arrange
            List<List<ulong>> expected = new List<List<ulong>>
            {
                new List<ulong> { 0, 3}, new List<ulong> { 1, 7},new List<ulong> { 2, 0},
                new List<ulong> { 4, 6}, new List<ulong> { 5, 1},new List<ulong> { 6, 9},
                new List<ulong> { 8, 7}, new List<ulong> { 9, 0},new List<ulong> { 9, 4},
            };

            // Act
            List<List<ulong>> result = newUniverse.GetCoordinates();

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(7)]
        public void Should_return_bool_on_index_row(ulong row)
        {
            // Act
            bool result = newUniverse.RowIsEmpty(row);

            // Assert
            result.Should().BeTrue();
        }

        [Theory]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(8)]
        public void Should_return_bool_on_index_column(ulong col)
        {
            // Act
            bool result = newUniverse.ColISEmpty(col);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Should_get_distance_between_galaxies()
        {
            // Arrange
            ulong orderOfExpansion = 2;
            List<ulong> first = new List<ulong> { 0, 3 };
            List<ulong> second = new List<ulong> { 1, 7 };

            // Act
            ulong result = newUniverse.GetDistanceBetweenGalaxies(first, second, orderOfExpansion);

            // Assert
            result.Should().Be(6);
        }

        [Theory]
        [InlineData(2, 374)]
        [InlineData(10, 1030)]
        [InlineData(100, 8410)]
        public void Should_get_total_distance(ulong orderOfExpansion, ulong expected)
        {
            // Act
            ulong result = newUniverse.GetTotalDistance(orderOfExpansion);

            // Assert
            result.Should().Be(expected);
        }

        private static Universe CreateUniverse()
        {
            return new Universe();
        }
    }
}