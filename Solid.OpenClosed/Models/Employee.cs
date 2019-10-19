using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.OpenClosed.Models
{
	public class Employee
	{
		public long? EmployeeId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string Title { get; set; }
		public bool IsActive { get; set; }
	}
}
