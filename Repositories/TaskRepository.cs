
public class TaskRepository
{
    private readonly TaskDbContext _context;

    public TaskRepository(TaskDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Task> GetAllTasks()
    {
        return _context.Tasks.ToList();
    }

    public Task GetTaskById(int taskId)
    {
        return _context.Tasks.FirstOrDefault(t => t.Id == taskId);
    }

    public void AddTask(Task task)
    {
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }
}
