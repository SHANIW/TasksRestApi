using Microsoft.AspNetCore.Mvc;
using TasksRestApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TasksRestApi
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TasksController : ControllerBase
    {
        readonly ITasksRepository _tasksRepository;

        public TasksController(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<Models.Task> GetAllTasks()
        {
            return _tasksRepository.GetAllTasks();
        }

        // GET api/<TasksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TasksController>
        [HttpPost]
        [Route("SaveTask")]
        public Models.Task SaveTask([FromBody] string value)
        {
           return _tasksRepository.SaveTask(new Models.Task());
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
