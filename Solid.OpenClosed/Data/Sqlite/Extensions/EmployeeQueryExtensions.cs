using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solid.OpenClosed.Data.Sqlite.Entities;

namespace Solid.OpenClosed.Data.Sqlite.Extensions
{
	public static class EmployeeQueryExtensions
	{
		public static IQueryable<Employee> ById(this IQueryable<Employee> query, long? employeeId)
		{
			if (employeeId.HasValue)
				query = query.Where(employee => employee.Id == employeeId.Value);

			return query;
		}

		public static IQueryable<Employee> ByIsActive(this IQueryable<Employee> query, bool? isActive)
		{
			if (isActive.HasValue)
				query = query.Where(employee => employee.IsActive == isActive.Value);

			return query;
		}
	}
}
