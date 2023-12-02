using advent_of_code;
using FluentAssertions;

namespace Tests
{
    public class Tests
    {
        private static Calibration CreateCalculator()
        {
            return new Calibration();
        }

        Calibration newDocument = CreateCalculator();

        [Theory]
        [InlineData("1abc2", 12)]
        [InlineData("3asd4", 34)]
        [InlineData("6asd9", 69)]
        public void Numbers_are_in_the_first_and_last_position(string input, int expected)
        {
            int result = newDocument.DecypherSingleDocument(input);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("pqr3stu8vwx", 38)]
        [InlineData("a2rgs4uwvwx", 24)]
        [InlineData("yqr1tu8vhtr", 18)]
        public void Numbers_are_somewhere_in_between(string input, int expected)
        {
            int result = newDocument.DecypherSingleDocument(input);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("a1b2c3d4e5f", 15)]
        [InlineData("awg1aaaaaaad4e9f", 19)]
        [InlineData("awwdas6ba4wd4e1fgreger", 61)]
        public void Numbers_are_somewhere_in_between_and_there_is_more_than_two(string input, int expected)
        {
            int result = newDocument.DecypherSingleDocument(input);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("treb7uchet", 77)]
        [InlineData("asdasd1asdasdasd", 11)]
        [InlineData("h2o", 22)]
        public void There_is_only_one_number(string input, int expected)
        {
            int result = newDocument.DecypherSingleDocument(input);

            result.Should().Be(expected);
        }

        [Fact]
        public void Decypher_multiple_documents()
        {
            List<string> documents = new List<string>()
            {
                "1abc2",
                "pqr3stu8vwx",
                "a1b2c3d4e5f",
                "treb7uchet"
            };

            int result = newDocument.DecypherMultipleDocuments(documents);

            result.Should().Be(142);
        }

        [Fact]
        public void Spelled_out_with_letters()
        {
            int result = newDocument.DecypherSingleDocument("two1nine");

            result.Should().Be(142);
        }
    }
}