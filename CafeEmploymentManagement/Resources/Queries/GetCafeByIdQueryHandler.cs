using CafeEmploymentManagement.Data;
using CafeEmploymentManagement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
			return _context.Cafes.Include(cafe => cafe.Employees).FirstOrDefault(cafe => cafe.Id == request.Id);
		}
	}
}
