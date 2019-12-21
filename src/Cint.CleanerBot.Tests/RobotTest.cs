using Xunit;

namespace Cint.CleanerBot.Tests
{
    public class RobotTest
    {
        [Fact]
        public void Robot_CreateObject_ObjectShouldBeCreatedInStartingLocation()
        {
            //arrange
            const int startingX = 10;
            const int startingY = 22;

            //act
            var robot = new Robot(startingX, startingY);

            //check
            Assert.Equal(startingX, robot.CurrentLocation.X);
            Assert.Equal(startingY, robot.CurrentLocation.Y);
        }

        [Theory]
        [InlineData("E", 1)]
        [InlineData("W", 1)]
        [InlineData("N", 1)]
        [InlineData("S", 1)]
        public void Move_WithOneCommand_TwoPointsMustBeCleaned(string direction, int step)
        {
            //arrange
            const int startingX = 10;
            const int startingY = 22;

            var robot = new Robot(startingX, startingY);

            //act
            robot.Move(direction, step);

            //check
            Assert.Equal(2, robot.GetCleanedLocations());
        }
    }
}
