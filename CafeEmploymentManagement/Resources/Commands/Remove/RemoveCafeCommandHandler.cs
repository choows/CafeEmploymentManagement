using CafeEmploymentManagement.Data;
using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Commands.Remove
{
	public class RemoveCafeCommandHandler : IRequestHandler<RemoveCafeCommand, Cafe>
	{
		private readonly CafeDbContext _context;
		public RemoveCafeCommandHandler(CafeDbContext context)
		{
			_context = context;
		}

		public async Task<Cafe> Handle(RemoveCafeCommand request, CancellationToken cancellationToken)
		{
			using (var transaction = _context.Database.BeginTransaction())
			{
				var cafe = _context.Cafes.FirstOrDefault(cafe => cafe.Id == request.Id);
				if (cafe is null)
					throw new Exception("Invalid Id.");
				_context.Cafes.Remove(cafe);
				await _context.SaveChangesAsync(cancellationToken);
				await transaction.CommitAsync(cancellationToken);
				return cafe;
			}
		}
	}
}
