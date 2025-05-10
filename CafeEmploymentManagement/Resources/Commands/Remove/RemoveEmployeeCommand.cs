using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Commands.Remove
{
	public class RemoveEmployeeCommand : IRequest<Employee>
	{
		public string Id { get; set; }
	}
}
