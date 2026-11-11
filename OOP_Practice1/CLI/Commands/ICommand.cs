namespace OOP_Practice1.CLI.Commands;

/// <summary>
/// Патерн Command: інкапсулює запити та дії у вигляді об'єктів.
/// Дозволяє параметризувати об'єкти різними операціями, ставити запити в чергу 
/// та підтримувати виконання чи скасування дій через CLI.
/// </summary>
public interface ICommand
{
    string Name { get; }
    void Execute(string[] args);
}