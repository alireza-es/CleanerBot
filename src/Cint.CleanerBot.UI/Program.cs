using Microsoft.Extensions.DependencyInjection;

namespace Cint.CleanerBot.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = BuildServiceProvider();

            var robotController = serviceProvider.GetService<IRobotController>();
            robotController.Run();
        }

        private static ServiceProvider BuildServiceProvider()
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddScoped<IReader, ConsoleReader>()
                .AddScoped<IWriter, ConsoleWriter>()
                .AddScoped<IRobotController, RobotController>()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
