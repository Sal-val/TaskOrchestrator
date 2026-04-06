using Microsoft.EntityFrameworkCore;
using TaskOrchestrator.Infrastructure.Data;
using TaskOrchestrator.Application.Interfaces;
using TaskOrchestrator.Infrastructure.Repositories;
using Hangfire;
using Hangfire.MemoryStorage;

var builder = WebApplication.CreateBuilder(args);

// 1. Add Database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tasks.db"));

// 2. Register Repository
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

// 3. Add Hangfire
builder.Services.AddHangfire(config => config.UseMemoryStorage());
builder.Services.AddHangfireServer();

// 4. Add Standard API Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Configure Middleware Pipe
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

// 6. Add Hangfire Dashboard
app.UseHangfireDashboard();

app.MapControllers();

app.Run();