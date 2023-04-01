global using SharedModal;
global using DataAccess;
global using Microsoft.EntityFrameworkCore;
global using Response = SharedModal.ReponseModal.Response;
using PostService.Service;
using PostService.Mapper;
using PostService.Service.Repository;
using CommonCalls;
using SharedModal.Modals;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>().AddProjections().AddSorting().AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(ReponseMapper).Assembly);
builder.Services.AddScoped<IProductCatagoryRepository, ProductCatagoryRepository>();
builder.Services.AddScoped<ICommon<ProductCatagory>, IProductCatagoryRepository>();
builder.Services.AddScoped<IManager<ProductCatagory>, Manager<ProductCatagory>>();
builder.Services.AddScoped<IRepository<ProductCatagory>, Repository<ProductCatagory>>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapGraphQL("/graphql");

app.Run();
public partial class Program { }
