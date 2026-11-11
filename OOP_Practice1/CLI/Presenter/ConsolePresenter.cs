using OOP_Practice1.Infra.Display;

namespace OOP_Practice1.CLI.Presenter;

public class ConsolePresenter
{
    private readonly IDisplay _display;

    public ConsolePresenter(IDisplay display)
    {
        _display = display;
    }

    public void ShowHeader(string title)
    {
        _display.WriteLine($"\n=== {title} ===");
    }

    public void ShowMessage(string message)
    {
        _display.WriteLine(message);
    }

    // Ось цей метод треба додати:
    public void ShowError(string error)
    {
        _display.WriteLine($"[ERROR] {error}");
    }
}