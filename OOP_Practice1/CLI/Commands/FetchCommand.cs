using OOP_Practice1.Core.GameSystem;
using OOP_Practice1.Core.Text;
using OOP_Practice1.Core.TextSystem;
using OOP_Practice1.Infra.WebApi;
using System;
using System.Threading.Tasks;

namespace OOP_Practice1.CLI.Commands;

public class FetchCommand : ICommand
{
    private readonly IGenshinApiService _apiService;

    public FetchCommand(IGenshinApiService? apiService = null)
    {
        _apiService = apiService ?? new GenshinApiService();
    }

    public string Name => "fetch";

    public void Execute(string[] args)
    {
        // Execute async logic synchronously for CLI command interface
        ExecuteAsync(args).GetAwaiter().GetResult();
    }

    private async Task ExecuteAsync(string[] args)
    {
        if (args.Length < 1)
        {
            Console.WriteLine("Usage: fetch <character_name> [weapon_name]");
            Console.WriteLine("Example: fetch amber dull-blade");
            return;
        }

        string charName = args[0];
        string weaponName = args.Length > 1 ? args[1] : "dull-blade";

        Console.WriteLine($"[API] Fetching data for character '{charName}'...");
        var charDto = await _apiService.GetCharacterAsync(charName);

        if (charDto == null)
        {
            Console.WriteLine($"[ERROR] Character '{charName}' not found in remote API.");
            return;
        }

        // 1. Transform DTO to Core model
        Warrior warrior = CharacterFactory.CreateFromGenshin(charDto);
        GameStore.Characters.Add(warrior);

        // 2. Fetch and equip weapon
        Console.WriteLine($"[API] Fetching weapon '{weaponName}'...");
        var weaponDto = await _apiService.GetWeaponAsync(weaponName);
        if (weaponDto != null)
        {
            Item weapon = CharacterFactory.CreateWeaponFromGenshin(weaponDto);
            warrior.EquipItem(weapon);
        }

        // 3. Generate and display structured text representation
        TextDocument doc = CharacterPresenter.BuildCharacterReport(warrior, charDto.Vision, charDto.Description);
        Console.WriteLine("\n--- GENERATED STRUCTURED TEXT REPORT ---");
        Console.WriteLine(doc.RenderDocument());
    }
}