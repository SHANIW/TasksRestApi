namespace TasksRestApi.Models
{
    public interface ITasksRepository
    {
        public Task SaveTask(Task task);

        public void UpdateTask(Task task);

        public void DeleteTask(Task task);

        public IEnumerable<Task> GetAllTasks();

        public Task GetTaskById(int id);//optional

        public Task GetTaskByTitle(string name);//optional

        public Task GetTaskByDateRange(DateTime startDate, DateTime endDate);

    }
}
