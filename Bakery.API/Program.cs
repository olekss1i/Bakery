using Bakery.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Добавляем DbContext с SQL Server (строку подключения берем из appsettings.json)
builder.Services.AddDbContext<BakeryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем контроллеры (Web API)
builder.Services.AddControllers();

// Добавляем Swagger (для автодокументации API)
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Bakery API",
        Version = "v1"
    });
});

var app = builder.Build();

// В режиме разработки включаем Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bakery API v1");
    });
}

// Включаем маршрутизацию
app.UseRouting();

// Включаем маппинг контроллеров
app.MapControllers();

app.Run();
