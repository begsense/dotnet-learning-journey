using DevTracker_Final_ConsoleApp.Models;

namespace DevTracker_Final_ConsoleApp.Interfaces;

internal interface IAuthService
{
    User SignIn(string email, string password);
    bool SignUp(string email, string userName, string password);
}
