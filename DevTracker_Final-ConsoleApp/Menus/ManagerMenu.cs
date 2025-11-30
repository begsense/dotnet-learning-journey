using DevTracker_Final_ConsoleApp.Data;
using DevTracker_Final_ConsoleApp.Models;
using DevTracker_Final_ConsoleApp.Enums;
using DevTracker_Final_ConsoleApp.Helpers;
using DevTracker_Final_ConsoleApp.FileLogging;

namespace DevTracker_Final_ConsoleApp.Menus;

internal class ManagerMenu
{
    private readonly TaskRepository taskRepo = new TaskRepository();
    private readonly UserRepository userRepo = new UserRepository();
    private readonly Visualisation visual = new Visualisation();
    private readonly Logger logger = new Logger();

    public void Start(User manager)
    {
        visual.WriteColored($"Welcome {manager.UserName} !", ConsoleColor.Magenta);
        visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

        while (true)
        {
            visual.WriteColored("======Manager Menu =======", ConsoleColor.White, ConsoleColor.DarkCyan);

            visual.WriteColored("1. Add Task", ConsoleColor.DarkCyan);
            visual.WriteColored("2. Assign Task", ConsoleColor.DarkCyan);
            visual.WriteColored("3. Filter Tasks", ConsoleColor.DarkCyan);
            visual.WriteColored("4. Make User Manager", ConsoleColor.DarkCyan);
            visual.WriteColored("5. Logout", ConsoleColor.DarkCyan);

            visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

            visual.WriteColored("Choose: ", ConsoleColor.White, line: false);
            string input = Console.ReadLine();

            if (input == "1")
            {
                AddTask();
                logger.Log($"User Added Task: {manager.UserName} With Email: {manager.Email}, ID: {manager.Id}, Role: {manager.Role}");
            }
            else if (input == "2")
            {
                bool successfullyAssigned = AssignTask();
                if (successfullyAssigned)
                {
                    logger.Log($"Manager Assign Task: {manager.UserName} With Email: {manager.Email}, ID: {manager.Id}, to User");
                }
            }
            else if (input == "3")
            {
                FilterTasks();
                logger.Log($"Manager Filtered Tasks: {manager.UserName} With Email: {manager.Email}, ID: {manager.Id}, to User");
            }
            else if (input == "4")
            {
                MakeUserManager();
                logger.Log($"Manager Promote User: {manager.UserName} With Email: {manager.Email}, ID: {manager.Id}, to User");
            }
            else if (input == "5")
            {
                Console.Clear();
                Console.Beep(800, 200);
                visual.WriteColored("Loggout Successfully!", ConsoleColor.Green);
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

    private void AddTask()
    {
        Console.Clear();

        visual.WriteColored("======Manager Menu [Add Task]=======", ConsoleColor.White, ConsoleColor.DarkCyan);

        visual.WriteColored("Task Title: ", ConsoleColor.White, line: false);
        string title = Console.ReadLine();

        visual.WriteColored("Task Description: ", ConsoleColor.White, line: false);
        string desc = Console.ReadLine();

        var tasks = taskRepo.Load();
        int newId = tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;

        TaskItem task = new TaskItem
        {
            Id = newId,
            Title = title,
            Description = desc,
            Status = TASK_STATUS.New,
            Priority = TASK_PRIORITY.Medium,
            CreatedAt = DateTime.Now
        };

        tasks.Add(task);
        taskRepo.Save(tasks);

        Console.Beep(800, 200);
        visual.WriteColored($"Task '{title}' added successfully. [Press any key to back to the main menu]", ConsoleColor.Green);
        visual.ClearOnClick();
    }

    private bool AssignTask()
    {
        Console.Clear();

        visual.WriteColored("======Manager Menu [Assign Task]=======", ConsoleColor.White, ConsoleColor.DarkCyan);

        var tasks = taskRepo.Load().Where(t => t.AssignedDeveloperID == 0).ToList();
        var users = userRepo.Load().Where(u => u.Role != USER_ROLE.Manager).ToList();

        if (!tasks.Any())
        {
            Console.Beep(300, 500);
            visual.WriteColored("No unassigned tasks! try again [Press any key]", ConsoleColor.Red);
            visual.ClearOnClick();
            return false;
        }

        visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

        visual.WriteColored("Unassigned Tasks: ", ConsoleColor.White);

        foreach (var t in tasks)
        {
            visual.WriteColored($"[{t.Id}] {t.Title}", ConsoleColor.DarkCyan);
        }

        visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

        visual.WriteColored("Enter Task ID to assign: ", ConsoleColor.White, line: false);
        int taskId = int.Parse(Console.ReadLine());

        var task = tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null)
        {
            Console.Beep(300, 500);
            visual.WriteColored("Task not found! try again [Press any key]", ConsoleColor.Red);
            visual.ClearOnClick();
            return false;
        }

        visual.WriteColored("======Available Developers======", ConsoleColor.White, ConsoleColor.DarkCyan);

        foreach (var u in users)
        {
            visual.WriteColored($"[{u.Id}] {u.UserName}", ConsoleColor.DarkCyan);
        }

        visual.WriteColored("Enter Developer ID: ", ConsoleColor.White, line: false);
        int devId = int.Parse(Console.ReadLine());

        var dev = users.FirstOrDefault(u => u.Id == devId);
        if (dev == null)
        {
            Console.Beep(300, 500);
            visual.WriteColored("Developer not found! try again [Press any key]", ConsoleColor.Red);
            visual.ClearOnClick();
            return false;
        }

        task.AssignedDeveloperID = dev.Id;
        taskRepo.Save(taskRepo.Load());

        Console.Clear();
        Console.Beep(800, 200);
        visual.WriteColored($"Task '{task.Title}' assigned to {dev.UserName}.", ConsoleColor.Green);

        visual.WriteColored("[Press any key to back to Manager menu]", ConsoleColor.White);
        visual.ClearOnClick();

        return true;
    }

    private void FilterTasks()
    {
        Console.Clear();

        visual.WriteColored("======Manager Menu [Filter Task]=======", ConsoleColor.White, ConsoleColor.DarkCyan);

        var tasks = taskRepo.Load();

        visual.WriteColored("Filter by status", ConsoleColor.White);

        visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

        visual.WriteColored("1. New", ConsoleColor.DarkCyan);
        visual.WriteColored("2. InProgress", ConsoleColor.DarkCyan);
        visual.WriteColored("3. Completed", ConsoleColor.DarkCyan);
        visual.WriteColored("4. All", ConsoleColor.DarkCyan);

        visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

        visual.WriteColored("Enter Status: ", ConsoleColor.White, line: false);
        string choice = Console.ReadLine();

        var filteredTasks = new List<TaskItem>();

        if (choice == "1")
        {
            filteredTasks = tasks.Where(x => x.Status == TASK_STATUS.New).ToList();
        }
        else if (choice == "2")
        {
            filteredTasks = tasks.Where(x => x.Status == TASK_STATUS.InProgress).ToList();
        }
        else if (choice == "3")
        {
            filteredTasks = tasks.Where(x => x.Status == TASK_STATUS.Completed).ToList();
        }
        else
        {
            filteredTasks = tasks;
        }

        Console.Clear();
        Console.Beep(800, 200);

        visual.WriteColored("======Filtered Tasks======", ConsoleColor.White, ConsoleColor.DarkCyan);

        foreach (var t in filteredTasks)
        {
            visual.WriteColored($"[{t.Id}] {t.Title} - {t.Status} - Assigned to []: {(t.AssignedDeveloperID == 0 ? "Nobody" : t.AssignedDeveloperID.ToString())}", ConsoleColor.DarkCyan);
        }

        visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

        visual.WriteColored("[Press any key to back to Manager menu]", ConsoleColor.White);
        visual.ClearOnClick();
    }

    private void MakeUserManager()
    {
        Console.Clear();

        visual.WriteColored("======Manager Menu [Promote User to Manager]=======", ConsoleColor.White, ConsoleColor.DarkCyan);

        var users = userRepo.Load().Where(u => u.Role != USER_ROLE.Manager).ToList();

        if (!users.Any())
        {
            Console.Beep(300, 500);
            visual.WriteColored("No users to promote.! try again [Press any key]", ConsoleColor.Red);
            visual.ClearOnClick();
            return;
        }

        visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

        visual.WriteColored("Available Users: ", ConsoleColor.White);

        foreach (var u in users)
        {
            visual.WriteColored($"[{u.Id}] {u.UserName} - Role: {u.Role}", ConsoleColor.DarkCyan);
        }

        visual.WriteColored("==============================", ConsoleColor.DarkMagenta);

        visual.WriteColored("Enter User ID to promote to Manager: ", ConsoleColor.White, line: false);
        int userId = int.Parse(Console.ReadLine());

        var user = users.FirstOrDefault(u => u.Id == userId);

        if (user == null)
        {
            Console.Beep(300, 500);
            visual.WriteColored("User not found.! try again [Press any key]", ConsoleColor.Red);
            visual.ClearOnClick();
            return;
        }

        user.Role = USER_ROLE.Manager;
        userRepo.Save(userRepo.Load());

        Console.Beep(800, 200);
        visual.WriteColored($"{user.UserName} is now a Manager.", ConsoleColor.Green);

        visual.WriteColored("Press any key to back to Manager menu ", ConsoleColor.White);
        visual.ClearOnClick();
    }
}
