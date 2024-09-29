using Microsoft.EntityFrameworkCore;
using RendaFixa.Domain.Entities;
using RendaFixa.Domain.Interfaces;
using RendaFixa.Infrastruct.Context;
using RendaFixa.Infrastruct.Repository;
using RendaFixa.Service.Services;

var builder = WebApplication.CreateBuilder(args);

//Conection DB
var configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

IConfigurationRoot configuration = configurationBuilder.Build();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//BD
builder.Services.AddDbContext<AppDbContext>(p =>
{
    p.UseSqlServer(configuration.GetConnectionString("SqlServer"),
    m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
});

//builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

builder.Services.AddScoped<IBaseRepository<ProdutoRendaFixa>, BaseRepository<ProdutoRendaFixa>>();
builder.Services.AddScoped<IProdutoRendaFixaService, ProdutoRendaFixaService>();

//USANDO O AUTOMAPPER PARA UTILIZAR AS VIEWS MODELS
//builder.Services.AddSingleton(new MapperConfiguration(config =>
//{
//    config.CreateMap<CreateUserModel, User>();
//    config.CreateMap<UpdateUserModel, User>();
//    config.CreateMap<User, UserModel>();
//}).CreateMapper());
var app = builder.Build();



// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
