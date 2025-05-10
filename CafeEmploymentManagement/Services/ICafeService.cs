using CafeEmploymentManagement.Models;
using CafeEmploymentManagement.Models.DataContract;

namespace CafeEmploymentManagement.Services
{
	public interface ICafeService
	{
		public Task<IEnumerable<Cafe>> GetCafeByLocationAsync(string? Location, CancellationToken cancellationToken = default);
		public Task<Cafe> AddCafeAsync(AddCafeRequest request, CancellationToken cancellationToken = default);
		public Task<Cafe> UpdateCafeAsync(Guid id, UpdateCafeRequest request, CancellationToken cancellation = default);
		public Task<Cafe> RemoveCafeAsync(Guid id, CancellationToken cancellationToken = default);
	}
}