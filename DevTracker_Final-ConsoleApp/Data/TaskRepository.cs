using System.Text.Json;

using DevTracker_Final_ConsoleApp.Models;

namespace DevTracker_Final_ConsoleApp.Data;

internal class TaskRepository
{
    private readonly string path = "Data/tasks.json";

    public List<TaskItem> Load()
    {
        if (!File.Exists(path))
        {
            return new List<TaskItem>();
        }

        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
    }

    public void Save(List<TaskItem> tasks)
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
    }
}
