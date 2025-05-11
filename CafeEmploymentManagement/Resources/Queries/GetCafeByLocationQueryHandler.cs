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
			var query = _context.Set<Cafe>().AsQueryable();

			if (!string.IsNullOrEmpty(request.Location))
			{
				query = query.Where(cafe => cafe.Location == request.Location);
			}
			query = query.IgnoreAutoIncludes().AsNoTracking();
			query = query.Include(x => x.Employees);
			var result = query.ToList();
			return result;
		}
	}
}
