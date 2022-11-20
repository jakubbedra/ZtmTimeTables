using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ZtmTimeTables.Data;
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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:7146/",
            ValidAudience = "https://localhost:7146/",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("DhftOS5uphK3vmCJQrexST1RsyjZBjXWRgJMFPU4")
            )
        };
    });
builder.Services.AddMvc();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

//app.MapGet("/", () => "Hello World!");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();