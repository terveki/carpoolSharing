using System.Linq;
using AutoMapper;
using CarpoolSharing.API.Dtos;
using CarpoolSharing.API.Models;

namespace CarpoolSharing.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Ride, RideForListDto>()
                .ForMember(dest => dest.Employee, opt => {
                    opt.MapFrom(src => src.EmployeeRides.Select(p => p.Employee));
                });
            CreateMap<Ride, RideForDetailedDto>()
                .ForMember(dest => dest.Employees, opt => {
                    opt.MapFrom(src => src.EmployeeRides.Select(p => p.Employee));
                });
            CreateMap<Employee, EmployeeForListDto>();
            CreateMap<Car, CarForDetailedDto>();
            CreateMap<RideForUpdateDto, Ride>();
        }
    }
}