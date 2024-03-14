using AutoMapper;
using Data.Entities;
using WebApp.Models;

namespace WebApp.Infrastructure
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TodoTask, TaskModel>().ReverseMap();
        }
    }
}
