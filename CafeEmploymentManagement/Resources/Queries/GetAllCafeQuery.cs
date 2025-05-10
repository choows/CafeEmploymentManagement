using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Queries
{
	public class GetAllCafeQuery : IRequest<IEnumerable<Cafe>>
	{
	}
}
