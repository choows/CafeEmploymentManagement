using CafeEmploymentManagement.Data;
using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Commands.Create
{
	public class CreateCafeCommandHandler : IRequestHandler<CreateCafeCommand, Cafe>
	{
		private readonly CafeDbContext _context;
		public CreateCafeCommandHandler(CafeDbContext context)
		{
			_context = context;
		}
		public async Task<Cafe> Handle(CreateCafeCommand request, CancellationToken cancellationToken)
		{
			using (var transaction = _context.Database.BeginTransaction())
			{
				var newCafe = new Cafe
				{
					Name = request.Name,
					Description = request.Description,
					Location = request.Location,
					CreatedDateTime = DateTime.Now,
					UpdatedDateTime = DateTime.Now,
					Id = Guid.NewGuid(),
				};
				_context.Cafes.Add(newCafe);
				await _context.SaveChangesAsync(cancellationToken);
				await transaction.CommitAsync(cancellationToken);
				return newCafe;
			}
		}
	}
}
