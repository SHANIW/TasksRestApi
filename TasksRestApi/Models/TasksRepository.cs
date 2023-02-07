namespace TasksRestApi.Models
{
    public class TasksRepository: ITasksRepository
    {
        IList<Task> TaskList = new List<Task>() { new Task { Category="IT", Description="This is an IT Task",
            StartDate=DateTime.Now, EndDate=DateTime.Now.AddDays(10), Priority=1, Status="Pending", Title="Create new user"} };
        

        public TasksRepository() { 
        
            
        }

        public void DeleteTask(Task task)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return TaskList;
        }

        public Task GetTaskByDateRange(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task GetTaskById(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetTaskByTitle(string name)
        {
            throw new NotImplementedException();
        }

        public Task SaveTask(Task task)
        {
            Task newTask = new Task
            {
                Category = "HR",
                Description = "This is an HR Task",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(15),
                Priority = 1,
                Status = "Pending",
                Title = "Create new account"
            };
            TaskList.Add(newTask);
            return newTask;
        }

        public void UpdateTask(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
