namespace Cint.CleanerBot
{
    public class Robot
    {
        public Robot(int x, int y)
        {
            CurrentLocation = new Point(x, y);
        }

        public Point CurrentLocation { get; set; }
    }
}