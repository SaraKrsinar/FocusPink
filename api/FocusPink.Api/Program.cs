using Microsoft.EntityFrameworkCore;
using FocusPink.Api.Endpoints;
using FocusPink.Core.Interfaces;
using FocusPink.Infrastructure.Data;
using FocusPink.Infrastructure.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    var cs = builder.Configuration.GetConnectionString("Default")
             ?? Environment.GetEnvironmentVariable("ConnectionStrings__Default")
             ?? throw new InvalidOperationException("Connection string not found.");
    opt.UseNpgsql(cs);
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("any", p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddScoped<ITodoRepository, TodoRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("any");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.MapTodoEndpoints();

app.Run();
