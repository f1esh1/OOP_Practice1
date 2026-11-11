using System;
using System.IO;

namespace OOP_Practice1.States
{
    /// <summary>
    /// Represents the Directory browsing state.
    /// Allows users to view folder contents, change directories, or select files.
    /// </summary>
    public class DirectoryState : IAppState
    {
        private string _currentDirectory = Directory.GetCurrentDirectory();

        public IAppState Handle()
        {
            Console.WriteLine($"\n--- STATE: Directory Mode ---");
            Console.WriteLine($"Current path: {_currentDirectory}");
            Console.WriteLine("Enter command (e.g., ls, cd [path], view [filename], exit):");

            string input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
                return this; // Stay in the current state

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Exiting application context...");
                return null; // Terminate the application loop
            }

            if (input.StartsWith("view ", StringComparison.OrdinalIgnoreCase))
            {
                string fileName = input.Substring(5).Trim();
                string filePath = Path.Combine(_currentDirectory, fileName);

                if (File.Exists(filePath))
                {
                    // Transition to the File View state
                    return new FileViewState(filePath);
                }
                else
                {
                    Console.WriteLine("Error: File not found!");
                }
            }
            else
            {
                // Integrate with existing Interpreter / Command pattern if applicable
                Console.WriteLine($"Executed command in directory: {input}");
            }

            return this; // Remain in DirectoryState
        }
    }
}