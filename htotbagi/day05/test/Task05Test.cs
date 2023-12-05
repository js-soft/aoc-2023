using Day05Src;
using FluentAssertions;
using Xunit;

namespace Day05Tests
{
    public class Task05Test
    {
        public string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\Day05Src\\data\\alamac.txt";
        Alamac newAlamac = CreateAlamac();

        [Fact]
        public void Should_return_all_seeds()
        {
            // Arrange
            List<int> expected = new List<int> { 79, 14, 55, 13 };

            // Act
            List<int> result = newAlamac.GetAllSeeds(filePath);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { "seed-to-soil map:", new List<List<int>> { new List<int> { 50, 98, 2 }, new List<int> { 52, 50, 48 } } };
            yield return new object[] { "soil-to-fertilizer map:", new List<List<int>> { new List<int> { 0, 15, 37 }, new List<int> { 37, 52, 2 }, new List<int> { 39, 0, 15 } } };
            yield return new object[] { "humidity-to-location map:", new List<List<int>> { new List<int> { 60, 56, 37 }, new List<int> { 56, 93, 4 } } };
        }

        [Theory]
        [MemberData(nameof(TestData))]
        public void Should_return_list_of_all_mappings_based_on_mapping_name(string mappingName, List<List<int>> expectedMappings)
        {
            // Act
            List<List<int>> result = newAlamac.GetAllMappings(filePath, mappingName);

            // Assert
            result.Should().BeEquivalentTo(expectedMappings);
        }

        [Fact]
        public void Should_create_entire_mapping()
        {
            // Arrange
            List<List<int>> mappings = new List<List<int>>
            {
                new List<int> { 50, 98, 2 },
                new List<int> { 52, 50, 48 }
            };

            List<int> expected_seed = new List<int> {0, 1,2,3,4,5,6,7,8,9,10,
                                                    11,12,13,14,15,16,17,18,19,20,
                                                    21,22,23,24,25,26,27,28,29,30,
                                                    31,32,33,34,35,36,37,38,39,40,
                                                    41,42,43,44,45,46,47,48,49,52,
                                                    53,54,55,56,57,58,59,60,61,62,
                                                    63,64,65,66,67,68,69,70,71,72,
                                                    73,74,75,76,77,78,79,80,81,82,
                                                    83,84,85,86,87,88,89,90,91,92,
                                                    93,94,95,96,97,98,99,50,51,100,
                                                    101,102,103,104,105,106,107};

            List<int> result = newAlamac.CreateEntireMapping(mappings);

            // Assert
            result.Should().Equal(expected_seed);
        }

        [Theory]
        [InlineData(79, 82)]
        [InlineData(14, 43)]
        [InlineData(55, 86)]
        [InlineData(13, 35)]
        public void Should_return_location_for_seeds(int seedNumber, int expected)
        {
            // Act
            int result = newAlamac.GetSeedLoaction(seedNumber, filePath);

            result.Should().Be(expected);
        }

        [Fact]
        public void Should_return_lowest_location_number()
        {
            // Arrange
            int expected = 35;

            // Act
            int result = newAlamac.GetLowestLocationNumber(filePath);

            // Assert
            result.Should().Be(expected);
        }

        private static Alamac CreateAlamac()
        {
            return new Alamac();
        }
    }
}