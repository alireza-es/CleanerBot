using System;

namespace Cint.CleanerBot
{
    public class Point
    {
        public Point(in int x, in int y)
        {
            X = x;
            Y = y;
        }

        public int Y { get; }
        public int X { get; }
        public Point GetNeighborLocation(Direction direction)
        {
            switch (direction)
            {
                case Direction.East:
                    return new Point(X - 1, Y);
                case Direction.West:
                    return new Point(X + 1, Y);
                case Direction.North:
                    return new Point(X, Y + 1);
                case Direction.South:
                    return new Point(X, Y - 1);
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        public override string ToString()
        {
            return $"[{X},{Y}]";
        }
    }
}