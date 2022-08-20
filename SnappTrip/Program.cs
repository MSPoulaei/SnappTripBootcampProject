using SnappTrip.BusinessLayer.Interfaces;
using SnappTrip.BusinessLayer.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddMemoryCache();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SnappTrip.DataAccessLayer.SnappTripDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDatabase")));
builder.Services.AddTransient<IPopulateRepos, PopulateRepositoryHomeMadeCache>();
builder.Services.AddTransient<IApplyRepos, ApplyRepository>();


//builder.Services.UseSqlServer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

((IPopulateRepos)builder.Services.BuildServiceProvider().GetService(typeof(IPopulateRepos))).Populate();
app.Run();
