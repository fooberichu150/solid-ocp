using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solid.OpenClosed.Models.Requests
{
	public class EmployeeFilter
	{
		public int? EmployeeId { get; set; }
		public bool? IsActive { get; set; }
	}
}
