using System.Diagnostics;
using Xunit;

namespace Cint.CleanerBot.IntegrationTests
{
    public class CleanerBotTest
    {
        [Fact]
        public void CleanerBot_MainScenario_CleanedSuccessfully()
        {
            //arrange
#if DEBUG
            const string appDllPath = @"..\..\..\..\Cint.CleanerBot.UI\bin\Debug\netcoreapp3.0\Cint.CleanerBot.UI.dll";
#else
            const string appDllPath = @"..\..\..\..\Cint.CleanerBot.UI\bin\Release\netcoreapp3.0\Cint.CleanerBot.UI.dll";
#endif
            var processInfo = new ProcessStartInfo("dotnet", appDllPath);
            processInfo.RedirectStandardInput = true;
            processInfo.RedirectStandardOutput = true;


            //act
            var process = Process.Start(processInfo);

            process.StandardInput.WriteLine("2");
            process.StandardInput.WriteLine("10 22");
            process.StandardInput.WriteLine("E 2");
            process.StandardInput.WriteLine("N 1");

            //check
            Assert.Equal("=> Cleaned: 4", process.StandardOutput.ReadLine());
        }
    }
}
