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
    }
}
