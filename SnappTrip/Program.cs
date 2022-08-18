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
//builder.Services.AddTransient<populate>();
new populate(builder.Services.BuildServiceProvider());

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

app.Run();

class populate
{
    private readonly IServiceProvider services;

    public populate(IServiceProvider services)
    {
        this.services = services;
        IPopulateRepos populater = (IPopulateRepos)services.GetService(typeof(IPopulateRepos));
        populater.Populate();
    }

}