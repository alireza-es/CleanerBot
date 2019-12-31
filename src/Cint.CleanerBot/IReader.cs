namespace Cint.CleanerBot
{
    /// <summary>
    /// An interface to get inputs from user
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Get inputs from user
        /// </summary>
        /// <returns>Entered inputs by user</returns>
        string ReadLine();
    }
}