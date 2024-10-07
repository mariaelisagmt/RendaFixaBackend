using RendaFixa.Infrastruct.Config;
using RendaFixa.Service.Config;

var builder = WebApplication.CreateBuilder(args);

// Configurar CORS para permitir o Angular acessar a API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Endere�o do Angular
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.ConfigureInfrastructApp(builder.Configuration);
builder.Services.ConfigureApplicationApp();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Habilitar CORS
app.UseCors("AllowAngular");

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