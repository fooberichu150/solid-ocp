using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Solid.OpenClosed.Data.Sqlite.Entities;

namespace Solid.OpenClosed.Data.Sqlite.Adapters
{
	public interface IEmployeeAdapter
	{
		Employee ToEntity(Models.Employee employee);
		Models.Employee ToModel(Employee employee);
	}

	public class EmployeeAdapter : IEmployeeAdapter
	{
		public EmployeeAdapter(IMapper mapper)
		{
			Mapper = mapper;
		}

		protected IMapper Mapper { get; }

		public Models.Employee ToModel(Employee employee)
		{
			return Mapper.Map<Models.Employee>(employee);
		}

		public Employee ToEntity(Models.Employee employee)
		{
			return Mapper.Map<Employee>(employee);
		}
	}
}
