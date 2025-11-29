using DevTracker_Final_ConsoleApp.Models;

namespace DevTracker_Final_ConsoleApp.Interfaces;

internal interface ITaskRepository
{
    List<TaskItem> Load();
    void Save(List<TaskItem> tasks);
}
