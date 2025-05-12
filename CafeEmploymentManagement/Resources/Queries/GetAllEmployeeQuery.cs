using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Queries
{
	public class GetAllEmployeeQuery : IRequest<IEnumerable<Employee>>
	{
		public Guid? cafeId { get; set; } = null;
	}
}
