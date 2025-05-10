using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Queries
{
	public class GetCafeByLocationQuery : IRequest<IEnumerable<Cafe>>
	{
		public string? Location { get; set; } = string.Empty;
	}
}
