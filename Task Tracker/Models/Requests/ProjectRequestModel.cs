using System;
using Task_Tracker.Entities;

namespace Task_Tracker.Models.Requests
{
    public class ProjectRequestModel
    {
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime CompletionDate { get; set; }

        public ProjectStatus Status { get; set; }

        public int Priority { get; set; }
    }
}
