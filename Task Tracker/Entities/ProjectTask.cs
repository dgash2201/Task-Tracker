using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Tracker.Entities
{
    public enum TaskStatus
    {
        ToDo,
        InProgress,
        Done
    }

    public class ProjectTask
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public TaskStatus Status { get; set; }

        public int Priority { get; set; }

        public int ProjectId { get; set; }
    }
}
