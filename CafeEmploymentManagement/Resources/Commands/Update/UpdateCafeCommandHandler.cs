using CafeEmploymentManagement.Data;
using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Commands.Update
{
	public class UpdateCafeCommandHandler : IRequestHandler<UpdateCafeCommand, Cafe>
	{
		private readonly CafeDbContext _context;
		public UpdateCafeCommandHandler(CafeDbContext context)
		{
			_context = context;
		}

		public async Task<Cafe> Handle(UpdateCafeCommand request, CancellationToken cancellationToken)
		{
			using (var transaction = _context.Database.BeginTransaction())
			{
				var cafe = _context.Cafes.FirstOrDefault(cafe => cafe.Id == request.Id);
				if (cafe is null)
					throw new InvalidOperationException("Invalid Id");
				cafe.Name = request.Name;
				cafe.Description = request.Description;
				cafe.Location = request.Location;
				cafe.UpdatedDateTime = DateTime.Now;

				await _context.SaveChangesAsync(cancellationToken);
				await transaction.CommitAsync(cancellationToken);
				return cafe;
			}
		}
	}
}
