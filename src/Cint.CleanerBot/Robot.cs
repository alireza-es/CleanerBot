namespace Cint.CleanerBot
{
    public class Robot
    {
        public Robot(int x, int y)
        {
            CurrentLocation = new Point(x, y);
        }

        public Point CurrentLocation { get; set; }

        public void Move(string direction, in int step)
        {
            throw new System.NotImplementedException();
        }

        public int GetCleanedPoints()
        {
            throw new System.NotImplementedException();
        }
    }
}