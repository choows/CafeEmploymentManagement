using CafeEmploymentManagement.Data;
using CafeEmploymentManagement.Models;
using MediatR;

namespace CafeEmploymentManagement.Resources.Commands.Create
{
	public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Employee>
	{
		private readonly CafeDbContext _context;
		public CreateEmployeeCommandHandler(CafeDbContext context)
		{
			_context = context;
		}
		public async Task<Employee> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
		{
			using (var transaction = _context.Database.BeginTransaction())
			{

				var newEmployee = new Employee
				{
					Id = "dummy", ///the id will be auto replaced by the trigger in the database table 
					name = request.Name,
					email_address = request.EmailAddrss,
					phone_number = request.PhoneNumber,
					gender = request.Gender,
					CreatedDateTime = DateTime.Now,
					LastUpdatedDateTime = DateTime.Now,
					StartDate = request.StartDate
				};

				if (request.cafeId.HasValue)
				{
					var cafequery = (from cafe in _context.Cafes
									 where cafe.Id == request.cafeId.Value
									 select cafe).FirstOrDefault();
					newEmployee.cafe = cafequery;
				}
				await _context.Employees.AddAsync(newEmployee, cancellationToken);
				await _context.SaveChangesAsync(cancellationToken);
				await transaction.CommitAsync(cancellationToken);
				return newEmployee;
			}
		}
	}
}
