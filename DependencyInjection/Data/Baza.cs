using Microsoft.EntityFrameworkCore;
using DependencyInjection.Models;

namespace DependencyInjection.Data;

public class Baza : DbContext
{
    public DbSet<Food> Foods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BegiTestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
