using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Commands.Remove
{
	public class RemoveCafeCommand : IRequest<Cafe>
	{
		public Guid Id { get; set; }
	}
}
