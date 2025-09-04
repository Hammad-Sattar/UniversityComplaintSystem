using AutoMapper;
using UniversityComplaintSystem.Models.Dtos;
using UniversityComplaintSystem.Models;

namespace ComplaintSystem.Mappings
    {
    public class MappingProfile : Profile
        {
        public MappingProfile()
            {
            // User → UserDto
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.DepartmentName,
                           opt => opt.MapFrom(src => src.Department != null ? src.Department.Name : null));

            // CreateUserDto → User
            CreateMap<CreateUserDto, User>();

            // Department mappings
            CreateMap<Department, DepartmentDto>()
                .ForMember(dest => dest.HeadName,
                           opt => opt.MapFrom(src => src.HeadUser != null ? src.HeadUser.Name : null));
            CreateMap<CreateDepartmentDto, Department>();



            // Complaint mappings
            CreateMap<Complaint, ComplaintDto>()
    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
    .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));

            CreateMap<ComplaintDto, Complaint>();



            }
        }
    }
