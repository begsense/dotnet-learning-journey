using Microsoft.EntityFrameworkCore;
using APIAssignment2_NeoBank.Models;

namespace APIAssignment2_NeoBank.Data;

public class Baza : DbContext
{
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<UserAccount> UserAccounts { get; set; }
    public DbSet<AppSettings> AppSettings { get; set; }
    public DbSet<FinancialProfile> FinancialProfiles { get; set; }
    public DbSet<PassportDetails> PassportDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=NeoBank;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
