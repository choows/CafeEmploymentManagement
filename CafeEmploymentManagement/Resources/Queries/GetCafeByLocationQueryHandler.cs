using CafeEmploymentManagement.Data;
using CafeEmploymentManagement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeEmploymentManagement.Resources.Queries
{
	public class GetCafeByLocationQueryHandler : IRequestHandler<GetCafeByLocationQuery, IEnumerable<Cafe>>
	{
		private readonly CafeDbContext _context;
		public GetCafeByLocationQueryHandler(CafeDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Cafe>> Handle(GetCafeByLocationQuery request, CancellationToken cancellation)
		{
			if (string.IsNullOrEmpty(request.Location))
			{
				return _context.Cafes
					.Include(emp => emp.Employees)
					.ToList();
			}
			else
			{
				return _context.Cafes
					.Where(cafe => cafe.Location == request.Location)
					.Include(emp => emp.Employees)
					.ToList();
			}
		}
	}
}
