using System;

namespace Cint.CleanerBot
{
    /// <summary>
    /// A Value Object to represent coordinates of a point
    /// </summary>
    public class Point
    {
        public Point(in int x, in int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }
        /// <summary>
        /// Get the Neighbor point of this point depend on direction
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Point GetNeighborLocation(Direction direction)
        {
            switch (direction)
            {
                case Direction.East:
                    return new Point(X + 1, Y);
                case Direction.West:
                    return new Point(X - 1, Y);
                case Direction.North:
                    return new Point(X, Y + 1);
                case Direction.South:
                    return new Point(X, Y - 1);
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }
        /// <summary>
        /// String representation of point
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{X},{Y}]";
        }
    }
}