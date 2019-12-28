namespace Cint.CleanerBot
{
    public interface IRobotController
    {
        void Run();
    }
    public class RobotController : IRobotController
    {
        public RobotController(IReader reader, IWriter writer)
        {
            Reader = reader;
            Writer = writer;
        }

        private const string Separator = " ";
        public IReader Reader { get; }
        public IWriter Writer { get; }

        public void Run()
        {
            var numberOfCommands = int.Parse(Reader.ReadLine());

            var startPointArray = Reader.ReadLine().Split(Separator);

            var startX = int.Parse(startPointArray[0]);
            var startY = int.Parse(startPointArray[1]);

            var robot = new Robot(startX, startY);

            for (var i = 0; i < numberOfCommands; i++)
            {
                var commandArray = Reader.ReadLine().Split(Separator);
                var direction = commandArray[0].ParseDirection();
                var step = int.Parse(commandArray[1]);

                robot.Move(direction, step);
            }
            Writer.WriteLine($"=> Cleaned: {robot.GetCleanedLocations()}");
        }
    }
}
