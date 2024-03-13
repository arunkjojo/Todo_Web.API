using Microsoft.EntityFrameworkCore;
using Todo_Web.API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var mySqlConnectionString = builder.Configuration.GetConnectionString("MySqlConnectionSting");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(mySqlConnectionString, ServerVersion.AutoDetect(mySqlConnectionString)));

// var msSqlconnectionString = builder.Configuration.GetConnectionString("MSSqlConnectionSting");
// builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(msSqlconnectionString));


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
