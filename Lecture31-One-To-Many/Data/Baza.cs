using Lecture31_One_To_Many.Models;
using Microsoft.EntityFrameworkCore;

namespace Lecture31_One_To_Many.Data;

public class Baza : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<BankAccount> BankAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OneToMany;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
