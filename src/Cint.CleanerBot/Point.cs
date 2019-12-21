namespace Cint.CleanerBot
{
    public class Point
    {
        public Point(in int x, in int y)
        {
            X = x;
            Y = y;
        }

        public int Y { get; set; }
        public int X { get; set; }
        public override string ToString()
        {
            return $"[{X},{Y}]";
        }
    }
}