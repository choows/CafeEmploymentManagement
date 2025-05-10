using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Queries
{
	public class GetCafeByIdQuery : IRequest<Cafe>
	{
		public Guid Id { get; set; }
	}
}
