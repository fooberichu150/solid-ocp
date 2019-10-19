using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solid.OpenClosed.Data.Repositories;
using Solid.OpenClosed.Models;
using Solid.OpenClosed.Models.Requests;

namespace Solid.OpenClosed.Handlers
{
	public interface IGetEmployeeHandler
	{
		Task<Employee> GetAsync(int employeeId);
		Task<Employee[]> GetAsync(EmployeeFilter filter);
	}

	public class GetEmployeeHandler : IGetEmployeeHandler
	{
		public GetEmployeeHandler(IEmployeeRepository employeeRepository)
		{
			EmployeeRepository = employeeRepository;
		}

		protected IEmployeeRepository EmployeeRepository { get; }

		public async Task<Employee> GetAsync(int employeeId)
		{
			var employee = await GetAsync(new EmployeeFilter { EmployeeId = employeeId });

			return employee
				.SingleOrDefault();
		}

		public async Task<Employee[]> GetAsync(EmployeeFilter filter)
		{
			var employees = await EmployeeRepository.GetAsync(filter);

			return employees.ToArray();
		}
	}
}
