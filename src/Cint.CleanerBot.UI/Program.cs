using System;

namespace Cint.CleanerBot.UI
{
    class Program
    {
        private const string Separator = " ";
        static void Main(string[] args)
        {
            Console.Write("Enter the number of Commands:");
            var numberOfCommands = int.Parse(Console.ReadLine());

            Console.Write("Enter the start point (x y) of robot with a white space separator:");
            var startPointArray = Console.ReadLine().Split(Separator);

            var startX = int.Parse(startPointArray[0]); 
            var startY = int.Parse(startPointArray[1]);

            var robot = new Robot(startX, startY);

            for (var i = 0; i < numberOfCommands; i++)
            {
                Console.Write($"Enter the direction (E,W,N,S) of command #{i+1} then steps count with a white space separator:");
                var commandArray = Console.ReadLine().Split(Separator);
                var direction = commandArray[0].ParseDirection();
                var step = int.Parse(commandArray[1]);

                robot.Move(direction, step);
            }

            Console.WriteLine("\n***** Finished *****\n");
            Console.WriteLine($"=> Cleaned: {robot.GetCleanedLocations()}");
        }
    }
}
