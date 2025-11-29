using DevTracker_Final_ConsoleApp.Models;

namespace DevTracker_Final_ConsoleApp.Interfaces;

internal interface IUserRepository
{
    List<User> Load();
    void Save(List<User> users);
}
