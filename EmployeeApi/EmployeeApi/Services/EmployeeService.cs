using EmployeeApi.Models;

namespace EmployeeApi.Services
{
	public class EmployeeService
	{
		private static List<Employee> _employees = new List<Employee>();
		private static int _nextId = 1;

		public List<Employee> GetAll() => _employees;

		public Employee GetById(int id) => _employees.FirstOrDefault(e => e.Id == id);

		public Employee Create(Employee employee)
		{
			employee.Id = _nextId++;
			_employees.Add(employee);
			return employee;
		}

		public bool Update(int id,Employee updated)
		{
			var existing = _employees.FirstOrDefault(e => e.Id == id);
			if (existing == null) return false;

			existing.FirstName = updated.FirstName;
			existing.LastName = updated.LastName;
			existing.Email = updated.Email;
			existing.Position = updated.Position;
			return true;
		}

		public bool Delete(int id)
		{
			var employee = _employees.FirstOrDefault(e => e.Id == id);
			if (employee == null) return false;

			_employees.Remove(employee);
			return true;
		}

	}
}
