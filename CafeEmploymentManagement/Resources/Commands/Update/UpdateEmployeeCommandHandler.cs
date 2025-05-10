using CafeEmploymentManagement.Data;
using CafeEmploymentManagement.Models;
using MediatR;

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
				employee.gender = request.Gender;
				employee.LastUpdatedDateTime = DateTime.Now;
				await _context.SaveChangesAsync(cancellationToken);
				await transaction.CommitAsync(cancellationToken);
				return employee;
			}
		}
	}
}
