namespace Cint.CleanerBot
{
    public class Robot
    {
        public Robot(int x, int y)
        {
            CurrentLocation = new Point{X = x, Y = y};
        }

        public Point CurrentLocation { get; set; }
    }
}