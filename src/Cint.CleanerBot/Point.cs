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
        public Point GetNeighborLocation(string direction)
        {
            switch (direction)
            {
                case "E":
                    return new Point(X - 1, Y);
                case "W":
                    return new Point(X + 1, Y);
                case "N":
                    return new Point(X, Y + 1);
                case "S":
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