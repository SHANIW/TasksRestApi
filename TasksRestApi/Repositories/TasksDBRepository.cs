using System.Data.SqlClient;
using System.Data;


namespace TasksRestApi.Repositories
{
    public class TasksDBRepository : ITasksDBRepository 
    {
        private static IConfiguration _configuration;

        public TasksDBRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Models.Task> GetAllTasks()
        {
            IList<TasksRestApi.Models.Task> allTaskList = new List<TasksRestApi.Models.Task>();

            using (SqlConnection conn = getConnection())
            {                
                try
                {
                    conn.Open();
                                        
                    using (SqlCommand cmd = new SqlCommand("select * from Task", conn))
                    {
                        // get query results
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader != null)
                            {
                                while (reader.Read())
                                {
                                    //TODO null handle
                                    TasksRestApi.Models.Task task = new TasksRestApi.Models.Task();
                                    task.Id = Convert.ToInt32(reader["id"]);
                                    task.Title = reader["Title"].ToString();
                                    task.Description = reader["Description"].ToString();
                                    task.StartDate = Convert.ToDateTime(reader["StartDate"]);
                                    task.EndDate = Convert.ToDateTime(reader["EndDate"]);
                                    task.Priority = Convert.ToInt32(reader["Priority"]);
                                    task.Category = reader["Category"].ToString();
                                    task.Status = reader["Status"].ToString();
                                    allTaskList.Add(task);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return allTaskList;
        }

        public IEnumerable<Models.Task> GetTaskByDateRange(DateTime startDate, DateTime endDate)
        {
            IList<Models.Task> allTaskList = new List<TasksRestApi.Models.Task>();

            using (SqlConnection conn = getConnection())
            {
                try
                {
                    conn.Open();
                                       
                    SqlCommand cmd = new SqlCommand("SelectTaskByDateRange", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                   
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader != null)
                        {
                            while (reader.Read())
                            {
                                //TODO null handle
                                TasksRestApi.Models.Task task = new TasksRestApi.Models.Task();
                                task.Id = Convert.ToInt32(reader["id"]);
                                task.Title = reader["Title"].ToString();
                                task.Description = reader["Description"].ToString();
                                task.StartDate = Convert.ToDateTime(reader["StartDate"]);
                                task.EndDate = Convert.ToDateTime(reader["EndDate"]);
                                task.Priority = Convert.ToInt32(reader["Priority"]);
                                task.Category = reader["Category"].ToString();
                                task.Status = reader["Status"].ToString();
                                allTaskList.Add(task);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return allTaskList;
        }

        public Models.Task? GetTaskById(int id)
        {
            TasksRestApi.Models.Task task = new TasksRestApi.Models.Task();
            using (SqlConnection connection = getConnection())
            {
                try
                {
                    connection.Open();
                                        
                    using (SqlCommand command = new SqlCommand("GetTaskById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", id);

                        // get query results
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows) return null;

                            while (reader.Read())
                            {
                                int.TryParse(reader["id"].ToString(), out int taskId);

                                task.Id = taskId;
                                task.Title = reader["Title"].ToString();
                                task.Description = reader["Description"].ToString();
                                task.StartDate = Convert.ToDateTime(reader["StartDate"]);
                                task.EndDate = Convert.ToDateTime(reader["EndDate"]);
                                task.Priority = Convert.ToInt32(reader["Priority"]);
                                task.Category = reader["Category"].ToString();
                                task.Status = reader["Status"].ToString();

                            }
                        }
                    }

                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    // TODO: We can imporve code by Wirte logs to log file. 
                }

                return task;
            }
        }

        public Models.Task? SaveTask(Models.Task task)
        {
            using (SqlConnection conn = getConnection())
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SaveTask", conn);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Title", task.Title);
                    cmd.Parameters.AddWithValue("@Description", task.Description);
                    cmd.Parameters.AddWithValue("@StartDate", task.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", task.EndDate);
                    cmd.Parameters.AddWithValue("@Priority", task.Priority);
                    cmd.Parameters.AddWithValue("@Category", task.Category);
                    cmd.Parameters.AddWithValue("@Status", task.Status);
                    var val = cmd.ExecuteScalar();
                    task.Id = Convert.ToInt32(val);
                    return task;  //TODO return the saved object
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return null;
                }
            }
        }

        public bool UpdateTask(Models.Task task)
        {
            using (SqlConnection conn = getConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateTask", conn))
                    {
                        if (GetTaskById(task.Id)==null) 
                        {
                            return false;
                        }

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id", task.Id);
                        cmd.Parameters.AddWithValue("@Title", task.Title);
                        cmd.Parameters.AddWithValue("@Description", task.Description);
                        cmd.Parameters.AddWithValue("@StartDate", task.StartDate);
                        cmd.Parameters.AddWithValue("@EndDate", task.EndDate);
                        cmd.Parameters.AddWithValue("@Priority", task.Priority);
                        cmd.Parameters.AddWithValue("@Category", task.Category);
                        cmd.Parameters.AddWithValue("@Status", task.Status);
                        var val = cmd.ExecuteScalar();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }

            }
        }

        
        private static SqlConnection getConnection()
        {            
            string TasksDBConnectionString = _configuration.GetConnectionString("TasksDBConnection"); // read logDb connection string example
            SqlConnection conn = new SqlConnection(TasksDBConnectionString);

            return conn;

            

        }
    }
}
