using AutoMapper;
using Practical_18.Models;
using Practical_18.ViewModels;

namespace Practical_18.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentListVM>().ReverseMap();

            CreateMap<Student, StudentCreateVM>().ReverseMap();

            CreateMap<Student, StudentEditVM>().ReverseMap();

            CreateMap<Student, StudentDetailsVM>().ReverseMap();
        }
    }
}
