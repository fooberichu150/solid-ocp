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
	}

	public class GetEmployeeHandler : IGetEmployeeHandler
	{
		public GetEmployeeHandler(IEmployeeRepository employeeRepository)
		{
			EmployeeRepository = employeeRepository;
		}

		protected IEmployeeRepository EmployeeRepository { get; }

		public Task<Employee> GetAsync(int employeeId)
		{
			return EmployeeRepository.GetAsync(employeeId);
		}
	}
}
