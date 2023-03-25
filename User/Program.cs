global using SharedModal;
global using DataAccess;
global using Microsoft.EntityFrameworkCore;
using UserService.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddProjections().AddSorting();
builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:ManigdhaServer").Value, b => b.MigrationsAssembly("UserService"));
});
builder.Services.AddLogging(builder => builder.AddConsole());
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

app.MapGraphQL("/graphql");

app.Run();
