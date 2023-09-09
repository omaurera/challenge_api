using AutoMapper;
using ChallengeN5.Application.Features.Commands;
using ChallengeN5.Application.Responses;
using ChallengeN5.Domain;

namespace ChallengeN5.Application.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<RequestPermissionCommand, Permissions>()
				.ForMember(p => p.EmployeeName, req => req.MapFrom(x => x.EmployeeName))
				.ForMember(p => p.EmployeeLastName, req => req.MapFrom(x => x.EmployeeLastName))
				.ForMember(p => p.PermissionType, req => req.MapFrom(x => x.PermissionType))
				.ForMember(p => p.PermissionDate, req => req.MapFrom(x => DateTime.Now));
			CreateMap<Permissions, PermissionResponse>()
				.ForMember(p => p.IdPermissionType, res => res.MapFrom(x => x.PermissionType));
            CreateMap<UpdatePermissionCommand, Permissions>()
                .ForMember(p => p.Id, req => req.MapFrom(x => x.Id))
                .ForMember(p => p.EmployeeName, req => req.MapFrom(x => x.EmployeeName))
                .ForMember(p => p.EmployeeLastName, req => req.MapFrom(x => x.EmployeeLastName))
                .ForMember(p => p.PermissionType, req => req.MapFrom(x => x.PermissionType))
                .ForMember(p => p.PermissionDate, req => req.MapFrom(x => DateTime.Now));
        }
	}
}

