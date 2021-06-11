using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Task_Tracker.Entities
{
    public enum ProjectStatus
    {
        NotStarted,
        Active,
        Completed
    }

    public class Project
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public ProjectStatus Status { get; set; }

        public int Priority { get; set; }

        public List<ProjectTask> Tasks { get; set; }
    }
}
