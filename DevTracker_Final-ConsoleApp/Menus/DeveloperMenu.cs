using DevTracker_Final_ConsoleApp.Data;
using DevTracker_Final_ConsoleApp.Enums;
using DevTracker_Final_ConsoleApp.Models;
using DevTracker_Final_ConsoleApp.Helpers;

namespace DevTracker_Final_ConsoleApp.Menus;

internal class DeveloperMenu
{
    private readonly TaskRepository taskRepo = new TaskRepository();
    private readonly Visualisation visual = new Visualisation();

    public void Start(User developer)
    {
        while (true)
        {
            visual.WriteColored("============Developer Menu==============", ConsoleColor.Cyan);
            visual.WriteColored("1. Assigned Tasks", ConsoleColor.Yellow);
            visual.WriteColored("2. Change Task Status", ConsoleColor.Yellow);
            visual.WriteColored("3. Logout", ConsoleColor.Yellow);

            Console.Write("Choose: ");
            string input = Console.ReadLine();

            if (input == "1")
                ShowAssignedTasks(developer.Id);
            else if (input == "2")
                ChangeStatus(developer.Id);
            else if (input == "3")
                break;
            else
                Console.WriteLine("Something went wrong.");
        }
    }

    private void ShowAssignedTasks(int devId)
    {
        var tasks = taskRepo.Load().Where(t => t.AssignedDeveloperID == devId).ToList();

        if (!tasks.Any())
        {
            Console.WriteLine("Something went wrong");
            return;
        }

        foreach (var t in tasks)
        {
            visual.WriteColored($"[{t.Id}] {t.Title} - {t.Status}");
        }
    }

    private void ChangeStatus(int devId)
    {
        var tasks = taskRepo.Load().Where(t => t.AssignedDeveloperID == devId).ToList();

        if (!tasks.Any())
        {
            Console.WriteLine("No tasks to update.");
            return;
        }

        Console.Write("Enter Task ID: ");
        int id = int.Parse(Console.ReadLine());

        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            Console.WriteLine("Task not found.");
            return;
        }

        visual.WriteColored("1. ToDo\n2. InProgress\n3. Completed");

        Console.Write("Choose status: ");
        string choice = Console.ReadLine();

        task.Status = choice switch
        {
            "1" => TASK_STATUS.New,
            "2" => TASK_STATUS.InProgress,
            "3" => TASK_STATUS.Completed,
            _ => task.Status
        };

        if (choice == "1")
        {
            task.Status = TASK_STATUS.New;
        }
        else if (choice == "2")
        {
            task.Status = TASK_STATUS.InProgress;
        }
        else if (choice == "3")
        {
            task.Status = TASK_STATUS.Completed;
        }
        else
        {
            visual.WriteColored("Something went wrong", ConsoleColor.Red);
        }

        var all = taskRepo.Load();
        var index = all.FindIndex(x => x.Id == task.Id);
        all[index] = task;
        taskRepo.Save(all);

        visual.WriteColored("Status updated");
    }
}