using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Commands.Update
{
	public class UpdateEmployeeCommand : IRequest<Employee>
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string EmailAddrss { get; set; }
		public string PhoneNumber { get; set; }
		public string Gender { get; set; }
		public DateTime? StartDate { get; set; } = null;
		public Guid? cafeId { get; set; } = null;
	}
}