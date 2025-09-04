using ComplaintSystem.Repositories;
using Microsoft.EntityFrameworkCore;
using UniversityComplaintSystem.Models;
using UniversityComplaintSystem.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ComplainsDbContext>(o =>
    o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



// repositories

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IComplaintRepository, ComplaintRepository>();
builder.Services.AddScoped<IComplaintActionRepository,ComplaintActionRepository>();
builder.Services.AddAutoMapper(typeof(Program));



builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
