using PhoneApiSchoolProject.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOsService, OsService>();
builder.Services.AddScoped<IPhoneService, PhoneService>();
builder.Services.AddScoped<IAppsService, AppsService>();

builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
