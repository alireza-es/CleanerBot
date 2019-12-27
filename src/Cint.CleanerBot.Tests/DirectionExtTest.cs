using System;
using Xunit;

namespace Cint.CleanerBot.Tests
{
    public class DirectionExtTest
    {
        [Theory]
        [InlineData("E", Direction.East)]
        [InlineData("W", Direction.West)]
        [InlineData("N", Direction.North)]
        [InlineData("S", Direction.South)]
        public void ParseDirection_ValidInput_ReturnValidOutput(string input, Direction output)
        {
            //arrange

            //act
            var actual = input.ParseDirection();

            //check
            Assert.Equal(output, actual);
        }

        [Fact]
        public void ParseDirection_InvalidInput_ThrowArgumentOutOfRangeException()
        {
            //arrange
            var input = "U";

            //act
            Action action = () => input.ParseDirection();

            //check
            var exception = Assert.Throws<ArgumentOutOfRangeException>(action);
            
            Assert.Equal(input, exception.ActualValue);
            Assert.Equal("direction", exception.ParamName);
        }
    }
}
