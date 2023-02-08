using Task = TasksRestApi.Models.Task;

namespace TasksRestApi.Repositories
{
    public interface ITasksDBRepository
    {
        public Task? SaveTask(Task task);

        public bool UpdateTask(Task task);

        public IEnumerable<Task> GetAllTasks();

        public Task? GetTaskById(int id);//optional

        public IEnumerable<Task> GetTaskByDateRange(DateTime startDate, DateTime endDate);
    }
}
