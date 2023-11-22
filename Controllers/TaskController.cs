
[Route("api/tasks")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly TaskRepository _taskRepository;

    public TaskController(TaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    [HttpGet]
    public IActionResult GetTasks()
    {
        var tasks = _taskRepository.GetAllTasks();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public IActionResult GetTaskById(int id)
    {
        var task = _taskRepository.GetTaskById(id);

        if (task == null)
        {
            return NotFound();
        }

        return Ok(task);
    }

    [HttpPost]
    public IActionResult AddTask(Task task)
    {
        _taskRepository.AddTask(task);
        return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
    }
}
