using ZtmTimeTables.Data;
using ZtmTimeTables.Entity;
using ZtmTimeTables.Repository;
using ZtmTimeTables.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>();

// repositories
builder.Services.AddScoped<ZtmVehicleRepository>();
builder.Services.AddScoped<ZtmStopRepository>();
builder.Services.AddScoped<ZtmVehicleArrivalRepository>();

// services
builder.Services.AddScoped<ZtmVehicleService>();
builder.Services.AddScoped<ZtmStopService>();
builder.Services.AddScoped<ZtmVehicleArrivalService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.MapGet("/", () => "Hello World!");

app.MapControllers();

app.Run();