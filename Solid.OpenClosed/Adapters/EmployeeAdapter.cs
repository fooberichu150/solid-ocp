using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Solid.OpenClosed.Adapters
{
	public interface IEmployeeAdapter
	{
		Data.Entities.Employee ToEntity(Models.Employee employee);
		Models.Employee ToModel(Data.Entities.Employee employee);
	}

	public class EmployeeAdapter : IEmployeeAdapter
	{
		public EmployeeAdapter(IMapper mapper)
		{
			Mapper = mapper;
		}

		protected IMapper Mapper { get; }

		public Models.Employee ToModel(Data.Entities.Employee employee)
		{
			return Mapper.Map<Models.Employee>(employee);
		}

		public Data.Entities.Employee ToEntity(Models.Employee employee)
		{
			return Mapper.Map<Data.Entities.Employee>(employee);
		}
	}
}
