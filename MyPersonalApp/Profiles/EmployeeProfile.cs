using AutoMapper;
using MyPersonalApp.DTO;
using MyPersonalApp.Models;

namespace MyPersonalApp.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() 
        {
            CreateMap<PositionAddDTO, Position>();
            CreateMap<Position, PositionGetDTO>();
        }
    }
}
