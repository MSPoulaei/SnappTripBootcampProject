using SnappTrip.BusinessLayer.Interfaces;
using SnappTrip.BusinessLayer.Services;
using Microsoft.EntityFrameworkCore;
using SnappTrip;
using System.Net;
using SnappTrip.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddMemoryCache();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//string connectionString = builder.Configuration.GetConnectionString("WebApiDatabase") ?? "Server=db;Database=SnappTripDB;User=sa;Password=Your_password123;";
//string connectionString = $"Server={DockerHostMachineIpAddress},1433;Database=SnappTripDB;User=sa;Password=Your_password123;";
string connectionString = "host=db;port=5432;database=SnappTripDB;username=sa;password=Your_password123";
//builder.Services.AddDbContext<SnappTrip.DataAccessLayer.SnappTripDbContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddDbContext<SnappTripDbContext>(x => x.UseNpgsql(connectionString));
builder.Services.AddTransient<IPopulateRepos, PopulateRepositoryHomeMadeCache>();
builder.Services.AddTransient<IApplyRepos, ApplyRepository>();


//builder.Services.UseSqlServer();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


DatabaseManagementService.MigrationInitialisation(app);//apply migration
((IPopulateRepos)builder.Services.BuildServiceProvider().GetService(typeof(IPopulateRepos))).Populate();//populate dump data

app.Run();
