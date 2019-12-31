using System;
using System.Diagnostics;
using Xunit;

namespace Cint.CleanerBot.IntegrationTests
{
    public class IntegrationBaseTest : IDisposable
    {
        protected Process Process;

        public IntegrationBaseTest()
        {

            const string appDllPath = @"..\..\..\..\Cint.CleanerBot.UI\bin\Debug\netcoreapp3.0\Cint.CleanerBot.UI.dll";

            var processInfo = new ProcessStartInfo("dotnet", appDllPath)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            Process = Process.Start(processInfo);
        }

        public void Dispose()
        {
            var error = GetErrors();
            Assert.Empty(error);

            Process?.WaitForExit(1);
            Process?.Dispose();
        }

        protected string GetErrors()
        {
            return Process.StandardError.ReadToEnd();
        }

        protected void PutInput(string input)
        {
            Process.StandardInput.WriteLine(input);
        }

        protected string GetOutput()
        {
            return Process.StandardOutput.ReadLine();
        }
    }
}