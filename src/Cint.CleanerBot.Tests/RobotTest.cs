using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Cint.CleanerBot.Tests
{
    public class RobotTest
    {
        [Fact]
        public void Robot_WhenCreateObject_ObjectShouldBeCreatedInStartingLocationWithOneLocation()
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
        [Fact]
        public void Robot_WhenCreateObject_OneLocationShouldBeCleaned()
        {
            //arrange
            const int startingX = 0;
            const int startingY = 0;

            //act
            var robot = new Robot(startingX, startingY);

            //check
            Assert.Equal(1, robot.GetCleanedLocations());
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
        [Fact]
        public void Move_MultipleCommandsInUniqueLocations_ResultShouldBeEqualToTotalStepsPlus1()
        {
            //arrange
            var robot = new Robot(5, 6);

            var commands = new List<KeyValuePair<Direction, int>>
            {
                KeyValuePair.Create(Direction.East, 2),
                KeyValuePair.Create(Direction.North, 2),
                KeyValuePair.Create(Direction.West, 3),
                KeyValuePair.Create(Direction.South, 1)
            };

            //act
            foreach (var command in commands)
            {
                robot.Move(command.Key, command.Value);
            }

            //check
            var totalSteps = commands.Sum(x => x.Value);
            var expectedResult = totalSteps + 1;
            Assert.Equal(expectedResult, robot.GetCleanedLocations());
        }
        [Fact]
        public void Move_MultipleCommandsInForwardAndBackwardMethod_ResultShouldBeUniqueLocations()
        {
            //arrange
            var robot = new Robot(3, 2);

            var commands = new List<KeyValuePair<Direction, int>>
            {
                KeyValuePair.Create(Direction.East, 3),
                KeyValuePair.Create(Direction.West, 3),
                KeyValuePair.Create(Direction.North, 3),
                KeyValuePair.Create(Direction.South, 3)
            };

            //act
            foreach (var (key, value) in commands)
            {
                robot.Move(key, value);
            }

            //check
            Assert.Equal(7, robot.GetCleanedLocations());
        }
        [Fact]
        public void Move_MultipleCommandsWithJunction_ResultShouldBeUniqueLocations()
        {
            //arrange
            var commands = new List<KeyValuePair<Direction, int>>
            {
                KeyValuePair.Create(Direction.East, 6),
                KeyValuePair.Create(Direction.North, 3),
                KeyValuePair.Create(Direction.West, 3),
                KeyValuePair.Create(Direction.South, 6),
                KeyValuePair.Create(Direction.West, 3),
                KeyValuePair.Create(Direction.North, 3)
            };

            var robot = new Robot(1, 2);

            //act
            foreach (var (key, value) in commands)
            {
                robot.Move(key, value);
            }

            //check
            Assert.Equal(23, robot.GetCleanedLocations());
        }
    }
}
