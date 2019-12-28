namespace Cint.CleanerBot.Tests.Mocks
{
    public class MockReader : IReader
    {
        public string[] InputData { get; }
        private int CurrentIndex { get; set; }
        public MockReader(string[] inputData)
        {
            CurrentIndex = 0;
            InputData = inputData;
        }

        public string ReadLine()
        {
            var result = InputData[CurrentIndex];
            CurrentIndex++;

            return result;
        }
    }
}