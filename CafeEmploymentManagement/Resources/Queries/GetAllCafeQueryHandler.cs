using CafeEmploymentManagement.Data;
using CafeEmploymentManagement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeEmploymentManagement.Resources.Queries
{
	public class GetAllCafeQueryHandler : IRequestHandler<GetAllCafeQuery, IEnumerable<Cafe>>
	{
		private readonly CafeDbContext _context;
		public GetAllCafeQueryHandler(CafeDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Cafe>> Handle(GetAllCafeQuery request, CancellationToken cancellation)
		{
			return await _context.Cafes.ToListAsync();
		}
	}
}
