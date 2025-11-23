namespace DevTracker_Final_ConsoleApp.Interfaces;

internal interface IPasswordService
{
    string Hash(string password);
    bool Verify(string password, string hash);
}
