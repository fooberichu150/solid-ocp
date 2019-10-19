using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Solid.OpenClosed.Profiles
{
	public class EmployeeProfile : Profile
	{
		public EmployeeProfile()
		{
			CreateMap<Data.Entities.Employee, Models.Employee>()
				.ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Id))
				.ReverseMap();
		}
	}
}