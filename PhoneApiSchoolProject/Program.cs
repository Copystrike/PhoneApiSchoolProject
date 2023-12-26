using Microsoft.EntityFrameworkCore;
using PhoneApiSchoolProject.Models;
using PhoneApiSchoolProject.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PhoneContext>(options =>
{
    const string connectionString = "Server=localhost;Port=3306;Database=phone_db;User=root;";
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

const bool useDatabase = true;

if (useDatabase)
{
    builder.Services.AddScoped<IOsService, DbOsService>();
    builder.Services.AddScoped<IPhoneService, DbPhoneService>();
    builder.Services.AddScoped<IAppsService, DbAppsService>();
}
else
{
    builder.Services.AddScoped<IOsService, InMemoryOsService>();
    builder.Services.AddScoped<IPhoneService, InMemoryPhoneService>();
    builder.Services.AddScoped<IAppsService, InMemoryAppsService>();
}

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.EnableTryItOutByDefault());
}

app.UseAuthorization();

app.MapControllers();

app.Run();
