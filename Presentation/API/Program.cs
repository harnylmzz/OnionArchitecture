using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger'ý ekle
builder.Services.AddEndpointsApiExplorer();  // API explorer'ý ekliyoruz
builder.Services.AddSwaggerGen(c =>   // SwaggerGen'i ekliyoruz
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OnionArchitecture API",
        Version = "v1",
        Description = "Onion Architecture API"
    });
});

// Diðer servisler
builder.Services.AddPersistenceServices();

var app = builder.Build();

// Swagger'ý geliþtirme ortamýnda etkinleþtir
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Swagger'ý aktif hale getiriyoruz
    app.UseSwaggerUI(c =>  // Swagger UI'yi ekliyoruz
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnionArchitecture API v1");  // Swagger endpoint
        c.RoutePrefix = string.Empty; // Ana sayfada Swagger UI açýlacak
    });
}

// Diðer middleware'lar
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
