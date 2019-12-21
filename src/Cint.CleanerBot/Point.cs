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
        public override string ToString()
        {
            return $"[{X},{Y}]";
        }
    }
}