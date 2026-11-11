using System.Threading.Tasks;

namespace OOP_Practice1.Infra.WebApi;

public interface IGenshinApiService
{
    Task<GenshinCharacterDto?> GetCharacterAsync(string name);
    Task<GenshinWeaponDto?> GetWeaponAsync(string name);
}