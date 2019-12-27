using System;
using Xunit;

namespace Cint.CleanerBot.Tests
{
    public class PointTest
    {
        #region Constructor

        [Fact]
        public void Point_CreateObject_CoordinatesShouldBeSetProperly()
        {
            //arrange
            const int x = 15, y = 25;

            //act
            var point = new Point(x, y);

            //check
            Assert.Equal("[15,25]", point.ToString());
        }


        #endregion

        #region Equals

        [Fact]
        public void Equals_WhenTwoDifferentObjectsHaveTheSameCoordinates_ObjectsAreEqual()
        {
            //arrange
            var point1 = new Point(10, 50);
            var point2 = new Point(10, 50);

            //act
            var actual = point1.Equals(point2);

            //check
            Assert.True(actual);
        }

        [Fact]
        public void Equals_ComparingPointWithEqualObjectType_ObjectsAreEqual()
        {
            //arrange
            const int x = 10;
            const int y = 20;

            object point1 = new Point(x, y);//object
            var point2 = new Point(x, y);//Point

            //act
            var actual = point2.Equals(point1);

            //check
            Assert.True(actual);
        }
        [Fact]
        public void Equals_ComparingPointWithNotEqualObjectType_ObjectsAreNotEqual()
        {
            //arrange

            object point1 = new Point(10, 20);//object
            var point2 = new Point(16, 30);//Point

            //act
            var actual = point2.Equals(point1);

            //check
            Assert.False(actual);
        }
        [Fact]
        public void Equals_ComparingPointWithNullObjectType_ObjectsAreNotEqual()
        {
            //arrange

            object point1 = null;//object
            var point2 = new Point(16, 30);//Point

            //act
            var actual = point2.Equals(point1);

            //check
            Assert.False(actual);
        }
        [Fact]
        public void Equals_ComparingPointWithNullPoint_ObjectsAreNotEqual()
        {
            //arrange

            Point point1 = null;//object
            var point2 = new Point(16, 30);//Point

            //act
            var actual = point2.Equals(point1);

            //check
            Assert.False(actual);
        }
        [Fact]
        public void Equals_ComparingTwoDifferentType_ObjectsAreNotEqual()
        {
            //arrange
            const int x = 10;
            const int y = 20;

            object fakePoint = new FakePoint(x, y);//object of FakePoint
            var point = new Point(x, y);//Point

            //act
            var actual = point.Equals(fakePoint);

            //check
            var fakePointForCheck = (FakePoint)fakePoint;
            Assert.NotNull(fakePointForCheck);
            Assert.Equal(x, fakePointForCheck.X);
            Assert.Equal(y, fakePointForCheck.Y);
            Assert.False(actual);
        }
        [Fact]
        public void Equals_ComparingReferenceEqualsToObject_ObjectsAreEqual()
        {
            //arrange
            const int x = 10;
            const int y = 20;

            object objectPoint = null;//object type of the Point
            var point = new Point(x, y);//Point

            objectPoint = point;//Do reference equality

            //act
            var actual = point.Equals(objectPoint);

            //check
            Assert.True(actual);
        }
        [Fact]
        public void Equals_ComparingReferenceEqualsToPoint_ObjectsAreEqual()
        {
            //arrange
            const int x = 10;
            const int y = 20;

            Point point1 = null;//object type of the Point
            var point2 = new Point(x, y);//Point

            point1 = point2;//Do reference equality

            //act
            var actual = point2.Equals(point1);

            //check
            Assert.True(actual);
        }

        #endregion

        #region GetNeighborLocation

        [Theory]
        [InlineData(Direction.North, 0, 1)]
        public void GetNeighborLocation_WithValidInput_GetValidResult(Direction direction, int expectedX, int expectedY)
        {
            //arrange
            var point = new Point(0, 0);

            //act
            var neighborPoint = point.GetNeighborLocation(direction);

            //check
            Assert.Equal(expectedX, neighborPoint.X);
            Assert.Equal(expectedY, neighborPoint.Y);
        }
        [Fact]
        public void GetNeighborLocation_WithInValidInput_ThrowArgumentOutOfRangeException()
        {
            //arrange
            var point = new Point(0, 0);
            const Direction invalidDirection = (Direction)10;

            //act
            void Action() => point.GetNeighborLocation(invalidDirection);

            //check
            var exception = Assert.Throws<ArgumentOutOfRangeException>(Action);

            Assert.Equal("10", exception.ActualValue.ToString());
            Assert.Equal("direction", exception.ParamName);
        }
        #endregion

    }

    public class FakePoint
    {
        public FakePoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

    }
}
