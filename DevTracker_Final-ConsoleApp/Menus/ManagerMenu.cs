using DevTracker_Final_ConsoleApp.Data;
using DevTracker_Final_ConsoleApp.Models;

namespace DevTracker_Final_ConsoleApp.Menus;

internal class ManagerMenu
{
    private readonly TaskRepository taskRepo = new TaskRepository();
    private readonly UserRepository userRepo = new UserRepository();

    public void Start(User manager)
    {
        Console.WriteLine("Test");
    }
}
