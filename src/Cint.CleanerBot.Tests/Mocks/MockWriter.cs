using System.Collections.Generic;
using System.Linq;

namespace Cint.CleanerBot.Tests.Mocks
{
    public class MockWriter : IWriter
    {
        private List<string> Outputs { get; }

        public MockWriter()
        {
            Outputs = new List<string>();
        }

        public string GetLastOutput()
        {
            return Outputs.Last();
        }
        public void WriteLine(string output)
        {
            Outputs.Add(output);
        }
    }
}