using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Solid.OpenClosed.Handlers;

namespace Solid.OpenClosed.Controllers
{
	[Route("[controller]")]
	//[Route("api/[controller]")]
	public class EmployeeController : Controller
	{
		public EmployeeController(IGetEmployeeHandler getEmployeeHandler)
		{
			EmployeeHandler = getEmployeeHandler;
		}

		protected IGetEmployeeHandler EmployeeHandler { get; }

		// GET api/<controller>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var employee = await EmployeeHandler.GetAsync(id);
			if (employee == null)
				return NotFound(id);

			return Ok(employee);
		}

		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] Models.Requests.EmployeeFilter filter)
		{
			var employees = await EmployeeHandler.GetAsync(filter);

			return Ok(employees);
		}
	}
}