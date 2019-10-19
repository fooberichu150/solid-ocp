using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Solid.OpenClosed.Adapters;
using Solid.OpenClosed.Data.Extensions;

namespace Solid.OpenClosed.Data.Repositories
{
	public interface IEmployeeRepository
	{
		Task<Models.Employee> GetAsync(int employeeId);
		Task<IEnumerable<Models.Employee>> GetAsync(Models.Requests.EmployeeFilter filter);
		Task<Models.Employee> SaveAsync(Models.Employee employee);
	}

	public class EmployeeRepository : IEmployeeRepository
	{
		public EmployeeRepository(IEmployeeDbContext context,
			IEmployeeAdapter employeeAdapter)
		{
			Context = context;
			EmployeeAdapter = employeeAdapter;
		}

		protected IEmployeeDbContext Context { get; set; }
		protected IEmployeeAdapter EmployeeAdapter { get; set; }

		public async Task<Models.Employee> GetAsync(int employeeId)
		{
			var employee = Context.Employees
				.ById(employeeId)
				.SingleOrDefault();

			return EmployeeAdapter.ToModel(employee);
		}

		public async Task<IEnumerable<Models.Employee>> GetAsync(Models.Requests.EmployeeFilter filter)
		{
			var employees = Context.Employees
			   .ById(filter.EmployeeId)
			   .ByIsActive(filter.IsActive)
			   .AsEnumerable();

			return employees
				.Select(employee => EmployeeAdapter.ToModel(employee))
				.ToArray();
		}

		public async Task<Models.Employee> SaveAsync(Models.Employee employee)
		{
			throw new NotImplementedException();
		}
	}
}
