using System;

namespace OOP_Practice1.Infra.Display;

public class ConsoleDisplay : IDisplay
{
    public void WriteLine(string message) => Console.WriteLine(message);
    public void Write(string message) => Console.Write(message);
    public string? ReadLine() => Console.ReadLine();
}