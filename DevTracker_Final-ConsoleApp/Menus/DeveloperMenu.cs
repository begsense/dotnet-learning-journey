using DevTracker_Final_ConsoleApp.Data;
using DevTracker_Final_ConsoleApp.Enums;
using DevTracker_Final_ConsoleApp.Models;
using DevTracker_Final_ConsoleApp.Helpers;
using DevTracker_Final_ConsoleApp.FileLogging;

namespace DevTracker_Final_ConsoleApp.Menus;

internal class DeveloperMenu
{
    private readonly TaskRepository taskRepo = new TaskRepository();
    private readonly Visualisation visual = new Visualisation();
    private readonly Logger logger = new Logger();

    public void Start(User developer)
    {
        Console.Clear();
        visual.WriteColored($"Welcome {developer.UserName}", ConsoleColor.Magenta);
        visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

        while (true)
        {
            visual.WriteColored("======Developer Menu======", ConsoleColor.White, ConsoleColor.DarkCyan);

            visual.WriteColored("1. Assigned Tasks", ConsoleColor.DarkCyan);
            visual.WriteColored("2. Change Task Status", ConsoleColor.DarkCyan);
            visual.WriteColored("3. Logout", ConsoleColor.DarkCyan);

            visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

            visual.WriteColored("Choose: ", ConsoleColor.White, line: false);
            string input = Console.ReadLine();

            if (input == "1")
            {
                bool successfullyShown = ShowAssignedTasks(developer.Id);

                if (successfullyShown)
                {
                    logger.Log($"User opened Tasks list: {developer.UserName} With Email: {developer.Email}, ID: {developer.Id}, Role: {developer.Role}");
                }
            }
            else if (input == "2")
            {
                bool successfullyChanged = ChangeStatus(developer.Id);

                if (successfullyChanged)
                {
                    logger.Log($"User changed Tasks Status: {developer.UserName} With Email: {developer.Email}, ID: {developer.Id}, Role: {developer.Role}");
                }
            }
            else if (input == "3")
            {
                Console.Clear();
                break;
            }
            else
            {
                Console.Beep(300, 500);
                visual.WriteColored("Something went wrong, try again [Press any key].", ConsoleColor.Red);
                visual.ClearOnClick();
            }
        }
    }

    private bool ShowAssignedTasks(int devId)
    {
        Console.Clear();

        visual.WriteColored("======Developer Menu [Show Assigned Tasks]=======", ConsoleColor.White, ConsoleColor.DarkCyan);

        var tasks = taskRepo.Load().Where(t => t.AssignedDeveloperID == devId).ToList();

        if (!tasks.Any())
        {
            Console.Beep(300, 500);
            visual.WriteColored("Something went wrong!", ConsoleColor.Red);
            return false;
        }

        visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

        visual.WriteColored("Assigned Tasks: ", ConsoleColor.White);

        foreach (var t in tasks)
        {
            string id = t.Id.ToString().PadRight(5);
            string title = t.Title.PadRight(30);
            string status = t.Status.ToString().PadRight(12);

            visual.WriteColored(
                $"ID: {id} | Title: {title} | Status: {status}",
                ConsoleColor.DarkCyan
            );
        }


        visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

        visual.WriteColored("Press any key to back to Developer menu ", ConsoleColor.White);
        visual.ClearOnClick();

        return true;
    }

    private bool ChangeStatus(int devId)
    {
        Console.Clear();

        visual.WriteColored("======Developer Menu [Change Status]=======", ConsoleColor.White, ConsoleColor.DarkCyan);

        var tasks = taskRepo.Load().Where(t => t.AssignedDeveloperID == devId).ToList();

        if (!tasks.Any())
        {
            Console.Beep(300, 500);
            visual.WriteColored("No tasks to update!", ConsoleColor.Red);
            return false;
        }

        visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

        visual.WriteColored("Available Tasks: ", ConsoleColor.White);

        foreach (var t in tasks)
        {
            string taskId = t.Id.ToString().PadRight(5);
            string title = t.Title.PadRight(30);

            visual.WriteColored(
                $"ID: {taskId} | Title: {title}",
                ConsoleColor.DarkCyan
            );
        }


        visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

        visual.WriteColored("Enter Task ID: ", ConsoleColor.White, line: false);
        int.TryParse(Console.ReadLine(), out int id);

        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            Console.Beep(300, 500);
            visual.WriteColored("Task not found!", ConsoleColor.Red);
            return false;
        }

        visual.WriteColored("1. New", ConsoleColor.DarkCyan);
        visual.WriteColored("2. InProgress", ConsoleColor.DarkCyan);
        visual.WriteColored("3. Completed", ConsoleColor.DarkCyan);

        visual.WriteColored("Choose status: ", ConsoleColor.White, line: false);
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            task.Status = TASK_STATUS.New;
            task.CreatedAt = DateTime.Now;
        }
        else if (choice == "2")
        {
            task.Status = TASK_STATUS.InProgress;
            task.StartedAt = DateTime.Now;
        }
        else if (choice == "3")
        {
            task.Status = TASK_STATUS.Completed;
            task.CompletedAt = DateTime.Now;
        }
        else
        {
            Console.Beep(300, 500);
            visual.WriteColored("Something went wrong!", ConsoleColor.Red);
            return false;
        }

        var all = taskRepo.Load();
        var index = all.FindIndex(x => x.Id == task.Id);
        all[index] = task;
        taskRepo.Save(all);

        Console.Beep(800, 200);
        visual.WriteColored("Status updated", ConsoleColor.Green);

        visual.WriteColored("Press any key to back to Developer menu ", ConsoleColor.White);
        visual.ClearOnClick();

        return true;
    }
}