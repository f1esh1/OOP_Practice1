using System;
using System.IO;

namespace OOP_Practice1.States
{
    /// <summary>
    /// Represents the File Viewing state.
    /// Displays file contents and allows navigation back to directory or switching to edit mode.
    /// </summary>
    public class FileViewState : IAppState
    {
        private readonly string _filePath;

        public FileViewState(string filePath)
        {
            _filePath = filePath;
        }

        public IAppState Handle()
        {
            Console.WriteLine($"\n--- STATE: File View Mode ({Path.GetFileName(_filePath)}) ---");

            if (File.Exists(_filePath))
            {
                string content = File.ReadAllText(_filePath);
                Console.WriteLine("File Content:\n-------------------------");
                Console.WriteLine(content);
                Console.WriteLine("-------------------------");
            }

            Console.WriteLine("Commands: [back] - return to directory, [edit] - switch to editor");
            string input = Console.ReadLine()?.Trim();

            if (input?.Equals("edit", StringComparison.OrdinalIgnoreCase) == true)
            {
                // Transition to the File Edit state
                return new FileEditState(_filePath);
            }

            // Default fallback: return to DirectoryState
            return new DirectoryState();
        }
    }
}