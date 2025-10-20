namespace Lecture12.Models
{
    internal class Loan
    {
        public decimal amount;
        public float interestRate;
        public int termInMonths;
        public string borrowerUserName;
        public string loanType;
        public string status;
        public decimal outstandingBalance;
        public decimal monthlyPayment;

        public void displayLoan()
        {
            Console.WriteLine(amount);
            Console.WriteLine(interestRate);
            Console.WriteLine(termInMonths);
            Console.WriteLine(borrowerUserName);
            Console.WriteLine(loanType);
            Console.WriteLine(status);
            Console.WriteLine(outstandingBalance);
            Console.WriteLine(monthlyPayment);
        }
    }
}