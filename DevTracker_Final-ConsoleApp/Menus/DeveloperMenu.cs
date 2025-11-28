using DevTracker_Final_ConsoleApp.Data;
using DevTracker_Final_ConsoleApp.Enums;
using DevTracker_Final_ConsoleApp.Models;
using DevTracker_Final_ConsoleApp.Helpers;
using System;

namespace DevTracker_Final_ConsoleApp.Menus;

internal class DeveloperMenu
{
    private readonly TaskRepository taskRepo = new TaskRepository();
    private readonly Visualisation visual = new Visualisation();

    public void Start(User developer)
    {
        visual.WriteColored($"Welcome {developer.UserName}", ConsoleColor.DarkGreen);
        Console.WriteLine();

        while (true)
        {
            visual.WriteColored("======Developer Menu======", ConsoleColor.White, ConsoleColor.DarkCyan);

            visual.WriteColored("1. Assigned Tasks", ConsoleColor.DarkCyan);
            visual.WriteColored("2. Change Task Status", ConsoleColor.DarkCyan);
            visual.WriteColored("3. Logout", ConsoleColor.DarkCyan);

            Console.WriteLine();

            visual.WriteColored("Choose: ", ConsoleColor.White, line: false);
            string input = Console.ReadLine();

            if (input == "1")
            {
                ShowAssignedTasks(developer.Id);
            }
            else if (input == "2")
            {
                ChangeStatus(developer.Id);
            }
            else if (input == "3")
            {
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

    private void ShowAssignedTasks(int devId)
    {
        Console.Clear();

        visual.WriteColored("======Developer Menu [Show Assigned Tasks]=======", ConsoleColor.White, ConsoleColor.DarkCyan);

        var tasks = taskRepo.Load().Where(t => t.AssignedDeveloperID == devId).ToList();

        if (!tasks.Any())
        {
            Console.Beep(300, 500);
            visual.WriteColored("Something went wrong!", ConsoleColor.Red);
            return;
        }

        visual.WriteColored("============Assigned Tasks==============", ConsoleColor.White, ConsoleColor.DarkCyan);

        foreach (var t in tasks)
        {
            visual.WriteColored($"[{t.Id}] {t.Title} - {t.Status}", ConsoleColor.DarkCyan);
        }
    }

    private void ChangeStatus(int devId)
    {
        Console.Clear();

        visual.WriteColored("======Developer Menu [Change Status]=======", ConsoleColor.White, ConsoleColor.DarkCyan);

        var tasks = taskRepo.Load().Where(t => t.AssignedDeveloperID == devId).ToList();

        if (!tasks.Any())
        {
            Console.Beep(300, 500);
            visual.WriteColored("No tasks to update!", ConsoleColor.Red);
            return;
        }

        visual.WriteColored("Enter Task ID: ", ConsoleColor.White, line: false);
        int id = int.Parse(Console.ReadLine());

        var task = tasks.FirstOrDefault(t => t.Id == id);

        if (task == null)
        {
            Console.Beep(300, 500);
            visual.WriteColored("Task not found!", ConsoleColor.Red);
            return;
        }

        visual.WriteColored("1. New", ConsoleColor.DarkCyan);
        visual.WriteColored("2. InProgress", ConsoleColor.DarkCyan);
        visual.WriteColored("3. LCompleted", ConsoleColor.DarkCyan);

        visual.WriteColored("Choose status: ", ConsoleColor.White, line: false);
        string choice = Console.ReadLine();

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
            Console.Beep(300, 500);
            visual.WriteColored("Something went wrong!", ConsoleColor.Red);
        }

        var all = taskRepo.Load();
        var index = all.FindIndex(x => x.Id == task.Id);
        all[index] = task;
        taskRepo.Save(all);

        Console.Beep(800, 200);
        visual.WriteColored("Status updated", ConsoleColor.Green);
        visual.ClearOnClick();
    }
}