using CafeEmploymentManagement.Data;
using CafeEmploymentManagement.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CafeEmploymentManagement.Resources.Commands.Update
{
	public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Employee>
	{
		private readonly CafeDbContext _context;
		public UpdateEmployeeCommandHandler(CafeDbContext context)
		{
			_context = context;
		}

		public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
		{
			using (var transaction = _context.Database.BeginTransaction())
			{
				var employee = _context.Employees.FirstOrDefault(emp => emp.Id == request.Id);

				if (employee is null)
					throw new Exception("Invalid Id");
				employee.name = request.Name;
				employee.email_address = request.EmailAddrss;
				employee.phone_number = request.PhoneNumber;
				employee.StartDate = request.StartDate;
				employee.gender = request.Gender;
				employee.LastUpdatedDateTime = DateTime.Now;
				if (request.cafeId.HasValue)
				{
					var cafequery = (from cafe in _context.Cafes
									 where cafe.Id == request.cafeId.Value
									 select cafe).IgnoreAutoIncludes().FirstOrDefault();
					employee.cafe = cafequery;
				}
				await _context.SaveChangesAsync(cancellationToken);
				await transaction.CommitAsync(cancellationToken);
				return employee;
			}
		}
	}
}
