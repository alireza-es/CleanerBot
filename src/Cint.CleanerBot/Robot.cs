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

        public void Move(string direction, int step)
        {
            while (step >= 1)
            {
                CurrentLocation = GetNeighborLocation(direction);

                step--;
            }
        }

        private Point GetNeighborLocation(string direction)
        {
            switch (direction)
            {
                case "E":
                    return new Point(CurrentLocation.X - 1, CurrentLocation.Y);
                case "W":
                    return new Point(CurrentLocation.X + 1, CurrentLocation.Y);
                case "N":
                    return new Point(CurrentLocation.X, CurrentLocation.Y + 1);
                case "S":
                    return new Point(CurrentLocation.X, CurrentLocation.Y - 1);
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
        }

        public int GetCleanedLocations()
        {
            return CleanedLocations.Count;
        }
    }
}