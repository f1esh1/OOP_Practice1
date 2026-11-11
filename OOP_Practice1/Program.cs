using System;
using OOP_Practice1.States;

namespace OOP_Practice1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initial state configuration: Directory Mode
            IAppState currentState = new DirectoryState();

            Console.WriteLine("Application running in continuous process context.");

            // Execution loop running until null state is received
            while (currentState != null)
            {
                currentState = currentState.Handle();
            }

            Console.WriteLine("Process terminated successfully.");
        }
    }
}