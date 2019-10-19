using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solid.OpenClosed.Models;

namespace Solid.OpenClosed.Data.InMemory.Extensions
{
	public static class EmployeeExtensions
	{
		public static IQueryable<Employee> ById(this IQueryable<Employee> employees, long? id)
		{
			if (id.HasValue)
				employees = employees.Where(employee => employee.EmployeeId == id);

			return employees;
		}

		public static IQueryable<Employee> ByIsActive(this IQueryable<Employee> employees, bool? activeOnly)
		{
			if (activeOnly.HasValue)
				employees = employees.Where(employee => employee.IsActive);

			return employees;
		}

		public static IQueryable<Employee> ByFirstName(this IQueryable<Employee> employees, string firstName)
		{
			if (!string.IsNullOrWhiteSpace(firstName))
				employees = employees.Where(employee => string.Compare(employee.FirstName, firstName, true) == 0);

			return employees;
		}

		public static IQueryable<Employee> ByLastName(this IQueryable<Employee> employees, string lastName)
		{
			if (!string.IsNullOrWhiteSpace(lastName))
				employees = employees.Where(employee => string.Compare(employee.LastName, lastName, true) == 0);

			return employees;
		}
	}
}
