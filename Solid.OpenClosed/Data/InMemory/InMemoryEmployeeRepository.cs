using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Solid.OpenClosed.Data.Repositories;
using Solid.OpenClosed.Models;
using Solid.OpenClosed.Models.Requests;
using Solid.OpenClosed.Data.InMemory.Extensions;

namespace Solid.OpenClosed.Data.InMemory
{
	public class InMemoryEmployeeRepository : IEmployeeRepository
	{
		private LockDictionary<int, Employee> _employees = new LockDictionary<int, Employee>();
		private ReaderWriterLockSlim _locker = new ReaderWriterLockSlim();
		private int _nextId = 0;

		public InMemoryEmployeeRepository()
		{
			Populate();
		}

		public Task<Employee> GetAsync(int employeeId)
		{
			_employees.TryGetValue(employeeId, out Employee employee);
			return Task.FromResult(employee);
		}

		public Task<IEnumerable<Employee>> GetAsync(EmployeeFilter filter)
		{
			var employees = _employees
				.Values
				.AsQueryable()
				.ById(filter.EmployeeId)
				.ByIsActive(filter.IsActive)
				.AsEnumerable();

			return Task.FromResult(employees);
		}

		public Task<Employee> SaveAsync(Employee employee)
		{
			throw new NotImplementedException();
		}

		private void Populate()
		{
			int employeeId = 1;
			_employees.AddOrUpdate(employeeId, new Employee
			{
				EmployeeId = employeeId++,
				IsActive = true,
				EmailAddress = "joe@shmoe.com",
				FirstName = "Joe",
				LastName = "Shmoe",
				Title = "Burgermeister-meister"
			});
			_employees.AddOrUpdate(employeeId, new Employee
			{
				EmployeeId = employeeId++,
				IsActive = true,
				EmailAddress = "brim@jickman.com",
				FirstName = "Brim",
				LastName = "Jickman",
				Title = "Pianoman"
			});
			_employees.AddOrUpdate(employeeId, new Employee
			{
				EmployeeId = employeeId++,
				IsActive = true,
				EmailAddress = "jimmy@sausage.com",
				FirstName = "Jimmy",
				LastName = "Dean",
				Title = "Sausage Shredder"
			});

			_nextId = employeeId;
		}
	}
}
