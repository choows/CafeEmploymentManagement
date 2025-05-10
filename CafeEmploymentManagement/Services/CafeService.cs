using CafeEmploymentManagement.Models;
using CafeEmploymentManagement.Models.DataContract;
using CafeEmploymentManagement.Resources.Commands.Create;
using CafeEmploymentManagement.Resources.Commands.Remove;
using CafeEmploymentManagement.Resources.Commands.Update;
using CafeEmploymentManagement.Resources.Queries;
using MediatR;

namespace CafeEmploymentManagement.Services
{
	public class CafeService : ICafeService
	{
		private IMediator _mediator;

		public CafeService(IMediator mediator)
		{
			this._mediator = mediator;
		}
		public async Task<IEnumerable<Cafe>> GetCafeByLocationAsync(string? Location, CancellationToken cancellationToken = default)
		{
			var command = new GetCafeByLocationQuery()
			{
				Location = Location
			};
			return await _mediator.Send(command, cancellationToken);
		}

		public async Task<Cafe> AddCafeAsync(AddCafeRequest request, CancellationToken cancellationToken = default)
		{
			var command = new CreateCafeCommand()
			{
				Active = request.Active,
				Description = request.Description,
				Location = request.Location,
				Name = request.Name,
			};
			return await _mediator.Send(command, cancellationToken);
		}

		public async Task<Cafe> UpdateCafeAsync(Guid id, UpdateCafeRequest request, CancellationToken cancellationToken = default)
		{
			var command = new UpdateCafeCommand()
			{
				Id = id,
				Active = request.Active,
				Description = request.Description,
				Location = request.Location,
				Name = request.Name
			};
			return await _mediator.Send(command, cancellationToken);
		}

		public async Task<Cafe> RemoveCafeAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var command = new RemoveCafeCommand()
			{
				Id = id
			};
			return await _mediator.Send(command, cancellationToken);
		}
	}
}
