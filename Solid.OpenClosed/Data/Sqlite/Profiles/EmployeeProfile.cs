using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Solid.OpenClosed.Data.Sqlite.Entities;

namespace Solid.OpenClosed.Data.Sqlite.Profiles
{
	public class EmployeeProfile : Profile
	{
		public EmployeeProfile()
		{
			CreateMap<Employee, Models.Employee>()
				.ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.Id))
				.ReverseMap();
		}
	}
}