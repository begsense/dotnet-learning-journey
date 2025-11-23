using DevTracker_Final_ConsoleApp.Enums;

namespace DevTracker_Final_ConsoleApp.Models;

internal class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int AssignedDeveloperID { get; set; }
    public TASK_PRIORITY Priority { get; set; }
    public TASK_STATUS Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime CompletedAt { get; set; }
}
