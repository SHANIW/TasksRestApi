using Microsoft.AspNetCore.Mvc;
using TasksRestApi.Repositories;

namespace TasksRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TasksController : ControllerBase
    {
        readonly ITasksDBRepository _tasksRepository;

        public TasksController(ITasksDBRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        // GET: api/<TasksController>
        [HttpGet("GetAll")]
        public IEnumerable<Models.Task> GetAllTasks()
        {
            return _tasksRepository.GetAllTasks();
        }

        // GET api/<TasksController>/5
        [HttpGet("GetTask/{id}")]
        public IActionResult GetTask(int id)
        {
            var task = _tasksRepository.GetTaskById(id);
            if (task == null) { return NotFound(); }
            else { return Ok(task); }
        }

        // GET api/<TasksController>/5
        [HttpGet("TasksWithinRange/{startDate}/{endDate}")]
        public IEnumerable<Models.Task> GetTasks(DateTime startDate, DateTime endDate)
        {
            return _tasksRepository.GetTaskByDateRange(startDate, endDate);
        }

        // POST api/<TasksController>
        [HttpPost("SaveTask")]
        public Models.Task? SaveTask(Models.Task task)
        {
            return _tasksRepository.SaveTask(task);
        }

        // PUT api/<TasksController>/5
        [HttpPut("UpdateTask/{id}")]
        public IActionResult UpdateTask(int id, [FromBody] Models.Task task)
        {
            task.Id = id;
            bool updated = _tasksRepository.UpdateTask(task);
            if (updated) { return Ok(task); }
            else { return NotFound(); }
        }
    }
}
