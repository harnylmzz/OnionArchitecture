using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Swagger'� ekle
builder.Services.AddEndpointsApiExplorer();  // API explorer'� ekliyoruz
builder.Services.AddSwaggerGen(c =>   // SwaggerGen'i ekliyoruz
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "OnionArchitecture API",
        Version = "v1",
        Description = "Onion Architecture API"
    });
});

// Di�er servisler
builder.Services.AddPersistenceServices();

var app = builder.Build();

// Swagger'� geli�tirme ortam�nda etkinle�tir
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Swagger'� aktif hale getiriyoruz
    app.UseSwaggerUI(c =>  // Swagger UI'yi ekliyoruz
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnionArchitecture API v1");  // Swagger endpoint
        c.RoutePrefix = string.Empty; // Ana sayfada Swagger UI a��lacak
    });
}

// Di�er middleware'lar
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
