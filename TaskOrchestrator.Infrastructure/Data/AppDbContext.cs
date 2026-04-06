using Microsoft.EntityFrameworkCore;
using TaskOrchestrator.Domain.Entities;

namespace TaskOrchestrator.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}