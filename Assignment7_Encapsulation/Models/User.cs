namespace Assignment7_Encapsulation.Models;
internal class User
{
    private string _fullName;
    private decimal _balance = 0;
    private bool _isAdmin = false;

    public string FullName
    {
        get { return _fullName; }
        set { _fullName = value; }
    }
    public decimal Balance
    {
        get { return _balance; }
    }
    public bool IsAdmin
    {
        get { return _isAdmin; }
    }

    public void MakeAdmin()
    {
        _isAdmin = true;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            _balance += amount;
        }
    }
}