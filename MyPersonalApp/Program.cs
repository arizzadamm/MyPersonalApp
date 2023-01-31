<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
=======
>>>>>>> e6eb58c7488093f510233ee9268d82d756604fe7
using MyPersonalApp.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

<<<<<<< HEAD
//For EF
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlServer(
    builder.Configuration.GetConnectionString("CompanyConnection")));
=======
//DI
builder.Services.AddScoped<IEmployee, EmployeeDAL>();
>>>>>>> e6eb58c7488093f510233ee9268d82d756604fe7

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
