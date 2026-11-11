using System.IO;
using System.Text.Json;

namespace OOP_Practice1.Infra.Data;

public static class DataSerializer
{
    // Utility methods for state serialization and deserialization
    public static void SaveToJson<T>(string filePath, T data)
    {
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    public static T? LoadFromJson<T>(string filePath)
    {
        if (!File.Exists(filePath)) return default;
        string json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }
}