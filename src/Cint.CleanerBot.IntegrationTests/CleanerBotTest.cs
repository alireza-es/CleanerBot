using Xunit;

namespace Cint.CleanerBot.IntegrationTests
{
    [Trait("Category", "Integration")]
    public class CleanerBotTest : IntegrationBaseTest
    {
        [Fact]
        public void CleanerBot_MainScenario_CleanedSuccessfully()
        {
            //arrange

            //act
            PutInput("2");
            PutInput("10 22");
            PutInput("E 2");
            PutInput("N 1");

            //check
            Assert.Equal("=> Cleaned: 4", GetOutput());
        }
        [Theory]
        [InlineData(1, "0 0", "=> Cleaned: 2", "E 1")]
        [InlineData(1, "0 0", "=> Cleaned: 2", "W 1")]
        [InlineData(1, "0 0", "=> Cleaned: 2", "N 1")]
        [InlineData(1, "0 0", "=> Cleaned: 2", "S 1")]
        [InlineData(1, "10 63", "=> Cleaned: 2", "E 1")]
        [InlineData(1, "15 21", "=> Cleaned: 2", "W 1")]
        [InlineData(1, "20 32", "=> Cleaned: 2", "N 1")]
        [InlineData(1, "30 25", "=> Cleaned: 2", "S 1")]
        [InlineData(1, "-10 -63", "=> Cleaned: 2", "E 1")]
        [InlineData(1, "-15 -21", "=> Cleaned: 2", "W 1")]
        [InlineData(1, "-20 -32", "=> Cleaned: 2", "N 1")]
        [InlineData(1, "-30 -25", "=> Cleaned: 2", "S 1")]
        public void CleanerBot_OneWayOneCommandInMultipleStartPoints_CleanedTwoPlaces(int commandsCount, string currentPosition, string expectedOutput, string command)
        {
            //arrange

            //act
            PutInput(commandsCount.ToString());
            PutInput(currentPosition);
            PutInput(command);

            //check
            Assert.Equal(expectedOutput, GetOutput());
        }
        [Theory]
        [InlineData(2, "10 22", "=> Cleaned: 4", "E 1", "N 2")]
        [InlineData(3, "10 22", "=> Cleaned: 9", "E 2", "N 5", "S 6")]
        [InlineData(4, "10 22", "=> Cleaned: 13", "E 2", "N 5", "S 6", "W 4")]
        [InlineData(5, "10 22", "=> Cleaned: 14", "E 2", "N 5", "S 6", "W 4", "E 5")]
        [InlineData(6, "10 22", "=> Cleaned: 122", "E 20", "N 12", "S 18", "W 32", "E 26", "S 51")]
        public void CleanerBot_MultipleCommands_CleanedExpectedPlaces(int commandsCount, string currentPosition, string expectedOutput, params string[] commands)
        {
            //arrange

            //act
            PutInput(commandsCount.ToString());
            PutInput(currentPosition);

            foreach (var command in commands)
            {
                PutInput(command);
            }

            //check
            Assert.Equal(expectedOutput, GetOutput());
        }

    }
}
