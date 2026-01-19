namespace APIAssignment1_Login_and_Register.Interfaces;

internal interface IPasswordService
{
    string Hash(string password);
    bool Verify(string password, string hash);
}