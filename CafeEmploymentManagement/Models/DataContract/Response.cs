﻿namespace CafeEmploymentManagement.Models.DataContract
{
	public class GetCafeResponse
	{
		public string name { get; set; }
		public string description { get; set; }
		public int employees { get; set; }
		public string location { get; set; }
		public Guid id { get; set; }
	}

	public class GetEmployeeResponse
	{
		public string id { get; set; }
		public string name { get; set; }
		public string email_address { get; set; }
		public string phone_number { get; set; }
		public int day_worked { get; set; }
		public string gender { get; set; }
		public DateTime start_date { get; set; }
		public string cafeName { get; set; } = string.Empty;
		public Guid? cafeId { get; set; }
	}
}
