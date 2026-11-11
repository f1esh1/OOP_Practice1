namespace OOP_Practice1.States
{
    /// <summary>
    /// Represents the base interface for the State design pattern.
    /// Manages the application context transitions.
    /// </summary>
    public interface IAppState
    {
        /// <summary>
        /// Executes the state's logic and returns the next state of the application.
        /// </summary>
        /// <returns>The next state instance, or null to terminate the process loop.</returns>
        IAppState Handle();
    }
}