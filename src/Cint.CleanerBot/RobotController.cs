namespace Cint.CleanerBot
{
    /// <summary>
    /// An interface of RobotController for injecting its dependencies
    /// </summary>
    public interface IRobotController
    {
        /// <summary>
        /// Run the main process of cleaning by robot
        /// </summary>
        void Run();
    }
    /// <summary>
    /// A controller for starting and controlling the robot
    /// </summary>
    public class RobotController : IRobotController
    {
        /// <summary>
        /// Create a RobotController to control the robot
        /// </summary>
        /// <param name="reader">An injected service to get inputs from user</param>
        /// <param name="writer">An injected service to show outputs to user</param>
        public RobotController(IReader reader, IWriter writer)
        {
            Reader = reader;
            Writer = writer;
        }

        private const string Separator = " ";
        /// <summary>
        /// An injected service to get inputs from user
        /// </summary>
        public IReader Reader { get; }
        /// <summary>
        /// An injected service to show outputs to user
        /// </summary>
        public IWriter Writer { get; }
        /// <summary>
        /// Run the main process of cleaning by robot
        /// </summary>

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
