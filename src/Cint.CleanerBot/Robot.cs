using System;
using System.Collections.Generic;
using System.Linq;

namespace Cint.CleanerBot
{
    public class Robot
    {
        private Point _currentLocation;

        public Robot(int x, int y)
        {
            CurrentLocation = new Point(x, y);
        }

        public Point CurrentLocation
        {
            get => _currentLocation;
            set
            {
                _currentLocation = value;

                if(CleanedLocations == null)
                    CleanedLocations = new List<Point>();

                if (!CleanedLocations.Any(p => p.X == CurrentLocation.X && p.Y == CurrentLocation.Y))
                    CleanedLocations.Add(CurrentLocation);

            }
        }

        private List<Point> CleanedLocations { get; set; }

        public void Move(Direction direction, int step)
        {
            while (step >= 1)
            {
                CurrentLocation = CurrentLocation.GetNeighborLocation(direction);

                step--;
            }
        }

        public int GetCleanedLocations()
        {
            return CleanedLocations.Count;
        }
    }
}