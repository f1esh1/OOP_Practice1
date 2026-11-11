using OOP_Practice1.CLI.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Practice1.CLI;

/// <summary>
/// Патерн Interpreter: здійснює аналіз і перетворення 
/// введених текстових команд у структури даних для подальшого виконання.
/// </summary>
public class Interpreter
{
    private readonly Dictionary<string, ICommand> _commands = new();

    /// <summary>
    /// Registers a new command in the interpreter system.
    /// </summary>
    /// <param name="command">The command instance to register.</param>
    public void RegisterCommand(ICommand command)
    {
        _commands[command.Name.ToLower()] = command;
    }

    /// <summary>
    /// Starts the infinite CLI loop waiting for user input.
    /// </summary>
    public void Run()
    {
        Console.WriteLine("CLI System Initialized. Type 'exit' to quit.");

        while (true)
        {
            Console.Write("> ");
            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                continue;
            }

            if (input.Trim().ToLower() == "exit")
            {
                Console.WriteLine("Shutting down CLI...");
                break;
            }

            // Split input into the command name and its arguments
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = parts[0].ToLower();
            string[] args = parts.Skip(1).ToArray();

            // Find and execute the command
            if (_commands.TryGetValue(commandName, out ICommand command))
            {
                try
                {
                    command.Execute(args);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error executing command: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine($"Command not found: '{commandName}'.");
            }
        }
    }
}