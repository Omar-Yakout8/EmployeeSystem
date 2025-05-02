using EmployeeApi.Models;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeController : ControllerBase
	{
		private readonly EmployeeService _employeeService;

		public EmployeeController(EmployeeService employeeService)
		{
			_employeeService = employeeService;
		}

		[HttpGet]
		public ActionResult<List<Employee>> GetAll() => _employeeService.GetAll();

		[HttpGet("{id}")]
		public ActionResult<Employee>GetById(int id)
		{
			var employee = _employeeService.GetById(id);
			if (employee == null) return NotFound();
			return employee;
		}

		[HttpPost]
		public ActionResult<Employee> Create(Employee employee)
		{
			var created = _employeeService.Create(employee);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[HttpPut("{id}")]
		public IActionResult Update(int id,Employee employee)
		{
			var result = _employeeService.Update(id, employee);
			if (!result) return NotFound();
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var result = _employeeService.Delete(id);
			if (!result) return NotFound();
			return NoContent();
		}
	}
}
