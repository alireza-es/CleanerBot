using Cint.CleanerBot.Tests.Mocks;
using Xunit;

namespace Cint.CleanerBot.Tests
{
    public class RobotControllerTest
    {
        [Fact]
        public void Run()
        {
            //arrange
            var inputData = new[] {
                "2",
                "10 22",
                "E 2",
                "N 1"
            };
            var mockReader = new MockReader(inputData);
            var mockWriter = new MockWriter();

            var robotController = new RobotController(mockReader, mockWriter);

            //act
            robotController.Run();

            //check
            Assert.Equal("=> Cleaned: 4", mockWriter.GetLastOutput());
        }

    }
}
