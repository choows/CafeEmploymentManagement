using CafeEmploymentManagement.Models.DataContract;
using CafeEmploymentManagement.Services;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace CafeEmploymentManagement.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CafeController : ControllerBase
	{
		private ICafeService _service;
		private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

		public CafeController(ICafeService cafeService)
		{
			this._service = cafeService;
		}

		[HttpGet]
		public async Task<IActionResult> Get(string? Location, CancellationToken cancellationToken)
		{
			try
			{
				var cafe = await this._service.GetCafeByLocationAsync(Location);
				var response = cafe.Select(c => new GetCafeResponse
				{
					name = c.Name,
					description = c.Description,
					employees = c.Employees.Count(),
					id = c.Id,
					location = c.Location,
				});
				return response is not null ? Ok(response) : NotFound();
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return BadRequest(ex.Message);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Post(AddCafeRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var result = await this._service.AddCafeAsync(request, cancellationToken);
				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return BadRequest(ex.Message);
			}
		}

		[HttpPut]
		public async Task<IActionResult> Update(Guid id, UpdateCafeRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var result = await this._service.UpdateCafeAsync(id, request, cancellationToken);
				return Ok(result);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
		{
			try
			{
				var cafe = await this._service.RemoveCafeAsync(id, cancellationToken);
				return Ok(cafe);
			}
			catch (Exception ex)
			{
				_logger.Error(ex.Message);
				return BadRequest(ex.Message);
			}
		}
	}
}
