namespace EmailerSinglePageApp.Controller.Models
{
	public class EmailResponseModel
	{
		public string FromAddress { get; set; }
		public string ToAddress { get; set; }
		public string? CcAddresses { get; set; }
		public string Subject { get; set; }
		public Importance Importance { get; set; }
		public string Body { get; set; }
		public DateTime CreatedOn { get; set; }
	}
}
