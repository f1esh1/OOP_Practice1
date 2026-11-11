using System.Text.Json.Serialization;

namespace OOP_Practice1.Infra.WebApi;

public class GenshinCharacterDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("vision")]
    public string Vision { get; set; } = string.Empty;

    [JsonPropertyName("weapon")]
    public string WeaponType { get; set; } = string.Empty;

    [JsonPropertyName("rarity")]
    public int Rarity { get; set; } = 4;

    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}

public class GenshinWeaponDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("rarity")]
    public int Rarity { get; set; } = 1;

    [JsonPropertyName("baseAttack")]
    public int BaseAttack { get; set; } = 20;
}