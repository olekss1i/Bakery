using Bakery.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ��������� DbContext � SQL Server (������ ����������� ����� �� appsettings.json)
builder.Services.AddDbContext<BakeryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ��������� ����������� (Web API)
builder.Services.AddControllers();

// ��������� Swagger (��� ���������������� API)
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Bakery API",
        Version = "v1"
    });
});

var app = builder.Build();

// � ������ ���������� �������� Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bakery API v1");
    });
}

// �������� �������������
app.UseRouting();

// �������� ������� ������������
app.MapControllers();

app.Run();
