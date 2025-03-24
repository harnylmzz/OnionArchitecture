using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

public class OnionArchitectureDbContext : DbContext
{
    public OnionArchitectureDbContext(DbContextOptions<OnionArchitectureDbContext> options)
        : base(options)  // doğru yapılandırma
    { }

    public DbSet<Product> Products { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        //ChangeTracker : Entityler üzerinden yapılan değişiklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir.
        //Update operasyonlarında Track edilen verileri yakalayıp elde etmemizi sağlar.

        var datas = ChangeTracker
                  .Entries<BaseEntity>();

        foreach (var data in datas)
        {
            _ = data.State switch
            {
                EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }
        return await base.SaveChangesAsync(cancellationToken);
    }
}
