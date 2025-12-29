using Microsoft.EntityFrameworkCore;
using Lecture27.Models;

namespace Lecture27.Database;

internal class Data : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Burger> Burgers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BurgerShop;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
