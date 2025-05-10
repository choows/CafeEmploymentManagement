using CafeEmploymentManagement.Data;
using CafeEmploymentManagement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeEmploymentManagement.Resources.Queries
{
	public class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<Employee>>
	{
		private readonly CafeDbContext _context;
		public GetAllEmployeeQueryHandler(CafeDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellation)
		{
			return _context.Employees.Include(emp => emp.cafe).ToList();
		}
	}
}
