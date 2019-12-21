using Xunit;

namespace Cint.CleanerBot.Tests
{
    public class PointTest
    {
        [Fact]
        public void Point_CreateObject_CoordinatesShouldBeSetProperly()
        {
            //arrange
            const int x = 15, y = 25;

            //act
            var point = new Point(x ,y);

            //check
            Assert.Equal("[15,25]", point.ToString());
        }

        [Fact]
        public void Equals_WhenTwoDifferentObjectsHaveTheSameCoordinates_ObjectsAreEqual()
        {
            //arrange
            var point1 = new Point(10,50);
            var point2 = new Point(10, 50);

            //act
            var actual = point1.Equals(point2);

            //check
            Assert.True(actual);
        }
    }
}
