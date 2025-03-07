using BusinessLayer.Interface;
using BusinessLayer.Service;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IGreetingBL, GreetingBL>();
builder.Services.AddScoped<IGreetingRL, GreetingRL>();

var logger = LogManager.Setup()
    .LoadConfigurationFromFile(Path.Combine(Directory.GetCurrentDirectory(), "NLog.config"))
    .GetCurrentClassLogger();

builder.Host.UseNLog();

var connectionString = builder.Configuration.GetConnectionString("SqlConnection");

builder.Services.AddDbContext<HelloGreetingContext>(options =>
    options.UseSqlServer(connectionString));

//Add swagger to container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
