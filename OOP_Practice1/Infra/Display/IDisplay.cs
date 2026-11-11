namespace OOP_Practice1.Infra.Display;

public interface IDisplay
{
    void WriteLine(string message);
    void Write(string message);
    string? ReadLine();
}