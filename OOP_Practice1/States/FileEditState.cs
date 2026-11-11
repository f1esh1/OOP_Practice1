using System;
using System.IO;

namespace OOP_Practice1.States
{
    /// <summary>
    /// Represents the File Editing state.
    /// Handles user text input and updates the target file.
    /// </summary>
    public class FileEditState : IAppState
    {
        private readonly string _filePath;

        public FileEditState(string filePath)
        {
            _filePath = filePath;
        }

        public IAppState Handle()
        {
            Console.WriteLine($"\n--- STATE: File Edit Mode ({Path.GetFileName(_filePath)}) ---");
            Console.WriteLine("Enter new text to append/save to file (or [back] to cancel):");

            string input = Console.ReadLine();

            if (input?.Equals("back", StringComparison.OrdinalIgnoreCase) == true)
            {
                return new FileViewState(_filePath);
            }

            // Write updated text back to the file system
            File.WriteAllText(_filePath, input);
            Console.WriteLine("File content updated successfully!");

            // Transition back to File View mode after saving
            return new FileViewState(_filePath);
        }
    }
}