using CafeEmploymentManagement.Models.DataContract;
using CafeEmploymentManagement.Services;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CafeEmploymentManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		IEmployeeService _service;
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
		public EmployeesController(IEmployeeService employeeService)
		{
			this._service = employeeService;
		}

		[HttpGet]
		public async Task<IActionResult> Get(Guid? cafe, CancellationToken cancellationToken = default)
		{
			try
			{
				var employee = await this._service.GetEmployees(cafe, cancellationToken);

				var response = employee.Select(emp => new GetEmployeeResponse
				{
					name = emp.name,
					email_address = emp.email_address,
					cafeName = emp.cafe?.Name,
					cafeId = emp.cafe?.Id,
					day_worked = (int)(DateTime.Now - emp.StartDate).TotalDays,
					id = emp.Id,
					phone_number = emp.phone_number
				}).ToList();
				return response is not null ? Ok(new { employees = response }) : NotFound();
			}
			catch (Exception ex)
			{
				_logger.Error(ex);
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post(AddEmployeeRequest request, CancellationToken cancellationToken = default)
		{
			try
			{
				var result = await _service.AddEmployeeAsync(request, cancellationToken);
				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.Error(ex);
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		public async Task<IActionResult> Update(string id, UpdateEmployeeRequest request, CancellationToken cancellationToken = default)
		{
			try
			{
				var result = await _service.UpdateEmployeeAsync(id, request, cancellationToken);
				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.Error(ex);
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
		{
			try
			{
				var cafe = await this._service.RemoveEmployee(id, cancellationToken);
				return Ok(cafe);
			}
			catch (Exception ex)
			{
				_logger.Error(ex);
				return BadRequest(ex.Message);
			}
		}
	}
}
