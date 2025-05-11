using CafeEmploymentManagement.Models;
using CafeEmploymentManagement.Models.DataContract;
using CafeEmploymentManagement.Resources.Commands.Create;
using CafeEmploymentManagement.Resources.Commands.Remove;
using CafeEmploymentManagement.Resources.Commands.Update;
using CafeEmploymentManagement.Resources.Queries;
using MediatR;

namespace CafeEmploymentManagement.Services
{
	public class EmployeeService : IEmployeeService
	{
		IMediator _mediator;
		public EmployeeService(IMediator mediator)
		{
			this._mediator = mediator;
		}

		public async Task<Employee> AddEmployeeAsync(AddEmployeeRequest request, CancellationToken cancellationToken = default)
		{
			var command = new CreateEmployeeCommand()
			{
				Name = request.name,
				PhoneNumber = request.phone_number,
				EmailAddrss = request.email_address,
				Gender = request.gender,
				StartDate = request.start_date,
				cafeId = request.cafeId
			};
			return await _mediator.Send(command, cancellationToken);
		}

		public async Task<Employee> UpdateEmployeeAsync(string id, UpdateEmployeeRequest request, CancellationToken cancellationToken = default)
		{
			var command = new UpdateEmployeeCommand()
			{
				Id = id,
				EmailAddrss = request.email_address,
				Gender = request.gender,
				PhoneNumber = request.phone_number,
				Name = request.name,
				StartDate = request.startDate,
				cafeId = request.cafeId
			};
			return await _mediator.Send(command, cancellationToken);
		}
		public async Task<IEnumerable<Employee>> GetEmployees(Guid? cafeId, CancellationToken cancellationToken = default)
		{

			if (cafeId.HasValue)
			{
				var command = new GetCafeByIdQuery()
				{
					Id = cafeId.Value
				};
				var cafe = await _mediator.Send(command, cancellationToken);
				return cafe.Employees == null ? new List<Employee>() : cafe.Employees;
			}
			else
			{
				return await _mediator.Send(new GetAllEmployeeQuery(), cancellationToken);
			}

		}

		public async Task<Employee> RemoveEmployee(string id, CancellationToken cancellationToken)
		{
			var command = new RemoveEmployeeCommand()
			{
				Id = id
			};
			return await _mediator.Send(command, cancellationToken);
		}
	}
}
