using System.ComponentModel.DataAnnotations;

namespace CafeEmploymentManagement.Models
{
	public class Employee
	{

		[Key]
		[MaxLength(10)]
		public string Id { get; set; }

		[MaxLength(100)]
		[Required]
		public string name { get; set; }
		[Required]
		[MaxLength(100)]
		public string email_address { get; set; }
		[Required]
		[MaxLength(8)]
		public string phone_number { get; set; }
		[Required]
		[MaxLength(6)]
		public string gender { get; set; }
		[Required]
		public DateTime CreatedDateTime { get; set; } = DateTime.Now;
		[Required]
		public DateTime LastUpdatedDateTime { get; set; } = DateTime.Now;
		public Cafe? cafe { get; set; }
		public DateTime StartDate { get; set; }
	}
}
