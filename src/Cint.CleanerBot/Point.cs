using System;

namespace Cint.CleanerBot
{
    /// <summary>
    /// A Value Object to represent coordinates of a point
    /// </summary>
    public class Point : IEquatable<Point>
    {
        /// <summary>
        /// Create a point object with its required attributes: x, y
        /// </summary>
        /// <param name="x">x coordinate of point object</param>
        /// <param name="y">y coordinate of point object</param>
        public Point(in int x, in int y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// X coordinate of point object
        /// </summary>
        public int X { get; }
        /// <summary>
        /// Y coordinate of point object
        /// </summary>
        public int Y { get; }
        /// <summary>
        /// Get the Neighbor point of this point depend on direction
        /// </summary>
        /// <param name="direction">The direction of the neighbor we are looking for</param>
        /// <returns>Neighbor's location as a new Point'</returns>
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
        /// Convert Point to String 
        /// </summary>
        /// <returns>String representation of point</returns>
        public override string ToString()
        {
            return $"[{X},{Y}]";
        }

        public bool Equals(Point other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point) obj);
        }
        /// <summary>
        /// Generate a unique hashcode of this point
        /// </summary>
        /// <returns>The unique hashcode of this point</returns>
        public override int GetHashCode()
        {
            return $"{X}-{Y}".GetHashCode();
        }
    }
}