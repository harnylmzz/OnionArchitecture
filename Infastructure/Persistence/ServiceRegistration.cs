using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<OnionArchitectureDbContext>(options =>
        {
            options.UseNpgsql("User ID=postgres;Password=1;Host=localhost;Port=5432;Database=EticaretAPIDb");
        });
    }
}
