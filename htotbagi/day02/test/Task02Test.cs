namespace Day02Tests
{
    public class Task02Tests
    {
        private static Bag CreateBag()
        {
            return new Bag();
        }

        Bag newBag = CreateBag();

        Dictionary<string, int> loadedBag = new Dictionary<string, int>()
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1)]
        [InlineData("Game 24: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 24)]
        [InlineData("Game 134: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 134)]
        public void Should_return_game_id(string input, int expected)
        {
            // Act
            int result = newBag.GetGameId(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", "3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green")]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", "1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue")]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", "6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green")]
        public void Should_split_into_cubes_string(string input, string expected)
        {
            // Act
            string result = newBag.GetCubesString(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", "3blue,4red;1red,2green,6blue;2green")]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", "1blue,2green;3green,4blue,1red;1green,1blue")]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", "6red,1blue,3green;2blue,1red,2green")]
        public void Should_return_string_without_spaces(string input, string expected)
        {
            // Act
            string result = newBag.GetCubesWithoutEmptySpaces(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", new[] { "3blue,4red", "1red,2green,6blue", "2green" })]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", new[] { "1blue,2green", "3green,4blue,1red", "1green,1blue" })]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", new[] { "6red,1blue,3green", "2blue,1red,2green" })]
        public void Should_split_cubes_string_into_segments(string input, string[] expected)
        {
            // Act
            List<string> result = newBag.GetCubesStringSegments(input);

            // Assert
            result.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 0, "3blue,4red")]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1, "1red,2green,6blue")]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 2, "2green")]
        public void Should_return_segment_by_index(string input, int segmentIndex, string expected)
        {
            // Act
            string result = newBag.GetSegmentByIndex(input, segmentIndex);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 0, new string[] { "red", "green", "blue" }, new int[] { 4, 0, 3 })]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1, new string[] { "red", "green", "blue" }, new int[] { 1, 2, 6 })]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 2, new string[] { "red", "green", "blue" }, new int[] { 0, 2, 0 })]
        public void Should_create_dictionary_for_segment(string input, int index, string[] keys, int[] values)
        {
            // Arrange
            Dictionary<string, int> keyValuePairs = new Dictionary<string, int>();
            for (int i = 0; i < keys.Length; i++)
            {
                keyValuePairs.Add(keys[i], values[i]);
            }

            // Act
            var result = newBag.CreateDictionaryOutOfSegment(input, index);

            // Assert
            result.Should().BeEquivalentTo(keyValuePairs);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 0, true)]
        [InlineData("Game 2: 1 red; 3 green, 2 blue; 4 red, 1 green", 1, true)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 0, false)]
        public void Should_return_bool_based_on_wether_game_segment_is_possible(string input, int segmentIndex, bool expectedResult)
        {
            // Act
            bool result = newBag.IsGameSegmentPossible(input, segmentIndex, loadedBag);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 1)]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 2)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 0)]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 0)]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 5)]
        public void Should_return_game_id_if_possible(string input, int expected)
        {
            // Act
            int result = newBag.IsGamePossible(input, loadedBag);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", new int[] { 4, 2, 6 })]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", new int[] { 1, 3, 4 })]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", new int[] { 20, 13, 6 })]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", new int[] { 14, 3, 15 })]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", new int[] { 6, 3, 2 })]
        public void Should_return_maximum_value_per_color(string input, int[] expected)
        {
            // Act
            List<int> result = newBag.GetMaximumValuePerColor(input);

            // Assert
            result.Should().Equal(expected);
        }

        [Theory]
        [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)]
        [InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)]
        [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)]
        [InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)]
        [InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36)]
        public void Should_return_power_of_the_cube(string input, int expected)
        {
            // Act
            int result = newBag.CalculatePowerOfCubes(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Should_return_power_of_the_cube_added_up()
        {
            // Arrange
            string filePath = "C:\\Users\\htotbagi\\OneDrive - j&s-soft GmbH\\Dokumente\\C#-10-fundamentals\\advent-of-code\\src\\data\\game.txt";
            int expected = 66016;

            // Act
            int result = newBag.CalculateSumOfCubePowers(filePath);

            // Assert
            result.Should().Be(expected);
        }
    }
}