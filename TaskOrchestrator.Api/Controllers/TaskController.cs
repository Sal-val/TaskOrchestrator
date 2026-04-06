using Microsoft.AspNetCore.Mvc;
using TaskOrchestrator.Application.Interfaces;
using TaskOrchestrator.Domain.Entities;
using Hangfire;

namespace TaskOrchestrator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repository;
    private readonly IBackgroundJobClient _backgroundJobs;

    public TasksController(ITaskRepository repository, IBackgroundJobClient backgroundJobs)
    {
        _repository = repository;
        _backgroundJobs = backgroundJobs;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _repository.GetAllAsync();
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskItem task)
    {
        await _repository.AddAsync(task);
        await _repository.SaveChangesAsync();

        // The "Orchestrator" part: Schedule a background job!
        _backgroundJobs.Enqueue(() => 
            Console.WriteLine($"Task '{task.Title}' was created. Notification logic would run here."));

        return CreatedAtAction(nameof(GetAll), new { id = task.Id }, task);
    }

    [HttpPut("{id}/complete")]
    public async Task<IActionResult> Complete(Guid id)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task == null) return NotFound();

        task.MarkAsComplete();
        await _repository.UpdateAsync(task);
        await _repository.SaveChangesAsync();

        return NoContent();
    }
}