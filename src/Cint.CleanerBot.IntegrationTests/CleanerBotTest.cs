using System;
using System.Diagnostics;
using Xunit;

namespace Cint.CleanerBot.IntegrationTests
{
    public class CleanerBotTest : IDisposable
    {
        private Process process;

        public CleanerBotTest()
        {

            const string appDllPath = @"..\..\..\..\Cint.CleanerBot.UI\bin\Debug\netcoreapp3.0\Cint.CleanerBot.UI.dll";

            var processInfo = new ProcessStartInfo("dotnet", appDllPath);
            processInfo.UseShellExecute = false;
            processInfo.CreateNoWindow = true;
            processInfo.WindowStyle = ProcessWindowStyle.Hidden;
            processInfo.RedirectStandardInput = true;
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;

            process = Process.Start(processInfo);
        }

        [Fact]
        public void CleanerBot_MainScenario_CleanedSuccessfully()
        {
            //arrange

            //act
            process.StandardInput.WriteLine("2");
            process.StandardInput.WriteLine("10 22");
            process.StandardInput.WriteLine("E 2");
            process.StandardInput.WriteLine("N 1");

            var error = process.StandardError.ReadToEnd();
            Assert.Null(error);
            //check
            Assert.Equal("=> Cleaned: 4", process.StandardOutput.ReadLine());
        }

        public void Dispose()
        {
            process?.WaitForExit(1);
            process?.Dispose();
        }
    }
}
