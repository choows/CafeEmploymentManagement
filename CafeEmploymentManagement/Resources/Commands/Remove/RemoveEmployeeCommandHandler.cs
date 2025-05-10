using CafeEmploymentManagement.Data;
using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Commands.Remove
{
	public class RemoveEmployeeCommandHandler : IRequestHandler<RemoveEmployeeCommand, Employee>
	{
		private readonly CafeDbContext _context;
		public RemoveEmployeeCommandHandler(CafeDbContext context)
		{
			_context = context;
		}

		public async Task<Employee> Handle(RemoveEmployeeCommand request, CancellationToken cancellationToken)
		{
			using (var transaction = _context.Database.BeginTransaction())
			{
				var employee = _context.Employees.FirstOrDefault(emp => emp.Id == request.Id);
				if (employee is null)
					throw new Exception("Invalid Id.");
				_context.Employees.Remove(employee);
				await _context.SaveChangesAsync(cancellationToken);
				await transaction.CommitAsync(cancellationToken);
				return employee;
			}
		}
	}
}
