using CafeEmploymentManagement.Data;
using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Queries
{
	public class GetCafeByIdQueryHandler : IRequestHandler<GetCafeByIdQuery, Cafe>
	{
		private readonly CafeDbContext _context;
		public GetCafeByIdQueryHandler(CafeDbContext context)
		{
			_context = context;
		}

		public async Task<Cafe> Handle(GetCafeByIdQuery request, CancellationToken cancellation)
		{
			var results = (from cafe in _context.Cafes
						   where cafe.Id == request.Id
						   select new Cafe()
						   {
							   CreatedDateTime = cafe.CreatedDateTime,
							   Description = cafe.Description,
							   Employees = _context.Employees.Where(emp => emp.cafe == cafe).ToList(),
							   Id = cafe.Id,
							   Location = cafe.Location,
							   Name = cafe.Name,
							   UpdatedDateTime = cafe.UpdatedDateTime
						   }).FirstOrDefault();
			return results;
		}
	}
}
