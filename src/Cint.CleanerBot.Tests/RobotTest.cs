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
        [InlineData(Direction.East, 1)]
        [InlineData(Direction.West, 1)]
        [InlineData(Direction.North, 1)]
        [InlineData(Direction.South, 1)]
        public void Move_WithOneCommand_TwoPointsMustBeCleaned(Direction direction, int step)
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
