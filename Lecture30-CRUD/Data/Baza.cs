namespace Lecture30_CRUD.Data;
using Microsoft.EntityFrameworkCore;
using Lecture30_CRUD.Models;

public class Baza : DbContext
{
    public DbSet<Product> Products
    {
        get; set;

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=APICRUD;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
    }
}
