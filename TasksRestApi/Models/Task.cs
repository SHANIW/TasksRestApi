namespace TasksRestApi.Models
{
    public class Task
    {
        //Title, Description, start date, end date, priority, category, status.
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        public int Priority { get; set; }
       
        public string Category { get; set; }

        public string Status { get; set; }


    }
}
