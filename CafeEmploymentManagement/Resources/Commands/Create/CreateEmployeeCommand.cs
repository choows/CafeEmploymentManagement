using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Commands.Create
{
	public class CreateEmployeeCommand : IRequest<Employee>
	{
		public string Name { get; set; }
		public string EmailAddrss { get; set; }
		public string PhoneNumber { get; set; }
		public string Gender { get; set; }
		public DateTime StartDate { get; set; }
		public Guid? cafeId { get; set; } = null;
	}
}
