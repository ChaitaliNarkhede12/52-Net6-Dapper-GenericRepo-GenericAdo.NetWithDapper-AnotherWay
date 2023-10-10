using TCCS.DataAccess.Interfaces;
using TCCS.DataAccess.Repositories;
using TCCS.Domain.Interfaces;
using TCCS.Domain.Models;
using TCCS.Domain.Repositories;
using TCCS.Domain.SQLConnections;
using TCCS.WebAPI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddConfiguration<DatabaseConnectionWithoutCredentials>("DatabaseConnectionWithoutCredentials");
builder.Services.Configure<DatabaseConnectionWithoutCredentials>(builder.Configuration.GetSection("DatabaseConnectionWithoutCredentials"));


builder.Services.AddScoped<ISqlCommandWrapper, SqlCommandWrapper>();
builder.Services.AddScoped<ISqlConnectionProvider, SqlConnectionProvider>();


builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddScoped<IStudentRepository, StudentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
