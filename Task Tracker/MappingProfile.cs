using AutoMapper;
using Task_Tracker.Entities;
using Task_Tracker.Models.Requests;

namespace Task_Tracker
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProjectRequestModel, Project>();
            CreateMap<TaskRequestModel, ProjectTask>();
        }
    }
}
