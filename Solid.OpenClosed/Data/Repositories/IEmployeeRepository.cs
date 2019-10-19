using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.OpenClosed.Data.Repositories
{
	public interface IEmployeeRepository
	{
		Task<Models.Employee> GetAsync(int employeeId);
		Task<IEnumerable<Models.Employee>> GetAsync(Models.Requests.EmployeeFilter filter);
		Task<Models.Employee> SaveAsync(Models.Employee employee);
	}
}
