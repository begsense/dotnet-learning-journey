using Microsoft.EntityFrameworkCore;
using Lecture29_One_To_One.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Lecture29_One_To_One.Data;

public class Baza : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserDetails> UsersDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OneToOne;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
