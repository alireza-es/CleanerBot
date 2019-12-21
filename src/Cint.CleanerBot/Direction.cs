namespace Cint.CleanerBot
{
    public enum Direction
    {
        East,
        West,
        North,
        South
    }

    public static class DirectionExt
    {
        public static Direction ParseDirection(this string direction)
        {
            switch (direction)
            {
                case "W":
                    return Direction.West;
                case "E":
                    return Direction.East;
                case "N":
                    return Direction.North;
                case "S":
                    return Direction.South;

            }

            return 0;
        }
    }
}
