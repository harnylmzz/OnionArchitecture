using Application.Validators.Products;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infastructure.Filters;

var builder = WebApplication.CreateBuilder(args);

// FluentValidation'u ekleyelim
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
})
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

// FluentValidation Middleware
builder.Services.AddFluentValidationAutoValidation(); // Bunu ekledim
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();

// OpenAPI ve diðer servisleri ekleyelim
builder.Services.AddOpenApi();
builder.Services.AddPersistenceServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
