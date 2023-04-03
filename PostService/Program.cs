global using SharedModal;
global using DataAccess;
global using Microsoft.EntityFrameworkCore;
global using Response = SharedModal.ReponseModal.Response;
using PostService.Service;
using PostService.Mapper;
using PostService.Service.Repository;
using CommonCalls;
using SharedModal.Modals;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>().AddProjections().AddSorting().AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MapperCls).Assembly);

builder.Services.AddScoped<IProductCatagoryRepository, ProductCatagoryRepository>();
builder.Services.AddScoped<ICatagoryTypeRepository, CatagoryTypeRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IManager<ProductCatagory>, Manager<ProductCatagory>>();
builder.Services.AddScoped<IRepository<ProductCatagory>, Repository<ProductCatagory>>();

builder.Services.AddScoped<IManager<CatagoryType>, Manager<CatagoryType>>();
builder.Services.AddScoped<IRepository<CatagoryType>, Repository<CatagoryType>>();

builder.Services.AddScoped<IManager<Product>, Manager<Product>>();
builder.Services.AddScoped<IRepository<Product>, Repository<Product>>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:ManigdhaServer").Value, b => b.MigrationsAssembly("UserService"));
});
builder.Services.AddLogging(builder => builder.AddConsole());

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
