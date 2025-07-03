using Bakery.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Підключення DbContext з рядком підключення з appsettings.json
builder.Services.AddDbContext<BakeryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Додаємо сервіси контролерів
builder.Services.AddControllers();

// Налаштовуємо Swagger/OpenAPI для документації API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Bakery API",
        Version = "v1"
    });
});

var app = builder.Build();

// Автоматично застосовуємо міграції і сідимо базу при старті програми
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BakeryDbContext>();
    dbContext.Database.Migrate(); // застосувати міграції (створити БД, якщо потрібно)
    dbContext.Seed();             // заповнити початковими даними
}

// У середовищі розробки вмикаємо Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bakery API v1");
    });
}

app.UseRouting();

app.UseAuthorization(); // якщо додаси авторизацію — поки можна залишити

app.MapControllers();

app.Run();
builder.Services.AddAutoMapper(typeof(MappingProfile));
