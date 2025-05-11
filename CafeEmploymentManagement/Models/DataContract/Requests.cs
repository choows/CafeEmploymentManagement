using System.ComponentModel.DataAnnotations;

namespace CafeEmploymentManagement.Models.DataContract
{
	#region Employee Related Request
	public class AddEmployeeRequest
	{
		[Required]
		[MaxLength(100)]
		public string name { get; set; }
		[Required]
		[MaxLength(100)]
		[RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Incorrect format of email")]
		public string email_address { get; set; }
		[Required]
		[MaxLength(8)]
		[RegularExpression("^[89]\\d{7}$", ErrorMessage = "Incorrect format of phone number")]
		public string phone_number { get; set; }
		[Required]
		[MaxLength(6)]
		public string gender { get; set; }
		public DateTime startDate { get; set; }
		public Guid? cafeId { get; set; } = null;
	}

	public class UpdateEmployeeRequest
	{
		[Required]
		[MaxLength(100)]
		public string name { get; set; }
		[Required]
		[MaxLength(100)]
		[RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$", ErrorMessage = "Incorrect format of email")]
		public string email_address { get; set; }
		[Required]
		[MaxLength(8)]
		[RegularExpression("^[89]\\d{7}$", ErrorMessage = "Incorrect format of phone number")]
		public string phone_number { get; set; }
		[Required]
		[MaxLength(6)]
		public string gender { get; set; }
		public DateTime startDate { get; set; }
		public Guid? cafeId { get; set; } = null;
	}
	#endregion

	#region Cafe Related Request
	public class AddCafeRequest
	{
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }
		[Required]
		[MaxLength(300)]
		public string Description { get; set; }
		[Required]
		[MaxLength(300)]
		public string Location { get; set; }
	}

	public class UpdateCafeRequest
	{
		[Required]
		[MaxLength(100)]
		public string Name { get; set; }
		[Required]
		[MaxLength(300)]
		public string Description { get; set; }
		[Required]
		[MaxLength(300)]
		public string Location { get; set; }
	}

	#endregion
}
