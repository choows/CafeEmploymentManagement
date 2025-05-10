using System.ComponentModel.DataAnnotations;

namespace CafeEmploymentManagement.Models
{
	public class Cafe
	{
		[Key]
		[Required]
		public Guid Id { get; set; }
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }
		[Required]
		[MaxLength(300)]
		public string Description { get; set; }
		[Required]
		[MaxLength(300)]
		public string Location { get; set; }
		[Required]
		public bool Active { get; set; }
		[Required]
		public DateTime CreatedDateTime { get; set; } = DateTime.Now;
		[Required]
		public DateTime UpdatedDateTime { get; set; } = DateTime.Now;
		public virtual ICollection<Employee> Employees { get; set; }
	}
}
