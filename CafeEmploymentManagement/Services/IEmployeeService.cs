using CafeEmploymentManagement.Models;
using CafeEmploymentManagement.Models.DataContract;

namespace CafeEmploymentManagement.Services
{
	public interface IEmployeeService
	{
		public Task<Employee> AddEmployeeAsync(AddEmployeeRequest request, CancellationToken cancellationToken = default);
		public Task<Employee> UpdateEmployeeAsync(string id, UpdateEmployeeRequest request, CancellationToken cancellationToken = default);
		public Task<IEnumerable<Employee>> GetEmployees(Guid? cafe, CancellationToken cancellationToken = default);
		public Task<Employee> RemoveEmployee(string id, CancellationToken cancellationToken);
	}
}
