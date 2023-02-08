using System.ComponentModel.DataAnnotations;

namespace TasksRestApi.Models
{
    public class Task
    {
        //Title, Description, start date, end date, priority, category, status.
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        
        public int Priority { get; set; }
       
        public string Category { get; set; }

        [EnumDataType(typeof(EnumStatus), ErrorMessage =
            "Status should be valid. Try - Pending, InProgress,Completed ")]
        public string Status { get; set; }

            
        public enum EnumStatus
        {
            Pending = 0,
            InProgress = 1,
            Completed = 2
        }
    }
}
