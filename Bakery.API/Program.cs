using Bakery.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// ϳ��������� DbContext � ������ ���������� � appsettings.json
builder.Services.AddDbContext<BakeryDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ������ ������ ����������
builder.Services.AddControllers();

// ����������� Swagger/OpenAPI ��� ������������ API
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Bakery API",
        Version = "v1"
    });
});

var app = builder.Build();

// ����������� ����������� ������� � ����� ���� ��� ����� ��������
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BakeryDbContext>();
    dbContext.Database.Migrate(); // ����������� ������� (�������� ��, ���� �������)
    dbContext.Seed();             // ��������� ����������� ������
}

// � ���������� �������� ������� Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bakery API v1");
    });
}

app.UseRouting();

app.UseAuthorization(); // ���� ������ ����������� � ���� ����� ��������

app.MapControllers();

app.Run();
builder.Services.AddAutoMapper(typeof(MappingProfile));
