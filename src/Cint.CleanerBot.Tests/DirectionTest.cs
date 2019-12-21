using Xunit;

namespace Cint.CleanerBot.Tests
{
    public class DirectionTest
    {
        [Theory]
        [InlineData("E", Direction.East)]
        [InlineData("W", Direction.West)]
        [InlineData("N", Direction.North)]
        [InlineData("S", Direction.South)]
        public void ParseDirection_ValidInput_ParseSuccess(string input, Direction expected)
        {
            //arrange

            //act
            var actual = input.ParseDirection();

            //check
            Assert.Equal(expected, actual);
        }
    }
}
