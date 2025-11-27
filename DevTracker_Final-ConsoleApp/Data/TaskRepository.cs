using System.Text.Json;
using System.Text.Json.Serialization;

using DevTracker_Final_ConsoleApp.Models;

namespace DevTracker_Final_ConsoleApp.Data;

internal class TaskRepository
{
    private readonly string filePath;

    public TaskRepository()
    {
        var projectRoot =
            Directory.GetParent(AppContext.BaseDirectory).Parent.Parent.Parent.FullName;

        var dataDir = Path.Combine(projectRoot, "Data");

        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);

        filePath = Path.Combine(dataDir, "tasks.json");
    }

    public List<TaskItem> Load()
    {
        if (!File.Exists(filePath))
        {
            return new List<TaskItem>();
        }

        string json = File.ReadAllText(filePath);

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        };

        return JsonSerializer.Deserialize<List<TaskItem>>(json, options);
    }

    public void Save(List<TaskItem> tasks)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Converters = { new JsonStringEnumConverter() }
        };

        string json = JsonSerializer.Serialize(tasks, options);
        File.WriteAllText(filePath, json);
    }
}
