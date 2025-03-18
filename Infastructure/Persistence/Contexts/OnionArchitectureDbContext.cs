using Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class OnionArchitectureDbContext : DbContext
{
    public OnionArchitectureDbContext(DbContextOptions<OnionArchitectureDbContext> options)
        : base(options)  // doğru yapılandırma
    { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
}
