using CafeEmploymentManagement.Data;
using CafeEmploymentManagement.Models;
using MediatR;

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
			var results = (from emp in _context.Employees
						   join cafe in _context.Cafes on emp.cafe equals cafe
						   where (request.cafeId.HasValue ? cafe.Id == request.cafeId.Value : true)
						   select new Employee
						   {
							   Id = emp.Id,
							   name = emp.name,
							   email_address = emp.email_address,
							   cafe = cafe,
							   CreatedDateTime = emp.CreatedDateTime,
							   gender = emp.gender,
							   LastUpdatedDateTime = emp.LastUpdatedDateTime,
							   phone_number = emp.phone_number,
							   StartDate = emp.StartDate
						   }).ToList();
			return results;
		}
	}
}
