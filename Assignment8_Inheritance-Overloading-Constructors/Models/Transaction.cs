namespace Assignment8_Inheritance_Overloading_Constructors.Models;

internal class Transaction
{
    private readonly string _transactionId;

    private readonly double _amount;

    public string TransactionId
    {
        get { return _transactionId; }
    }

    public double Amount
    {
        get { return _amount; }
    }

    public Transaction(double amount)
    {
        _amount = amount;
        _transactionId = DateTime.Now.Ticks.ToString();
    }


}
