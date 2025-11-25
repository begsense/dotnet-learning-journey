using System.Text.Json;

using DevTracker_Final_ConsoleApp.Models;

namespace DevTracker_Final_ConsoleApp.Data;

internal class UserRepository
{
    private readonly string path = "Data/users.json";

    public List<User> Load()
    {
        if (!File.Exists(path))
        {
            return new List<User>();
        }

        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();
    }

    public void Save(List<User> users)
    {
        string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }
}
