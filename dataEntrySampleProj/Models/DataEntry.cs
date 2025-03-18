namespace dataEntrySampleProj.Models
{
	public class DataEntry
	{
		public int Id { get; set; } // Primary Key
		public string Number { get; set; } // Tracking Number
		public DateTime SubmittedAt { get; set; } // Timestamp
	}

}
