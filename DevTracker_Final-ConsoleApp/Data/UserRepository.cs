using System.Text.Json;
using System.Text.Json.Serialization;

using DevTracker_Final_ConsoleApp.Models;
using DevTracker_Final_ConsoleApp.Interfaces;

namespace DevTracker_Final_ConsoleApp.Data;

internal class UserRepository : IUserRepository
{
    private readonly string filePath;

    public UserRepository()
    {
        var projectRoot =
            Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;

        var dataDir = Path.Combine(projectRoot, "Data");

        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);

        filePath = Path.Combine(dataDir, "users.json");
    }

    public List<User> Load()
    {
        if (!File.Exists(filePath))
        {
            return new List<User>();
        }

        string json = File.ReadAllText(filePath);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };

        return JsonSerializer.Deserialize<List<User>>(json, options);
    }

    public void Save(List<User> users)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        string json = JsonSerializer.Serialize(users, options);
        File.WriteAllText(filePath, json);
    }
}
