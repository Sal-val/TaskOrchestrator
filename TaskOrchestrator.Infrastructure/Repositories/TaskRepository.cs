using Microsoft.EntityFrameworkCore;
using TaskOrchestrator.Application.Interfaces;
using TaskOrchestrator.Domain.Entities;
using TaskOrchestrator.Infrastructure.Data;

namespace TaskOrchestrator.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TaskItem?> GetByIdAsync(Guid id) => 
        await _context.Tasks.FindAsync(id);

    public async Task<IEnumerable<TaskItem>> GetAllAsync() => 
        await _context.Tasks.ToListAsync();

    public async Task AddAsync(TaskItem task) => 
        await _context.Tasks.AddAsync(task);

    public async Task UpdateAsync(TaskItem task) => 
        await Task.Run(() => _context.Tasks.Update(task));

    public async Task SaveChangesAsync() => 
        await _context.SaveChangesAsync();
}