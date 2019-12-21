using Xunit;

namespace Cint.CleanerBot.Tests
{
    public class RobotTest
    {
        [Fact]
        public void Robot_CreateObject_ObjectCreatedInStartingLocation()
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
    }

    public class Robot
    {
        public Robot(int x, int y)
        {
            CurrentLocation = new Point{X = x, Y = y};
        }

        public Point CurrentLocation { get; set; }
    }

    public class Point
    {
        public int Y { get; set; }
        public int X { get; set; }
    }
}
