using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Commands.Create
{
	public class CreateCafeCommand : IRequest<Cafe>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public bool Active { get; set; }
	}
}
