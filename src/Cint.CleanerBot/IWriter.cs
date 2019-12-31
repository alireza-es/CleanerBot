namespace Cint.CleanerBot
{
    /// <summary>
    /// An interface to show outputs to user
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Show output to user
        /// </summary>
        /// <param name="output">output</param>
        void WriteLine(string output);
    }
}