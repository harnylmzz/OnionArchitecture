using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {

        //IoC Container
        services.AddDbContext<OnionArchitectureDbContext>(options =>
        {
            options.UseNpgsql("User ID=postgres;Password=1;Host=localhost;Port=5432;Database=EticaretAPIDb");
        });
        services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
        services.AddScoped<IProductReadRepository, ProductReadRepository>();
        services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

    }
}
