using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OOP_Practice1.Infra.WebApi;

public class GenshinApiService : IGenshinApiService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "https://genshin.jmp.blue/";

    public GenshinApiService(HttpClient? httpClient = null)
    {
        _httpClient = httpClient ?? new HttpClient();
    }

    public async Task<GenshinCharacterDto?> GetCharacterAsync(string name)
    {
        try
        {
            string url = $"{BaseUrl}characters/{name.ToLower()}";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<GenshinCharacterDto>(json);
        }
        catch
        {
            return null;
        }
    }

    public async Task<GenshinWeaponDto?> GetWeaponAsync(string name)
    {
        try
        {
            string url = $"{BaseUrl}weapons/{name.ToLower().Replace(" ", "-")}";
            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return null;

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<GenshinWeaponDto>(json);
        }
        catch
        {
            return null;
        }
    }
}